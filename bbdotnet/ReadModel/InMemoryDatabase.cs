using System;
using System.Collections.Generic;

namespace bbdotnet
{
    public static class InMemoryDatabase 
    {
        public readonly static Dictionary<Guid, TopicListItemDTO> ListItems = new Dictionary<Guid, TopicListItemDTO>();
    }
}