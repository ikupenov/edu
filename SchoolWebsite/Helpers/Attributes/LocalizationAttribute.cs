using System;
using System.Globalization;
using System.Threading;
using System.Web.Mvc;

namespace SchoolWebsite.Helpers.Attributes
{
    public class LocalizationAttribute : ActionFilterAttribute
    {
        private string defaultLanguage = "en";

        public LocalizationAttribute(string defaultLanguage)
        {
            this.defaultLanguage = defaultLanguage;
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            string lang = (string)filterContext.RouteData.Values["lang"] ?? this.defaultLanguage;
            if (lang != this.defaultLanguage)
            {
                try
                {
                    var culture = new CultureInfo(lang);

                    Thread.CurrentThread.CurrentCulture = culture;
                    Thread.CurrentThread.CurrentUICulture = culture;
                }
                catch (CultureNotFoundException)
                {
                    throw new NotSupportedException(String.Format("ERROR: Invalid language code '{0}'.", lang));
                }
            }
        }
    }
}
