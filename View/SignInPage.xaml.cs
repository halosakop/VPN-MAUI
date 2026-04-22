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

    private async void BtnCreate_OnClicked(object? sender, EventArgs e)
    {
        string meno = MenoSignIn.Text;
        
        var hasher = new HashSignIn();
        string heslo = await hasher.Hash(HesloSignIn.Text);
        
        if (await PostgresUpload.Upload(meno, heslo))
        {
            await Shell.Current.GoToAsync(nameof(HomePage));
        }
    }

    private void BtnNoCreate_OnClicked(object? sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//" + nameof(StartPage));
    }

    private void PointerGestureRecognizer_OnPointerEntered(object? sender, PointerEventArgs e)
    {
        BtnSignIn.TextColor = Colors.Black;
    }

    private void PointerGestureRecognizer_OnPointerExited(object? sender, PointerEventArgs e)
    {
        BtnSignIn.TextColor = Colors.White;
    }

    private void PointerGestureRecognizer2_OnPointerEntered(object? sender, PointerEventArgs e)
    {
        BtnNoSignIn.TextColor = Colors.Black;
    }

    private void PointerGestureRecognizer2_OnPointerExited(object? sender, PointerEventArgs e)
    {
        BtnNoSignIn.TextColor = Colors.White;
    }
}