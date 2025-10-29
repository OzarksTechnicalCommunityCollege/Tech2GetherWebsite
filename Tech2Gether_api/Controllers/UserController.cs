using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tech2Gether_api.Data;
using Tech2Gether_api.IRepository;
using Tech2Gether_api.Models;
using Tech2Gether_api.Repository;

namespace Tech2Gether_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUser repository;

        // Constructor - inject dependencies instead of creating them
        public UserController(T2TContext context, IConfiguration config)
        {
            repository = new UserDAL(context, config);
        }


        #region Get All Users Method
        // Get: api/users
        [HttpGet("GetAllUsers", Name = "GetAllUsers")]
        public async Task<GetAllUsersResponseModel> GetAllUsers()
        {
            GetAllUsersResponseModel response = new GetAllUsersResponseModel();

            List<User> users = new List<User>();

            try
            {
                users = await Task.Run(() => repository.GetAllUsers());

                if (users.Count != 0)
                {
                    response.Status = true;
                    response.StatusCode = 200;
                    response.userList = users;
                }
                else
                {
                    //there has been an error
                    response.Status = false;
                    response.Message = "Get Failed";
                    response.StatusCode = 0;
                }
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = "Get Failed";
                response.StatusCode = 0;
                //there has been an error
                Console.WriteLine(ex.Message);
            }
            return response;
        }
        #endregion
    }
}
