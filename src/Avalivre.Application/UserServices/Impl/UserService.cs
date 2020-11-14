using Avalivre.Domain.Users;
using Avalivre.Infrastructure.DTO.UserAuth;
using System.Threading.Tasks;

namespace Avalivre.Application.UserServices.Impl
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            this._userRepository = userRepository;
        }
        public async Task Register(RegisterUserDTO dto)
        {
            var user = new User(dto.Name, dto.Email, dto.Password);

            _userRepository.Insert(user);

            await _uow.SaveChangesAsync();
        }
    }
}
