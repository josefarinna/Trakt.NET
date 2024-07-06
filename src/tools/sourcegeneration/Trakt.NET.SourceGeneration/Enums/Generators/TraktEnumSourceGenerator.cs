using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using TraktNET.SourceGeneration.Models;

using EnumDeclarationSyntaxTuple =
    ((Microsoft.CodeAnalysis.CSharp.Syntax.EnumDeclarationSyntax ContextClass, Microsoft.CodeAnalysis.SemanticModel SemanticModel) EnumDeclarationContext,
    TraktNET.SourceGeneration.Enums.KnownEnumSymbols KnownEnumSymbols);

using EnumGenerationSpecificationTuple =
    (TraktNET.SourceGeneration.Enums.EnumGenerationSpecification? EnumGenerationSpecification,
        TraktNET.SourceGeneration.Models.ImmutableEquatableArray<TraktNET.SourceGeneration.Models.DiagnosticInfo> Diagnostics);

namespace TraktNET.SourceGeneration.Enums
{
    [Generator]
    public sealed class TraktEnumSourceGenerator : IIncrementalGenerator
    {
        private IncrementalValueProvider<KnownEnumSymbols> _knownEnumTypeSymbols;
        private IncrementalValuesProvider<EnumGenerationSpecificationTuple> _enumGenerationSpecifications;

        public void Initialize(IncrementalGeneratorInitializationContext context)
        {
            _knownEnumTypeSymbols = context.CompilationProvider.Select(static (compilation, _) => new KnownEnumSymbols(compilation));
            _enumGenerationSpecifications = CombineAndSelectEnumsWithAttribute(context);
            context.RegisterSourceOutput(_enumGenerationSpecifications, ReportDiagnosticsAndEmitSource);
        }

        private IncrementalValuesProvider<EnumGenerationSpecificationTuple> CombineAndSelectEnumsWithAttribute(
            IncrementalGeneratorInitializationContext context)
            => context.SyntaxProvider
                .ForAttributeWithMetadataName(EnumConstants.FullTraktEnumAttributeName,
                    static (syntaxNode, _) => syntaxNode is EnumDeclarationSyntax,
                    (context, _) => (ContextClass: (EnumDeclarationSyntax)context.TargetNode, context.SemanticModel))
                .WithTrackingName(EnumConstants.TrackingNames.InitialEnumExtraction)
                .Combine(_knownEnumTypeSymbols)
                .Select(ParseEnumDeclaration)
                .WithTrackingName(EnumConstants.TrackingNames.FilteredEnums);

        private EnumGenerationSpecificationTuple ParseEnumDeclaration(EnumDeclarationSyntaxTuple enumDeclarationInput, CancellationToken cancellationToken)
        {
            TraktEnumDeclarationParser parser = new(enumDeclarationInput.KnownEnumSymbols);

            EnumGenerationSpecification? enumGenerationSpecification =
                parser.ParseTraktEnumDeclaration(enumDeclarationInput.EnumDeclarationContext.ContextClass, enumDeclarationInput.EnumDeclarationContext.SemanticModel, cancellationToken);

            var diagnostics = parser.Diagnostics.ToImmutableEquatableArray();
            return (enumGenerationSpecification, diagnostics);
        }

        private void ReportDiagnosticsAndEmitSource(SourceProductionContext sourceProductionContext, EnumGenerationSpecificationTuple input)
        {
            foreach (DiagnosticInfo diagnosticInfo in input.Diagnostics)
            {
                sourceProductionContext.ReportDiagnostic(diagnosticInfo.CreateDiagnostic());
            }

            if (input.EnumGenerationSpecification == null)
            {
                return;
            }

            var enumSourceEmitter = new EnumSourceEmitter(sourceProductionContext);
            enumSourceEmitter.Emit(input.EnumGenerationSpecification);
        }
    }
}
