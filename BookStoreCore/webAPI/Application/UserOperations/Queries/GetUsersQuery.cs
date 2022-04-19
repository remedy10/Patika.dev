using webAPI.DBOperations;
using webAPI.Entities;

namespace webAPI.Application.UserOperations.Queries
{
    public class GetUsersQuery
    {
        private readonly IBookStoreDbContext _context;

        public GetUsersQuery(IBookStoreDbContext context)
        {
            _context = context;
        }

        public List<GetUsersModel> Handle()
        {
            var AllUsers = _context.Users.OrderBy(x => x.Id).ToList<User>();
            List<GetUsersModel> UsersVM = new();
            AllUsers.ForEach(x => UsersVM.Add(x));
            return UsersVM;
        }
    }

    public class GetUsersModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string RefreshToken { get; set; }

        public static implicit operator GetUsersModel(User model) =>
            new GetUsersModel
            {
                Name = model.Name,
                Surname = model.Surname,
                Email = model.Email,
                RefreshToken=model.RefreshToken
            };
    }
}
