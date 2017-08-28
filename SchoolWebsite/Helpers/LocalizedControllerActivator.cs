using System;
using System.Globalization;
using System.Threading;
using System.Web.Mvc;
using System.Web.Routing;

namespace SchoolWebsite.Helpers
{
    public class LocalizedControllerActivator : IControllerActivator
    {
        private string defaultLanguage = "en";

        public IController Create(RequestContext requestContext, Type controllerType)
        {
            var lang = (string)requestContext.RouteData.Values["lang"] ?? this.defaultLanguage;

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

            return DependencyResolver.Current.GetService(controllerType) as IController;
        }
    }
}
