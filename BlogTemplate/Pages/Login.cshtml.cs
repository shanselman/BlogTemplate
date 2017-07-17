using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BlogTemplate.Pages
{
    public class LoginModel : PageModel
    {
        public string NewMessage { get; set; }
        public void OnGet()
        {
            NewMessage = "here is what you want to put on the page.";
        }
    }
}