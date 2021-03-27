using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Xml;

namespace AppCursValutar
{
    public class Net
    {
        public const string URL_ADRESA = @"https://bnr.ro/nbrfxrates.xml";
        public const string URL_ADRESA10 = @"https://bnr.ro/nbrfxrates10days.xml";
        public async static Task<List<Curs>> PreiaCurs(string url)
        {
            List<Curs> listaCurs = new List<Curs>();

            HttpClient httpClient = new HttpClient();
            Stream stream = await httpClient.GetStreamAsync(url);

            XmlReader reader = XmlReader.Create(stream);
            string data = string.Empty;
            Curs curs = null;

            while (reader.Read())
            {
                if (reader.IsStartElement())
                {
                    /*if (reader.Name == "PublishingDate")
                    {
                        reader.Read();
                        data = reader.Value;
                    }*/

                    if (reader.Name == "Cube")
                    {
                        data = reader["date"];
                    }

                    if (reader.Name == "Rate")
                    {
                        curs = new Curs();

                        curs.Valuta = reader["currency"];
                        if (reader["multiplier"] != null)
                        {
                            curs.Multiplicator = int.Parse(reader["multiplier"]);
                        }

                        reader.Read();
                        curs.Valoare = double.Parse(reader.Value);
                        curs.Data = data;

                        listaCurs.Add(curs);
                    }
                }
            }

            return listaCurs;
        }
    }
}
