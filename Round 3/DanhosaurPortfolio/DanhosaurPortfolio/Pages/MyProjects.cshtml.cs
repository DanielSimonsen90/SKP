using DanhosaurPortfolio.Classes;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;

namespace DanhosaurPortfolio.Pages
{
    public class MyProjectsModel : PageModel
    {
        public Me Me = new Me();

        public string Language { get; set; }

        public string[] GetLanguages()
        {
            var temp = new List<string> { "Alle" };
            foreach (Project p in Me.Projects)
            {
                if (p.Language == "C#" && temp.Contains("CSharp")) continue;
                if (!temp.Contains(p.Language))
                    temp.Add(p.Language == "C#" ? "CSharp" : p.Language);
            }
            temp.Sort((a, b) => a.CompareTo(b));
            return temp.ToArray();
        }
        public Project[] DisplayProjects;


        public MyProjectsModel()
        {
            DisplayProjects = Me.Projects.Clone() as Project[];
        }

        public void OnGet(string projectLanguage = "Alle")
        {
            Language = projectLanguage;
            DisplayProjects = Me.GetProjectsByLanguage(projectLanguage).ToArray();
        }
    }
}
