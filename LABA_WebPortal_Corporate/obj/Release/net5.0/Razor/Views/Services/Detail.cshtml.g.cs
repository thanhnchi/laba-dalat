#pragma checksum "D:\Workspace\DOTNET\Working\LABA.WebCorporate\LABA_WebPortal_Corporate\Views\Services\Detail.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "027667c176ae3d13dfcfeec392b449fac7b60927"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Services_Detail), @"mvc.1.0.view", @"/Views/Services/Detail.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"027667c176ae3d13dfcfeec392b449fac7b60927", @"/Views/Services/Detail.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"dc6bb33a3151fa5e74ecfbe0200d6ae1cee36978", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Services_Detail : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<LABA_WebPortal_Corporate.Models.M_News>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "P_BreadCrumb", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "D:\Workspace\DOTNET\Working\LABA.WebCorporate\LABA_WebPortal_Corporate\Views\Services\Detail.cshtml"
  
	var breadCrumb = new LABA_WebPortal_Corporate.ViewModels.VM_BreadCrumb
	{
		lv1Url = "/dich-vu",
		lv1Name = "Dịch vụ",
		lv2Name = Model.categoryObj?.name,
		lv2Url = "/dich-vu?c=" + Model.categoryObj?.id,
		currentName = Model.title
	};
	var related = ViewBag.ListRelated as List<M_News>;

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "027667c176ae3d13dfcfeec392b449fac7b609273995", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Name = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
#nullable restore
#line 13 "D:\Workspace\DOTNET\Working\LABA.WebCorporate\LABA_WebPortal_Corporate\Views\Services\Detail.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Model = breadCrumb;

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("model", __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Model, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"

<section class=""wrapper bg-light"">
	<div class=""container py-14"">
		<div class=""row gx-lg-8 gx-xl-12"">
			<div class=""col-lg-8"">
				<div class=""blog classic-view"">
					<article class=""post"">
						<div class=""card"">
							<figure class=""card-img-top""><img");
            BeginWriteAttribute("src", " src=\"", 674, "\"", 708, 1);
#nullable restore
#line 22 "D:\Workspace\DOTNET\Working\LABA.WebCorporate\LABA_WebPortal_Corporate\Views\Services\Detail.cshtml"
WriteAttributeValue("", 680, Model.imageObj?.relativeUrl, 680, 28, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"h-25\" style=\"object-fit: cover\"");
            BeginWriteAttribute("alt", " alt=\"", 748, "\"", 766, 1);
#nullable restore
#line 22 "D:\Workspace\DOTNET\Working\LABA.WebCorporate\LABA_WebPortal_Corporate\Views\Services\Detail.cshtml"
WriteAttributeValue("", 754, Model.title, 754, 12, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" /></figure>\r\n\t\t\t\t\t\t\t<div class=\"card-body  p-3 p-md-6\">\r\n\t\t\t\t\t\t\t\t<div class=\"classic-view\">\r\n\t\t\t\t\t\t\t\t\t<article class=\"post\">\r\n\t\t\t\t\t\t\t\t\t\t<div class=\"post-content mb-5\">\r\n\t\t\t\t\t\t\t\t\t\t\t<h2 class=\"h1 mb-4\">");
#nullable restore
#line 27 "D:\Workspace\DOTNET\Working\LABA.WebCorporate\LABA_WebPortal_Corporate\Views\Services\Detail.cshtml"
                                                           Write(Model.title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h2>\r\n\t\t\t\t\t\t\t\t\t\t\t<blockquote class=\"fs-lg my-8\">\r\n\t\t\t\t\t\t\t\t\t\t\t\t<p class=\"fs-17\">");
#nullable restore
#line 29 "D:\Workspace\DOTNET\Working\LABA.WebCorporate\LABA_WebPortal_Corporate\Views\Services\Detail.cshtml"
                                                            Write(Model.description);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n\t\t\t\t\t\t\t\t\t\t\t</blockquote>\r\n\t\t\t\t\t\t\t\t\t\t\t<p>");
#nullable restore
#line 31 "D:\Workspace\DOTNET\Working\LABA.WebCorporate\LABA_WebPortal_Corporate\Views\Services\Detail.cshtml"
                                          Write(Html.Raw(Model.detail));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</p>
										</div>
										<!-- /.post-content -->
									</article>
									<!-- /.post -->
								</div>
								<!-- /.swiper-container -->
							</div>
							<!--/.card-body -->
						</div>
						<!-- /.card -->
					</article>
					<!-- /.post -->
				</div>
				<!-- /.blog -->
			</div>
			<!-- /column -->
			<aside class=""col-lg-4 sidebar"">
				<div class=""widget"">
					<h4 class=""widget-title mb-3"">Dịch vụ liên quan</h4>
					<ul class=""image-list"">
");
#nullable restore
#line 52 "D:\Workspace\DOTNET\Working\LABA.WebCorporate\LABA_WebPortal_Corporate\Views\Services\Detail.cshtml"
                         if (related.Count > 0)
						{
							foreach (var item in related)
							{
								var link = "/dich-vu/" + item.titleSlug + "-" + item.id;

#line default
#line hidden
#nullable disable
            WriteLiteral("\t\t\t\t\t\t\t\t<li>\r\n\t\t\t\t\t\t\t\t\t<figure class=\"rounded\">\r\n\t\t\t\t\t\t\t\t\t\t<a");
            BeginWriteAttribute("href", " href=\"", 1857, "\"", 1869, 1);
#nullable restore
#line 59 "D:\Workspace\DOTNET\Working\LABA.WebCorporate\LABA_WebPortal_Corporate\Views\Services\Detail.cshtml"
WriteAttributeValue("", 1864, link, 1864, 5, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("><img");
            BeginWriteAttribute("src", " src=\"", 1875, "\"", 1908, 1);
#nullable restore
#line 59 "D:\Workspace\DOTNET\Working\LABA.WebCorporate\LABA_WebPortal_Corporate\Views\Services\Detail.cshtml"
WriteAttributeValue("", 1881, item.imageObj?.relativeUrl, 1881, 27, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("alt", " alt=\"", 1909, "\"", 1926, 1);
#nullable restore
#line 59 "D:\Workspace\DOTNET\Working\LABA.WebCorporate\LABA_WebPortal_Corporate\Views\Services\Detail.cshtml"
WriteAttributeValue("", 1915, item.title, 1915, 11, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"h-10\" style=\"object-fit: cover\" /></a>\r\n\t\t\t\t\t\t\t\t\t</figure>\r\n\t\t\t\t\t\t\t\t\t<div class=\"post-content\">\r\n\t\t\t\t\t\t\t\t\t\t<h6 class=\"text-truncate-2 mb-2\"> <a class=\"link-dark\"");
            BeginWriteAttribute("href", " href=\"", 2096, "\"", 2108, 1);
#nullable restore
#line 62 "D:\Workspace\DOTNET\Working\LABA.WebCorporate\LABA_WebPortal_Corporate\Views\Services\Detail.cshtml"
WriteAttributeValue("", 2103, link, 2103, 5, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("title", " title=\"", 2109, "\"", 2128, 1);
#nullable restore
#line 62 "D:\Workspace\DOTNET\Working\LABA.WebCorporate\LABA_WebPortal_Corporate\Views\Services\Detail.cshtml"
WriteAttributeValue("", 2117, item.title, 2117, 11, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 62 "D:\Workspace\DOTNET\Working\LABA.WebCorporate\LABA_WebPortal_Corporate\Views\Services\Detail.cshtml"
                                                                                                                           Write(item.title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a> </h6>\r\n\t\t\t\t\t\t\t\t\t\t<ul class=\"post-meta\">\r\n\t\t\t\t\t\t\t\t\t\t\t<li class=\"post-date\"><i class=\"uil uil-calendar-alt\"></i><span>");
#nullable restore
#line 64 "D:\Workspace\DOTNET\Working\LABA.WebCorporate\LABA_WebPortal_Corporate\Views\Services\Detail.cshtml"
                                                                                                       Write(item.publishedAt?.ToString("dd/MM/yyyy"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</span></li>\r\n\t\t\t\t\t\t\t\t\t\t</ul>\r\n\t\t\t\t\t\t\t\t\t</div>\r\n\t\t\t\t\t\t\t\t</li>\r\n");
#nullable restore
#line 68 "D:\Workspace\DOTNET\Working\LABA.WebCorporate\LABA_WebPortal_Corporate\Views\Services\Detail.cshtml"
							}
						}
						else
						{

#line default
#line hidden
#nullable disable
            WriteLiteral("\t\t\t\t\t\t\t<li class=\"d-flex align-items-center flex-column\">\r\n\t\t\t\t\t\t\t\t<img class=\"w-auto d-flex m-auto\" src=\"/assets/img/other/empty.png\">\r\n\t\t\t\t\t\t\t\t<span class=\"text-muted\">Không có dữ liệu !</span>\r\n\t\t\t\t\t\t\t</li>\r\n");
#nullable restore
#line 76 "D:\Workspace\DOTNET\Working\LABA.WebCorporate\LABA_WebPortal_Corporate\Views\Services\Detail.cshtml"
						}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\t\t\t\t\t</ul>\r\n\t\t\t\t\t<!-- /.image-list -->\r\n\t\t\t\t</div>\r\n\t\t\t\t<!-- /.widget -->\r\n\t\t\t</aside>\r\n\t\t\t<!-- /column .sidebar -->\r\n\t\t</div>\r\n\t\t<!-- /.row -->\r\n\t</div>\r\n\t<!-- /.container -->\r\n</section>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<LABA_WebPortal_Corporate.Models.M_News> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
