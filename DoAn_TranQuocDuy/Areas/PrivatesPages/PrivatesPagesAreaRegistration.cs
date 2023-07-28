using System.Web.Mvc;

namespace DoAn_TranQuocDuy.Areas.PrivatesPages
{
    public class PrivatesPagesAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "PrivatesPages";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "PrivatesPages_default",
                "PrivatesPages/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}