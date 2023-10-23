﻿using Application.Abstractions;
using Application.Posts.Commands;
using Domain.Models;
using MediatR;

namespace Application.Posts.CommandHandlers
{
    public class CreatePostHandler : IRequestHandler<CreatePost, Post>
    {
        private readonly IPostRepository _postRepository;

        public CreatePostHandler(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public async Task<Post> Handle(CreatePost request, CancellationToken cancellationToken)
        {

            return await _postRepository.CreatePostAsync(new Post
            {
                Content = request.PostContent
            });
        }
    }
}
