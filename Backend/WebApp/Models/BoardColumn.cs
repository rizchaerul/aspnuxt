namespace WebApp.Models
{
    public class BoardColumn
    {
        public int Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public List<BoardTask> Tasks { get; set; } = new();
    }
}
