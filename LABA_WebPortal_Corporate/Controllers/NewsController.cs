using LABA_WebPortal_Corporate.Lib;
using LABA_WebPortal_Corporate.Models;
using LABA_WebPortal_Corporate.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static System.String;

namespace LABA_WebPortal_Corporate.Controllers
{
	public class NewsController : BaseController<NewsController>
	{
		private readonly IS_News _s_News;

		public NewsController(IS_News news)
		{
			_s_News = news;
		}

		public async Task<IActionResult> Index(int? c, int record = 12, int page = 1)
		{
			ViewBag.categoryId = c;
			ViewBag.record = record;
			ViewBag.page = page;
			string metaTitle = Empty;
			string metaDescription = Empty;
			string metaKeyword = Empty;
			string metaImage = Empty;
			if (c.HasValue)
			{
				var res = await _s_NewsCategory.getNewsCategoryById<M_NewsCategory>(c.Value);
				if (res.result == 1 && res.data != null)
				{
					ViewBag.categoryId = res.data.id;
					ViewBag.categoryTitle = res.data.name;
					metaTitle = res.data.metaTitle ?? res.data.name;
					metaDescription = res.data.metaDescription ?? res.data.description;
					metaKeyword = res.data.metaKeyword ?? res.data.name;
					metaImage = res.data.imageObj?.mediumUrl;
				}
			}
			ExtensionMethods.SetViewDataSEOExtensionMethod.SetViewDataSEOCustom(this, new ViewModels.VM_ViewDataSEO
			{
				Title = IsNullOrEmpty(metaTitle) ? "Tin tức" : metaTitle,
				Description = IsNullOrEmpty(metaDescription) ? "Tin tức" : metaDescription,
				Keywords = IsNullOrEmpty(metaKeyword) ? "Tin tức" : metaKeyword,
				Image = metaImage,
			});
			var resLatestNews = await _s_News.getListLatestNews<List<M_News>>(0, "publishedAt", true, 6);
			return View(resLatestNews.data ?? new List<M_News>());
		}
		public async Task<JsonResult> GetList(int? c, int page = 1, int record = 10)
		{
			ResponseData<List<M_News>> res = new ResponseData<List<M_News>>();
			if (c.HasValue) //Get list by categoryId
				res = await _s_News.getListNewsByCategoryId<List<M_News>>(c, "publishedAt", true, page, record);
			else if (!c.HasValue) //Get list all
				res = await _s_News.getListNewsFilterByOrderByPagination<List<M_News>>(0, "publishedAt", true, page, record);
			return Json(new M_JResult(res, res.data, res.data2nd == null ? 0 : (int)res.data2nd.totalRecord));
		}
		public async Task<IActionResult> Detail(string titleSlug, int id)
		{
			string metaTitle = Empty;
			string metaDescription = Empty;
			string metaKeyword = Empty;
			string metaImage = Empty;

			var res = await _s_News.getNewsByIdWithListRelated<M_News>(id, 0, 8, 8);
			if (res.result == 1 && res.data != null)
			{
				if (res.result == 1 && res.data != null)
				{
					ViewBag.categoryTitle = res.data.title;
					metaTitle = res.data.metaTitle ?? res.data.title;
					metaDescription = res.data.metaDescription ?? res.data.description;
					metaKeyword = res.data.metaKeyword ?? res.data.title;
					metaImage = res.data.imageObj?.mediumUrl;
				}

				ExtensionMethods.SetViewDataSEOExtensionMethod.SetViewDataSEOCustom(this, new ViewModels.VM_ViewDataSEO
				{
					Title = IsNullOrEmpty(metaTitle) ? "Tin tức" : metaTitle,
					Description = IsNullOrEmpty(metaDescription) ? "Tin tức" : metaDescription,
					Keywords = IsNullOrEmpty(metaKeyword) ? "Tin tức" : metaKeyword,
					Image = metaImage,
				});
				ViewBag.ListRelated = res.data2nd?.lstNewsRefObj.ToObject<List<M_News>>();
				ViewBag.ListLatest = res.data2nd?.lstNewsIsNewObj.ToObject<List<M_News>>();
				return View(res.data);
			}
			return Redirect($"/error/{res.error.code}");
		}
	}
}
