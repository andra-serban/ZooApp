using SQLite;
using System;

namespace Zoo.Models
{
    public partial class MainHistory
    {
        [PrimaryKey, Unique]
        public string Anchor { get; set; }
        public int? Idindivid { get; set; }
        public int? IdZoo { get; set; }
        public DateTime? Data { get; set; }
    }
}
