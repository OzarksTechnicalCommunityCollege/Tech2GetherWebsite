using Tech2Gether_api.Data;
using Tech2Gether_api.IRepository;

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
    }
}
