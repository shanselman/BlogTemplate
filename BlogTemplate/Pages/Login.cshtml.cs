using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using System;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BlogTemplate.Pages
{
    public class UserModel : PageModel
    {
        private IConfiguration _config;

        public UserModel(IConfiguration config) //Dependency Injection!
        {
            _config = config;
        }

        public void OnGet()
        {

        }

        public async Task OnPost(string username, string password)
        {
            if (username == _config["user:username"] && VerifyHashedPassword(password))
            {
                var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
                identity.AddClaim(new Claim(ClaimTypes.Name, _config["user:username"]));

                var principle = new ClaimsPrincipal(identity);
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principle);

                HttpContext.Response.Redirect("/");
            }
        }

        private bool VerifyHashedPassword(string password)
        {
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
            byte[] saltBytes = Encoding.UTF8.GetBytes(_config["user:salt"]);
            byte[] saltedValue = passwordBytes.Concat(saltBytes).ToArray();

            using (var sha = new SHA256Managed())
            {
                byte[] hash = sha.ComputeHash(saltedValue);
                var hashText = BitConverter.ToString(hash).Replace("-", string.Empty);
                return hashText == _config["user:password"];
            }
        }


    }
}