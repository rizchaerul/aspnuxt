using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    public class BoardUpdate
    {
        [Required]
        public int ColumnId { get; set; }

        [Required]
        public int OldColumnId { get; set; }

        [Required]
        public int TaskId { get; set; }
    }
}
