namespace VPN_MAUI.Model;
using Npgsql;

public class PostgresUpload
{
   public static async Task<bool> Upload(string meno,string heslo)
   {
        var connectionString =
            "Host=91.99.203.50;" +
            "Port=5432;" +
            "Database=postgres;" +
            "Username=postgres;" +
            "Password=halovpn;" +
            "SSL Mode=Require;" +
            "Trust Server Certificate=true";

        await using var connection = NpgsqlDataSource.Create(connectionString);
         
        await using (var cmd = connection.CreateCommand("INSERT INTO halovpn_database (meno,heslo,datum_prihlasenia) VALUES (@meno, @heslo,@datum)"))
        { 
          cmd.Parameters.AddWithValue("meno", meno);
          cmd.Parameters.AddWithValue("heslo", heslo);
          cmd.Parameters.AddWithValue("datum", DateTime.Now);
          
          await cmd.ExecuteNonQueryAsync();
        }

        return true;
    }
}