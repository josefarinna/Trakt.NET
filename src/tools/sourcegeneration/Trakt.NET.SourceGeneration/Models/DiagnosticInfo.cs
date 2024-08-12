using Microsoft.CodeAnalysis;
using TraktNET.SourceGeneration.Common;

namespace TraktNET.SourceGeneration.Models
{
    public readonly struct DiagnosticInfo : IEquatable<DiagnosticInfo>
    {
        public DiagnosticDescriptor Descriptor { get; private init; }

        public Location? Location { get; private init; }

        public static DiagnosticInfo Create(DiagnosticDescriptor descriptor, Location? location)
            => new()
            {
                Descriptor = descriptor,
                Location = location
            };

        public Diagnostic CreateDiagnostic() => Diagnostic.Create(Descriptor, Location);

        public override bool Equals(object obj) => obj is DiagnosticInfo diagnosticInfo && Equals(diagnosticInfo);

        public bool Equals(DiagnosticInfo other) => Descriptor.Equals(other.Descriptor) && Location == other.Location;

        public override int GetHashCode()
        {
            int hashCode = Descriptor.GetHashCode();
            return HashHelpers.Combine(hashCode, Location?.GetHashCode() ?? 0);
        }

        public static bool operator ==(DiagnosticInfo left, DiagnosticInfo right) => left.Equals(right);

        public static bool operator !=(DiagnosticInfo left, DiagnosticInfo right) => !(left == right);
    }
}
