using Los_Pollos_Hermanos.Models;
using System;
using AutoMapper;
using Los_Pollos_Hermanos.ApiModels.Pagination.Models;
using Los_Pollos_Hermanos.ApiModels;
using Los_Pollos_Hermanos.Services.Interfaces;

namespace Los_Pollos_Hermanos.Services
{
    public class UserService : BaseService<UserApiModel, User>, IUserService
    {

    }
}
