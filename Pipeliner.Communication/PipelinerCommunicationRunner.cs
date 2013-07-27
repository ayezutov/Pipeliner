using System.Web.Http;
using System.Web.Http.Filters;
using System.Web.Http.SelfHost;

namespace Pipeliner.Communication
{
    public class PipelinerCommunicationRunner
    {
        private HttpSelfHostServer server;

        public void Run()
        {
            var config = new HttpSelfHostConfiguration("http://localhost:8080");

            config.Routes.MapHttpRoute(
                "API Default", "api/{controller}/{id}",
                new { id = RouteParameter.Optional });


            server = new HttpSelfHostServer(config);
            server.Configuration.Filters.Add(new CorsFilterAttribute("*"));
            server.OpenAsync().Wait();
        }

        public void Stop()
        {
            server.CloseAsync().Wait();
        }
    }

    public class CorsFilterAttribute : ActionFilterAttribute
    {
        private readonly string urlRestriction;

        public CorsFilterAttribute(string urlRestriction)
        {
            this.urlRestriction = urlRestriction;
        }

        public bool AllowMultiple { get; private set; }

        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            base.OnActionExecuted(actionExecutedContext);
            actionExecutedContext.Response.Headers.Add("Access-Control-Allow-Origin", urlRestriction);
        }
    }
}