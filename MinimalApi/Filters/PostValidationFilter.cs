using Domain.Models;

namespace MinimalApi.Filters
{
    public class PostValidationFilter : IEndpointFilter
    {
        public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
        {
            var post = context.GetArgument<Post>(1);

            if (string.IsNullOrWhiteSpace(post.Content)) return await Task.FromResult(Results.BadRequest("Post not valid."));

            return await next(context);
        }
    }
}
