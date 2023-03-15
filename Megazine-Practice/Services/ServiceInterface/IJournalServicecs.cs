using Megazine_Practice.ViewModel;

namespace Megazine_Practice.Services.ServiceInterface
{
    public interface IJournalServicecs
    {
        void save(JournalViewModel journalViewModel);
        void update(JournalViewModel journalViewModel);
        List<JournalViewModel> GetAll();
        JournalViewModel GetById(int Journal_Id);
        void delete(JournalViewModel journalViewModel);
    }
}
