using VPN_MAUI.View;

namespace VPN_MAUI;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
		
		Routing.RegisterRoute(nameof(StartPage), typeof(StartPage));
		Routing.RegisterRoute(nameof(SignInPage), typeof(SignInPage));
		Routing.RegisterRoute(nameof(LoginPage), typeof(LoginPage));
		Routing.RegisterRoute(nameof(HomePage), typeof(HomePage));
	}
}
