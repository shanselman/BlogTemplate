using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BlogTemplate.Models;

namespace BlogTemplate.Pages
{
    public class UserModel : PageModel
    {
        public Owner Owner { get; set; }
        public void OnGet()
        {
            
        }
    }
}