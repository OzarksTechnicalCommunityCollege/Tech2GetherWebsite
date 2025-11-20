using Tech2Gether_api.Data;

namespace Tech2Gether_api.Models
{
    public class GetAllUsersResponseModel
    {
        public bool Status { get; set; }
        public int StatusCode { get; set; }
        public string? Message { get; set; } = null;
        public List<User>? userList { get; set; } = null;
    }
}
