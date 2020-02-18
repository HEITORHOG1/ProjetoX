using ProjetoX.API;
using ProjetoX.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProjetoX
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private void btnLogar_Clicked(object sender, EventArgs e)
        {
            Logar(txtLogin.Text,txtSenha.Text);
        }

        public async void Logar(string email, string senha)
        {
            var dto = new LoginDto();
            try
            {
                dto = await ApiService.ValidarLogin(email, senha);
                if (dto.id != 0)
                {
                    await Navigation.PushAsync(new MainPage());
                }
                else
                {
                    await DisplayAlert("Erro", "Não Foi Possivel Logar", "OK");
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Erro", ex.Message, "OK");
            }
        }
    }
}