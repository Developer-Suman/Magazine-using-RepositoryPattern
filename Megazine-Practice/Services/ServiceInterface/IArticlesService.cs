using Megazine_Practice.ViewModel;

namespace Megazine_Practice.Services.ServiceInterface
{
    public interface IArticlesService
    {
        void save(ArticlesViewModel articlesViewModel);

        void update(ArticlesViewModel articlesViewModel);

        ArticlesViewModel GetById(int Articles_Id);

        List<ArticlesViewModel> GetAll();

        void delete(ArticlesViewModel articlesViewModel);
    }
}
