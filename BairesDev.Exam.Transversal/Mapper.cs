using AutoMapper;
using BairesDev.Exam.Domain.Entity.Model;
using BairesDev.Exam.Domain.Model;
using BairesDev.Exam.Service.Model;
using Microsoft.AspNetCore.Mvc;

namespace BairesDev.Exam.Transversal
{
    public static class Maps
    {
        public static IMapper InitMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<PersonDTO, PersonInputModel>();
                cfg.CreateMap<PersonInputModel, PersonDTO>();

                cfg.CreateMap<FileOutputDTO, PersonOutputModel>();
                cfg.CreateMap<PersonOutputModel, FileOutputDTO>();

                cfg.CreateMap<Response<FileOutputDTO>, Response<PersonOutputModel>>();
                cfg.CreateMap< Response<PersonOutputModel>, Response<FileOutputDTO>>();
            });

            return config.CreateMapper();
        }
    }
}
