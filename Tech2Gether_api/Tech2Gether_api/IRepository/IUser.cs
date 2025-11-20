using Tech2Gether_api.Data;

namespace Tech2Gether_api.IRepository

{
    public interface IUser
    {
        /// <summary>
        /// Returns a list of all users in the database.
        /// </summary>
        List<User> GetAllUsers();
    }
}
