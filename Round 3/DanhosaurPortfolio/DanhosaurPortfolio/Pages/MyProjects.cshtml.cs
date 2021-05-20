using DanhosaurPortfolio.Classes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;

namespace DanhosaurPortfolio.Pages
{
    public class MyProjectsModel : PageModel
    {
        public Me Me = new Me();

        public string Language { get; set; }
        public string Type { get; set; }

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
        public string[] GetProjectTypes()
        {
            var temp = new List<string> { "Alle" };
            foreach (Project p in Me.Projects)
            {
                if (!temp.Contains(p.ProjectType))
                    temp.Add(p.ProjectType);
            }
            temp.Sort((a, b) => a.CompareTo(b));
            return temp.ToArray();
        }
        
        public Project[] DisplayProjects;


        public MyProjectsModel()
        {
            DisplayProjects = Me.Projects.Clone() as Project[];
        }

        public void OnGet(string projectType = "Alle", string projectLanguage = "Alle")
        {
            Language = projectLanguage;
            DisplayProjects = DisplayProjects
                .GetProjectsByType(projectType)
                .GetProjectsByLanguage(projectLanguage);
        }
        public string FilterClicked(FilterType type, string filter)
        {
            switch (type)
            {
                case FilterType.Language: Language = filter; break;
                case FilterType.Type: Type = filter; break;
                default: break;
            }

            return $"?projectLanguage={Language}&projectType={Type}";
            
        }
    }

    public enum FilterType { Language, Type }
}
