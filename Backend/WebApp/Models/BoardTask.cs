namespace WebApp.Models
{
    public class BoardTask
    {
        public int Id { get; set; }

        public int Ordering { get; set; }

        public DateTime Date { get; set; }

        public string? Type { get; set; }

        public string Title { get; set; } = string.Empty;
    }
}
