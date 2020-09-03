using SQLite;

namespace Zoo.Models
{
    public partial class Animal
    {
        [PrimaryKey, Unique]
        public int Id { get; set; }
        public string NumeComun { get; set; }
        public string Specie { get; set; }
        public int? GreutateMaxima { get; set; }
        public string Poza { get; set; }

    }
}
