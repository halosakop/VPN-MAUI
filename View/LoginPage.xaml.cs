using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using VPN_MAUI.Model;
using WebKit;

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
            DisplayAlert("", "Nesprávne prihlasovacie údaje", "OK");
        }
    }

    private void BtnNoLogin_OnClicked(object? sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//" + nameof(StartPage));
        
    }
}