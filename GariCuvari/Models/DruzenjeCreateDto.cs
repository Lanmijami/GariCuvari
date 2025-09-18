namespace GariCuvari.Models
{
    public class DruzenjeCreateDto
    {
        public string Title { get; set; } = string.Empty;
        public DateTime Date { get; set; }
        public string Location { get; set; }
        public List<Guid> GariIds { get; set; } = new();
    }
}
