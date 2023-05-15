using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace HelpfulNeighbor.web.Features.Shelters.ShelterType
{
    public class ShelterType
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [NotNull]
        public string Type { get; set; } = string.Empty;
    }
}
