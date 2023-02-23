namespace LABA_WebPortal_Corporate.Models
{
	public class M_Farm
	{
		public int id { get; set; }
		public string name { get; set; }
		public string slogan { get; set; }
		public string description { get; set; }
		public string imageLogo { get; set; }
		public string imageFavicon { get; set; }
		public string imageQrcode { get; set; }
		public string telephoneNumber { get; set; }
		public string email { get; set; }
		public string faceBook { get; set; }
		public string twitter { get; set; }
		public string instagram { get; set; }
		public string zalo { get; set; }
		public string siteUrl { get; set; }
		public M_Address addressObj { get; set; }
	}
}
