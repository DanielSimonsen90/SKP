#pragma checksum "C:\Users\Daniel Simonsen\Documents\GitHub\SKP\Round 3\DanhosaurPortfolio\DanhosaurPortfolio\Pages\AboutMe.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "78b15f024d73fa9e0d0ee737423594965a4953cc"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(DanhosaurPortfolio.Pages.Pages_AboutMe), @"mvc.1.0.razor-page", @"/Pages/AboutMe.cshtml")]
namespace DanhosaurPortfolio.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\Daniel Simonsen\Documents\GitHub\SKP\Round 3\DanhosaurPortfolio\DanhosaurPortfolio\Pages\_ViewImports.cshtml"
using DanhosaurPortfolio;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"78b15f024d73fa9e0d0ee737423594965a4953cc", @"/Pages/AboutMe.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"456452e36760a2577ad111cb44a1bd35c7600db5", @"/Pages/_ViewImports.cshtml")]
    public class Pages_AboutMe : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "C:\Users\Daniel Simonsen\Documents\GitHub\SKP\Round 3\DanhosaurPortfolio\DanhosaurPortfolio\Pages\AboutMe.cshtml"
  
    ViewData["Title"] = "Om mig";
    ViewData["Description"] = "Hvem er jeg??";


#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div name=\"aboutMe\" class=\"mainContainer\">\r\n    <h1 class=\"text-center startPage\">Daniel Simonsen</h1>\r\n    <div name=\"whoAmI\" class=\"mainContent\">\r\n        <h3>Hvem er jeg?</h3>\r\n        <p>Mit navn er ");
#nullable restore
#line 13 "C:\Users\Daniel Simonsen\Documents\GitHub\SKP\Round 3\DanhosaurPortfolio\DanhosaurPortfolio\Pages\AboutMe.cshtml"
                  Write(Model.Me.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral(" og jeg er en ");
#nullable restore
#line 13 "C:\Users\Daniel Simonsen\Documents\GitHub\SKP\Round 3\DanhosaurPortfolio\DanhosaurPortfolio\Pages\AboutMe.cshtml"
                                              Write(Model.Me.Age.ToString());

#line default
#line hidden
#nullable disable
            WriteLiteral(" årig dreng, som tager uddannelsen som datatekniker med speciale i programmering på TECHCOLLEGE.</p>\r\n        <p>Jeg har ");
#nullable restore
#line 14 "C:\Users\Daniel Simonsen\Documents\GitHub\SKP\Round 3\DanhosaurPortfolio\DanhosaurPortfolio\Pages\AboutMe.cshtml"
              Write(Model.Me.CodingFor.ToString());

#line default
#line hidden
#nullable disable
            WriteLiteral(@" års erfaring med programmering og programmerer både i skole- og fritiden.</p>
        <p>Jeg interesserer mig meget for OOP og er ret stærk til det. Jeg synes, det er sjovt at lege med klassehierakier, og især hvis der kommer noget tilfældighed ind over det.</p>
        <br />
        <h6>");
#nullable restore
#line 17 "C:\Users\Daniel Simonsen\Documents\GitHub\SKP\Round 3\DanhosaurPortfolio\DanhosaurPortfolio\Pages\AboutMe.cshtml"
       Write(Model.Me.Occupation);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h6>\r\n    </div>\r\n    <div name=\"Other\" class=\"mainContent\">\r\n        <div class=\"spareTime\">\r\n            <h3>Fritid</h3>\r\n            <div name=\"spareTimeContent\">\r\n");
#nullable restore
#line 23 "C:\Users\Daniel Simonsen\Documents\GitHub\SKP\Round 3\DanhosaurPortfolio\DanhosaurPortfolio\Pages\AboutMe.cshtml"
                 for (int i = 0; i < Model.Me.SpareTime.Length; i++)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <div class=\"spareTimeItem\"");
            BeginWriteAttribute("id", " id=\"", 1170, "\"", 1183, 1);
#nullable restore
#line 25 "C:\Users\Daniel Simonsen\Documents\GitHub\SKP\Round 3\DanhosaurPortfolio\DanhosaurPortfolio\Pages\AboutMe.cshtml"
WriteAttributeValue("", 1175, i + 1, 1175, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                        <h5 class=\"subItem\">");
#nullable restore
#line 26 "C:\Users\Daniel Simonsen\Documents\GitHub\SKP\Round 3\DanhosaurPortfolio\DanhosaurPortfolio\Pages\AboutMe.cshtml"
                                       Write(Model.Me.SpareTime[i].Title);

#line default
#line hidden
#nullable disable
            WriteLiteral(":</h5>\r\n                        <p class=\"subItem\">");
#nullable restore
#line 27 "C:\Users\Daniel Simonsen\Documents\GitHub\SKP\Round 3\DanhosaurPortfolio\DanhosaurPortfolio\Pages\AboutMe.cshtml"
                                      Write(Model.Me.SpareTime[i].Description);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                    </div>\r\n");
#nullable restore
#line 29 "C:\Users\Daniel Simonsen\Documents\GitHub\SKP\Round 3\DanhosaurPortfolio\DanhosaurPortfolio\Pages\AboutMe.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"            </div>
        </div>
        <div class=""contactInfo"">
            <h3>Kontakt</h3>
            <div name=""spareTimeContent"">
                <div class=""contactInfoItem"" id=""1"">
                    <h5 class=""subItem"">Email:</h5>
                    <a class=""contactLinks subItem""");
            BeginWriteAttribute("href", "\r\n                       href=\"", 1699, "\"", 1760, 2);
            WriteAttributeValue("", 1730, "mailto:", 1730, 7, true);
#nullable restore
#line 38 "C:\Users\Daniel Simonsen\Documents\GitHub\SKP\Round 3\DanhosaurPortfolio\DanhosaurPortfolio\Pages\AboutMe.cshtml"
WriteAttributeValue("", 1737, Classes.Contacts.Email, 1737, 23, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("\r\n                       title=\"Kun send mig noget jeg kan bruge\">\r\n                        ");
#nullable restore
#line 40 "C:\Users\Daniel Simonsen\Documents\GitHub\SKP\Round 3\DanhosaurPortfolio\DanhosaurPortfolio\Pages\AboutMe.cshtml"
                   Write(Classes.Contacts.Email);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </a>\r\n                </div>\r\n                <div class=\"contactInfoItem\" id=\"2\">\r\n                    <h5 class=\"subItem\">Telefon:</h5>\r\n                    <a class=\"contactLinks subItem\"");
            BeginWriteAttribute("onclick", "\r\n                       onclick=\"", 2088, "\"", 2185, 5);
            WriteAttributeValue("", 2122, "CopyToClipboard(\'", 2122, 17, true);
#nullable restore
#line 46 "C:\Users\Daniel Simonsen\Documents\GitHub\SKP\Round 3\DanhosaurPortfolio\DanhosaurPortfolio\Pages\AboutMe.cshtml"
WriteAttributeValue("", 2139, Classes.Contacts.Phone, 2139, 23, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 2162, "\',", 2162, 2, true);
            WriteAttributeValue(" ", 2164, "\'mit", 2165, 5, true);
            WriteAttributeValue(" ", 2169, "telefonnummer\')", 2170, 16, true);
            EndWriteAttribute();
            WriteLiteral("\r\n                       title=\"Du kan ligeså godt lade vær, jeg tager den ikke\">\r\n                        ");
#nullable restore
#line 48 "C:\Users\Daniel Simonsen\Documents\GitHub\SKP\Round 3\DanhosaurPortfolio\DanhosaurPortfolio\Pages\AboutMe.cshtml"
                   Write(Classes.Contacts.Phone);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </a>\r\n                </div>\r\n                <div class=\"contactInfoItem\" id=\"3\">\r\n                    <h5 class=\"subItem\">Github:</h5>\r\n                    <a class=\"contactLinks subItem\"");
            BeginWriteAttribute("href", "\r\n                       href=\"", 2527, "\"", 2582, 1);
#nullable restore
#line 54 "C:\Users\Daniel Simonsen\Documents\GitHub\SKP\Round 3\DanhosaurPortfolio\DanhosaurPortfolio\Pages\AboutMe.cshtml"
WriteAttributeValue("", 2558, Classes.Contacts.Github, 2558, 24, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("\r\n                       target=\"_blank\"\r\n                       title=\"FeelsBadMan når alle mine repos er private :kekw:\">\r\n                        ");
#nullable restore
#line 57 "C:\Users\Daniel Simonsen\Documents\GitHub\SKP\Round 3\DanhosaurPortfolio\DanhosaurPortfolio\Pages\AboutMe.cshtml"
                   Write(Classes.Contacts.Github);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </a>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n<div name=\"aboutMe\" class=\"profilePictureContainer danhoborder mainContent\">\r\n    <img");
            BeginWriteAttribute("src", " src=\"", 2950, "\"", 2980, 1);
#nullable restore
#line 65 "C:\Users\Daniel Simonsen\Documents\GitHub\SKP\Round 3\DanhosaurPortfolio\DanhosaurPortfolio\Pages\AboutMe.cshtml"
WriteAttributeValue("", 2956, Model.Me.ProfilePicture, 2956, 24, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" alt=\"Billede af mig selv\" title=\"Han nikker og han smiler og han er så glad\" />\r\n</div>\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<DanhosaurPortfolio.Pages.AboutMeModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<DanhosaurPortfolio.Pages.AboutMeModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<DanhosaurPortfolio.Pages.AboutMeModel>)PageContext?.ViewData;
        public DanhosaurPortfolio.Pages.AboutMeModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
