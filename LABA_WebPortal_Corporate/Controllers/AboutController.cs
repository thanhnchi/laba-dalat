using LABA_WebPortal_Corporate.Models;
using LABA_WebPortal_Corporate.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using static System.String;

namespace LABA_WebPortal_Corporate.Controllers
{
	public class AboutController : BaseController<AboutController>
	{
		private readonly IS_About _s_About;

		public AboutController(IS_About about)
		{
			_s_About = about;
		}
		public async Task<IActionResult> Index(string titleSlug, int? id = 1)
		{
			string metaTitle = Empty;
			string metaDescription = Empty;
			string metaKeyword = Empty;
			string metaImage = Empty;

			if (!id.HasValue)
			{
				var res = await _s_About.getAboutUsByIdIsHotWithListRelated<M_About>(id, "1", 1, "publishedAt", true);
				if (res.result == 1 && res.data != null)
				{
					ViewBag.categoryTitle = res.data.title;
					metaTitle = res.data.metaTitle ?? res.data.title;
					metaDescription = res.data.metaDescription ?? res.data.description;
					metaKeyword = res.data.metaKeyword ?? res.data.title;
					metaImage = res.data.imageObj?.mediumUrl;

					ViewBag.ListRelated = res.data2nd?.lstRefObj.ToObject<List<M_About>>();
				}
				ExtensionMethods.SetViewDataSEOExtensionMethod.SetViewDataSEOCustom(this, new ViewModels.VM_ViewDataSEO
				{
					Title = IsNullOrEmpty(metaTitle) ? "Giới thiệu" : metaTitle,
					Description = IsNullOrEmpty(metaDescription) ? "Giới thiệu" : metaDescription,
					Keywords = IsNullOrEmpty(metaKeyword) ? "Giới thiệu" : metaKeyword,
					Image = metaImage,
				});
				return View(res.data);
			}
			else
			{
				var res = await _s_About.getAboutUsByIdWithListRelated<M_About>(id, "publishedAt", true);
				if (res.result == 1 && res.data != null)
				{
					ViewBag.categoryTitle = res.data.title;
					metaTitle = res.data.metaTitle ?? res.data.title;
					metaDescription = res.data.metaDescription ?? res.data.description;
					metaKeyword = res.data.metaKeyword ?? res.data.title;
					metaImage = res.data.imageObj?.mediumUrl;

					ViewBag.ListRelated = res.data2nd?.lstRefObj.ToObject<List<M_About>>();
				}
				ExtensionMethods.SetViewDataSEOExtensionMethod.SetViewDataSEOCustom(this, new ViewModels.VM_ViewDataSEO
				{
					Title = IsNullOrEmpty(metaTitle) ? "Giới thiệu" : metaTitle,
					Description = IsNullOrEmpty(metaDescription) ? "Giới thiệu" : metaDescription,
					Keywords = IsNullOrEmpty(metaKeyword) ? "Giới thiệu" : metaKeyword,
					Image = metaImage,
				});
				return View(res.data);
			}
		}
	}
}
