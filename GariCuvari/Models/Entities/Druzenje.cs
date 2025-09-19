using System.ComponentModel.DataAnnotations;

namespace GariCuvari.Models.Entities
{
    public class Druzenje

    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        [Range(typeof(DateTime), "1/1/2025", "12/31/2100")]
        public DateTime Date { get; set; }
        public string Location { get; set; }

        public List<Gari> Garis { get; set; } = new();
    }
}
