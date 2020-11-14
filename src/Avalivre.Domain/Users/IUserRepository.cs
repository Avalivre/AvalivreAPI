using System;

namespace Avalivre.Domain.Users
{
    public interface IUserRepository
    {
        void Insert(User entity);
    }
}
