using System.Web;
using System.Web.Mvc;
using MVC5RealWorld.Models.DB;
using MVC5RealWorld.Models.EntityManager;

namespace MVC5RealWorld.Security
{
    public class AuthorizeRolesAttribute : AuthorizeAttribute
    {
        private readonly string[] userAssignedRoles;
        public AuthorizeRolesAttribute(params string[] roles) {
            this.userAssignedRoles = roles;
        }
        protected override bool AuthorizeCore(HttpContextBase httpContext) {
            bool authorize = false;
            using (DemoDBEntities db = new DemoDBEntities()) {
                UserManager UM = new UserManager();
                foreach (var roles in userAssignedRoles) {
                    authorize = UM.IsUserInRole(httpContext.User.Identity.Name, roles);
                    if (authorize)
                        return authorize;
                }
            }
            return authorize;
        }
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext) {
            filterContext.Result = new RedirectResult("~/Home/UnAuthorized");
        }
    }
}