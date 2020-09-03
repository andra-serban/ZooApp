﻿using SQLite;
using System;

namespace Zoo.Models
{
    public partial class MainIstoric
    {
        [PrimaryKey, Unique]
        public int Id { get; set; }
        public string Ancora { get; set; }
        public int? Idindivid { get; set; }
        public int? Idzoo { get; set; }
        public DateTime? Data { get; set; }
    }
}
