using System.Security.Cryptography;
using System.Text;

namespace VPN_MAUI.Model;
using Isopoh.Cryptography.Argon2;

public class HashSignIn
{
    public Task<string> Hash(string heslo)
    {
        return Task.Run(() =>
        {
            var config = new Argon2Config
            {
                Password = Encoding.UTF8.GetBytes(heslo),
                Type = Argon2Type.HybridAddressing,
                Version = Argon2Version.Nineteen,
                TimeCost = 4,
                MemoryCost = 1024 * 64, 
                Lanes = 4,
                Threads = Environment.ProcessorCount,
                Salt = GenerateSalt(),
                HashLength = 32
            };

            return Argon2.Hash(config);
        });
        
    }
    private static byte[] GenerateSalt()
    {
        var salt = new byte[16];     
        RandomNumberGenerator.Fill(salt); 
        return salt;
    }
}