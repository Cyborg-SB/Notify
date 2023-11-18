using Microsoft.AspNetCore.Mvc.Filters;
using Notify.Extensions;
using System.Diagnostics.CodeAnalysis;

namespace Notify.Filters
{
    [ExcludeFromCodeCoverage]
    public class NotifiableFilter : IAsyncResultFilter
    {
        public async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next) =>
           await NotifiableFilterExtensions.NotifiableFilterProcessAsync(context, next);      

    }
}
