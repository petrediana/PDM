using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppCursValutar
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ConvertorPage : ContentPage
    {
        List<Curs> listaCurs = new List<Curs>();
        List<string> listaValute = new List<string>();
        Dictionary<string, Curs> dictionarCurs = new Dictionary<string, Curs>();

        public ConvertorPage(List<Curs> listaCurs)
        {
            InitializeComponent();
            this.listaCurs = listaCurs;
            this.listaCurs.Add(new Curs { Valuta = "RON", Valoare = 1 });

            listaValute = listaCurs.Select(curs => curs.Valuta).ToList();
            dictionarCurs = listaCurs.ToDictionary(curs => curs.Valuta, curs => curs);
            
            pickerSursa.ItemsSource = listaValute;
            pickerDestinatie.ItemsSource = listaValute;

            pickerSursa.SelectedIndex = 0;
            pickerDestinatie.SelectedIndex = 0;
        }

        private void ConvertesteBtn_Clicked(object sender, EventArgs e)
        {
            /*
            1. obtinere valoare de convertit
            2. obtinere obiect de tip Curs asociat valutei selectate
            3. efectuarea conversiei
            4. afisarea rezultatului
            */

            double.TryParse(entryValoare.Text, out double valoare);

            Curs cursSursa, cursDestinatie;

            cursSursa = dictionarCurs[(string)pickerSursa.SelectedItem];
            cursDestinatie = dictionarCurs[(string)pickerDestinatie.SelectedItem];


            double rezultat = (valoare * cursSursa.Valoare * cursDestinatie.Multiplicator)
                            / (cursDestinatie.Valoare * cursSursa.Multiplicator);
            entryDestinatie.Text = rezultat.ToString();
        }
    }
}