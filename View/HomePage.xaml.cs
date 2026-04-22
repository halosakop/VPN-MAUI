using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace VPN_MAUI.View;

public partial class HomePage : ContentPage
{
    private Process? _vpnProcess;

    public HomePage()
    {
        InitializeComponent();
    }

    private async void Btn_spustitVPN_OnClicked(object? sender, EventArgs e)
    {
        await StartVpnAsync();
    }

    private async void Btn_spet_OnClicked(object? sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//" + nameof(StartPage));
    }

    private async void BtnZastavitVpn_OnClicked(object? sender, EventArgs e)
    {
        await StopVpnAsync();
    }

    private async Task StartVpnAsync()
    {
        try
        {

            string goFolder = "/Users/kristofharant/GolandProjects/haloVPN";
            string binaryName = "myvpn";
            string fullCommand = $"cd \"{goFolder}\" && ./{binaryName}";

            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                FileName = "/usr/bin/osascript",
                Arguments = $"-e \"do shell script \\\"{fullCommand}\\\" with administrator privileges\"",
                UseShellExecute = false,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                CreateNoWindow = true
            };

            _vpnProcess = new Process { StartInfo = startInfo };
            _vpnProcess.Start();

            string output = await _vpnProcess.StandardOutput.ReadToEndAsync();
            string error = await _vpnProcess.StandardError.ReadToEndAsync();
            await _vpnProcess.WaitForExitAsync();

            if (_vpnProcess.ExitCode != 0)
            {
                await DisplayAlert("Chyba", $"Nepodarilo sa spustit VPN:\n\n{error}\n\nOutput:\n{output}", "OK");
            }
            else
            {
                await DisplayAlert("Spustenie VPN", "VPN sa podarilo spustiť !\n\n" + output, "OK");
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("bez", ex.Message, "OK");
        }
    }

    private async Task StopVpnAsync()
    {
        try
        {
            if (_vpnProcess == null || _vpnProcess.HasExited)
            {
                await DisplayAlert("Info", "VPN neni spustená.", "OK");
                return;
            }

            _vpnProcess.Kill();
            await _vpnProcess.WaitForExitAsync();

            await DisplayAlert("Pozastavenie VPN", "VPN bola pozastavená.", "OK");
            _vpnProcess = null;
        }
        catch (Exception ex)
        {
            await DisplayAlert("Chyba", $"Chyba: {ex.Message}", "OK");
        }
    }

    private string EscapeForShell(string path)
    {
        return path.Replace("\"", "\\\"").Replace(" ", "\\ ");
    }

    private void PointerGestureRecognizer_OnPointerEntered(object? sender, PointerEventArgs e)
    {
        BtnSpustitVpn.TextColor = Colors.Black;
    }

    private void PointerGestureRecognizer_OnPointerExited(object? sender, PointerEventArgs e)
    {
        BtnSpustitVpn.TextColor = Colors.White;
    }

    private void PointerGestureRecognizer2_OnPointerEntered(object? sender, PointerEventArgs e)
    {
        BtnZastavitVpn.TextColor = Colors.Black;
    }

    private void PointerGestureRecognizer2_OnPointerExited(object? sender, PointerEventArgs e)
    {
        BtnZastavitVpn.TextColor = Colors.White;
    }

    private void PointerGestureRecognizer3_OnPointerEntered(object? sender, PointerEventArgs e)
    {
        BtnSpet.TextColor = Colors.Black;
    }

    private void PointerGestureRecognizer3_OnPointerExited(object? sender, PointerEventArgs e)
    {
        BtnSpet.TextColor = Colors.White;
    }
}