namespace GariCuvari.Models
{
    public class UpdateGariDto
    {
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string? Description { get; set; }
        public int Closeness { get; set; }
        public int Priority { get; set; }
    }
}
