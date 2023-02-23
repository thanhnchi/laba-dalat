namespace LABA_WebAdmin_Corporate.Lib
{
    public static class GlobalVariables
    {
        public static bool is_development = false;
        public static string default_site_portal = "dev.koolselling.com";
        public static string url_api = "https://apicms.labadalat.com/";
        public static void SetVariablesEnviroment(bool isDevelop)
        {
            is_development = isDevelop;
        }
    }
}
