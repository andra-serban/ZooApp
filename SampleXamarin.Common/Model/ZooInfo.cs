using SQLite;

namespace Zoo.Models
{
    public partial class ZooInfo
    {
        [PrimaryKey, Unique]
        public int Id { get; set; }
        public string Nume { get; set; }
        public string Detalii { get; set; }
    }
}
