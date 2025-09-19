using System.ComponentModel.DataAnnotations;

namespace GariCuvari.Models.Entities
{
    public class Gari
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string? Description { get; set; }

        [Range(0,10)]
        public int Closeness { get; set; }
        [Range(0,10)]
        public int Priority { get; set; }

        public List<Druzenje> Druzenja { get; set; } = new();
    }
}
