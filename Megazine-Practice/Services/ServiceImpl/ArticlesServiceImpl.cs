using AutoMapper;
using Megazine_Practice.Models;
using Megazine_Practice.Repository.RepoImplementation;
using Megazine_Practice.Services.ServiceInterface;
using Megazine_Practice.ViewModel;

namespace Megazine_Practice.Services.ServiceImpl
{
    public class ArticlesServiceImpl : IArticlesService
    {
        private readonly UnitOfWorkRepoImpl _unitOfWorkImpl;
        private readonly IMapper _mapper; 
        public ArticlesServiceImpl(UnitOfWorkRepoImpl unitOfWorkImpl, IMapper mapper)
        {
            _unitOfWorkImpl = unitOfWorkImpl;
            _mapper = mapper;

        }
   
        public List<ArticlesViewModel> GetAll()
        {
            try
            {
                var articlesModel = _unitOfWorkImpl.Repository<Articles>().getAll();
                List<ArticlesViewModel> articlesViewModels = Mapping(articlesModel);
                return articlesViewModels;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        private List<ArticlesViewModel> Mapping(List<Articles> articlesModel)
        {
            List<ArticlesViewModel> articlesViewModels = new List<ArticlesViewModel>();
            foreach (var items in articlesModel)
            {
                var articleViewModel = _mapper.Map<ArticlesViewModel>(items);
                articlesViewModels.Add(articleViewModel);

            }
            return articlesViewModels;

        }


        public void delete(ArticlesViewModel articlesViewModel)
        {
            try
            {
                Articles articles = new Articles();
                var articlesToBeDeleted = _mapper.Map<Articles>(articlesViewModel);
                _unitOfWorkImpl.Repository<Articles>().delete(articlesToBeDeleted);
                //var articlesToBeDeleted = _unitOfWorkImpl.Repository<Articles>().getById(Articles_Id);
                //_unitOfWorkImpl.Repository<Articles>().delete(articlesToBeDeleted);
                _unitOfWorkImpl.Commit();

            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }



        public ArticlesViewModel GetById(int Articles_Id)
        {
            try
            {
                var articles = _unitOfWorkImpl.Repository<Articles>().getById(Articles_Id);
                ArticlesViewModel articlesVM = _mapper.Map<ArticlesViewModel>(articles);
                return articlesVM;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public void save(ArticlesViewModel articlesViewModel)
        {
            try
            {
                Articles articles = new Articles();
                var ArticlesToBeInserted = _mapper.Map<Articles>(articlesViewModel);
                _unitOfWorkImpl.Repository<Articles>().insert(ArticlesToBeInserted);
                _unitOfWorkImpl.Commit();

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public void update(ArticlesViewModel articlesViewModel)
        {
            try
            {
                Articles articles = new Articles();
                var ArticlesTobeUpdated = _mapper.Map<Articles>(articlesViewModel);
                _unitOfWorkImpl.Repository<Articles>().update(ArticlesTobeUpdated);
                _unitOfWorkImpl.Commit();

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
    }
}
