using Microsoft.AspNetCore.Mvc.Filters;

namespace BlockChain.Api.Filters
{
    public class LoggingFilter : IActionFilter
    {
        private readonly ILogger<LoggingFilter> _logger;
        public LoggingFilter(ILogger<LoggingFilter> logger)
        {
            _logger = logger;
        }
        public void OnActionExecuting(ActionExecutingContext context)
        {
            var request = context.HttpContext.Request;
            _logger.LogInformation("Request: RequestMethod {0}, RequestPAth {1}, Query paramteters {2} " , request.Method, request.Path, request.QueryString);
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {
            var response = context.HttpContext.Response;
            _logger.LogInformation("Response: StatusCode {0}" , response.StatusCode);
        }
    }
}
