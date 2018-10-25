using System.Web.Mvc;

namespace ProHallManagement.Areas.Admin
{
    public class AdminAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Admin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Admin_default",
                "Admin/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );


            context.MapRoute(
                "assignRole",
                "Admin/{controller}/{action}/{userId}/{roleId}",
                new { action = "Assign" }

                );
        }


    }
}