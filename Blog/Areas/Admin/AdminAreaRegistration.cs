using System.Web.Mvc;

namespace Blog.Areas.Admin
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
                "Admin/",
                new { action = "Index", controller = "Admin" },
                namespaces: new[] { "Blog.Areas.Admin.Controllers" }
            );

            context.MapRoute(
                "Admin_create",
                "Admin/{action}/{id}",
                new { action = "Create", controller = "Admin", id = UrlParameter.Optional},
                namespaces: new[] { "Blog.Areas.Admin.Controllers" }
            );

       
        }
    }
}
