using System;
using System.Text;
using System.Web.Mvc;

namespace MvcChallenge.Filters
{
    public class ErrorLoggerAttribute : HandleErrorAttribute
    {
        protected static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public override void OnException(ExceptionContext filterContext)
        {
            LogError(filterContext);
            base.OnException(filterContext);
        }

        public void LogError(ExceptionContext filterContext)
        {
          
            var builder = new StringBuilder();
            builder
                .AppendLine("----------------------------------------")
                .AppendLine(DateTime.Now.ToString())
                .AppendFormat("Source:\t{0}", filterContext.Exception.Source)
                .AppendLine()
                .AppendFormat("Target:\t{0}", filterContext.Exception.TargetSite)
                .AppendLine()
                .AppendFormat("Type:\t{0}", filterContext.Exception.GetType().Name)
                .AppendLine()
                .AppendFormat("Message:\t{0}", filterContext.Exception.Message)
                .AppendLine()
                .AppendFormat("Stack:\t{0}", filterContext.Exception.StackTrace)
                .AppendLine();

            log.Error(builder);

            //var filePath = filterContext.HttpContext.Server.MapPath("~/App_Data/Error.log");

            //using (var writer = File.AppendText(filePath))
            //{
            //    writer.Write(builder.ToString());
            //    writer.Flush();
            //}
        }
    }
}