using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LABA_WebPortal_Corporate.Models
{
	public class M_NewsCategory
	{
		public int id { get; set; }
		public int parentId { get; set; }
		public string name { get; set; }
		public string nameSlug { get; set; }
		public string typeId { get; set; }
		public int reOrder { get; set; }
		public string description { get; set; }
		public string metaTitle { get; set; }
		public string metaKeyword { get; set; }
		public string metaDescription { get; set; }
		public M_Image imageObj { get; set; }
	}
	public class M_NewsCategoryMenu
	{
		public List<M_NewsCategory> newsCategoryServiceObjs { get; set; }
		public List<M_NewsCategory> newsCategoryObjs { get; set; }
	}
}
