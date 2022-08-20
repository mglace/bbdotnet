using bbdotnet.Application;

namespace bbdotnet.WebApi.Models
{
    public record PagedRequest
    {
        public int PageNumber { get; init; } = 1;

        private int _pageSize = Settings.DefaultPageSize;

        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = Math.Min(value == default ? Settings.DefaultPageSize : value, Settings.MaxPageSize);
        }
    }
}
