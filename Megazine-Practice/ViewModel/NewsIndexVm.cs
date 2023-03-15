using Megazine_Practice.Helper;

namespace Megazine_Practice.ViewModel
{
    public class NewsIndexVm
    {
        public NewsViewModel NewsViewModel { get; set; }
        public List<NewsViewModel> NewsViewModels { get; set; }

        public PaginatedList<NewsViewModel> NewsPagedList { get; set; }
    }
}
