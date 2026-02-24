using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VPN_MAUI.View;

public partial class HomePage : ContentPage
{
    public HomePage()
    {
        InitializeComponent();
    }

    private void Btn_spustitVPN_OnClicked(object? sender, EventArgs e)
    {
        throw new NotImplementedException();
    }

    private void Btn_spet_OnClicked(object? sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//" + nameof(StartPage));
    }
}