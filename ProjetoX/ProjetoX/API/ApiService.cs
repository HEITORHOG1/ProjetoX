using Newtonsoft.Json;
using ProjetoX.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ProjetoX.API
{
    public class ApiService : INotifyPropertyChanged
    {

        public const string urlService = "https://projetoxamarin.azurewebsites.net/";

        public event PropertyChangedEventHandler PropertyChanged;

        public static INavigation Navigation { get; set; }
        public static async Task<LoginDto> ValidarLogin(string email, string senha)
        {
            try
            {
                HttpClient _client = new HttpClient();
                string url = urlService + "api/Login/ValidarLogin/" + email + "/" + senha;
                string response = await _client.GetStringAsync(url);

                LoginDto login = JsonConvert.DeserializeObject<LoginDto>(response);

                return login;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static async Task<List<LoginDto>> Get()
        {
            try
            {
                HttpClient _client = new HttpClient();
                string url = urlService + "api/Login";
                string response = await _client.GetStringAsync(url);

                List<LoginDto> login = JsonConvert.DeserializeObject<List<LoginDto>>(response);

                return login;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static async Task<int> Post(LoginDto dto)
        {
            int retorno = 0;
            try
            {
                string url = urlService + "api/Login/InserirLogin/";
                HttpClient client = new HttpClient();
                string jsonData = JsonConvert.SerializeObject(dto);
                StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync(url, content);
                //JsonConvert.DeserializeObject<LoginDto>(response);
                var resposta = response.IsSuccessStatusCode;

                if (resposta == true)
                {
                    retorno = 1;
                }
                return retorno;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static async Task<int> Put(LoginDto dto)
        {
            int retorno = 0;
            try
            {
                string url = urlService + "api/Login/AlterarLogin/";
                HttpClient client = new HttpClient();
                string jsonData = JsonConvert.SerializeObject(dto);
                StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PutAsync(url, content);
                //JsonConvert.DeserializeObject<LoginDto>(response);
                var resposta = response.IsSuccessStatusCode;

                if (resposta == true)
                {
                    retorno = 1;
                }
                return retorno;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static async Task<int> Delete(int id)
        {
            int retorno = 0;
            try
            {
                string url = urlService + "api/Login/DeletarLogin/" + id;
                HttpClient client = new HttpClient();
                HttpResponseMessage response = await client.DeleteAsync(url);
                var resposta = response.IsSuccessStatusCode;

                if (resposta == true)
                {
                    retorno = 1;
                }
                return retorno;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

public class Response
{
    public string Message { get; set; }
    public int Status { get; set; }
}
