using System.Security.Cryptography;
using System.Text;
using Isopoh.Cryptography.Argon2;

namespace VPN_MAUI.Model;

public class HashLogIn
{
    public Task<bool> Hash(string? hash , string heslo)
    {
        return Task.Run(() =>
        {
            bool valid = Argon2.Verify(hash,heslo );
            return valid;
        });
    }


}
