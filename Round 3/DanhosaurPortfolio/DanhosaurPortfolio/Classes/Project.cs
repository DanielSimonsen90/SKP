using System;
using System.Collections.Generic;
using System.Linq;

namespace DanhosaurPortfolio.Classes
{
    public class Project
    {
        public static string IntetLink = "Intet Link";

        public string Name { get; }
        public string Language { get; }
        public string ProjectType { get; }
        public DateTime DateOfCreation { get; }
        public string[] Description { get; }
        public bool Display { get; }
        public string ImagePath => $"Images/Project Images/{Name}.png";
        public string ProjectPath { get; }

        public Project(string name, Languages language, ProjectTypes projectType, DateTime creationDate, string[] description, string link, bool display = true)
        {
            Name = name;
            Language = GetLanguage(language);
            ProjectType = GetProjectType(projectType);
            DateOfCreation = creationDate;
            Description = description;
            Display = display;
            ProjectPath = link;
        }

        private string GetLanguage(Languages language) => language switch
        {
            Languages.CSharp => "C#",
            Languages.JavaScript => "JavaScript",
            Languages.Website => "Website",
            Languages.TypeScript => "TypeScript",
            Languages.VueJS => "Vue.js",
            Languages.EJS => "EJS",
            Languages.XML => "XML",
            _ => "Unknown Language",
        };
        private string GetProjectType(ProjectTypes projectType) => projectType switch
        {
            ProjectTypes.ASPNet => "ASP.NET Core",
            ProjectTypes.Console => "Console",
            ProjectTypes.Library => "Library",
            ProjectTypes.Node => "Node.js",
            ProjectTypes.Website => "Website",
            ProjectTypes.WindowsForms => "Windows Forms",
            ProjectTypes.WPF => "WPF",
            _ => "Unknown ProjectType"
        };
    }

    public enum Languages { CSharp, JavaScript, Website, TypeScript, VueJS, EJS, XML }
    public enum ProjectTypes { Console, WindowsForms, WPF, ASPNet, Node, Website, Library }

    public static class ProjectExtensions
    {
        public static Project[] GetProjectsByLanguage(this Project[] projects, string language) => (
            from p in projects
            where (language == p.Language || language == "CSharp" && p.Language == "C#" || language == "Alle") && p.Display
            select p
        ).ToArray();

        public static Project[] GetProjectsByType(this Project[] projects, string type) => (
            from p in projects
            where (type == p.ProjectType) && p.Display || type == "Alle"
            select p
        ).ToArray();
    }
}
