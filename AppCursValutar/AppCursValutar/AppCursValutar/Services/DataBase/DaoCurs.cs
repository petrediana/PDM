using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using SQLite;

namespace AppCursValutar
{
    public class DaoCurs
    {
        SQLiteConnection connection;

        private static readonly DaoCurs _instance;
        private DaoCurs()
        {
            string caleBazaDate = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                "curs_valutar.db");
            connection = new SQLiteConnection(caleBazaDate);
            connection.CreateTable<Curs>();
        }

        static DaoCurs()
        {
            _instance = new DaoCurs();
        }

        public static DaoCurs Instance
        {
            get => _instance;
        }

        public int AdaugaCurs(Curs curs) 
            => connection.Insert(curs);

        public int AdaugaListaCurs(List<Curs> listaCurs) 
            => connection.InsertAll(listaCurs);

        public List<Curs> ObtineCursDinData(string data)
            => connection.Query<Curs>("SELECT * FROM Curs WHERE Data = ?", data);

        public List<Curs> ObtineCursValuta(string valuta) 
            => connection.Query<Curs>("SELECT * FROM Curs WHERE Valuta = ?", valuta);
    }
}
