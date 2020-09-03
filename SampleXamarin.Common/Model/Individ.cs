using SQLite;

namespace Zoo.Models
{
    public partial class Individ
    {
        [PrimaryKey, Unique]
        public int Id { get; set; }
        public int? Idanimal { get; set; }
        public string Nume { get; set; }
        public string Bio { get; set; }
    }
}
