using SQLite;

namespace Crud.Models
{
    [Table("Tasks")]
    public class TaskModel
    {
        [PrimaryKey]
        [AutoIncrement]
        public int TaskID { get; set; }

        [MaxLength(50)]
        public string Title { get; set; }

        [MaxLength(255)]
        public string Description { get; set; }

        public bool IsCompleted { get; set; }
    }
}
