using Avalivre.Domain.Users;
using Avalivre.Infrastructure.DTO.UserAuth;
using Avalivre.Infrastructure.Persistence.UnitOfWork;
using System.Threading.Tasks;

namespace Avalivre.Application.UserServices.Impl
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly UnitOfWork _uow;

        public UserService(
            UnitOfWork uow,
            IUserRepository userRepository)
        {
            this._userRepository = userRepository;
            this._uow = uow;
        }
        public async Task Register(RegisterUserDTO dto)
        {
            var user = new User(dto.Name, dto.Email, dto.Password);

            _userRepository.Insert(user);

            await _uow.CommitAsync();
        }
    }
}
