#pragma checksum "D:\Workspace\DOTNET\Working\LABA.WebCorporate\LABA_WebPortal_Corporate\Views\Shared\_LayoutMaster.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "84a3295b9b56b41d03f230013dca7e1e2d840320"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__LayoutMaster), @"mvc.1.0.view", @"/Views/Shared/_LayoutMaster.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"84a3295b9b56b41d03f230013dca7e1e2d840320", @"/Views/Shared/_LayoutMaster.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"dc6bb33a3151fa5e74ecfbe0200d6ae1cee36978", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Shared__LayoutMaster : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "P_Styles", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "P_Header", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "P_Footer", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "P_Scripts", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "P_ValidationScripts", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "D:\Workspace\DOTNET\Working\LABA.WebCorporate\LABA_WebPortal_Corporate\Views\Shared\_LayoutMaster.cshtml"
  
	var farmInfo = ViewBag.FarmInfo as LABA_WebPortal_Corporate.Models.M_Farm;

#line default
#line hidden
#nullable disable
            WriteLiteral("<!DOCTYPE html>\r\n<html lang=\"en\">\r\n\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "84a3295b9b56b41d03f230013dca7e1e2d8403205322", async() => {
                WriteLiteral("\r\n\t<meta charset=\"utf-8\">\r\n\t<meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\">\r\n\t<meta name=\"description\"");
                BeginWriteAttribute("content", " content=\"", 252, "\"", 286, 1);
#nullable restore
#line 10 "D:\Workspace\DOTNET\Working\LABA.WebCorporate\LABA_WebPortal_Corporate\Views\Shared\_LayoutMaster.cshtml"
WriteAttributeValue("", 262, ViewData["Description"], 262, 24, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">\r\n\t<meta name=\"keywords\"");
                BeginWriteAttribute("content", " content=\"", 312, "\"", 343, 1);
#nullable restore
#line 11 "D:\Workspace\DOTNET\Working\LABA.WebCorporate\LABA_WebPortal_Corporate\Views\Shared\_LayoutMaster.cshtml"
WriteAttributeValue("", 322, ViewData["Keywords"], 322, 21, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">\r\n\t<meta name=\"author\"");
                BeginWriteAttribute("content", " content=\"", 367, "\"", 391, 1);
#nullable restore
#line 12 "D:\Workspace\DOTNET\Working\LABA.WebCorporate\LABA_WebPortal_Corporate\Views\Shared\_LayoutMaster.cshtml"
WriteAttributeValue("", 377, farmInfo.name, 377, 14, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">\r\n\t<title>");
#nullable restore
#line 13 "D:\Workspace\DOTNET\Working\LABA.WebCorporate\LABA_WebPortal_Corporate\Views\Shared\_LayoutMaster.cshtml"
      Write(ViewData["Title"]);

#line default
#line hidden
#nullable disable
                WriteLiteral(" ");
#nullable restore
#line 13 "D:\Workspace\DOTNET\Working\LABA.WebCorporate\LABA_WebPortal_Corporate\Views\Shared\_LayoutMaster.cshtml"
                         Write(ViewData["Slogan"]);

#line default
#line hidden
#nullable disable
                WriteLiteral("</title>\r\n\t<link rel=\"shortcut icon\"");
                BeginWriteAttribute("href", " href=\"", 477, "\"", 526, 1);
#nullable restore
#line 14 "D:\Workspace\DOTNET\Working\LABA.WebCorporate\LABA_WebPortal_Corporate\Views\Shared\_LayoutMaster.cshtml"
WriteAttributeValue("", 484, farmInfo.imageFavicon ?? "/favicon.ico", 484, 42, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">\r\n\t<!-- Facebook, Zalo, Telegram Meta Tags -->\r\n\t<meta property=\"og:image\"");
                BeginWriteAttribute("content", " content=\"", 602, "\"", 637, 1);
#nullable restore
#line 16 "D:\Workspace\DOTNET\Working\LABA.WebCorporate\LABA_WebPortal_Corporate\Views\Shared\_LayoutMaster.cshtml"
WriteAttributeValue("", 612, ViewData["ImagePreview"], 612, 25, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" />\r\n\t<meta property=\"og:image:alt\"");
                BeginWriteAttribute("content", " content=\"", 673, "\"", 701, 1);
#nullable restore
#line 17 "D:\Workspace\DOTNET\Working\LABA.WebCorporate\LABA_WebPortal_Corporate\Views\Shared\_LayoutMaster.cshtml"
WriteAttributeValue("", 683, ViewData["Title"], 683, 18, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" />\r\n\t<meta property=\"og:type\" content=\"website\" />\r\n\t<meta property=\"og:locale\" content=\"vi\" />\r\n");
                WriteLiteral("\t<meta property=\"og:site_name\"");
                BeginWriteAttribute("content", " content=\"", 918, "\"", 945, 1);
#nullable restore
#line 21 "D:\Workspace\DOTNET\Working\LABA.WebCorporate\LABA_WebPortal_Corporate\Views\Shared\_LayoutMaster.cshtml"
WriteAttributeValue("", 928, farmInfo.siteUrl, 928, 17, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" />\r\n\t<meta property=\"og:title\"");
                BeginWriteAttribute("content", " content=\"", 977, "\"", 1005, 1);
#nullable restore
#line 22 "D:\Workspace\DOTNET\Working\LABA.WebCorporate\LABA_WebPortal_Corporate\Views\Shared\_LayoutMaster.cshtml"
WriteAttributeValue("", 987, ViewData["Title"], 987, 18, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" />\r\n\t<meta property=\"og:description\"");
                BeginWriteAttribute("content", " content=\"", 1043, "\"", 1077, 1);
#nullable restore
#line 23 "D:\Workspace\DOTNET\Working\LABA.WebCorporate\LABA_WebPortal_Corporate\Views\Shared\_LayoutMaster.cshtml"
WriteAttributeValue("", 1053, ViewData["Description"], 1053, 24, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" />\r\n\t<meta property=\"og:url\"");
                BeginWriteAttribute("href", " href=\"", 1107, "\"", 1229, 1);
#nullable restore
#line 24 "D:\Workspace\DOTNET\Working\LABA.WebCorporate\LABA_WebPortal_Corporate\Views\Shared\_LayoutMaster.cshtml"
WriteAttributeValue("", 1114, new Uri($"{Context.Request.Scheme}://{Context.Request.Host}{Context.Request.Path}{Context.Request.QueryString}"), 1114, 115, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" />\r\n\t<!-- Twitter Meta Tags -->\r\n\t<meta name=\"twitter:card\" content=\"summary_large_image\" />\r\n\t<meta name=\"twitter:image\"");
                BeginWriteAttribute("content", " content=\"", 1352, "\"", 1387, 1);
#nullable restore
#line 27 "D:\Workspace\DOTNET\Working\LABA.WebCorporate\LABA_WebPortal_Corporate\Views\Shared\_LayoutMaster.cshtml"
WriteAttributeValue("", 1362, ViewData["ImagePreview"], 1362, 25, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" />\r\n\t<meta name=\"twitter:title\"");
                BeginWriteAttribute("content", " content=\"", 1420, "\"", 1448, 1);
#nullable restore
#line 28 "D:\Workspace\DOTNET\Working\LABA.WebCorporate\LABA_WebPortal_Corporate\Views\Shared\_LayoutMaster.cshtml"
WriteAttributeValue("", 1430, ViewData["Title"], 1430, 18, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" />\r\n\t<meta name=\"twitter:description\"");
                BeginWriteAttribute("content", " content=\"", 1487, "\"", 1521, 1);
#nullable restore
#line 29 "D:\Workspace\DOTNET\Working\LABA.WebCorporate\LABA_WebPortal_Corporate\Views\Shared\_LayoutMaster.cshtml"
WriteAttributeValue("", 1497, ViewData["Description"], 1497, 24, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" />\r\n\r\n\t<!-- styles-->\r\n\t");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "84a3295b9b56b41d03f230013dca7e1e2d84032012488", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Name = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n\t<!-- /styles-->\r\n\t");
#nullable restore
#line 34 "D:\Workspace\DOTNET\Working\LABA.WebCorporate\LABA_WebPortal_Corporate\Views\Shared\_LayoutMaster.cshtml"
Write(await RenderSectionAsync(name: "Styles", required: false));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "84a3295b9b56b41d03f230013dca7e1e2d84032014692", async() => {
                WriteLiteral("\r\n\t<!-- content-wrapper -->\r\n\t<div class=\"content-wrapper\">\r\n\t\t<!-- header -->\r\n\t\t");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "84a3295b9b56b41d03f230013dca7e1e2d84032015045", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Name = (string)__tagHelperAttribute_1.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n\t\t<!-- /header -->\r\n\t\t");
#nullable restore
#line 43 "D:\Workspace\DOTNET\Working\LABA.WebCorporate\LABA_WebPortal_Corporate\Views\Shared\_LayoutMaster.cshtml"
   Write(RenderBody());

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n\t</div>\r\n\t<!-- /content-wrapper -->\r\n\t<!-- footer -->\r\n\t");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "84a3295b9b56b41d03f230013dca7e1e2d84032016566", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Name = (string)__tagHelperAttribute_2.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n\t<!-- /footer -->\r\n\t<!-- scripts -->\r\n\t");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "84a3295b9b56b41d03f230013dca7e1e2d84032017789", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Name = (string)__tagHelperAttribute_3.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n\t<!-- /scripts -->\r\n\t");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "84a3295b9b56b41d03f230013dca7e1e2d84032018991", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Name = (string)__tagHelperAttribute_4.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n\t");
#nullable restore
#line 53 "D:\Workspace\DOTNET\Working\LABA.WebCorporate\LABA_WebPortal_Corporate\Views\Shared\_LayoutMaster.cshtml"
Write(await RenderSectionAsync(name: "Scripts", required: false));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n</html>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
