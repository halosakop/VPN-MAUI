using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VPN_MAUI.Model;

namespace VPN_MAUI.View;

public partial class LoginPage : ContentPage
{
    public LoginPage()
    {
        InitializeComponent();
    }

    private async void BtnLogin_OnClicked(object? sender, EventArgs e)
    {
        string meno = MenoLogin.Text;
        string heslo = HesloLogin.Text;

        if (await PostgresLogin.Login(meno, heslo))
        {
           await Shell.Current.GoToAsync(nameof(HomePage));
        }
        else
        {
            LabelError.Text = "Zlé meno alebo heslo. Zkúste to znovu.";
            LabelError.IsVisible = true;
        }
    }

    private void BtnNoLogin_OnClicked(object? sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//" + nameof(StartPage));
        
    }
}