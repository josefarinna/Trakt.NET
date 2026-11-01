using Microsoft.CodeAnalysis;
using TraktNET.SourceGeneration.Common;

namespace TraktNET.SourceGeneration.Models
{
    public class KnownSymbols(Compilation compilation)
    {
        private OptionalValue<INamedTypeSymbol?> _systemFlagsAttributeType;

        public Compilation Compilation { get; } = compilation;

        public INamedTypeSymbol? SystemFlagsAttributeType
            => GetOrResolveType(Constants.FullSystemFlagsAttributeName, ref _systemFlagsAttributeType);

        protected INamedTypeSymbol? GetOrResolveType(string fullQualifiedName, ref OptionalValue<INamedTypeSymbol?> symbol)
        {
            if (symbol.HasValue)
                return symbol.Value;

            INamedTypeSymbol? typeSymbol = GetBestTypeByMetadataName(fullQualifiedName);
            symbol = new(typeSymbol);
            return typeSymbol;
        }

        private INamedTypeSymbol? GetBestTypeByMetadataName(string fullQualifiedName)
        {
            INamedTypeSymbol? type = Compilation.GetTypeByMetadataName(fullQualifiedName);
            type ??= Compilation.Assembly.GetTypeByMetadataName(fullQualifiedName);
            return type ?? GetUniqueTypeFromReferencedAssemblies(fullQualifiedName);
        }

        /// <summary>
        /// Searches the referenced assemblies for an accessible type with the given name.
        /// Returns <see langword="null" /> if none or more than one accessible type is found.
        /// </summary>
        private INamedTypeSymbol? GetUniqueTypeFromReferencedAssemblies(string fullQualifiedName)
        {
            INamedTypeSymbol? type = null;

            foreach (IModuleSymbol module in Compilation.Assembly.Modules)
            {
                foreach (IAssemblySymbol referenceAssembly in module.ReferencedAssemblySymbols)
                {
                    INamedTypeSymbol? currentType = referenceAssembly.GetTypeByMetadataName(fullQualifiedName);

                    if (currentType == null || !IsAccessibleFrom(currentType, referenceAssembly))
                        continue;

                    if (type is not null)
                        return null;

                    type = currentType;
                }
            }

            return type;
        }

        private bool IsAccessibleFrom(INamedTypeSymbol type, IAssemblySymbol referenceAssembly)
            => GetVisibility(type) switch
            {
                SymbolVisibility.Public => true,
                SymbolVisibility.Internal => referenceAssembly.GivesAccessTo(Compilation.Assembly),
                _ => false
            };

        private static SymbolVisibility GetVisibility(ISymbol symbol)
        {
            SymbolVisibility visibility = SymbolVisibility.Public;

            switch (symbol.Kind)
            {
                case SymbolKind.Alias:
                case SymbolKind.TypeParameter:
                    return SymbolVisibility.Private;
                case SymbolKind.Parameter:
                    return GetVisibility(symbol.ContainingSymbol);
            }

            while (symbol != null && symbol.Kind != SymbolKind.Namespace)
            {
                switch (symbol.DeclaredAccessibility)
                {
                    case Accessibility.NotApplicable:
                    case Accessibility.Private:
                        return SymbolVisibility.Private;
                    case Accessibility.Internal:
                    case Accessibility.ProtectedOrInternal:
                        visibility = SymbolVisibility.Internal;
                        break;
                }

                symbol = symbol.ContainingSymbol;
            }

            return visibility;
        }

        private enum SymbolVisibility
        {
            Public = 0,
            Internal = 1,
            Private = 2,
            Friend = Internal
        }
    }
}
