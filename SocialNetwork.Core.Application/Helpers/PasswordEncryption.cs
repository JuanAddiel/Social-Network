using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace SocialNetwork.Core.Application.Helpers
{
    public class PasswordEncryption
    {
        public static string Encrypt(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                byte[] ps = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new();
                for (int i = 0; i < ps.Length; i++)
                {
                    builder.Append(ps[i].ToString("x2"));

                }
                return builder.ToString();
            }
        }

    }
}
