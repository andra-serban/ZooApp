using SQLite;

namespace Zoo.Models
{
    public partial class ZooInfo
    {
        [PrimaryKey, Unique]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Details { get; set; }


    }
}
