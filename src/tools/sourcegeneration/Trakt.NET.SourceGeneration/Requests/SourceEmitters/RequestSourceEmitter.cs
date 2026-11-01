using Microsoft.CodeAnalysis;
using System.Text;
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
        private RequestPayloadGenerationSpecification? _requestPayload;

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
            _requestNamespace = requestGenerationSpecification.Namespace;
            _httpMethodValue = requestGenerationSpecification.HttpMethodValue;
            _uriPath = requestGenerationSpecification.UriPath;
            _oauthRequirementValue = requestGenerationSpecification.OAuthRequirementValue;
            _supportsExtendedInfo = requestGenerationSpecification.SupportsExtendedInfo;
            _supportsPagination = requestGenerationSpecification.SupportsPagination;
            _hasOAuthRequirementDefined = requestGenerationSpecification.HasOAuthRequirementDefined;
            _requestParameters = [.. requestGenerationSpecification.RequestParameters];
            _requestQueries = [.. requestGenerationSpecification.RequestQueries];
            _requestPayload = requestGenerationSpecification.RequestPayload;

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
            WriteUriPlaceHolderProperties();
            WriteOptionalProperties();

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

            if (NeedsValidateMethod())
            {
                _sourceWriter.WriteEmptyLine();
                WriteValidateMethod();
            }
        }

        private void WriteUriPlaceHolderProperties()
        {
            foreach (PlaceHolder placeHolder in _uriPlaceHolders)
            {
                string modifier = placeHolder.IsRequired ? "internal required" : "internal";
                string setOrInit = placeHolder.IsRequired ? "init" : "set";

                _sourceWriter.WriteLine($"{modifier} {placeHolder.ValueType} {placeHolder.Name} {{ get; {setOrInit}; }}");
                _sourceWriter.WriteEmptyLine();
            }
        }

        /// <summary>Writes the extended info, pagination and OAuth requirement properties, each followed by an empty line.</summary>
        private void WriteOptionalProperties()
        {
            List<Action> propertyWriters = [];

            if (_supportsExtendedInfo)
                propertyWriters.Add(WriteExtendedInfoProperty);

            if (_supportsPagination)
                propertyWriters.Add(WritePaginationProperties);

            if (_hasOAuthRequirementDefined)
                propertyWriters.Add(WirteOAuthRequirementProperty);

            foreach (Action writeProperty in propertyWriters)
            {
                writeProperty();
                _sourceWriter.WriteEmptyLine();
            }
        }

        private bool NeedsValidateMethod()
            => _uriPlaceHolders.Any(x => x.NeedsVerification)
            || _requestParameters.Any(x => x.IsRequired)
            || _requestQueries.Any(x => x.IsRequired)
            || (_requestPayload != null && (_requestPayload.IsRequired || _requestPayload.HasValidateMethod));

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
            UriValueEntry? entry = GetParameterEntry(requestParameter);

            if (entry.HasValue)
                WriteUriValueEntry(entry.Value, "parameters", "/", writeDirectlyInBuildMethod);
        }

        private static UriValueEntry? GetParameterEntry(RequestParameterGenerationSpecification requestParameter)
        {
            string name = requestParameter.Name;
            bool isRequired = requestParameter.IsRequired;

            if (requestParameter.IsTraktEnum)
            {
                return isRequired
                    ? new UriValueEntry(null, $"{name}.AsPathParameter()")
                    : new UriValueEntry($"{name}.HasValue && {name}.Value != {requestParameter.TraktEnumTypeName}.{requestParameter.TraktEnumDefaultValue}", $"{name}.Value.AsPathParameter()");
            }

            return requestParameter.SpecialType switch
            {
                SpecialType.System_String => isRequired
                    ? new UriValueEntry(null, name)
                    : new UriValueEntry($"!string.IsNullOrWhiteSpace({name})", $"{name}!"),
                SpecialType.System_DateTime => new UriValueEntry(isRequired ? null : $"{name}.HasValue",
                    WriteDateTimeValue(name, requestParameter.UseCacheEfficientDateTime, isRequired)),
                _ when IsIntegerSpecialType(requestParameter.SpecialType) => isRequired
                    ? new UriValueEntry(null, name, string.Empty)
                    : new UriValueEntry($"{name}.HasValue && {name}.Value > 0", $"{name}.Value", string.Empty),
                SpecialType.System_Boolean => isRequired
                    ? new UriValueEntry(null, $"{name}.ToLowerCase()", string.Empty)
                    : new UriValueEntry($"{name}.HasValue", $"{name}.Value.ToLowerCase()", string.Empty),
                _ => null
            };
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
            UriValueEntry? entry = GetQueryEntry(requestQuery);

            if (entry.HasValue)
                WriteUriValueEntry(entry.Value, "queries", "?", writeDirectlyInBuildMethod);
        }

        private static UriValueEntry? GetQueryEntry(RequestQueryGenerationSpecification requestQuery)
        {
            string name = requestQuery.Name;
            bool isRequired = requestQuery.IsRequired;

            if (requestQuery.IsTraktEnum)
            {
                string? condition = isRequired ? null : $"{name}.HasValue && {name}.Value != {requestQuery.TraktEnumTypeName}.{requestQuery.TraktEnumDefaultValue}";
                string value = isRequired ? name : $"{name}.Value";

                // Without a query name, the enum provides the complete query, including its name.
                return string.IsNullOrEmpty(requestQuery.QueryName)
                    ? new UriValueEntry(condition, $"{value}.AsQuery()")
                    : new UriValueEntry(condition, $"{value}.ToURI()", $"{requestQuery.QueryName}=");
            }

            // Types without special type provide the complete query by their ToString() method.
            if (requestQuery.SpecialType == SpecialType.None)
                return new UriValueEntry(isRequired ? null : $"{name} != null", $"{name}.ToString()");

            string queryPrefix = $"{requestQuery.QueryName}=";

            return requestQuery.SpecialType switch
            {
                SpecialType.System_String => isRequired
                    ? new UriValueEntry(null, name, queryPrefix)
                    : new UriValueEntry($"!string.IsNullOrWhiteSpace({name})", $"{name}!", queryPrefix),
                SpecialType.System_DateTime => new UriValueEntry(isRequired ? null : $"{name}.HasValue",
                    WriteDateTimeValue(name, requestQuery.UseCacheEfficientDateTime, isRequired), queryPrefix),
                _ when IsIntegerSpecialType(requestQuery.SpecialType) => isRequired
                    ? new UriValueEntry(null, name, queryPrefix)
                    : new UriValueEntry($"{name}.HasValue && {name}.Value > 0", $"{name}.Value", queryPrefix),
                SpecialType.System_Boolean => isRequired
                    ? new UriValueEntry(null, $"{name}.ToLowerCase()", queryPrefix)
                    : new UriValueEntry($"{name}.HasValue", $"{name}.Value.ToLowerCase()", queryPrefix),
                _ => null
            };
        }

        /// <summary>
        /// Writes code which adds the value of an entry either to the given list or, if <paramref name="writeDirectlyInBuildMethod" /> is set,
        /// directly to the request URI, prefixed by the given separator.
        /// The value is only added, if the condition of the entry is met.
        /// </summary>
        private void WriteUriValueEntry(UriValueEntry entry, string listName, string separator, bool writeDirectlyInBuildMethod)
        {
            string line;

            if (entry.InterpolationPrefix == null)
            {
                line = writeDirectlyInBuildMethod
                    ? $"{RequestUriName} = {RequestUriName} + \"{separator}\" + {entry.Expression};"
                    : $"{listName}.Add({entry.Expression});";
            }
            else
            {
                line = writeDirectlyInBuildMethod
                    ? $"{RequestUriName} = {RequestUriName} + $\"{separator}{entry.InterpolationPrefix}{{{entry.Expression}}}\";"
                    : $"{listName}.Add($\"{entry.InterpolationPrefix}{{{entry.Expression}}}\");";
            }

            if (entry.Condition == null)
            {
                _sourceWriter.WriteLine(line);
                return;
            }

            _sourceWriter.WriteLine($"if ({entry.Condition})");
            _sourceWriter.WriteLine('{');
            _sourceWriter.Indent();
            _sourceWriter.WriteLine(line);
            _sourceWriter.DecrementIndent();
            _sourceWriter.WriteLine('}');
        }

        /// <summary>
        /// A value, which is added to the request URI.
        /// </summary>
        /// <param name="Condition">The condition, which must be met to add the value, or <see langword="null" /> to always add the value.</param>
        /// <param name="Expression">The expression of the value.</param>
        /// <param name="InterpolationPrefix">
        /// If not <see langword="null" />, the expression is written into an interpolated string, after this prefix.
        /// Otherwise the expression is used as-is.
        /// </param>
        private readonly record struct UriValueEntry(string? Condition, string Expression, string? InterpolationPrefix = null);

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

            if (!_hasOptionalPlaceholders && _uriPlaceHolders.Count == 0 && !_hasOptionalParameters && !_hasOptionalQueries && _requestPayload == null)
            {
                _sourceWriter.Indent();
                _sourceWriter.WriteLine($"=> RequestUri = new Uri(\"{_resolvedUriPath}\", UriKind.Relative);");
                _sourceWriter.DecrementIndent();
                return;
            }

            _sourceWriter.WriteLine('{');
            _sourceWriter.Indent();

            WriteRequestUriAssignment();
            WritePayloadContentAssignment();

            _sourceWriter.DecrementIndent();
            _sourceWriter.WriteLine('}');
        }

        private void WriteRequestUriAssignment()
        {
            if (!_hasOptionalPlaceholders && !_hasOptionalParameters && !_hasOptionalQueries)
            {
                _sourceWriter.WriteLine($"string {RequestUriName} = $\"{_resolvedUriPath}\";");
                _sourceWriter.WriteLine($"RequestUri = new Uri({RequestUriName}, UriKind.Relative);");
                return;
            }

            // Omitted optional placeholders leave double slashes in the resolved path.
            string replaceDoubleSlashes = _hasOptionalPlaceholders ? ".Replace(\"//\", \"/\")" : string.Empty;
            _sourceWriter.WriteLine($"string {RequestUriName} = $\"{_resolvedUriPath}\"{replaceDoubleSlashes};");

            if (_hasOptionalParameters)
            {
                _sourceWriter.WriteEmptyLine();

                if (_requestParameters.Count == 1)
                    WriteGetParametersEntry(_requestParameters[0], writeDirectlyInBuildMethod: true);
                else
                    WriteRequestUriAppendFromList("parameters", "GetParameters", "/");
            }

            if (_hasOptionalQueries)
            {
                _sourceWriter.WriteEmptyLine();

                if (_requestQueries.Count == 1)
                    WriteGetQueriesEntry(_requestQueries[0], writeDirectlyInBuildMethod: true);
                else
                    WriteRequestUriAppendFromList("queries", "GetQueries", "&", "?");
            }

            if (_hasOptionalParameters || _hasOptionalQueries)
                _sourceWriter.WriteEmptyLine();

            _sourceWriter.WriteLine($"RequestUri = new Uri({RequestUriName}, UriKind.Relative);");
        }

        /// <summary>Writes code which appends all values returned by the given method to the request URI, if any.</summary>
        private void WriteRequestUriAppendFromList(string listName, string getMethodName, string separator, string? prefix = null)
        {
            prefix ??= separator;

            _sourceWriter.WriteLine($"List<string> {listName} = {getMethodName}();");
            _sourceWriter.WriteEmptyLine();
            _sourceWriter.WriteLine($"if ({listName}.Count > 0)");
            _sourceWriter.WriteLine('{');
            _sourceWriter.Indent();
            _sourceWriter.WriteLine($"{RequestUriName} = {RequestUriName} + \"{prefix}\" + string.Join(\"{separator}\", {listName});");
            _sourceWriter.DecrementIndent();
            _sourceWriter.WriteLine('}');
        }

        private void WritePayloadContentAssignment()
        {
            if (_requestPayload == null)
                return;

            string contentAssignment = $"Content = System.Net.Http.Json.JsonContent.Create({_requestPayload.Name}, {_requestPayload.Name}.GetType(), options: Constants.Json.JsonOptions);";

            _sourceWriter.WriteEmptyLine();

            if (_requestPayload.IsRequired)
            {
                _sourceWriter.WriteLine(contentAssignment);
                return;
            }

            _sourceWriter.WriteLine($"if ({_requestPayload.Name} != null)");
            _sourceWriter.WriteLine('{');
            _sourceWriter.Indent();
            _sourceWriter.WriteLine(contentAssignment);
            _sourceWriter.DecrementIndent();
            _sourceWriter.WriteLine('}');
        }

        private void WriteValidateMethod()
        {
            _sourceWriter.WriteLine("internal override void Validate()");
            _sourceWriter.WriteLine('{');
            _sourceWriter.Indent();

            List<Action> validations = [];

            foreach (PlaceHolder placeholder in _uriPlaceHolders)
            {
                Action? placeholderValidation = GetPlaceHolderValidation(placeholder);

                if (placeholderValidation != null)
                    validations.Add(placeholderValidation);
            }

            foreach (RequestParameterGenerationSpecification requestParameter in _requestParameters.Where(x => x.IsRequired))
            {
                // Skip extended info enum default check handled elsewhere
                bool skipEnumDefault = requestParameter.Name == "TraktExtendedInfo";

                validations.Add(() => WriteMemberValidation(requestParameter.Name, requestParameter.IsTraktEnum, requestParameter.TraktEnumTypeName,
                    requestParameter.TraktEnumDefaultValue, requestParameter.SpecialType, skipEnumDefault));
            }

            foreach (RequestQueryGenerationSpecification requestQuery in _requestQueries.Where(x => x.IsRequired))
            {
                validations.Add(() => WriteMemberValidation(requestQuery.Name, requestQuery.IsTraktEnum, requestQuery.TraktEnumTypeName,
                    requestQuery.TraktEnumDefaultValue, requestQuery.SpecialType));
            }

            Action? payloadValidation = GetPayloadValidation();

            if (payloadValidation != null)
                validations.Add(payloadValidation);

            for (int i = 0; i < validations.Count; i++)
            {
                if (i > 0)
                    _sourceWriter.WriteEmptyLine();

                validations[i]();
            }

            _sourceWriter.DecrementIndent();
            _sourceWriter.WriteLine('}');
        }

        /// <summary>
        /// Gets the writer for the validation of the given placeholder, depending on its value type,
        /// or <see langword="null" /> if the placeholder needs no validation.
        /// </summary>
        private Action? GetPlaceHolderValidation(PlaceHolder placeholder)
        {
            string name = placeholder.Name;
            string valueType = placeholder.ValueType;

            if (valueType.Contains("string"))
                return placeholder.NeedsVerification ? () => WriteStringPlaceHolderValidation(name) : null;

            if (valueType.Contains("int") || valueType.Contains("long"))
                return placeholder.NeedsVerification ? () => WriteIntegerPlaceHolderValidation(name, placeholder.IsRequired) : null;

            if (!IsTraktEnum(valueType))
                return null;

            string cleanValueType = valueType.TrimEnd('?');

            if (placeholder.IsRequired && !valueType.Contains("?"))
            {
                return () =>
                {
                    _sourceWriter.WriteLine($"if ({name} == {cleanValueType}.Unspecified)");
                    WriteValidationThrow(name, $"{name} must not be Unspecified");
                };
            }

            if (placeholder.NeedsVerification)
            {
                return () =>
                {
                    _sourceWriter.WriteLine($"if (!{name}.HasValue || {name}.Value == {cleanValueType}.Unspecified)");
                    WriteValidationThrow(name, $"{name} must not be null or Unspecified");
                };
            }

            return null;
        }

        private void WriteStringPlaceHolderValidation(string name)
        {
            _sourceWriter.WriteLine($"if (string.IsNullOrWhiteSpace({name}))");
            WriteValidationThrow(name, $"{name} must not be null or empty");

            _sourceWriter.WriteEmptyLine();

            _sourceWriter.WriteLine($"if ({name}.ContainsSpace())");
            WriteValidationThrow(name, $"{name} must not contain any spaces");
        }

        private void WriteIntegerPlaceHolderValidation(string name, bool isRequired)
        {
            _sourceWriter.WriteLine(isRequired ? $"if ({name} == 0)" : $"if ({name}.HasValue && {name}.Value == 0)");
            WriteValidationThrow(name, $"{name} must not be zero");
        }

        private Action? GetPayloadValidation()
        {
            if (_requestPayload == null)
                return null;

            RequestPayloadGenerationSpecification requestPayload = _requestPayload;

            if (requestPayload.IsRequired)
            {
                return () =>
                {
                    WriteMemberValidation(requestPayload.Name, requestPayload.IsTraktEnum, requestPayload.TraktEnumTypeName,
                        requestPayload.TraktEnumDefaultValue, requestPayload.SpecialType);

                    if (requestPayload.HasValidateMethod)
                    {
                        _sourceWriter.WriteEmptyLine();
                        _sourceWriter.WriteLine($"{requestPayload.Name}.Validate();");
                    }
                };
            }

            if (!requestPayload.HasValidateMethod)
                return null;

            return () =>
            {
                _sourceWriter.WriteLine($"if ({requestPayload.Name} != null)");
                _sourceWriter.WriteLine('{');
                _sourceWriter.Indent();
                _sourceWriter.WriteLine($"{requestPayload.Name}.Validate();");
                _sourceWriter.DecrementIndent();
                _sourceWriter.WriteLine('}');
            };
        }

        /// <summary>Writes the validation of a generated member (parameter, query or payload), depending on its type.</summary>
        private void WriteMemberValidation(string name, bool isTraktEnum, string traktEnumTypeName, string traktEnumDefaultValue,
            SpecialType specialType, bool skipEnumDefaultCheck = false)
        {
            if (isTraktEnum && !skipEnumDefaultCheck)
            {
                _sourceWriter.WriteLine($"if ({name} == {traktEnumTypeName}.{traktEnumDefaultValue})");
                WriteValidationThrow(name, $"{name} must not be {traktEnumDefaultValue}");
            }
            else if (specialType == SpecialType.System_String)
            {
                _sourceWriter.WriteLine($"if (string.IsNullOrWhiteSpace({name}))");
                WriteValidationThrow(name, $"{name} must not be null or empty");
            }
            else if (IsIntegerSpecialType(specialType))
            {
                _sourceWriter.WriteLine($"if ({name} == 0)");
                WriteValidationThrow(name, $"{name} must not be zero");
            }
            else
            {
                _sourceWriter.WriteLine($"if ({name} == null)");
                WriteValidationThrow(name, $"{name} must not be null");
            }
        }

        private static bool IsIntegerSpecialType(SpecialType specialType)
            => specialType is SpecialType.System_Int16 or SpecialType.System_Int32 or SpecialType.System_Int64
                or SpecialType.System_UInt16 or SpecialType.System_UInt32 or SpecialType.System_UInt64;

        private void WriteValidationThrow(string memberName, string message)
        {
            _sourceWriter.WriteLine('{');
            _sourceWriter.Indent();
            _sourceWriter.WriteLine($"throw new TraktRequestValidationException(nameof({memberName}), \"{message}\");");
            _sourceWriter.DecrementIndent();
            _sourceWriter.WriteLine('}');
        }

        private static bool IsTraktEnum(string valueType)
        {
            string cleanType = valueType.TrimEnd('?');
            return cleanType.StartsWith("Trakt", StringComparison.Ordinal)
                && !cleanType.Equals("TraktId", StringComparison.Ordinal)
                && !cleanType.Equals("TraktExtendedInfo", StringComparison.Ordinal);
        }

        private void ParseRequestUri()
        {
            var uriPathParser = new UriPathParser(_uriPath);

            _resolvedUriPath = uriPathParser.Parse();
            _uriPlaceHolders.AddRange(uriPathParser.PlaceHolders);
            _hasOptionalPlaceholders = _hasOptionalPlaceholders || uriPathParser.HasOptionalPlaceHolders;
        }

        /// <summary>
        /// Resolves an URI path template like "users/{id}/lists/{list_id?:uint}" into an interpolatable path
        /// and collects its placeholders.
        /// <para>
        /// Placeholder names are converted to PascalCase. A placeholder without type is a string.
        /// '?' marks a placeholder as optional and "!!" marks it as needing verification.
        /// A trailing '/' is removed.
        /// </para>
        /// </summary>
        private sealed class UriPathParser(string uriPath)
        {
            private readonly StringBuilder _output = new(uriPath.Length);
            private UriParserState _state = UriParserState.Default;
            private bool _nextPlaceHolderNameLetterNeedsToBeUppercase;
            private int _placeHolderNameStartPosition = -1;
            private int _placeHolderTypeStartPosition = -1;
            private string _placeHolderName = string.Empty;
            private bool _hasQuestionMark;
            private int _exclamationMarkCount;

            internal List<PlaceHolder> PlaceHolders { get; } = [];

            internal bool HasOptionalPlaceHolders { get; private set; }

            internal string Parse()
            {
                for (int i = 0; i < uriPath.Length; i++)
                {
                    char currentCharacter = uriPath[i];

                    switch (_state)
                    {
                        case UriParserState.ParsingPlaceHolderName:
                            ProcessPlaceHolderNameCharacter(currentCharacter, i);
                            break;
                        case UriParserState.ParsingPlaceHolderType:
                            ProcessPlaceHolderTypeCharacter(currentCharacter, i);
                            break;
                        default:
                            ProcessDefaultCharacter(currentCharacter, i);
                            break;
                    }
                }

                return _output.ToString();
            }

            private void ProcessDefaultCharacter(char currentCharacter, int index)
            {
                if (currentCharacter == '{')
                {
                    _output.Append(currentCharacter);
                    _state = UriParserState.ParsingPlaceHolderName;
                    _placeHolderNameStartPosition = _output.Length;
                    _nextPlaceHolderNameLetterNeedsToBeUppercase = true;
                }
                else if (index != uriPath.Length - 1 || currentCharacter != '/')
                {
                    _output.Append(currentCharacter);
                }
            }

            private void ProcessPlaceHolderNameCharacter(char currentCharacter, int index)
            {
                switch (currentCharacter)
                {
                    case ':':
                        _state = UriParserState.ParsingPlaceHolderType;
                        _placeHolderTypeStartPosition = index + 1;
                        _placeHolderName = TakePlaceHolderName();
                        break;
                    case '_':
                        // Ignore this character, so '_' gets removed from the name.
                        _nextPlaceHolderNameLetterNeedsToBeUppercase = true;
                        break;
                    case '}':
                        // No parameter type defined, use "string" as default.
                        _state = UriParserState.Default;
                        HasOptionalPlaceHolders = HasOptionalPlaceHolders || _hasQuestionMark;

                        PlaceHolders.Add(new PlaceHolder
                        {
                            Name = TakePlaceHolderName(),
                            ValueType = "string",
                            IsRequired = !_hasQuestionMark,
                            NeedsVerification = _exclamationMarkCount == 2
                        });

                        _hasQuestionMark = false;
                        _exclamationMarkCount = 0;
                        _output.Append(currentCharacter);
                        break;
                    case '?':
                        _hasQuestionMark = true;
                        break;
                    case '!':
                        _exclamationMarkCount++;
                        break;
                    default:
                        // Flipping the sixth bit switches the casing of an ASCII letter ('a' ^ 32 == 'A').
                        _output.Append(_nextPlaceHolderNameLetterNeedsToBeUppercase ? (char)(currentCharacter ^ 32) : currentCharacter);
                        _nextPlaceHolderNameLetterNeedsToBeUppercase = false;
                        break;
                }
            }

            private void ProcessPlaceHolderTypeCharacter(char currentCharacter, int index)
            {
                // The type itself is not written to the output.
                if (currentCharacter != '}')
                    return;

                string placeHolderType = uriPath.Substring(_placeHolderTypeStartPosition, index - _placeHolderTypeStartPosition);
                _placeHolderTypeStartPosition = -1;

                bool isOptional = placeHolderType.IndexOf('?') >= 0;
                bool needsVerification = placeHolderType.IndexOf("!!", StringComparison.InvariantCulture) >= 0;
                HasOptionalPlaceHolders = HasOptionalPlaceHolders || isOptional;

                if (needsVerification)
                    placeHolderType = placeHolderType.Substring(0, placeHolderType.Length - 2);

                if (IsTraktEnum(placeHolderType))
                    _output.Append(isOptional ? "?.AsPathParameter()" : ".AsPathParameter()");

                _output.Append(currentCharacter);
                _state = UriParserState.Default;

                PlaceHolders.Add(new PlaceHolder
                {
                    Name = _placeHolderName,
                    ValueType = placeHolderType,
                    IsRequired = !isOptional,
                    NeedsVerification = needsVerification
                });

                _placeHolderName = string.Empty;
            }

            private string TakePlaceHolderName()
            {
                string placeHolderName = _output.ToString(_placeHolderNameStartPosition, _output.Length - _placeHolderNameStartPosition);
                _placeHolderNameStartPosition = -1;
                return placeHolderName;
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
