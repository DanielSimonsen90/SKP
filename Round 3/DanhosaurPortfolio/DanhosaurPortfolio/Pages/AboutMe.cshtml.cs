using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DanhosaurPortfolio.Classes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DanhosaurPortfolio.Pages
{
    public class AboutMeModel : PageModel
    {
        public Me Me = new Me();
        public void OnGet()
        {
        }
    }
}
