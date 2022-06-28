using AutoMapper;
using Los_Pollos_Hermanos.ApiModels;
using Los_Pollos_Hermanos.Helpers.Models;
using Los_Pollos_Hermanos.Models;
using Los_Pollos_Hermanos.Repositories.Interfaces;
using Los_Pollos_Hermanos.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace Los_Pollos_Hermanos.Services
{
    public class UserService : BaseService<UserApiModel, User>, IUserService
    {
        private readonly UserManager<User> _userManager;
        private readonly IUserRepository _userRepository;
        public UserService(UserManager<User> userManager, IUserRepository userRepository)
        {
            _userManager = userManager;
            _userRepository = userRepository;
        }
        public  async Task<UserApiModel> GetUserByUserEmail(string email)
        {
            var user = await _userManager.FindByNameAsync(email);
            if (user == null) throw new ApiException("find user by this email");
            return _mapper.Map<UserApiModel>(user);

        }
    }
}
