using Registration.Api.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Registration.Api.Repositories.Abstractions
{
    public interface IRegistrationRepository
    {
        Task<IEnumerable<UserRegistrationForm>> GetAllUsersAsync();
        Task<bool> CreateAsync(UserRegistrationForm registrationForm);
        Task<bool> UpdateAsync(string id, UserRegistrationForm registrationForm);
        Task<bool> DeleteAsync(UserRegistrationForm registrationForm);
        Task<UserRegistrationForm> GetByIdAsync(string id);
    }
}
