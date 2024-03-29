﻿using bbdotnet.Application.Abstractions.Repositories;
using bbdotnet.Domain;

namespace bbdotnet.Infrastructure.Persistence.Repositories;

internal class PostRepository : GenericRepositoryBase<Post, PostId>, IPostRepository
{
    public PostRepository(IServiceProvider serviceProvider) : base(serviceProvider) { }
}
