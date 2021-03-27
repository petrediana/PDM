using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppCursValutar
{
    public class Curs
    {
        public Curs()
        {
            Multiplicator = 1;
        }
        //[Column("id")]
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public int Multiplicator { get; set; }
        public string Valuta { get; set; }
        public double Valoare { get; set; }
        public string Data { get; set; }

        // eu.png, us.png...
        [Ignore]
        public string Drapel
        {
            get => Valuta.Substring(0, 2).ToLower() + ".png";
        }
    }
}
