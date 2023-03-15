﻿using bbdotnet.Domain.Shared;

namespace bbdotnet.Application;

public static partial class Errors
{
    public static class Topics
    { 
        public static readonly Error NotFound = new("Topic.NotFound", "Topic not found.");
    }
}
