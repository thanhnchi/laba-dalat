#pragma checksum "D:\Workspace\DOTNET\Working\LABA.WebCorporate\LABA_WebAdmin_Corporate\Views\Shared\_P_BreadCrumb.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "fea44398f31c2b76d4429ad1dab4871a3dd61c59"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__P_BreadCrumb), @"mvc.1.0.view", @"/Views/Shared/_P_BreadCrumb.cshtml")]
namespace AspNetCore
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
#line 1 "D:\Workspace\DOTNET\Working\LABA.WebCorporate\LABA_WebAdmin_Corporate\Views\_ViewImports.cshtml"
using LABA_WebAdmin_Corporate;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Workspace\DOTNET\Working\LABA.WebCorporate\LABA_WebAdmin_Corporate\Views\_ViewImports.cshtml"
using LABA_WebAdmin_Corporate.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fea44398f31c2b76d4429ad1dab4871a3dd61c59", @"/Views/Shared/_P_BreadCrumb.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"98e7d60c2dee6d6fe7c61810e52bc12f095beadc", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Shared__P_BreadCrumb : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<LABA_WebAdmin_Corporate.ViewModels.VM_BreadCrumb>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n\r\n");
#nullable restore
#line 4 "D:\Workspace\DOTNET\Working\LABA.WebCorporate\LABA_WebAdmin_Corporate\Views\Shared\_P_BreadCrumb.cshtml"
 if (Model != null)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("\t<div class=\"page-breadcrumb d-none d-md-flex align-items-center justify-content-end mb-3\">\r\n\t\t<div class=\"pl-3\">\r\n\t\t\t<nav aria-label=\"breadcrumb\">\r\n\t\t\t\t<ol class=\"breadcrumb mb-0 p-0\">\r\n");
#nullable restore
#line 10 "D:\Workspace\DOTNET\Working\LABA.WebCorporate\LABA_WebAdmin_Corporate\Views\Shared\_P_BreadCrumb.cshtml"
                     if (!string.IsNullOrEmpty(Model.ParentName))
					{

#line default
#line hidden
#nullable disable
            WriteLiteral("\t\t\t\t\t\t<li class=\"breadcrumb-item\"><a");
            BeginWriteAttribute("href", " href=\"", 368, "\"", 391, 1);
#nullable restore
#line 12 "D:\Workspace\DOTNET\Working\LABA.WebCorporate\LABA_WebAdmin_Corporate\Views\Shared\_P_BreadCrumb.cshtml"
WriteAttributeValue("", 375, Model.ParentUrl, 375, 16, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 12 "D:\Workspace\DOTNET\Working\LABA.WebCorporate\LABA_WebAdmin_Corporate\Views\Shared\_P_BreadCrumb.cshtml"
                                                                          Write(Model.ParentName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a></li>\r\n");
#nullable restore
#line 13 "D:\Workspace\DOTNET\Working\LABA.WebCorporate\LABA_WebAdmin_Corporate\Views\Shared\_P_BreadCrumb.cshtml"
					}

#line default
#line hidden
#nullable disable
#nullable restore
#line 14 "D:\Workspace\DOTNET\Working\LABA.WebCorporate\LABA_WebAdmin_Corporate\Views\Shared\_P_BreadCrumb.cshtml"
                     if (!string.IsNullOrEmpty(Model.ChildName))
					{

#line default
#line hidden
#nullable disable
            WriteLiteral("\t\t\t\t\t\t<li class=\"breadcrumb-item\"><a");
            BeginWriteAttribute("href", " href=\"", 524, "\"", 546, 1);
#nullable restore
#line 16 "D:\Workspace\DOTNET\Working\LABA.WebCorporate\LABA_WebAdmin_Corporate\Views\Shared\_P_BreadCrumb.cshtml"
WriteAttributeValue("", 531, Model.ChildUrl, 531, 15, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 16 "D:\Workspace\DOTNET\Working\LABA.WebCorporate\LABA_WebAdmin_Corporate\Views\Shared\_P_BreadCrumb.cshtml"
                                                                         Write(Model.ChildName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a></li>\r\n");
#nullable restore
#line 17 "D:\Workspace\DOTNET\Working\LABA.WebCorporate\LABA_WebAdmin_Corporate\Views\Shared\_P_BreadCrumb.cshtml"
					}

#line default
#line hidden
#nullable disable
            WriteLiteral("\t\t\t\t\t<li class=\"breadcrumb-item active\" aria-current=\"page\">");
#nullable restore
#line 18 "D:\Workspace\DOTNET\Working\LABA.WebCorporate\LABA_WebAdmin_Corporate\Views\Shared\_P_BreadCrumb.cshtml"
                                                                      Write(Model.CurrentName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>\r\n\t\t\t\t</ol>\r\n\t\t\t</nav>\r\n\t\t</div>\r\n\t</div>\r\n");
#nullable restore
#line 23 "D:\Workspace\DOTNET\Working\LABA.WebCorporate\LABA_WebAdmin_Corporate\Views\Shared\_P_BreadCrumb.cshtml"
}
else
{

#line default
#line hidden
#nullable disable
            WriteLiteral(@"	<div class=""page-breadcrumb d-none d-md-flex align-items-center mb-3"">
		<div class=""pl-3"">
			<nav aria-label=""breadcrumb"">
				<ol class=""breadcrumb mb-0 p-0"">
					<li class=""breadcrumb-item"">
						<a href=""/""><i class=""bx bx-home-alt""></i></a>
					</li>
				</ol>
			</nav>
		</div>
	</div>
");
#nullable restore
#line 37 "D:\Workspace\DOTNET\Working\LABA.WebCorporate\LABA_WebAdmin_Corporate\Views\Shared\_P_BreadCrumb.cshtml"
}

#line default
#line hidden
#nullable disable
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<LABA_WebAdmin_Corporate.ViewModels.VM_BreadCrumb> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
