namespace VPN_MAUI.Model;
using Isopoh.Cryptography.Argon2;

public class HashSignIn
{
    public static Task<string> Hash(string heslo)
    {
        return Task.Run(() =>
        {
            var config = new Argon2Config
            {
                Type = Argon2Type.DataDependentAddressing,
                Version = Argon2Version.Nineteen,
                TimeCost = 4,
                MemoryCost = 1024 * 64, // 64 MB
                Lanes = 4,
                Threads = Environment.ProcessorCount,
                Salt = GenerateSalt(16),
                HashLength = 32
            };

            using var argon2A = new Argon2(config);
            return argon2A.Hash(heslo);
        });
        
    }
}