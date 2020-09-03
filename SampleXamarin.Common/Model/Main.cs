using SQLite;

namespace Zoo.Models
{
    public partial class Main
    {
        [PrimaryKey, Unique]
        public string Ancora { get; set; }
        public int? Idindivid { get; set; }
        public int? Idzoo { get; set; }
    }
}
