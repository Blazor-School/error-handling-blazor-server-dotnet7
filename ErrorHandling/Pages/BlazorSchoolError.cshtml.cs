using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

namespace ComponentAndHttpErrorsHandling.Pages;
[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
[IgnoreAntiforgeryToken]
public class BlazorSchoolError : PageModel
{
    public string? RequestId { get; set; }

    public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);

    private readonly ILogger<BlazorSchoolError> _logger;

    public BlazorSchoolError(ILogger<BlazorSchoolError> logger)
    {
        _logger = logger;
    }

    public void OnGet() => RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier;

    [SuppressMessage("Reliability", "CA2017:Parameter count mismatch", Justification = "<Pending>")]
    public void OnPost()
    {
        var exceptionHandler = HttpContext.Features.Get<IExceptionHandlerFeature>();
        
        if (exceptionHandler is not null)
        {
            _logger.LogCritical("You can log the error with the detailed message in the exceptionHandler {exceptionHandler.Error.Message}");
            _logger.LogCritical("You can log the error with the stack trace in the exceptionHandler {exceptionHandler.Error.StackTrace}");
        }
    }
}
