using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.DataProtection;
using System.Security.Cryptography.Xml;

namespace GeldCSharp.Controllers
{
    [ApiController]
    public class AuthController : Controller
    {

        [HttpPost("signin-microsoft")]
        public IActionResult SigninGoogle()
        {
            var props = new AuthenticationProperties();
            props.RedirectUri = "/";
            return Challenge(props);
        }
    }
}
