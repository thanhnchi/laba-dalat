using System.Collections.Generic;

namespace LABA_WebPortal_Corporate.Models
{
	public class M_Home
	{
		public M_About aboutUsObj { get; set; }
		public List<M_NewsCategory> newCategoryObjs { get; set; }
		public List<M_News> newObjs { get; set; }
	}
}
