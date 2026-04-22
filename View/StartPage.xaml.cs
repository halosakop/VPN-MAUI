using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace VPN_MAUI.View;

public partial class StartPage : ContentPage
{
    public StartPage()
    {
        InitializeComponent();
    }

    private void VytvoritUcetButton_OnClicked(object? sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(SignInPage));
    }

    private void PrihlasenieDoUctuButton_OnClicked(object? sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(LoginPage));
    }

    private void PointerGestureRecognizer_OnPointerEntered(object? sender, PointerEventArgs e)
    {
        PrihlasenieDoUctuButton.TextColor = Colors.Black;
    }

    private void PointerGestureRecognizer_OnPointerExited(object? sender, PointerEventArgs e)
    {
        PrihlasenieDoUctuButton.TextColor = Colors.White;
    }

    private void PointerGestureRecognizer2_OnPointerEntered(object? sender, PointerEventArgs e)
    {
        VytvoritUcetButton.TextColor = Colors.Black;
    }

    private void PointerGestureRecognizer2_OnPointerExited(object? sender, PointerEventArgs e)
    {
        VytvoritUcetButton.TextColor = Colors.White;
    }

    private async void Button_ViacInfo_OnClicked(object? sender, EventArgs e)
    {
        Uri uri = new Uri("https://halovpn.app");
        await Browser.Default.OpenAsync(uri, BrowserLaunchMode.SystemPreferred);
    }

    private void PointerGestureRecognizer3_OnPointerEntered(object? sender, PointerEventArgs e)
    {
        ViacInfoButton.BackgroundColor = Color.FromArgb("#00e5ff");
    }

    private void PointerGestureRecognizer3_OnPointerExited(object? sender, PointerEventArgs e)
    {
        ViacInfoButton.BackgroundColor = Colors.Grey;
    }
}
