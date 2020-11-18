using Avalivre.Infrastructure.DTO.UserAuth;
using System.Threading.Tasks;

namespace Avalivre.Application.UserServices
{
    public interface IUserService
    {
        Task Register(RegisterUserDTO dto);
        Task<LoginUserResponseDTO> Login(LoginUserDTO dto);
    }
}
