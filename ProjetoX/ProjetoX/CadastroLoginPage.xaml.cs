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
    public partial class CadastroLoginPage : ContentPage
    {
        public CadastroLoginPage(LoginDto _LoginDto)
        {
            InitializeComponent();
            try
            {
                if (!_LoginDto.Equals("null"))
                {
                    txtEmail.Text = _LoginDto.email;
                    txtNome.Text = _LoginDto.nome;
                    txtSenha.Text = _LoginDto.senha;
                    lblId.Text = _LoginDto.id.ToString();
                    btnInserir.Text = "Atualizar Login";
                }
            }
            catch
            {
                btnInserir.Text = "Inserir Login";
            }

        }

        private void btnInserir_Clicked(object sender, EventArgs e)
        {
            InserirAsync();
        }

        public async Task InserirAsync()
        {
            if (btnInserir.Text == "Inserir Login")
            {
                LoginDto dto = new LoginDto();
                dto.email = txtEmail.Text;
                dto.nome =  txtNome.Text;
                dto.senha = txtSenha.Text;

                int retorno = await ApiService.Post(dto);

                if (retorno == 1)
                {
                    LinparCampos();
                    await DisplayAlert("Inserção", "Inserido com Sucesso", "OK");
                }
                else
                {
                    await DisplayAlert("Erro", "Erro ao Inserir", "OK");
                }
            }
            else if (btnInserir.Text == "Atualizar Login")
            {
                LoginDto dto = new LoginDto();
                dto.email = txtEmail.Text;
                dto.nome = txtNome.Text;
                dto.senha = txtSenha.Text;
                dto.id = Convert.ToInt32(lblId.Text);

                int retorno = await ApiService.Put(dto);

                if (retorno == 1)
                {
                    LinparCampos();
                   
                    await DisplayAlert("Alteração", "Alterado com Sucesso", "OK");

                    await Navigation.PushAsync(new MainPage());
                }
                else
                {
                    await DisplayAlert("Erro", "Erro ao Inserir", "OK");
                }
            }
        }
        public void LinparCampos()
        {
            txtEmail.Text = "";
            txtNome.Text = "";
            txtSenha.Text = "";
        }

        private void btnDeletar_Clicked(object sender, EventArgs e)
        {
            DeletarAsync();
        }

        public async Task DeletarAsync()
        {
            int id = Convert.ToInt32(lblId.Text);

            int retorno = await ApiService.Delete(id);

            if (retorno == 1)
            {
                LinparCampos();

                await DisplayAlert("Delete", "Deletado com Sucesso", "OK");

                await Navigation.PushAsync(new MainPage());
            }
            else
            {
                await DisplayAlert("Erro", "Erro ao Inserir", "OK");
            }
        }
    }
}