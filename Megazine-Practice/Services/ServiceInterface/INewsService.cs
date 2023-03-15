using Megazine_Practice.ViewModel;

namespace Megazine_Practice.Services.ServiceInterface
{
    public interface INewsService
    {
        void save(NewsViewModel newsViewModel);

        void update(NewsViewModel newsViewModel);
        void delete(NewsViewModel newsViewModel);

        List<NewsViewModel> GetAll();
        NewsViewModel GetById(int News_Id);
    }
}
