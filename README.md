# This is GUI for HaloVPN

## HaloVPN is a VPN server that hides your IP and encrypts your communication [HaloVPN](https://github.com/halosakop/haloVPNv1) this repository is a GUI for it build in .net MAUI.

This GUI also includes a login system that uses postgresql.

# Settings
For working login system you need to configure your database credentials for PostgresUpload.cs and PostgresLogin.cs
```
        var connectionString =
            "Host=database IP adress;" +
            "Port=5432;" +
            "Database=postgres;" +
            "Username=postgres;" +
            "Password=password;" +
            "SSL Mode=Require;" +
            "Trust Server Certificate=true";
```
In file HomePage.xamal.cs chang the file path to client.go
```
string goFolder = "/Users/path/to/client.go;
```
