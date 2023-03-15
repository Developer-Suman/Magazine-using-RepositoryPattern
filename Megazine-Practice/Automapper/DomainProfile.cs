using AutoMapper;
using Megazine_Practice.Models;
using Megazine_Practice.Services.ServiceImpl;
using Megazine_Practice.ViewModel;

namespace Megazine_Practice.Automapper
{
    public class DomainProfile: Profile
    {
        public DomainProfile()
        {
            CreateMap<Articles, ArticlesViewModel>().ReverseMap();
            CreateMap<Articles, ArticlesIndexVm>().ReverseMap();
            CreateMap<Journal,JournalViewModel>().ReverseMap();
            CreateMap<Journal, JournalIndexVmcs>().ReverseMap();
            CreateMap<Employee, EmployeeViewModel>().ReverseMap();
            CreateMap<Employee, EmployeeIndexVm>().ReverseMap();
            CreateMap<News, NewsViewModel>().ReverseMap();
            CreateMap<News, NewsIndexVm>().ReverseMap();


        }
    }
}
