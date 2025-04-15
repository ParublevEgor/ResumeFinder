using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace ResumeFinder.Utils
{
    public class AuthOptions
    {
        public const string ISSUER = "MyAuthServer"; // издатель токена
        public const string AUDIENCE = "MyAuthClient"; // потребитель токена
        const string KEY = "mysupersecret_secretkey!123mysupersecret_secretkey"; // ключ для шифрации
        public const int LIFETIME = 14; // значение в днях
        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));
        }
    }
}
