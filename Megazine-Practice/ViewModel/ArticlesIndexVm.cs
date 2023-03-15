using Megazine_Practice.Helper;

namespace Megazine_Practice.ViewModel
{
    public class ArticlesIndexVm
    {
        public ArticlesViewModel ArticlesViewModel { get; set; }
        public List<ArticlesViewModel> ArticlesViewModels { get; set; }
        
        public PaginatedList<ArticlesViewModel> ArticlesPagedList { get; set; }
    }
}
