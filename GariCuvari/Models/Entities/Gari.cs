namespace GariCuvari.Models.Entities
{
    public class Gari
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string? Description { get; set; }
        public int Closeness { get; set; }
        public int Priority { get; set; }

        public List<Druzenje> Druzenja { get; set; } = new();
    }
}
