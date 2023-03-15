using AutoMapper;
using Megazine_Practice.Models;
using Megazine_Practice.Repository.RepoImplementation;
using Megazine_Practice.Services.ServiceInterface;
using Megazine_Practice.ViewModel;

namespace Megazine_Practice.Services.ServiceImpl
{

    public class NewsServiceImpl : INewsService
    {
        private readonly UnitOfWorkRepoImpl _unitOfWorkRepoImpl;
        private readonly IMapper _mapper;
        private IWebHostEnvironment _webHostEnvironment;

        public NewsServiceImpl(UnitOfWorkRepoImpl unitOfWorkRepoImpl, IMapper mapper, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWorkRepoImpl = unitOfWorkRepoImpl;
            _mapper = mapper;
            _webHostEnvironment = webHostEnvironment;
        }

        public void delete(NewsViewModel newsViewModel)
        {
            try
            {
                News news = new News();
                var newsToBeDeleted = _mapper.Map<News>(newsViewModel);
                _unitOfWorkRepoImpl.Repository<News>().delete(newsToBeDeleted);
                _unitOfWorkRepoImpl.Commit();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        public List<NewsViewModel> GetAll()
        {
            try
            {
                var newsModel = _unitOfWorkRepoImpl.Repository<News>().getAll();
                List<NewsViewModel> newsViewModel = Mapping(newsModel);
                return newsViewModel;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        private List<NewsViewModel> Mapping(List<News> newsModel)
        {
            List<NewsViewModel> newsViewModels = new List<NewsViewModel>();

            foreach(var item in newsModel)
            {
                var NewsViewModel = _mapper.Map<NewsViewModel>(item);
                newsViewModels.Add(NewsViewModel);

            }
            return newsViewModels;
        }

        public NewsViewModel GetById(int News_Id)
        {
            try
            {
                var news = _unitOfWorkRepoImpl.Repository<News>().getById(News_Id);
                NewsViewModel newsVm = _mapper.Map<NewsViewModel>(news);
                return newsVm;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public void save(NewsViewModel newsViewModel)
        {
            try
            {
                newsViewModel.NewsImage = UploadFile(newsViewModel);
                var newsToBeInserted = _mapper.Map<News>(newsViewModel);
                _unitOfWorkRepoImpl.Repository<News>().insert(newsToBeInserted);
                _unitOfWorkRepoImpl.Commit();

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        private string UploadFile(NewsViewModel newsViewModel)
        {
            string filename = null;
            if(newsViewModel.File != null)
            {
                string uploadDir = Path.Combine(_webHostEnvironment.WebRootPath, "Images");
                filename = Guid.NewGuid().ToString() + " " + newsViewModel.File.FileName;
                string filePath = Path.Combine(uploadDir, filename);

                using(var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    newsViewModel.File.CopyTo(fileStream);
                }

            }
            else
            {
                filename = newsViewModel.NewsImage;
            }
            return filename;
        }

        public void update(NewsViewModel newsViewModel)
        {
            try
            {
                newsViewModel.NewsImage = UploadFile(newsViewModel);
                var JournalToBeUpdated = _mapper.Map<News>(newsViewModel);
                _unitOfWorkRepoImpl.Repository<News>().update(JournalToBeUpdated);
                _unitOfWorkRepoImpl.Commit();

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
    }
}
