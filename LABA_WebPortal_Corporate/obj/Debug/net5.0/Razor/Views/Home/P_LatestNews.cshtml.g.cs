#pragma checksum "D:\Workspace\DOTNET\Working\LABA.WebCorporate\LABA_WebPortal_Corporate\Views\Home\P_LatestNews.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b66ed938668dee4253037ac33f0ee59592331474"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_P_LatestNews), @"mvc.1.0.view", @"/Views/Home/P_LatestNews.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b66ed938668dee4253037ac33f0ee59592331474", @"/Views/Home/P_LatestNews.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"dc6bb33a3151fa5e74ecfbe0200d6ae1cee36978", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Home_P_LatestNews : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<LABA_WebPortal_Corporate.Models.M_Home>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<section class=\"wrapper bg-light\">\r\n\t<div class=\"container py-10\">\r\n\t\t<div class=\"row text-center\">\r\n\t\t\t<div class=\"col-lg-9 col-xl-8 col-xxl-7 mx-auto\">\r\n");
            WriteLiteral(@"				<h3 class=""display-4 mb-9 me-lg-n5"">
					Tin nổi bật
				</h3>
			</div>
			<!-- /column -->
		</div>
		<!-- /.row -->
		<div class=""swiper-container blog grid-view mb-17 mb-md-20"" data-autoplay=""true"" data-autoplaytime=""2000"" data-margin=""30"" data-dots=""true"" data-items-xl=""3"" data-items-md=""2"" data-items-xs=""1"">
			<div class=""swiper"">
				<div class=""swiper-wrapper"">
");
#nullable restore
#line 17 "D:\Workspace\DOTNET\Working\LABA.WebCorporate\LABA_WebPortal_Corporate\Views\Home\P_LatestNews.cshtml"
                     if (Model.newObjs.Count > 0)
					{
						

#line default
#line hidden
#nullable disable
#nullable restore
#line 19 "D:\Workspace\DOTNET\Working\LABA.WebCorporate\LABA_WebPortal_Corporate\Views\Home\P_LatestNews.cshtml"
                         foreach (var item in Model.newObjs)
						{
							var link = "/tin-tuc/" + item.titleSlug + "-" + item.id;

#line default
#line hidden
#nullable disable
            WriteLiteral("\t\t\t\t\t\t\t<div class=\"swiper-slide my-1\">\r\n\t\t\t\t\t\t\t\t<div class=\"card\">\r\n\t\t\t\t\t\t\t\t\t<figure class=\"card-img-top overlay overlay-1 hover-scale\">\r\n\t\t\t\t\t\t\t\t\t\t<a");
            BeginWriteAttribute("href", " href=\"", 987, "\"", 999, 1);
#nullable restore
#line 25 "D:\Workspace\DOTNET\Working\LABA.WebCorporate\LABA_WebPortal_Corporate\Views\Home\P_LatestNews.cshtml"
WriteAttributeValue("", 994, link, 994, 5, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("> <img");
            BeginWriteAttribute("src", " src=\"", 1006, "\"", 1039, 1);
#nullable restore
#line 25 "D:\Workspace\DOTNET\Working\LABA.WebCorporate\LABA_WebPortal_Corporate\Views\Home\P_LatestNews.cshtml"
WriteAttributeValue("", 1012, item.imageObj?.relativeUrl, 1012, 27, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"h-21\"");
            BeginWriteAttribute("alt", " alt=\"", 1053, "\"", 1070, 1);
#nullable restore
#line 25 "D:\Workspace\DOTNET\Working\LABA.WebCorporate\LABA_WebPortal_Corporate\Views\Home\P_LatestNews.cshtml"
WriteAttributeValue("", 1059, item.title, 1059, 11, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" style=""object-fit: cover"" /></a>
										<figcaption>
											<h5 class=""from-top mb-0"">Xem chi tiết</h5>
										</figcaption>
									</figure>
									<div class=""card-body p-3"">
										<div class=""post-header"">
											<div class=""post-category text-line"">
												<a");
            BeginWriteAttribute("href", " href=\"", 1370, "\"", 1408, 2);
            WriteAttributeValue("", 1377, "/tin-tuc?c=", 1377, 11, true);
#nullable restore
#line 33 "D:\Workspace\DOTNET\Working\LABA.WebCorporate\LABA_WebPortal_Corporate\Views\Home\P_LatestNews.cshtml"
WriteAttributeValue("", 1388, item.newsCategoryId, 1388, 20, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"hover\" rel=\"category\">");
#nullable restore
#line 33 "D:\Workspace\DOTNET\Working\LABA.WebCorporate\LABA_WebPortal_Corporate\Views\Home\P_LatestNews.cshtml"
                                                                                                                  Write(item.categoryObj?.name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n\t\t\t\t\t\t\t\t\t\t\t</div>\r\n\t\t\t\t\t\t\t\t\t\t\t<!-- /.post-category -->\r\n\t\t\t\t\t\t\t\t\t\t\t<h2 class=\"text-truncate-1  mt-1 mb-3 h3\">\r\n\t\t\t\t\t\t\t\t\t\t\t\t<a class=\"link-dark\"");
            BeginWriteAttribute("href", " href=\"", 1611, "\"", 1623, 1);
#nullable restore
#line 37 "D:\Workspace\DOTNET\Working\LABA.WebCorporate\LABA_WebPortal_Corporate\Views\Home\P_LatestNews.cshtml"
WriteAttributeValue("", 1618, link, 1618, 5, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("title", " title=\"", 1624, "\"", 1643, 1);
#nullable restore
#line 37 "D:\Workspace\DOTNET\Working\LABA.WebCorporate\LABA_WebPortal_Corporate\Views\Home\P_LatestNews.cshtml"
WriteAttributeValue("", 1632, item.title, 1632, 11, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 37 "D:\Workspace\DOTNET\Working\LABA.WebCorporate\LABA_WebPortal_Corporate\Views\Home\P_LatestNews.cshtml"
                                                                                                 Write(item.title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n\t\t\t\t\t\t\t\t\t\t\t</h2>\r\n\t\t\t\t\t\t\t\t\t\t</div>\r\n\t\t\t\t\t\t\t\t\t\t<!-- /.post-header -->\r\n\t\t\t\t\t\t\t\t\t\t<div class=\"post-content\">\r\n\t\t\t\t\t\t\t\t\t\t\t<p class=\"text-truncate-3\">");
#nullable restore
#line 42 "D:\Workspace\DOTNET\Working\LABA.WebCorporate\LABA_WebPortal_Corporate\Views\Home\P_LatestNews.cshtml"
                                                                  Write(item.description);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</p>
										</div>
										<!-- /.post-content -->
									</div>
									<!--/.card-body -->
									<div class=""card-footer"">
										<ul class=""post-meta d-flex mb-0"">
											<li class=""post-date""><i class=""uil uil-calendar-alt""></i><span>");
#nullable restore
#line 49 "D:\Workspace\DOTNET\Working\LABA.WebCorporate\LABA_WebPortal_Corporate\Views\Home\P_LatestNews.cshtml"
                                                                                                       Write(item.publishedAt?.ToString("dd/MM/yyyy"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</span></li>\r\n\t\t\t\t\t\t\t\t\t\t</ul>\r\n\t\t\t\t\t\t\t\t\t\t<!-- /.post-meta -->\r\n\t\t\t\t\t\t\t\t\t</div>\r\n\t\t\t\t\t\t\t\t\t<!-- /.card-footer -->\r\n\t\t\t\t\t\t\t\t</div>\r\n\t\t\t\t\t\t\t\t<!-- /.card -->\r\n\t\t\t\t\t\t\t</div>\r\n\t\t\t\t\t\t\t<!--/.swiper-slide -->\r\n");
#nullable restore
#line 58 "D:\Workspace\DOTNET\Working\LABA.WebCorporate\LABA_WebPortal_Corporate\Views\Home\P_LatestNews.cshtml"
						}

#line default
#line hidden
#nullable disable
#nullable restore
#line 58 "D:\Workspace\DOTNET\Working\LABA.WebCorporate\LABA_WebPortal_Corporate\Views\Home\P_LatestNews.cshtml"
                         
					}
					else
					{

#line default
#line hidden
#nullable disable
            WriteLiteral("\t\t\t\t\t\t<div class=\"d-flex align-items-center flex-column\">\r\n\t\t\t\t\t\t\t<img class=\"w-auto d-flex m-auto\" src=\"/assets/img/other/empty.png\">\r\n\t\t\t\t\t\t\t<span class=\"text-muted\">Không có dữ liệu !</span>\r\n\t\t\t\t\t\t</div>\r\n");
#nullable restore
#line 66 "D:\Workspace\DOTNET\Working\LABA.WebCorporate\LABA_WebPortal_Corporate\Views\Home\P_LatestNews.cshtml"
					}

#line default
#line hidden
#nullable disable
            WriteLiteral("\t\t\t\t</div>\r\n\t\t\t\t<!--/.swiper-wrapper -->\r\n\t\t\t</div>\r\n\t\t\t<!-- /.swiper -->\r\n\t\t</div>\r\n\t\t<!-- /.swiper-container -->\r\n\t</div>\r\n\t<!-- /.container -->\r\n</section>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<LABA_WebPortal_Corporate.Models.M_Home> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591