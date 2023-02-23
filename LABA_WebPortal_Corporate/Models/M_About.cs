using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LABA_WebPortal_Corporate.Models
{
	public class M_About
	{
		public int id { get; set; }
		public string title { get; set; }
		public string titleSlug { get; set; }
		public string description { get; set; }
		public string detail { get; set; }
		public int likeNumber { get; set; }
		public int viewNumber { get; set; }
		public int isHot { get; set; }
		public int status { get; set; }
		public int aboutType { get; set; }
		public string metaTitle { get; set; }
		public string metaKeyword { get; set; }
		public string metaDescription { get; set; }
		public DateTime? publishedAt { get; set; }
		public M_Image imageObj { get; set; }
	}
}
