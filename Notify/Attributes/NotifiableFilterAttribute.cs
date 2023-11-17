using Microsoft.AspNetCore.Mvc.Filters;
using Notify.Extensions;
using System.Diagnostics.CodeAnalysis;

namespace Notify.Attributes
{
    [ExcludeFromCodeCoverage]
    public class NotifiableFilterAttribute : ActionFilterAttribute
    {
        public override async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next) =>
            await NotifiableFilterExtensions.NotifiableFilterProcessAsync(context, next);
    }
}
