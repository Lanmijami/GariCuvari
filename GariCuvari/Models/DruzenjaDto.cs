namespace GariCuvari.Models
{
    public class DruzenjaDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public string? Location { get; set; }
        public List<GariDto> Garis { get; set; } = new();
    }
}
