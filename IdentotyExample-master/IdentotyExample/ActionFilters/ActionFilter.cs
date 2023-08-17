using AlohaAPIExample.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;

namespace IdentotyExample.ActionFilter
{
    public class ActionFilter :  IResultFilter
    {
        private readonly ISocketCommunicationHelper _socketCommunicationHelper;
        private Stopwatch? stopwatch;
        public ActionFilter(ISocketCommunicationHelper socketCommunicationHelper)
        {
            _socketCommunicationHelper = socketCommunicationHelper;
        }
        public virtual void OnResultExecuted(ResultExecutedContext context)
        {
            stopwatch.Stop();
            var statusCode = context.HttpContext.Response.StatusCode;
            _socketCommunicationHelper.SendMessage($"Status code: {statusCode}\nTime elapsed: {stopwatch.ElapsedMilliseconds} ms");
        }

        public void OnResultExecuting(ResultExecutingContext context)
        {
            stopwatch = Stopwatch.StartNew();
            var method = context.HttpContext.Request.Method;
            var path = context.HttpContext.Request.Path;
            string result = $"\nMethod: {method}\nPath: {path} \nTime: {DateTime.Now}";
            _socketCommunicationHelper.SendMessage(result);
        }
    }
}