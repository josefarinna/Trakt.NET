using Microsoft.CodeAnalysis;
using System.Buffers;
using System.Runtime.CompilerServices;
using TraktNET.SourceGeneration.Common;

namespace TraktNET.SourceGeneration.Requests
{
    public sealed class RequestSourceEmitter(SourceProductionContext context) : SourceEmitter<RequestGenerationSpecification>(context)
    {
        private const string RequestUriName = "requestUri";
        private const string ToTraktDateTimeMethodName = "ToTraktLongDateTimeString";
        private const string ToTraktCacheEfficientDateTimeMethodName = "ToTraktCacheEfficientLongDateTimeString";

        private readonly SourceWriter _sourceWriter = new();

        private string _requestName = string.Empty;
        private string _requestNamespace = string.Empty;
        private string _httpMethodValue = string.Empty;
        private string _uriPath = string.Empty;
        private string _oauthRequirementValue = string.Empty;
        private bool _supportsExtendedInfo;
        private bool _supportsPagination;
        private bool _hasOAuthRequirementDefined;
        private bool _hasOptionalParameters;
        private bool _hasOptionalQueries;

        private string _resolvedUriPath = string.Empty;
        private readonly List<PlaceHolder> _uriPlaceHolders = [];
        private bool _hasOptionalPlaceholders;

        private List<RequestParameterGenerationSpecification> _requestParameters = [];
        private List<RequestQueryGenerationSpecification> _requestQueries = [];

        public override void Emit(RequestGenerationSpecification generationSpecification)
        {
            if (generationSpecification == null)
            {
                return;
            }

            Setup(generationSpecification);

            _sourceWriter.WriteLine(Constants.Header);

            WriteNamespaceStart();
            WriteRequestClass();
            WriteNamespaceEnd();

            AddSource(_requestName + Constants.GeneratedFilenameSuffix, _sourceWriter.ToSourceText());
        }

        private void Setup(RequestGenerationSpecification requestGenerationSpecification)
        {
            _requestName = requestGenerationSpecification.Name;
            _requestNamespace = requestGenerationSpecification.Namespace!;
            _httpMethodValue = requestGenerationSpecification.HttpMethodValue;
            _uriPath = requestGenerationSpecification.UriPath;
            _oauthRequirementValue = requestGenerationSpecification.OAuthRequirementValue;
            _supportsExtendedInfo = requestGenerationSpecification.SupportsExtendedInfo;
            _supportsPagination = requestGenerationSpecification.SupportsPagination;
            _hasOAuthRequirementDefined = requestGenerationSpecification.HasOAuthRequirementDefined;
            _requestParameters = requestGenerationSpecification.RequestParameters;
            _requestQueries = requestGenerationSpecification.RequestQueries;

            if (_supportsExtendedInfo)
            {
                _requestQueries.Add(new RequestQueryGenerationSpecification
                {
                    Name = "ExtendedInfo",
                    QueryName = string.Empty,
                    SpecialType = SpecialType.None,
                    TraktEnumTypeName = "TraktExtendedInfo",
                    TraktEnumDefaultValue = "None",
                    IsRequired = false,
                    IsTraktEnum = true,
                    UseCacheEfficientDateTime = false
                });
            }

            if (_supportsPagination)
            {
                _requestQueries.Add(new RequestQueryGenerationSpecification
                {
                    Name = "Page",
                    QueryName = "page",
                    SpecialType = SpecialType.System_UInt32,
                    TraktEnumTypeName = string.Empty,
                    TraktEnumDefaultValue = string.Empty,
                    IsRequired = false,
                    IsTraktEnum = false,
                    UseCacheEfficientDateTime = false
                });

                _requestQueries.Add(new RequestQueryGenerationSpecification
                {
                    Name = "Limit",
                    QueryName = "limit",
                    SpecialType = SpecialType.System_UInt32,
                    TraktEnumTypeName = string.Empty,
                    TraktEnumDefaultValue = string.Empty,
                    IsRequired = false,
                    IsTraktEnum = false,
                    UseCacheEfficientDateTime = false
                });
            }

            _hasOptionalParameters = _requestParameters.Count > 0;
            _hasOptionalQueries = _requestQueries.Count > 0;

            ParseRequestUri();
        }

        private void WriteNamespaceStart()
        {
            _sourceWriter.WriteLine($"namespace {_requestNamespace}");
            _sourceWriter.WriteLine('{');
            _sourceWriter.Indent();
        }

        private void WriteNamespaceEnd()
        {
            _sourceWriter.DecrementIndent();
            _sourceWriter.WriteLine('}');
        }

        private void WriteRequestClass()
        {
            _sourceWriter.WriteLine($"internal sealed partial class {_requestName} : RequestBase");
            _sourceWriter.WriteLine('{');
            _sourceWriter.Indent();

            WriteRequestClassContent();

            _sourceWriter.DecrementIndent();
            _sourceWriter.WriteLine('}');
        }

        private void WriteRequestClassContent()
        {
            bool needsEmptyLine = false;

            if (_uriPlaceHolders.Count > 0)
            {
                foreach (PlaceHolder placeHolder in _uriPlaceHolders)
                {
                    string modifier = "internal";
                    string setOrInit = "set";

                    if (placeHolder.IsRequired)
                    {
                        modifier += " required";
                        setOrInit = "init";
                    }

                    _sourceWriter.WriteLine($"{modifier} {placeHolder.ValueType} {placeHolder.Name} {{ get; {setOrInit}; }}");
                    _sourceWriter.WriteEmptyLine();
                }
            }

            if (_supportsExtendedInfo)
            {
                WriteExtendedInfoProperty();
                needsEmptyLine = true;
            }

            if (_supportsPagination)
            {
                if (needsEmptyLine)
                {
                    _sourceWriter.WriteEmptyLine();
                }
                else
                {
                    needsEmptyLine = true;
                }

                WritePaginationProperties();
            }

            if (_hasOAuthRequirementDefined)
            {
                if (needsEmptyLine)
                {
                    _sourceWriter.WriteEmptyLine();
                }
                else
                {
                    needsEmptyLine = true;
                }

                WirteOAuthRequirementProperty();
            }

            if (needsEmptyLine)
            {
                _sourceWriter.WriteEmptyLine();
            }

            WriteRequestConstructor();
            _sourceWriter.WriteEmptyLine();

            WriteBuildUriMethod();

            if (_requestParameters.Count > 1)
            {
                _sourceWriter.WriteEmptyLine();
                WriteGetParametersMethod();
            }

            if (_requestQueries.Count > 1)
            {
                _sourceWriter.WriteEmptyLine();
                WriteGetQueriesMethod();
            }

            if (_uriPlaceHolders.Any(x => x.NeedsVerification))
            {
                _sourceWriter.WriteEmptyLine();
                WriteValidateMethod();
            }
        }

        private void WriteExtendedInfoProperty()
            => _sourceWriter.WriteLine("internal TraktExtendedInfo? ExtendedInfo { get; set; }");

        private void WritePaginationProperties()
        {
            _sourceWriter.WriteLine("internal uint? Page { get; set; }");
            _sourceWriter.WriteEmptyLine();
            _sourceWriter.WriteLine("internal uint? Limit { get; set; }");
        }

        private void WirteOAuthRequirementProperty()
            => _sourceWriter.WriteLine($"internal override TraktOAuthRequirement OAuthRequirement => TraktOAuthRequirement.{_oauthRequirementValue};");

        private void WriteRequestConstructor()
            => _sourceWriter.WriteLine($"internal {_requestName}() : base(HttpMethod.{_httpMethodValue}, (Uri?)null) {{ }}");

        private void WriteGetParametersMethod()
        {
            _sourceWriter.WriteLine("private List<string> GetParameters()");
            _sourceWriter.WriteLine('{');
            _sourceWriter.Indent();

            _sourceWriter.WriteLine("List<string> parameters = [];");

            foreach (RequestParameterGenerationSpecification requestParameter in _requestParameters)
            {
                _sourceWriter.WriteEmptyLine();
                WriteGetParametersEntry(requestParameter);
            }

            _sourceWriter.WriteEmptyLine();
            _sourceWriter.WriteLine("return parameters;");
            _sourceWriter.DecrementIndent();
            _sourceWriter.WriteLine('}');
        }

        private void WriteGetParametersEntry(RequestParameterGenerationSpecification requestParameter, bool writeDirectlyInBuildMethod = false)
        {
            if (requestParameter.IsTraktEnum)
            {
                if (requestParameter.IsRequired)
                {
                    if (writeDirectlyInBuildMethod)
                    {
                        _sourceWriter.WriteLine($"{RequestUriName} = {RequestUriName} + \"/\" + {requestParameter.Name}.AsPathParameter();");
                    }
                    else
                    {
                        _sourceWriter.WriteLine($"parameters.Add({requestParameter.Name}.AsPathParameter());");
                    }
                }
                else
                {
                    _sourceWriter.WriteLine($"if ({requestParameter.Name}.HasValue && {requestParameter.Name}.Value != {requestParameter.TraktEnumTypeName}.{requestParameter.TraktEnumDefaultValue})");
                    _sourceWriter.WriteLine('{');
                    _sourceWriter.Indent();

                    if (writeDirectlyInBuildMethod)
                    {
                        _sourceWriter.WriteLine($"{RequestUriName} = {RequestUriName} + \"/\" + {requestParameter.Name}.Value.AsPathParameter();");
                    }
                    else
                    {
                        _sourceWriter.WriteLine($"parameters.Add({requestParameter.Name}.Value.AsPathParameter());");
                    }

                    _sourceWriter.DecrementIndent();
                    _sourceWriter.WriteLine('}');
                }
            }
            else
            {
                switch (requestParameter.SpecialType)
                {
                    case SpecialType.System_String:
                    {
                        if (requestParameter.IsRequired)
                        {
                            if (writeDirectlyInBuildMethod)
                            {
                                _sourceWriter.WriteLine($"{RequestUriName} = {RequestUriName} + \"/\" + {requestParameter.Name};");
                            }
                            else
                            {
                                _sourceWriter.WriteLine($"parameters.Add({requestParameter.Name});");
                            }
                        }
                        else
                        {
                            _sourceWriter.WriteLine($"if (!string.IsNullOrWhiteSpace({requestParameter.Name}))");
                            _sourceWriter.WriteLine('{');
                            _sourceWriter.Indent();

                            if (writeDirectlyInBuildMethod)
                            {
                                _sourceWriter.WriteLine($"{RequestUriName} = {RequestUriName} + \"/\" + {requestParameter.Name}!;");
                            }
                            else
                            {
                                _sourceWriter.WriteLine($"parameters.Add({requestParameter.Name}!);");
                            }

                            _sourceWriter.DecrementIndent();
                            _sourceWriter.WriteLine('}');
                        }

                        break;
                    }
                    case SpecialType.System_DateTime:
                    {
                        if (requestParameter.IsRequired)
                        {
                            if (writeDirectlyInBuildMethod)
                            {
                                _sourceWriter.WriteLine($"{RequestUriName} = {RequestUriName} + \"/\" + {WriteDateTimeValue(requestParameter.Name, requestParameter.UseCacheEfficientDateTime, requestParameter.IsRequired)};");
                            }
                            else
                            {
                                _sourceWriter.WriteLine($"parameters.Add({WriteDateTimeValue(requestParameter.Name, requestParameter.UseCacheEfficientDateTime, requestParameter.IsRequired)});");
                            }
                        }
                        else
                        {
                            _sourceWriter.WriteLine($"if ({requestParameter.Name}.HasValue)");
                            _sourceWriter.WriteLine('{');
                            _sourceWriter.Indent();

                            if (writeDirectlyInBuildMethod)
                            {
                                _sourceWriter.WriteLine($"{RequestUriName} = {RequestUriName} + \"/\" + {WriteDateTimeValue(requestParameter.Name, requestParameter.UseCacheEfficientDateTime, requestParameter.IsRequired)};");
                            }
                            else
                            {
                                _sourceWriter.WriteLine($"parameters.Add({WriteDateTimeValue(requestParameter.Name, requestParameter.UseCacheEfficientDateTime, requestParameter.IsRequired)});");
                            }

                            _sourceWriter.DecrementIndent();
                            _sourceWriter.WriteLine('}');
                        }

                        break;
                    }
                    case SpecialType.System_UInt16:
                    case SpecialType.System_UInt32:
                    case SpecialType.System_UInt64:
                    case SpecialType.System_Int16:
                    case SpecialType.System_Int32:
                    case SpecialType.System_Int64:
                    {
                        if (requestParameter.IsRequired)
                        {
                            if (writeDirectlyInBuildMethod)
                            {
                                _sourceWriter.WriteLine($"{RequestUriName} = {RequestUriName} + $\"/{{{requestParameter.Name}}}\";");
                            }
                            else
                            {
                                _sourceWriter.WriteLine($"parameters.Add($\"{{{requestParameter.Name}}}\");");
                            }
                        }
                        else
                        {
                            _sourceWriter.WriteLine($"if ({requestParameter.Name}.HasValue && {requestParameter.Name}.Value > 0)");
                            _sourceWriter.WriteLine('{');
                            _sourceWriter.Indent();

                            if (writeDirectlyInBuildMethod)
                            {
                                _sourceWriter.WriteLine($"{RequestUriName} = {RequestUriName} + $\"/{{{requestParameter.Name}.Value}}\";");
                            }
                            else
                            {
                                _sourceWriter.WriteLine($"parameters.Add($\"{{{requestParameter.Name}.Value}}\");");
                            }

                            _sourceWriter.DecrementIndent();
                            _sourceWriter.WriteLine('}');
                        }

                        break;
                    }
                    case SpecialType.System_Boolean:
                    {
                        if (requestParameter.IsRequired)
                        {
                            if (writeDirectlyInBuildMethod)
                            {
                                _sourceWriter.WriteLine($"{RequestUriName} = {RequestUriName} + $\"/{{{requestParameter.Name}.ToLowerCase()}}\";");
                            }
                            else
                            {
                                _sourceWriter.WriteLine($"parameters.Add($\"{{{requestParameter.Name}.ToLowerCase()}}\");");
                            }
                        }
                        else
                        {
                            _sourceWriter.WriteLine($"if ({requestParameter.Name}.HasValue)");
                            _sourceWriter.WriteLine('{');
                            _sourceWriter.Indent();

                            if (writeDirectlyInBuildMethod)
                            {
                                _sourceWriter.WriteLine($"{RequestUriName} = {RequestUriName} + $\"/{{{requestParameter.Name}.Value.ToLowerCase()}}\";");
                            }
                            else
                            {
                                _sourceWriter.WriteLine($"parameters.Add($\"{{{requestParameter.Name}.Value.ToLowerCase()}}\");");
                            }

                            _sourceWriter.DecrementIndent();
                            _sourceWriter.WriteLine('}');
                        }

                        break;
                    }
                    default:
                        break;
                }
            }
        }

        private void WriteGetQueriesMethod()
        {
            _sourceWriter.WriteLine("private List<string> GetQueries()");
            _sourceWriter.WriteLine('{');
            _sourceWriter.Indent();
            _sourceWriter.WriteLine("List<string> queries = [];");

            foreach (RequestQueryGenerationSpecification requestQuery in _requestQueries)
            {
                _sourceWriter.WriteEmptyLine();
                WriteGetQueriesEntry(requestQuery);
            }

            _sourceWriter.WriteEmptyLine();
            _sourceWriter.WriteLine("return queries;");
            _sourceWriter.DecrementIndent();
            _sourceWriter.WriteLine('}');
        }

        private void WriteGetQueriesEntry(RequestQueryGenerationSpecification requestQuery, bool writeDirectlyInBuildMethod = false)
        {
            if (requestQuery.IsTraktEnum)
            {
                if (requestQuery.IsRequired)
                {
                    if (writeDirectlyInBuildMethod)
                    {
                        if (!string.IsNullOrEmpty(requestQuery.QueryName))
                        {
                            _sourceWriter.WriteLine($"{RequestUriName} = {RequestUriName} + $\"?{requestQuery.QueryName}={{{requestQuery.Name}.ToURI()}}\";");
                        }
                        else
                        {
                            _sourceWriter.WriteLine($"{RequestUriName} = {RequestUriName} + \"?\" + {requestQuery.Name}.AsQuery();");
                        }
                    }
                    else
                    {
                        if (!string.IsNullOrEmpty(requestQuery.QueryName))
                        {
                            _sourceWriter.WriteLine($"queries.Add($\"{requestQuery.QueryName}={{{requestQuery.Name}.ToURI()}}\");");
                        }
                        else
                        {
                            _sourceWriter.WriteLine($"queries.Add({requestQuery.Name}.AsQuery());");
                        }
                    }
                }
                else
                {
                    _sourceWriter.WriteLine($"if ({requestQuery.Name}.HasValue && {requestQuery.Name}.Value != {requestQuery.TraktEnumTypeName}.{requestQuery.TraktEnumDefaultValue})");
                    _sourceWriter.WriteLine('{');
                    _sourceWriter.Indent();

                    if (writeDirectlyInBuildMethod)
                    {
                        if (!string.IsNullOrEmpty(requestQuery.QueryName))
                        {
                            _sourceWriter.WriteLine($"{RequestUriName} = {RequestUriName} + $\"?{requestQuery.QueryName}={{{requestQuery.Name}.Value.ToURI()}}\";");
                        }
                        else
                        {
                            _sourceWriter.WriteLine($"{RequestUriName} = {RequestUriName} + \"?\" + {requestQuery.Name}.Value.AsQuery();");
                        }
                    }
                    else
                    {
                        if (!string.IsNullOrEmpty(requestQuery.QueryName))
                        {
                            _sourceWriter.WriteLine($"queries.Add($\"{requestQuery.QueryName}={{{requestQuery.Name}.Value.ToURI()}}\");");
                        }
                        else
                        {
                            _sourceWriter.WriteLine($"queries.Add({requestQuery.Name}.Value.AsQuery());");
                        }
                    }

                    _sourceWriter.DecrementIndent();
                    _sourceWriter.WriteLine('}');
                }
            }
            else if (requestQuery.SpecialType != SpecialType.None)
            {
                switch (requestQuery.SpecialType)
                {
                    case SpecialType.System_String:
                    {
                        if (requestQuery.IsRequired)
                        {
                            if (writeDirectlyInBuildMethod)
                            {
                                _sourceWriter.WriteLine($"{RequestUriName} = {RequestUriName} + $\"?{requestQuery.QueryName}={{{requestQuery.Name}}}\";");
                            }
                            else
                            {
                                _sourceWriter.WriteLine($"queries.Add($\"{requestQuery.QueryName}={{{requestQuery.Name}}}\");");
                            }
                        }
                        else
                        {
                            _sourceWriter.WriteLine($"if (!string.IsNullOrWhiteSpace({requestQuery.Name}))");
                            _sourceWriter.WriteLine('{');
                            _sourceWriter.Indent();

                            if (writeDirectlyInBuildMethod)
                            {
                                _sourceWriter.WriteLine($"{RequestUriName} = {RequestUriName} + $\"?{requestQuery.QueryName}={{{requestQuery.Name}!}};");
                            }
                            else
                            {
                                _sourceWriter.WriteLine($"queries.Add($\"{requestQuery.QueryName}={{{requestQuery.Name}!}}\");");
                            }

                            _sourceWriter.DecrementIndent();
                            _sourceWriter.WriteLine('}');
                        }

                        break;
                    }
                    case SpecialType.System_DateTime:
                    {
                        if (requestQuery.IsRequired)
                        {
                            if (writeDirectlyInBuildMethod)
                            {
                                _sourceWriter.WriteLine($"{RequestUriName} = {RequestUriName} + $\"?{requestQuery.QueryName}={{{WriteDateTimeValue(requestQuery.Name, requestQuery.UseCacheEfficientDateTime, requestQuery.IsRequired)}}}\";");
                            }
                            else
                            {
                                _sourceWriter.WriteLine($"queries.Add($\"{requestQuery.QueryName}={{{WriteDateTimeValue(requestQuery.Name, requestQuery.UseCacheEfficientDateTime, requestQuery.IsRequired)}}}\");");
                            }
                        }
                        else
                        {
                            _sourceWriter.WriteLine($"if ({requestQuery.Name}.HasValue)");
                            _sourceWriter.WriteLine('{');
                            _sourceWriter.Indent();

                            if (writeDirectlyInBuildMethod)
                            {
                                _sourceWriter.WriteLine($"{RequestUriName} = {RequestUriName} + $\"?{requestQuery.QueryName}={{{WriteDateTimeValue(requestQuery.Name, requestQuery.UseCacheEfficientDateTime, requestQuery.IsRequired)}}}\";");
                            }
                            else
                            {
                                _sourceWriter.WriteLine($"queries.Add($\"{requestQuery.QueryName}={{{WriteDateTimeValue(requestQuery.Name, requestQuery.UseCacheEfficientDateTime, requestQuery.IsRequired)}}}\");");
                            }

                            _sourceWriter.DecrementIndent();
                            _sourceWriter.WriteLine('}');
                        }

                        break;
                    }
                    case SpecialType.System_UInt16:
                    case SpecialType.System_UInt32:
                    case SpecialType.System_UInt64:
                    case SpecialType.System_Int16:
                    case SpecialType.System_Int32:
                    case SpecialType.System_Int64:
                    {
                        if (requestQuery.IsRequired)
                        {
                            if (writeDirectlyInBuildMethod)
                            {
                                _sourceWriter.WriteLine($"{RequestUriName} = {RequestUriName} + $\"?{requestQuery.QueryName}={{{requestQuery.Name}}}\";");
                            }
                            else
                            {
                                _sourceWriter.WriteLine($"queries.Add($\"{requestQuery.QueryName}={{{requestQuery.Name}}}\");");
                            }
                        }
                        else
                        {
                            _sourceWriter.WriteLine($"if ({requestQuery.Name}.HasValue && {requestQuery.Name}.Value > 0)");
                            _sourceWriter.WriteLine('{');
                            _sourceWriter.Indent();

                            if (writeDirectlyInBuildMethod)
                            {
                                _sourceWriter.WriteLine($"{RequestUriName} = {RequestUriName} + $\"?{requestQuery.QueryName}={{{requestQuery.Name}.Value}}\";");
                            }
                            else
                            {
                                _sourceWriter.WriteLine($"queries.Add($\"{requestQuery.QueryName}={{{requestQuery.Name}.Value}}\");");
                            }

                            _sourceWriter.DecrementIndent();
                            _sourceWriter.WriteLine('}');
                        }

                        break;
                    }
                    case SpecialType.System_Boolean:
                    {
                        if (requestQuery.IsRequired)
                        {
                            if (writeDirectlyInBuildMethod)
                            {
                                _sourceWriter.WriteLine($"{RequestUriName} = {RequestUriName} + $\"?{requestQuery.QueryName}={{{requestQuery.Name}.ToLowerCase()}}\";");
                            }
                            else
                            {
                                _sourceWriter.WriteLine($"queries.Add($\"{requestQuery.QueryName}={{{requestQuery.Name}.ToLowerCase()}}\");");
                            }
                        }
                        else
                        {
                            _sourceWriter.WriteLine($"if ({requestQuery.Name}.HasValue)");
                            _sourceWriter.WriteLine('{');
                            _sourceWriter.Indent();

                            if (writeDirectlyInBuildMethod)
                            {
                                _sourceWriter.WriteLine($"{RequestUriName} = {RequestUriName} + $\"?{requestQuery.QueryName}={{{requestQuery.Name}.Value.ToLowerCase()}}\";");
                            }
                            else
                            {
                                _sourceWriter.WriteLine($"queries.Add($\"{requestQuery.QueryName}={{{requestQuery.Name}.Value.ToLowerCase()}}\");");
                            }

                            _sourceWriter.DecrementIndent();
                            _sourceWriter.WriteLine('}');
                        }

                        break;
                    }
                    default:
                        break;
                }
            }
            else
            {
                if (requestQuery.IsRequired)
                {
                    if (writeDirectlyInBuildMethod)
                    {
                        _sourceWriter.WriteLine($"{RequestUriName} = {RequestUriName} + \"?\" + {requestQuery.Name}.ToString();");
                    }
                    else
                    {
                        _sourceWriter.WriteLine($"queries.Add({requestQuery.Name}.ToString());");
                    }
                }
                else
                {
                    if (writeDirectlyInBuildMethod)
                    {
                        _sourceWriter.WriteLine($"if ({requestQuery.Name} != null)");
                        _sourceWriter.WriteLine('{');
                        _sourceWriter.Indent();
                        _sourceWriter.WriteLine($"{RequestUriName} = {RequestUriName} + \"?\" + {requestQuery.Name}.ToString();");
                        _sourceWriter.DecrementIndent();
                        _sourceWriter.WriteLine('}');
                    }
                    else
                    {
                        _sourceWriter.WriteLine($"if ({requestQuery.Name} != null)");
                        _sourceWriter.WriteLine('{');
                        _sourceWriter.Indent();
                        _sourceWriter.WriteLine($"queries.Add({requestQuery.Name}.ToString());");
                        _sourceWriter.DecrementIndent();
                        _sourceWriter.WriteLine('}');
                    }
                }
            }
        }

        private static string WriteDateTimeValue(string name, bool cacheEfficient, bool isRequired)
        {
            if (isRequired)
            {
                if (cacheEfficient)
                    return $"{name}.{ToTraktCacheEfficientDateTimeMethodName}()";

                return $"{name}.{ToTraktDateTimeMethodName}()";
            }

            if (cacheEfficient)
                return $"{name}.Value.{ToTraktCacheEfficientDateTimeMethodName}()";

            return $"{name}.Value.{ToTraktDateTimeMethodName}()";
        }

        private void WriteBuildUriMethod()
        {
            _sourceWriter.WriteLine("internal override void BuildUri()");

            if ((!_hasOptionalPlaceholders && _uriPlaceHolders.Count == 0) && !_hasOptionalParameters && !_hasOptionalQueries)
            {
                _sourceWriter.Indent();
                _sourceWriter.WriteLine($"=> RequestUri = new Uri(\"{_resolvedUriPath}\", UriKind.Relative);");
                _sourceWriter.DecrementIndent();
            }
            else
            {
                _sourceWriter.WriteLine('{');
                _sourceWriter.Indent();

                if (_hasOptionalPlaceholders || _hasOptionalParameters || _hasOptionalQueries)
                {
                    if (_hasOptionalPlaceholders)
                    {
                        _sourceWriter.WriteLine($"string {RequestUriName} = $\"{_resolvedUriPath}\".Replace(\"//\", \"/\");");
                    }
                    else
                    {
                        _sourceWriter.WriteLine($"string {RequestUriName} = $\"{_resolvedUriPath}\";");
                    }

                    if (_hasOptionalParameters)
                    {
                        _sourceWriter.WriteEmptyLine();

                        if (_requestParameters.Count == 1)
                        {
                            WriteGetParametersEntry(_requestParameters[0], writeDirectlyInBuildMethod: true);
                        }
                        else
                        {
                            _sourceWriter.WriteLine("List<string> parameters = GetParameters();");
                            _sourceWriter.WriteEmptyLine();
                            _sourceWriter.WriteLine("if (parameters.Count > 0)");
                            _sourceWriter.WriteLine('{');
                            _sourceWriter.Indent();
                            _sourceWriter.WriteLine($"{RequestUriName} = {RequestUriName} + \"/\" + string.Join(\"/\", parameters);");
                            _sourceWriter.DecrementIndent();
                            _sourceWriter.WriteLine('}');
                        }
                    }

                    if (_hasOptionalQueries)
                    {
                        _sourceWriter.WriteEmptyLine();
                        
                        if (_requestQueries.Count == 1)
                        {
                            WriteGetQueriesEntry(_requestQueries[0], writeDirectlyInBuildMethod: true);
                        }
                        else
                        {
                            _sourceWriter.WriteLine("List<string> queries = GetQueries();");
                            _sourceWriter.WriteEmptyLine();
                            _sourceWriter.WriteLine("if (queries.Count > 0)");
                            _sourceWriter.WriteLine('{');
                            _sourceWriter.Indent();
                            _sourceWriter.WriteLine($"{RequestUriName} = {RequestUriName} + \"?\" + string.Join(\"&\", queries);");
                            _sourceWriter.DecrementIndent();
                            _sourceWriter.WriteLine('}');
                        }
                    }

                    if (_hasOptionalParameters || _hasOptionalQueries)
                    {
                        _sourceWriter.WriteEmptyLine();
                    }

                    _sourceWriter.WriteLine($"RequestUri = new Uri({RequestUriName}, UriKind.Relative);");
                }
                else
            {
                    _sourceWriter.WriteLine($"string {RequestUriName} = $\"{_resolvedUriPath}\";");
                    _sourceWriter.WriteLine($"RequestUri = new Uri({RequestUriName}, UriKind.Relative);");
                }

                _sourceWriter.DecrementIndent();
                _sourceWriter.WriteLine('}');
            }
        }

        private void WriteValidateMethod()
        {
            _sourceWriter.WriteLine("internal override void Validate()");
            _sourceWriter.WriteLine('{');
            _sourceWriter.Indent();

            bool needsEmptyLine = false;

            foreach (PlaceHolder placeholder in _uriPlaceHolders)
            {
                if (!placeholder.NeedsVerification)
                {
                    continue;
                }

                if (needsEmptyLine)
                {
                    _sourceWriter.WriteEmptyLine();
                }

                string name = placeholder.Name;
                string valueType = placeholder.ValueType;

                // valueType can be a nullable type name suffixed with '?'.
                // E.g. for "string?" == "string" a simple equal comparison does not work.

                if (valueType.Contains("string"))
                {
                    _sourceWriter.WriteLine($"if (string.IsNullOrWhiteSpace({name}))");
                    _sourceWriter.WriteLine('{');
                    _sourceWriter.Indent();
                    _sourceWriter.WriteLine($"throw new TraktRequestValidationException(nameof({name}), \"{name} must not be null or empty\");");
                    _sourceWriter.DecrementIndent();
                    _sourceWriter.WriteLine('}');

                    _sourceWriter.WriteEmptyLine();

                    _sourceWriter.WriteLine($"if ({name}.ContainsSpace())");
                    _sourceWriter.WriteLine('{');
                    _sourceWriter.Indent();
                    _sourceWriter.WriteLine($"throw new TraktRequestValidationException(nameof({name}), \"{name} must not contain any spaces\");");
                    _sourceWriter.DecrementIndent();
                    _sourceWriter.WriteLine('}');
                }
                else if (valueType.Contains("uint") || valueType.Contains("int") || valueType.Contains("ulong") || valueType.Contains("long"))
                {
                    if (placeholder.IsRequired)
                    {
                        _sourceWriter.WriteLine($"if ({name} == 0)");
                    }
                    else
                    {
                        _sourceWriter.WriteLine($"if ({name}.HasValue && {name}.Value == 0)");
                    }

                    _sourceWriter.WriteLine('{');
                    _sourceWriter.Indent();
                    _sourceWriter.WriteLine($"throw new TraktRequestValidationException(nameof({name}), \"{name} must not be zero\");");
                    _sourceWriter.DecrementIndent();
                    _sourceWriter.WriteLine('}');
                }

                needsEmptyLine = true;
            }

            _sourceWriter.DecrementIndent();
            _sourceWriter.WriteLine('}');
        }

        private void ParseRequestUri()
        {
            const int StackallocCharThreshold = 128;

            char[]? rentedBuffer = null;
            ReadOnlySpan<char> uriPath = _uriPath.AsSpan();
            int initialBufferLength = (int)(1.2 * uriPath.Length);

            Span<char> destination = initialBufferLength <= StackallocCharThreshold
                ? stackalloc char[StackallocCharThreshold]
                : (rentedBuffer = ArrayPool<char>.Shared.Rent(initialBufferLength));

            UriParserState state = UriParserState.Default;
            int charsWritten = 0;

            bool firstPlaceHolderNameLetterNeedsToBeUppercase = false;
            int placeHolderNameStartPosition = -1;
            int placeHolderTypeStartPosition = -1;

            string placeHolderName = string.Empty;
            string placeHolderType = string.Empty;

            bool hasQuesionMark = false;
            int exclamationMarkCount = 0;

            for (int i = 0; i < uriPath.Length; i++)
            {
                char currentCharacter = uriPath[i];

                switch (state)
                {
                    case UriParserState.ParsingPlaceHolderName:
                    {
                        switch (currentCharacter)
                        {
                            case ':':
                                state = UriParserState.ParsingPlaceHolderType;
                                placeHolderTypeStartPosition = i + 1;
                                placeHolderName = destination.Slice(placeHolderNameStartPosition, charsWritten - placeHolderNameStartPosition).ToString();
                                placeHolderNameStartPosition = -1;
                                break;
                            case '_':
                                // Ignore this character, so '_' gets removed from the name.
                                firstPlaceHolderNameLetterNeedsToBeUppercase = true;
                                break;
                            case '}':
                                // No parameter type defined.
                                // Use "string" as default.

                                state = UriParserState.Default;

                                placeHolderName = destination.Slice(placeHolderNameStartPosition, charsWritten - placeHolderNameStartPosition).ToString();
                                placeHolderNameStartPosition = -1;

                                placeHolderType = "string";
                                placeHolderTypeStartPosition = -1;

                                _hasOptionalPlaceholders = _hasOptionalPlaceholders || hasQuesionMark;

                                _uriPlaceHolders.Add(new PlaceHolder
                                {
                                    Name = placeHolderName,
                                    ValueType = placeHolderType,
                                    IsRequired = !hasQuesionMark,
                                    NeedsVerification = exclamationMarkCount == 2
                                });

                                placeHolderName = string.Empty;
                                placeHolderType = string.Empty;

                                hasQuesionMark = false;
                                exclamationMarkCount = 0;

                                WriteChar(currentCharacter, ref destination);
                                break;
                            case '?':
                                hasQuesionMark = true;
                                break;
                            case '!':
                                exclamationMarkCount++;
                                break;
                            default:
                            {
                                if (firstPlaceHolderNameLetterNeedsToBeUppercase)
                                {
                                    // Flip sixth bit to switch character casing.
                                    //     65 => 01000001 => 'A'
                                    // XOR 32 => 00100000
                                    // ---------------------
                                    //     97 => 01100001 => 'a'
                                    WriteChar((char)(currentCharacter ^ 32), ref destination);
                                    firstPlaceHolderNameLetterNeedsToBeUppercase = false;
                                }
                                else
                                {
                                    WriteChar(currentCharacter, ref destination);
                                }

                                break;
                            }
                        }

                        break;
                    }
                    case UriParserState.ParsingPlaceHolderType:
                    {
                        switch (currentCharacter)
                        {
                            case '}':
                                WriteChar(currentCharacter, ref destination);
                                state = UriParserState.Default;

                                placeHolderType = uriPath.Slice(placeHolderTypeStartPosition, i - placeHolderTypeStartPosition).ToString();
                                placeHolderTypeStartPosition = -1;

                                bool isOptional = placeHolderType.IndexOf('?') >= 0;
                                bool needsVerification = placeHolderType.IndexOf("!!", StringComparison.InvariantCulture) >= 0;
                                _hasOptionalPlaceholders = _hasOptionalPlaceholders || isOptional;

                                if (needsVerification)
                                {
                                    placeHolderType = placeHolderType.Substring(0, placeHolderType.Length - 2);
                                }

                                _uriPlaceHolders.Add(new PlaceHolder
                                {
                                    Name = placeHolderName,
                                    ValueType = placeHolderType,
                                    IsRequired = !isOptional,
                                    NeedsVerification = needsVerification
                                });

                                placeHolderName = string.Empty;
                                placeHolderType = string.Empty;

                                break;
                            default:
                                // Just proceed with the current character.
                                break;
                        }

                        break;
                    }
                    case UriParserState.Default:
                    {
                        switch (currentCharacter)
                        {
                            case '{':
                                WriteChar(currentCharacter, ref destination);
                                state = UriParserState.ParsingPlaceHolderName;
                                placeHolderNameStartPosition = charsWritten;
                                firstPlaceHolderNameLetterNeedsToBeUppercase = true;
                                break;
                            default:
                                if (i == _uriPath.Length - 1 && currentCharacter == '/')
                                {
                                    // Last character is "/"
                                    // Just ignore it.
                                }
                                else
                                {
                                    WriteChar(currentCharacter, ref destination);
                                }

                                break;
                        }

                        break;
                    }
                }
            }

            _resolvedUriPath = destination.Slice(0, charsWritten).ToString();

            if (rentedBuffer != null)
            {
                destination.Slice(0, charsWritten).Clear();
                ArrayPool<char>.Shared.Return(rentedBuffer);
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            void WriteChar(char value, ref Span<char> destination)
            {
                if (charsWritten == destination.Length)
                {
                    ExpandBuffer(ref destination);
                }

                destination[charsWritten++] = value;
            }

            void ExpandBuffer(ref Span<char> destination)
            {
                int newSize = checked(destination.Length * 2);
                char[] newBuffer = ArrayPool<char>.Shared.Rent(newSize);
                destination.CopyTo(newBuffer);

                if (rentedBuffer != null)
                {
                    destination.Slice(0, charsWritten).Clear();
                    ArrayPool<char>.Shared.Return(rentedBuffer);
                }

                rentedBuffer = newBuffer;
                destination = rentedBuffer;
            }
        }

        private readonly record struct PlaceHolder
        {
            internal required string Name { get; init; }

            internal required string ValueType { get; init; }

            internal required bool IsRequired { get; init; }

            internal required bool NeedsVerification { get; init; }
        }

        private enum UriParserState
        {
            Default,
            ParsingPlaceHolderName,
            ParsingPlaceHolderType
        }
    }
}
