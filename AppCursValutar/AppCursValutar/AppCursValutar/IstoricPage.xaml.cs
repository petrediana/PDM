using AppCursValutar.Services.Date;
using Microcharts;
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
    public partial class IstoricPage : ContentPage
    {
        private readonly DateTimeProvider _dateTimeProvider;
        public IstoricPage(List<Curs> listaCurs)
        {
            InitializeComponent();
            _dateTimeProvider = new DateTimeProvider();


            pickerValute.ItemsSource = listaCurs.Select(curs => curs.Valuta).ToList();
            pickerValute.SelectedItem = "EUR";

            pickerValute.SelectedIndexChanged += PickerValute_SelectedIndexChanged;
        }

        private void PickerValute_SelectedIndexChanged(object sender, EventArgs e)
        {
            Console.WriteLine($"Index Changed: {pickerValute.SelectedItem}");
            ChangeGraphCurrency(pickerValute.SelectedItem.ToString());
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            ChangeGraphCurrency("EUR");
        }

        private void ChangeGraphCurrency(string valuta)
        {
            List<Curs> listaCurs = DaoCurs.Instance.ObtineCursValuta(valuta.ToUpper());
            List<ChartEntry> dateGrafic = listaCurs.Select(curs => CreateChartEntry(curs)).ToList();


            chartViewCurs.Chart = new LineChart
            {
                Entries = dateGrafic
            };
        }

        private ChartEntry CreateChartEntry(Curs curs)
        {
            return new ChartEntry((float)curs.Valoare)
            {
                Label = curs.Data,
                ValueLabel = curs.Valoare.ToString()
            };
        }
    }
}