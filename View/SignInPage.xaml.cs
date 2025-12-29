using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VPN_MAUI.Model;
namespace VPN_MAUI.View;

public partial class SignInPage : ContentPage
{
    public SignInPage()
    {
        InitializeComponent();
    }

    private void BtnCreate_OnClicked(object? sender, EventArgs e)
    {
        PostgresUpload upload = new PostgresUpload();

        string meno = MenoSignIn.Text;
        string heslo = HesloSignIn.Text;

        if (upload != null)
        {
            upload(meno, heslo);
        }
    }

    private void BtnNoCreate_OnClicked(object? sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//" + nameof(StartPage));
    }
}