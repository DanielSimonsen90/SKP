﻿using System;
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
            Language =
                language == Languages.CSharp ? "C#" :
                language == Languages.JavaScript ? "JavaScript" :
                language == Languages.TypeScript ? "TypeScript" :
                language == Languages.VueJS ? "Vue.js" :
                language == Languages.EJS ? "EJS" :
                "Website";

            ProjectType =
                projectType == ProjectTypes.Console ? "Console" :
                projectType == ProjectTypes.WindowsForms ? "Windows Forms" :
                projectType == ProjectTypes.WPF ? "WPF" :
                projectType == ProjectTypes.ASPNet ? "ASP.NET Core" :
                projectType == ProjectTypes.Node ? "Node" :
                projectType == ProjectTypes.Library ? "Library" :
                "Website";

            DateOfCreation = creationDate;
            Description = description;
            Display = display;
            ProjectPath = link;
        }
    }

    public enum Languages { CSharp, JavaScript, Website, TypeScript, VueJS, EJS /*On hover, display "Dette inkluderer HTML, CSS & JavaScript"*/ }
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
