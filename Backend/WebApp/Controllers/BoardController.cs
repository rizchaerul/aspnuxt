using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace Namespace
{
    [Route("api/[controller]")]
    [ApiController]
    public class BoardController : ControllerBase
    {
        public static List<BoardColumn> Board = new()
        {
            new BoardColumn
            {
                Id = 1,
                Title = "Backlog",
                Tasks = new List<BoardTask>
                {
                    new BoardTask
                    {
                        Id = 1,
                        Ordering = 0,
                        Title = "Design shopping cart dropdown",
                        Type = "Feature Request",
                        Date = DateTime.UtcNow,
                    },
                        new BoardTask
                    {
                        Id = 2,
                        Ordering = 1,
                        Title = "Add discount page",
                        Type = null,
                        Date = DateTime.UtcNow,
                    },
                        new BoardTask
                    {
                        Id = 3,
                        Ordering = 2,
                        Title = "Test checkout workflow",
                        Type = "QA",
                        Date = DateTime.UtcNow,
                    }
                }
            },
            new BoardColumn
            {
                Id = 2,
                Title = "In Progress",
            },
            new BoardColumn
            {
                Id = 3,
                Title = "Review",
            },
            new BoardColumn
            {
                Id = 4,
                Title = "Done",
            },
        };

        [HttpGet]
        public ActionResult<List<BoardColumn>> GetBoard()
        {
            return Board
                .Select(b => new BoardColumn
                {
                    Id = b.Id,
                    Title = b.Title,
                    Tasks = b.Tasks
                        .OrderBy(t => t.Ordering)
                        .ToList()
                })
                .ToList();
        }

        [HttpPost]
        public ActionResult UpdateBoard([FromBody] BoardUpdate form)
        {
            var task = Board
                .Find(c => c.Id == form.OldColumnId)?
                .Tasks
                .Find(t => t.Id == form.TaskId);

            if (task != null)
            {
                var oldColumn = Board.Find(c => c.Tasks.Contains(task));

                if (oldColumn != null)
                {
                    oldColumn.Tasks.Remove(task);
                }

                var newColumn = Board.Find(c => c.Id == form.ColumnId);

                if (newColumn != null && task != null)
                {
                    newColumn.Tasks.Add(task);
                }
            }

            return Ok();
        }
    }
}
