using Application.Abstractions;
using Application.Posts.Commands;
using MediatR;

namespace Application.Posts.CommandHandlers
{
    public class DeletePostHandler : IRequestHandler<DeletePost>
    {
        private readonly IPostRepository _postRepository;

        public DeletePostHandler(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public async Task Handle(DeletePost request, CancellationToken cancellationToken)
        {
            await _postRepository.DeletePostAsync(request.PostId);
        }
    }
}
