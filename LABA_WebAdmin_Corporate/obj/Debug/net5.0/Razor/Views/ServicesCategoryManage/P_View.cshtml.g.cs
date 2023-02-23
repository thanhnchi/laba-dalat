#pragma checksum "D:\Workspace\DOTNET\Working\LABA.WebCorporate\LABA_WebAdmin_Corporate\Views\ServicesCategoryManage\P_View.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8b0b8bcbe944644a276dc6680a1062339dca4487"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_ServicesCategoryManage_P_View), @"mvc.1.0.view", @"/Views/ServicesCategoryManage/P_View.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8b0b8bcbe944644a276dc6680a1062339dca4487", @"/Views/ServicesCategoryManage/P_View.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"98e7d60c2dee6d6fe7c61810e52bc12f095beadc", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_ServicesCategoryManage_P_View : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"
<div class=""modal-dialog modal-dialog-centered"">
	<div class=""modal-content border-0"">
		<div class=""modal-header align-items-center p-3 bg-success"">
			<h5 class=""flex-grow-1 text-center text-uppercase lis-font-weight-500 mb-0 text-white"" id=""header_view_title""></h5>
			<button type=""button"" class=""close text-white-50"" style=""opacity:1"" data-dismiss=""modal"" aria-label=""Close"">
				<span aria-hidden=""true"">&times;</span>
			</button>
		</div>
		<div class=""modal-body p-3"">
			<div class=""card"">
				<div class=""card-header d-flex align-items-center font-weight-bolder text-primary p-1"">
					<i class=""bx bx-info-square font-20 mr-1""></i>
					<span>Thông tin</span>
				</div>
				<div class=""card-body"">
					<div class=""form-group row mb-0"">
						<label class=""col-sm-3 col-form-label"">Tên:</label>
						<div class=""col-sm-9 d-flex align-items-center"">
							<span id=""view_name""></span>
						</div>
					</div>
					<div class=""form-group row mb-0"">
						<label class=""col-sm-3 col-form");
            WriteLiteral(@"-label"">Thứ tự:</label>
						<div class=""col-sm-9 d-flex align-items-center"">
							<span id=""view_order""></span>
						</div>
					</div>
					<div class=""form-group row mb-0"">
						<label class=""col-sm-3 col-form-label"">Trạng thái:</label>
						<div class=""col-sm-9 d-flex align-items-center"" id=""view_status"">
						</div>
					</div>
					<div class=""form-group row mb-0"">
						<label class=""col-sm-3 col-form-label"">Mô tả:</label>
						<div class=""col-sm-9 d-flex align-items-center"">
							<span id=""view_description""></span>
						</div>
					</div>
				</div>
			</div>
			<div class=""row"">
				<div class=""col-lg-6"">
					<div class=""card h-100 mb-0"">
						<div class=""card-header d-flex align-items-center font-weight-bolder text-primary p-1"">
							<i class=""bx bx-history font-20 mr-1""></i>
							<span>Nhật ký</span>
						</div>
						<div class=""card-body"">
							<div");
            BeginWriteAttribute("class", " class=\"", 1944, "\"", 1952, 0);
            EndWriteAttribute();
            WriteLiteral(@">
								<label class=""font-weight-bolder text-secondary"">Ngày tạo:</label>
								<div class=""media align-items-center"">
									<div>
										<img src=""https://via.placeholder.com/110x110"" width=""40"" height=""40"" class=""rounded-circle shadow p-1"" id=""img_created_user_avatar"" />
									</div>
									<div class=""media-body ml-2"">
										<p class=""mb-0 font-weight-bolder"" id=""view_created_by""></p>
										<small class=""mb-0 text-secondary"" id=""view_created_at""></small>
									</div>
								</div>
							</div>
							<div class=""dropdown-divider""></div>
							<div");
            BeginWriteAttribute("class", " class=\"", 2552, "\"", 2560, 0);
            EndWriteAttribute();
            WriteLiteral(@">
								<label class=""font-weight-bolder text-secondary"">Ngày cập nhật:</label>
								<div class=""media align-items-center"">
									<div>
										<img src=""https://via.placeholder.com/110x110"" width=""40"" height=""40"" class=""rounded-circle shadow p-1"" id=""img_updated_user_avatar"" />
									</div>
									<div class=""media-body ml-2"">
										<p class=""mb-0 font-weight-bolder"" id=""view_updated_by""></p>
										<small class=""mb-0 text-secondary"" id=""view_updated_at""></small>
									</div>
								</div>
							</div>
						</div>
					</div>
				</div>
				<div class=""col-lg-6"">
					<div class=""card h-100 mb-0"">
						<div class=""card-header d-flex align-items-center font-weight-bolder text-primary p-1"">
							<i class=""bx bx-image font-20 mr-1""></i>
							<span>Hình ảnh</span>
						</div>
						<div class=""card-body text-center"">
							<img");
            BeginWriteAttribute("src", " src=\"", 3454, "\"", 3460, 0);
            EndWriteAttribute();
            WriteLiteral(" class=\"mw-100 rounded\" style=\"object-fit: contain\" id=\"view_image\" />\r\n\t\t\t\t\t\t</div>\r\n\t\t\t\t\t</div>\r\n\t\t\t\t</div>\r\n\t\t\t</div>\r\n\t\t</div>\r\n\t</div>\r\n</div>\r\n");
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
