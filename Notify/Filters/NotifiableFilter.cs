using Microsoft.AspNetCore.Mvc.Filters;
using Notify.Extensions;

namespace Notify.Filters
{
    public class NotifiableFilter : IAsyncResultFilter
    {
        public async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next) =>
           await NotifiableFilterExtensions.NotifiableFilterProcessAsync(context, next);      

    }
}
