using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Foundation; 

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
                await DisplayAlert("Error", $"Failed to start VPN:\n\n{error}\n\nOutput:\n{output}", "OK");
            }
            else
            {
                await DisplayAlert("Success", "VPN started successfully!\n\n" + output, "OK");
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Exception", ex.Message, "OK");
        }
    }

    private async Task StopVpnAsync()
    {
        try
        {
            if (_vpnProcess == null || _vpnProcess.HasExited)
            {
                await DisplayAlert("Info", "VPN is not running.", "OK");
                return;
            }

            _vpnProcess.Kill();
            await _vpnProcess.WaitForExitAsync();

            await DisplayAlert("Success", "VPN stopped.", "OK");
            _vpnProcess = null;
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", $"Exception: {ex.Message}", "OK");
        }
    }

    private string EscapeForShell(string path)
    {
        return path.Replace("\"", "\\\"").Replace(" ", "\\ ");
    }
}