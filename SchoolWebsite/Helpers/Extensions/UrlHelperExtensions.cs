using System.Globalization;
using System.Web.Mvc;

namespace SchoolWebsite.Helpers.Extensions
{
    public static class UrlHelperExtensions
    {
        public static string Action(
            this UrlHelper helper,
            string actionName,
            string controllerName,
            object routeValues,
            CultureInfo cultureInfo)
        {
            if (cultureInfo == null)
            {
                cultureInfo = CultureInfo.CurrentCulture;
            }

            var localizedControllerName = string.Format("{0}/{1}", cultureInfo.TwoLetterISOLanguageName, controllerName);

            var action = helper.Action(
                actionName,
                localizedControllerName,
                routeValues);

            return action;
        }
    }
}
