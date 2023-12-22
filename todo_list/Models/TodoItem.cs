using SQLite;

namespace Project5.Models
{
    public class TodoItem
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Task { get; set; }
        public string Details { get; set; }
        public bool Done { get; set; }
    }
}

