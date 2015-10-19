using System;
using System.Web;
using System.Web.Mvc;

namespace KoalaCode.BL.Code.Helpers
{
    public class LocationHelper
    {
        public static bool IsCurrentControllerAndAction(string controllerName, string actionName, ViewContext viewContext)
        {
            var routeValues = HttpContext.Current.Request.RequestContext.RouteData.Values;
            var currentAction = (string)routeValues["action"];
            var currentController = (string)routeValues["controller"];
            bool result = false;
            
            if (viewContext == null) return false;
            if (string.IsNullOrEmpty(actionName)) return false;

            if (routeValues.ContainsKey("controller") && (currentController == controllerName) && (currentAction == actionName))
            {
                result = true;
            }

            return result;
        }
    }
}