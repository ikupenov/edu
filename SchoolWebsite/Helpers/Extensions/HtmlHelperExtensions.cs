using System.Globalization;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace SchoolWebsite.Helpers.Extensions
{
    public static class HtmlHelperExtensions
    {
        public static IHtmlString ActionLink(
            this HtmlHelper helper,
            string linkText,
            string actionName,
            string controllerName,
            object routeValues,
            string htmlAttributes,
            CultureInfo cultureInfo)
        {
            if (cultureInfo == null)
            {
                cultureInfo = CultureInfo.CurrentCulture;
            }

            string localizedControllerName = string.Format("{0}/{1}", cultureInfo.TwoLetterISOLanguageName, controllerName);

            var actionLink = helper.ActionLink(
                linkText,
                actionName,
                localizedControllerName,
                routeValues,
                htmlAttributes);

            return actionLink;
        }
    }
}
