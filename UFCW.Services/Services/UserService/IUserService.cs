using System;
using System.Threading.Tasks;
using UFCW.Services.Models.User;

namespace UFCW.Services.Services
{
    public interface IUserService
    {
        Task<LoginResponse> LoginUser(String username, string password); //Fetch user login details
	}
}
