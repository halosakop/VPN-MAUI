namespace VPN_MAUI.Model;
using Npgsql;

public class PostgresLogin
{
    public static async Task<bool> Login(string meno, string heslo)
    {
        bool valid;

        var connectionString = 
            "Host=91.99.203.50;"+
            "Port=5432;"+
            "Database=postgres;"+
            "Username=postgres;"+
            "Password=halovpn;"+
            "SSL Mode=Require;"+
            "Trust Server Certificate=true";
        
        await using var connection = NpgsqlDataSource.Create(connectionString);

        await using (var cmd = connection.CreateCommand("SELECT EXISTS(select * from halovpn_database where meno=@meno and heslo=@heslo)"))
        {
            cmd.Parameters.AddWithValue("meno", meno);
            cmd.Parameters.AddWithValue("heslo", heslo);
            
            valid = (bool)await cmd.ExecuteScalarAsync();
        }
        
        return valid;
    }
}