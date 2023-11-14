using Microsoft.AspNetCore.Mvc.Filters;
using Notify.Extensions;

namespace Notify.Attributes
{
    public class NotifiableFilterAttribute : ActionFilterAttribute
    {
        public override async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next) =>
            await NotifiableFilterExtensions.NotifiableFilterProcessAsync(context, next);
    }
}
