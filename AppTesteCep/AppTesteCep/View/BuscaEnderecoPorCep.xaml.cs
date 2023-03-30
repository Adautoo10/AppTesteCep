using AppTesteCep.Model;
using AppTesteCep.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppTesteCep.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BuscaEnderecoPorCep : ContentPage
    {
        public BuscaEnderecoPorCep()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            try
            {
                simcarregando();

                Endereco[] arr_end = { await DataService.GetEnderecoByCep(txt_cep.Text) };

                lst_end.ItemsSource = arr_end;

            }
            catch (Exception ex)
            {
               await DisplayAlert("Erro!", ex.Message, "Ok"); 
            }
            finally
            {
                naocarregando();
            }
        }
        public void simcarregando()
        {
            carregando.IsEnabled = true;
            carregando.IsRunning = true;
        }
        public void naocarregando()
        {
            carregando.IsEnabled = false;
            carregando.IsRunning = false;
        }
    }
    
}