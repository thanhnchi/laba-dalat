using AutoMapper;
using LABA_WebPortal_Corporate.Lib;
using LABA_WebPortal_Corporate.Models;
using LABA_WebPortal_Corporate.Services;
using LABA_WebPortal_Corporate.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static System.String;

namespace LABA_WebPortal_Corporate.Controllers
{
	public abstract class BaseController<T> : Controller where T : BaseController<T>
	{
		private IMemoryCache memoryCache;
		private IS_Farm s_Farm;
		private IS_NewsCategory s_NewsCategory;

		protected IMemoryCache _memoryCache => memoryCache ?? (memoryCache = HttpContext?.RequestServices.GetService<IMemoryCache>());

		protected IS_Farm _s_Farm => s_Farm ?? (s_Farm = HttpContext?.RequestServices.GetService<IS_Farm>());
		protected IS_NewsCategory _s_NewsCategory => s_NewsCategory ?? (s_NewsCategory = HttpContext?.RequestServices.GetService<IS_NewsCategory>());

		public override void OnActionExecuting(ActionExecutingContext context)
		{
			if (!_memoryCache.TryGetValue(CommonConstants.CACHE_KEY_FARM_INFO, out ResponseData<M_Farm> farmInfo))
			{
				farmInfo = _s_Farm.getFarmById<M_Farm>(CommonConstants.OWNER_FARM_ID).Result;
				if (farmInfo.result == 1 && farmInfo.data != null)
				{
					MemoryCacheEntryOptions cacheExpiryOptions = new MemoryCacheEntryOptions
					{
						AbsoluteExpiration = DateTime.Now.AddMinutes(30),
						Priority = CacheItemPriority.Normal,
						//SlidingExpiration = TimeSpan.FromMinutes(5),
						Size = 1024
					};
					_memoryCache.Set(CommonConstants.CACHE_KEY_FARM_INFO, farmInfo, cacheExpiryOptions);
				}
			}
			if (!_memoryCache.TryGetValue(CommonConstants.CACHE_KEY_FARM_INFO, out ResponseData<M_NewsCategoryMenu> newsCategory))
			{
				newsCategory = _s_NewsCategory.getListNewsCategoryByTypeId<M_NewsCategoryMenu>().Result;
				if (newsCategory.result == 1 && newsCategory.data != null)
				{
					MemoryCacheEntryOptions cacheExpiryOptions = new MemoryCacheEntryOptions
					{
						AbsoluteExpiration = DateTime.Now.AddMinutes(30),
						Priority = CacheItemPriority.Normal,
						//SlidingExpiration = TimeSpan.FromMinutes(5),
						Size = 1024
					};
					_memoryCache.Set(CommonConstants.CACHE_KEY_FARM_INFO, newsCategory, cacheExpiryOptions);
				}
			}
			ViewBag.FarmInfo = farmInfo.data ?? new M_Farm();
			ViewBag.NewsCategory = newsCategory.data ?? new M_NewsCategoryMenu();
			base.OnActionExecuting(context);
		}

	}
}
