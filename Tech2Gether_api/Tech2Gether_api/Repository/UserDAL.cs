using Tech2Gether_api.Data;
using Tech2Gether_api.IRepository;
using Tech2Gether_api.Models;

namespace Tech2Gether_api.Repository
{
    public class UserDAL : IUser
    {
        private readonly T2TContext _context;

        private readonly IConfiguration _config;

        public UserDAL(T2TContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
        }

        #region Get All Users Method
        public List<User> GetAllUsers()
        {
            List<User> userList = new List<User>();

            try
            {
                var users = _context.Users.ToList();

                if (userList != null)
                {
                    foreach (var user in users)
                    {
                        userList.Add(new User()
                        {
                            UserId = user.UserId,
                            FirstName = user.FirstName,
                            LastName = user.LastName,
                            Email = user.Email,
                            Phone = user.Phone,
                            MemId = user.MemId,
                            EmFirstName = user.EmFirstName,
                            EmLastName = user.EmLastName,
                            EmRelationship = user.EmRelationship,
                            EmPhone = user.EmPhone,
                            UserGithub = user.UserGithub,
                            UserLinkedin = user.UserLinkedin,
                            Pronouns = user.Pronouns,
                            PreName = user.PreName,
                            MembershipDef = user.MembershipDef,
                            Addresses = user.Addresses,
                            UserOrgs = user.UserOrgs,
                            Attendances = user.Attendances,
                            UserTeams = user.UserTeams
                        });
                    }
                }
                else
                {
                    Console.WriteLine("No users found");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving users: " + ex.Message);
            }
            return userList;
        }
        #endregion

        #region Register User method 
        public async Task<RegisterUserResponseModel> RegisterUser(User user)
        {
            RegisterUserResponseModel res = new RegisterUserResponseModel();

            try
            {
                if (user != null)
                {
                    User newUser = new User();
                    newUser.Email = user.Email;

                    Login newUserLogin = new Login();

                    newUserLogin.PasswordHash = user.Login.PasswordHash;
                    newUserLogin.PasswordSalt = user.Login.PasswordSalt;
                    newUserLogin.Username = user.Email;

                    newUser.Login = newUserLogin;

                    _context.Users.Add(newUser);
                    _context.Logins.Add(newUserLogin);
                    _context.SaveChanges();

                    res.Status = true;
                    res.StatusCode = 200;
                    res.Message = "User registered successfully";
                    res.user = newUser;
                }
                else
                {
                    res.Status = false;
                    res.StatusCode = 400;
                    res.Message = "Invalid user data";
                }
            } catch (Exception ex)
            {
                throw new Exception("Error retrieving users: " + ex.Message);
            }

            return res;
        }
        #endregion
    }
}
