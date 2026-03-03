namespace VPN_MAUI.Model;
using Npgsql;

public class PostgresLogin
{
    public static async Task<bool> Login(string meno, string heslo)
    {
        var connectionString = 
            "Host=serverIP;"+
            "Port=5432;"+
            "Database=postgres;"+
            "Username=postgres;"+
            "Password=password;"+
            "SSL Mode=Require;"+
            "Trust Server Certificate=true";
        await using var connection = NpgsqlDataSource.Create(connectionString);

        await using var cmd = connection.CreateCommand("SELECT heslo FROM halovpn_database WHERE meno=@meno");
        cmd.Parameters.AddWithValue("meno", meno);
        
        await using var reader = await cmd.ExecuteReaderAsync();
        if (!await reader.ReadAsync())
            return false;
        
        var dbHash = reader.GetString(0);

        HashLogIn hash = new HashLogIn();
        return await hash.Hash(dbHash, heslo);
        
    }
}
