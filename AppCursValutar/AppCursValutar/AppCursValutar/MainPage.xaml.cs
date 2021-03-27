using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppCursValutar
{
    public partial class MainPage : ContentPage
    {
        List<Curs> listaCurs;
        public MainPage()
        {
            InitializeComponent();
            
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            // data de referinta
            // Data curenta: L-V ora 13:00 +
            // Ziua anterioara M-S, ora 00-13:00
            // Vineri: D (toata ziua), L (ora 00-13:00)

            // TODO: o metoda care returneaza data de referinta
            // 

            DaoCurs daoCurs = new DaoCurs();
            listaCurs = daoCurs.ObtineCursDinData(DateTime.Now.ToString("yyyy-MM-dd"));

            //if (listaCurs.Count == 0)
            await Task.Run(async () =>
            {
                listaCurs = await Net.PreiaCurs(Net.URL_ADRESA10);
                //listaCurs = await Net.PreiaCurs(Net.URL_ADRESA);
                daoCurs.AdaugaListaCurs(listaCurs);
            });

            listViewCurs.ItemsSource = listaCurs;
            BindingContext = listaCurs[0];
        }


        private void Convertor_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ConvertorPage(listaCurs));
        }

        private void Istoric_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new IstoricPage());
        }

        private void Setari_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new SetariPage());
        }

        private void Despre_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new DesprePage());
        }


    }
}
