using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ProjetoX.View
{
    public class LoginViewCell : ViewCell
    {
        public LoginViewCell()
        {
            try
            {
                var ID = new Label
                {
                    HorizontalTextAlignment = TextAlignment.End,
                    HorizontalOptions = LayoutOptions.Start,
                    FontSize = 16,
                    FontAttributes = FontAttributes.Bold,
                };
                ID.SetBinding(Label.TextProperty, new Binding("id"));

                var Nome = new Label
                {
                    FontSize = 24,
                    FontAttributes = FontAttributes.Bold,
                    HorizontalOptions = LayoutOptions.Start,
                    Margin = 5
                };
                Nome.SetBinding(Label.TextProperty, new Binding("nome"));

                var Email = new Label
                {
                    FontSize = 16,
                    FontAttributes = FontAttributes.None,
                    HorizontalOptions = LayoutOptions.Start,
                    VerticalOptions = LayoutOptions.Start
                    // Margin = 5
                };
                Email.SetBinding(Label.TextProperty, new Binding("email"));

                var Senha = new Label
                {
                    FontSize = 16,
                    FontAttributes = FontAttributes.None,
                    HorizontalOptions = LayoutOptions.Start,
                    VerticalOptions = LayoutOptions.Start
                    // Margin = 5
                };
                Senha.SetBinding(Label.TextProperty, new Binding("senha"));

                var line1 = new StackLayout
                {
                    Orientation = StackOrientation.Horizontal,
                    Children = {
                     Nome
                },
                };
                var line2 = new StackLayout
                {
                    Orientation = StackOrientation.Horizontal,
                    Children = {
                     Email
                },
                };
                var line3 = new StackLayout
                {
                    Orientation = StackOrientation.Horizontal,
                    Children = {
                    Senha
                },
                };


                View = new StackLayout
                {
                    Orientation = StackOrientation.Vertical,
                    Children = {
                    line1,line2,line3
                },
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
