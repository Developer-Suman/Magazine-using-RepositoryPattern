using Megazine_Practice.Helper;

namespace Megazine_Practice.ViewModel
{
    public class JournalIndexVmcs
    {
        public JournalViewModel JournalViewModel { get; set; }
        public List<JournalViewModel> JournalViewModels { get;set; }

        public PaginatedList<JournalViewModel> JournalPagedList { get;set; }
    }


}
