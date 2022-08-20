﻿using ErrorOr;

namespace bbdotnet.Application.Topics
{
    public static partial class Errors
    {
        public static class Topics
        { 
            public static readonly Error NotFound = Error.NotFound("Topic.NotFound", "Topic not found.");
        }
    }
}