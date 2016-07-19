using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.OData.Builder;
using System.Web.OData.Extensions;
using VMTP.Task.Models;

namespace VMTP.Task.Web
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Конфигурация и службы веб-API

            // Маршруты веб-API
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

			ODataModelBuilder builder = new ODataConventionModelBuilder();
			builder.EntitySet<Operation>("Operations");
			/*builder.EntitySet<UserDto>("Users");
			builder.EntitySet<UserGroupDto>("UserGroups");*/

			config.EnableEnumPrefixFree(true);

			config.MapODataServiceRoute(
				routeName: "ODataRoute",
				routePrefix: null,
				model: builder.GetEdmModel());
        }
    }
}
