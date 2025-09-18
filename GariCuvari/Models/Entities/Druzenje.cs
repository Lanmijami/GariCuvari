namespace GariCuvari.Models.Entities
{
    public class Druzenje

    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public string Location { get; set; }

        public List<Gari> Garis { get; set; } = new();
    }
}
