using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogTemplate.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BlogTemplate.Pages
{
    public class UserRegistrationModel : PageModel
    {
        public Owner Owner { get; set; }
        public void OnGet()
        {
        }

        public IActionResult OnRegistrationSubmit()
        {

        }
    }
}