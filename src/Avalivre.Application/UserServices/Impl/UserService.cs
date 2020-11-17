using Avalivre.Domain.Users;
using Avalivre.Infrastructure.DTO.Configuration;
using Avalivre.Infrastructure.DTO.UserAuth;
using Avalivre.Infrastructure.Persistence.UnitOfWork;
using Avalivre.Infrastructure.Security;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;
using Yaba.Tools.Validations;

namespace Avalivre.Application.UserServices.Impl
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IOptions<JwtConfig> _options;
        private readonly UnitOfWork _uow;

        public UserService(
            UnitOfWork uow,
            IOptions<JwtConfig> options,
            IUserRepository userRepository)
        {
            this._userRepository = userRepository;
            this._options = options;
            this._uow = uow;
        }

        public async Task<LoginUserResponseDTO> Login(LoginUserDTO dto)
        {
            var user = await _userRepository.GetByEmail(dto.Email);

            Validate.NotNull(user, "User not found");

            var passwordIsValid = SecurityManager.VerifyPasswordPbkdf2(dto.Password, user.Password);

            Validate.IsTrue(passwordIsValid, "Password is incorrect");

            return new LoginUserResponseDTO()
            {
                Message = "Login realizado com sucesso",
                Token = JwtHandler.GenerateToken(_options.Value.SecretKey, user.Id, user.Name)
            };
        }

        public async Task Register(RegisterUserDTO dto)
        {
            var user = await _userRepository.GetByEmail(dto.Email);
            Validate.IsTrue(user is null, "User already exists");

            dto.Password = EncryptPassword(dto.Password);

            user = new User(dto.Name, dto.Email, dto.Password);

            _userRepository.Insert(user);

            await _uow.CommitAsync();
        }

        #region Priv Methods
        private string EncryptPassword(string password)
        {
            return SecurityManager.GeneratePbkdf2Hash(password);
        }
        #endregion
    }
}
