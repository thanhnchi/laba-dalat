#pragma checksum "D:\Workspace\DOTNET\Working\LABA.WebCorporate\LABA_WebPortal_Corporate\Views\Shared\P_BreadCrumb.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1ed28b4d2025101e204eb2ebdd015f9df5116127"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_P_BreadCrumb), @"mvc.1.0.view", @"/Views/Shared/P_BreadCrumb.cshtml")]
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
#line 1 "D:\Workspace\DOTNET\Working\LABA.WebCorporate\LABA_WebPortal_Corporate\Views\_ViewImports.cshtml"
using LABA_WebPortal_Corporate;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Workspace\DOTNET\Working\LABA.WebCorporate\LABA_WebPortal_Corporate\Views\_ViewImports.cshtml"
using LABA_WebPortal_Corporate.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1ed28b4d2025101e204eb2ebdd015f9df5116127", @"/Views/Shared/P_BreadCrumb.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"dc6bb33a3151fa5e74ecfbe0200d6ae1cee36978", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Shared_P_BreadCrumb : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<LABA_WebPortal_Corporate.ViewModels.VM_BreadCrumb>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "D:\Workspace\DOTNET\Working\LABA.WebCorporate\LABA_WebPortal_Corporate\Views\Shared\P_BreadCrumb.cshtml"
 if (Model != null)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("\t<section class=\"wrapper bg-gray\">\r\n\t\t<div class=\"container py-3 py-md-5\">\r\n\t\t\t<nav class=\"d-inline-block\" aria-label=\"breadcrumb\">\r\n\t\t\t\t<ol class=\"breadcrumb mb-0\">\r\n");
#nullable restore
#line 9 "D:\Workspace\DOTNET\Working\LABA.WebCorporate\LABA_WebPortal_Corporate\Views\Shared\P_BreadCrumb.cshtml"
                     if (!string.IsNullOrEmpty(Model.lv1Name))
					{

#line default
#line hidden
#nullable disable
            WriteLiteral("\t\t\t\t\t\t<li class=\"breadcrumb-item\"><a");
            BeginWriteAttribute("href", " href=\"", 344, "\"", 364, 1);
#nullable restore
#line 11 "D:\Workspace\DOTNET\Working\LABA.WebCorporate\LABA_WebPortal_Corporate\Views\Shared\P_BreadCrumb.cshtml"
WriteAttributeValue("", 351, Model.lv1Url, 351, 13, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 11 "D:\Workspace\DOTNET\Working\LABA.WebCorporate\LABA_WebPortal_Corporate\Views\Shared\P_BreadCrumb.cshtml"
                                                                       Write(Model.lv1Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a></li>\r\n");
#nullable restore
#line 12 "D:\Workspace\DOTNET\Working\LABA.WebCorporate\LABA_WebPortal_Corporate\Views\Shared\P_BreadCrumb.cshtml"
					}

#line default
#line hidden
#nullable disable
#nullable restore
#line 13 "D:\Workspace\DOTNET\Working\LABA.WebCorporate\LABA_WebPortal_Corporate\Views\Shared\P_BreadCrumb.cshtml"
                     if (!string.IsNullOrEmpty(Model.lv2Name))
					{

#line default
#line hidden
#nullable disable
            WriteLiteral("\t\t\t\t\t\t<li class=\"breadcrumb-item\"><a");
            BeginWriteAttribute("href", " href=\"", 492, "\"", 512, 1);
#nullable restore
#line 15 "D:\Workspace\DOTNET\Working\LABA.WebCorporate\LABA_WebPortal_Corporate\Views\Shared\P_BreadCrumb.cshtml"
WriteAttributeValue("", 499, Model.lv2Url, 499, 13, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 15 "D:\Workspace\DOTNET\Working\LABA.WebCorporate\LABA_WebPortal_Corporate\Views\Shared\P_BreadCrumb.cshtml"
                                                                       Write(Model.lv2Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a></li>\r\n");
#nullable restore
#line 16 "D:\Workspace\DOTNET\Working\LABA.WebCorporate\LABA_WebPortal_Corporate\Views\Shared\P_BreadCrumb.cshtml"
					}

#line default
#line hidden
#nullable disable
#nullable restore
#line 17 "D:\Workspace\DOTNET\Working\LABA.WebCorporate\LABA_WebPortal_Corporate\Views\Shared\P_BreadCrumb.cshtml"
                     if (!string.IsNullOrEmpty(Model.lv3Name))
					{

#line default
#line hidden
#nullable disable
            WriteLiteral("\t\t\t\t\t\t<li class=\"breadcrumb-item\"><a");
            BeginWriteAttribute("href", " href=\"", 640, "\"", 660, 1);
#nullable restore
#line 19 "D:\Workspace\DOTNET\Working\LABA.WebCorporate\LABA_WebPortal_Corporate\Views\Shared\P_BreadCrumb.cshtml"
WriteAttributeValue("", 647, Model.lv3Url, 647, 13, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 19 "D:\Workspace\DOTNET\Working\LABA.WebCorporate\LABA_WebPortal_Corporate\Views\Shared\P_BreadCrumb.cshtml"
                                                                       Write(Model.lv3Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a></li>\r\n");
#nullable restore
#line 20 "D:\Workspace\DOTNET\Working\LABA.WebCorporate\LABA_WebPortal_Corporate\Views\Shared\P_BreadCrumb.cshtml"
					}

#line default
#line hidden
#nullable disable
            WriteLiteral("\t\t\t\t\t<li class=\"breadcrumb-item active text-muted\">");
#nullable restore
#line 21 "D:\Workspace\DOTNET\Working\LABA.WebCorporate\LABA_WebPortal_Corporate\Views\Shared\P_BreadCrumb.cshtml"
                                                             Write(Model.currentName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>\r\n\t\t\t\t</ol>\r\n\t\t\t</nav>\r\n\t\t\t<!-- /nav -->\r\n\t\t</div>\r\n\t\t<!-- /.container -->\r\n\t</section>\r\n");
#nullable restore
#line 28 "D:\Workspace\DOTNET\Working\LABA.WebCorporate\LABA_WebPortal_Corporate\Views\Shared\P_BreadCrumb.cshtml"
}
else
{

#line default
#line hidden
#nullable disable
            WriteLiteral(@"	<section class=""wrapper bg-gray"">
		<div class=""container py-3 py-md-5"">
			<nav class=""d-inline-block"" aria-label=""breadcrumb"">
				<ol class=""breadcrumb mb-0"">
					<li class=""breadcrumb-item active text-muted"">Trang ch???</li>
				</ol>
			</nav>
			<!-- /nav -->
		</div>
		<!-- /.container -->
	</section>
");
#nullable restore
#line 42 "D:\Workspace\DOTNET\Working\LABA.WebCorporate\LABA_WebPortal_Corporate\Views\Shared\P_BreadCrumb.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<LABA_WebPortal_Corporate.ViewModels.VM_BreadCrumb> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
