using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DanhosaurPortfolio.Classes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace DanhosaurPortfolio.Pages
{
    public class IndexModel : PageModel
    {
        public readonly Me Me = new Me();
        private readonly ILogger<IndexModel> _logger;
        public string[] IntroductionSentences => new string[]
        {
            "Velkommen til min hjemmeside.",
            "Brug min menubar i toppen, og udforsk siden.",
            "På forhånd, tak for besøget!",
            $"- {Me.Name}"
        };

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }
    }
}
