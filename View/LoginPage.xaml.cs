using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VPN_MAUI.View;

public partial class LoginPage : ContentPage
{
    public LoginPage()
    {
        InitializeComponent();
    }

    private void BtnLogin_OnClicked(object? sender, EventArgs e)
    {
        throw new NotImplementedException();
    }

    private void BtnNoLogin_OnClicked(object? sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//" + nameof(StartPage));
        
    }
}