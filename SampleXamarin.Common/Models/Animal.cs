using SQLite;

namespace Zoo.Models
{
    public partial class Animal
    {
        [PrimaryKey, Unique]
        public int Id { get; set; }
        public string CommonName { get; set; }
        public string Specie { get; set; }
        public int MaxWeight { get; set; }
        public string Image { get; set; }
    }
}