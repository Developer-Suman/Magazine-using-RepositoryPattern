using AutoMapper;
using Megazine_Practice.Models;
using Megazine_Practice.Repository.RepoImplementation;
using Megazine_Practice.Repository.RepoInterface;
using Megazine_Practice.Services.ServiceInterface;
using Megazine_Practice.ViewModel;

namespace Megazine_Practice.Services.ServiceImpl
{
    public class JournalServiceImpl : IJournalServicecs
    {
        private readonly UnitOfWorkRepoImpl _unitOfWorkRepoImpl;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public JournalServiceImpl(UnitOfWorkRepoImpl unitOfWorkRepoImpl, IMapper mapper, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWorkRepoImpl = unitOfWorkRepoImpl;
            _webHostEnvironment= webHostEnvironment;
            _mapper = mapper;
        }

        public void delete(JournalViewModel journalViewModel)
        {
            try
            {
                Journal journal = new Journal();
                var JournalToBeDeleted = _mapper.Map<Journal>(journalViewModel);
                _unitOfWorkRepoImpl.Repository<Journal>().delete(JournalToBeDeleted);
                _unitOfWorkRepoImpl.Commit();

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        public List<JournalViewModel> GetAll()
        {
            try
            {
                var journalModels = _unitOfWorkRepoImpl.Repository<Journal>().getAll();
                List<JournalViewModel> journalViewModel = Mapping(journalModels); 
                return journalViewModel;

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        private List<JournalViewModel> Mapping(List<Journal> journalModels)
        {
            List<JournalViewModel> journalViewModels = new List<JournalViewModel>();

            foreach (var items in journalModels)
            {
                var journalViewModel = _mapper.Map<JournalViewModel>(items);
                journalViewModels.Add(journalViewModel);

            }
            return journalViewModels;
        }

        public JournalViewModel GetById(int Journal_Id)
        {
            try
            {
                var journal = _unitOfWorkRepoImpl.Repository<Journal>().getById(Journal_Id);
                JournalViewModel journalVM = _mapper.Map<JournalViewModel>(journal);
                return journalVM;

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public void save(JournalViewModel journalViewModel)
        {
            try
            {
                journalViewModel.JournalImage = UploadFile(journalViewModel);
                var JournalToBeInserted = _mapper.Map<Journal>(journalViewModel);
                _unitOfWorkRepoImpl.Repository<Journal>().insert(JournalToBeInserted);
                _unitOfWorkRepoImpl.Commit();

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
        private string UploadFile(JournalViewModel journalViewModel)
        {
            string fileName = null;
            if(journalViewModel.File != null)
            {
                string uploadDir = Path.Combine(_webHostEnvironment.WebRootPath, "Images");
                fileName = Guid.NewGuid().ToString() + "-" + journalViewModel.File.FileName;
                string filePath = Path.Combine(uploadDir, fileName);

                using(var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    journalViewModel.File.CopyTo(fileStream);
                }
            }
            else
            {
                
                fileName = journalViewModel.JournalImage;
            }
            return fileName;
        }




        public void update(JournalViewModel journalViewModel)
        {
            try
            {
                journalViewModel.JournalImage = UploadFile(journalViewModel);
                Journal journal = new Journal();
                var JournalToBeUpdated = _mapper.Map<Journal>(journalViewModel);
                _unitOfWorkRepoImpl.Repository<Journal>().update(JournalToBeUpdated);
                _unitOfWorkRepoImpl.Commit() ;

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
    }
}
