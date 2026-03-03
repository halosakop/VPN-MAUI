using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        Process vpnProcess = new System.Diagnostics.Process();
        vpnProcess.StartInfo.FileName = "/bin/bash";
        vpnProcess.StartInfo.Arguments = "-c \"sudo go run client.go \"";
        vpnProcess.StartInfo.UseShellExecute = false;
        vpnProcess.StartInfo.RedirectStandardOutput = true;
        vpnProcess.Start();
    }

    private void Btn_spet_OnClicked(object? sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//" + nameof(StartPage));
    }
}
