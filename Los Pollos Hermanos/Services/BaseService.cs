using AutoMapper;
using Los_Pollos_Hermanos.ApiModels;
using Los_Pollos_Hermanos.Models;
using Los_Pollos_Hermanos.Repositories.Interfaces;
using Los_Pollos_Hermanos.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
;
namespace Los_Pollos_Hermanos.Services
{
    public class BaseService<TApiModel, TModel> : IBaseService<TApiModel> where TModel : class, IBaseModel where TApiModel : class
    {
        protected readonly IMapper _mapper;

    }
}
