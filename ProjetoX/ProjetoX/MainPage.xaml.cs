using ProjetoX.API;
using ProjetoX.Model;
using ProjetoX.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ProjetoX
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        List<LoginDto> RetornoLogin;
        LoginDto loginDto = new LoginDto();
        public MainPage()
        {
            InitializeComponent();
            RetornoLogin = new List<LoginDto>();
            ListaLogin.ItemTemplate = new DataTemplate(typeof(LoginViewCell));
            ListaLogin.RowHeight = 120;
            ListaLogin.ItemSelected += ListaLogin_ItemSelected;
        }

        public async void CarregarLogin()
        {
            RetornoLogin = await ApiService.Get();
            ListaLogin.ItemsSource = RetornoLogin.ToList().OrderBy(x => x.nome);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            CarregarLogin();
        }
        private void ListaLogin_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = (LoginDto)e.SelectedItem;
          
            loginDto.email = item.email;
            loginDto.nome = item.nome;
            loginDto.senha = item.senha;
            loginDto.id = item.id;

            Navigation.PushAsync(new CadastroLoginPage(loginDto));
        }

        private void Pesquisar_TextChanged(object sender, TextChangedEventArgs e)
        {
            string nomePesquisa = txtPesquisar.Text;
            ListaLogin.ItemsSource = RetornoLogin.Where(x => x.nome.ToLower().Contains(nomePesquisa.ToLower()));
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            loginDto = null;
            Navigation.PushAsync(new CadastroLoginPage(loginDto));
        }

        private void btnAtualiza_Clicked(object sender, EventArgs e)
        {
            CarregarLogin();
        }
    }
}
