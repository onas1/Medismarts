using Microsoft.EntityFrameworkCore;
using Registration.Api.Data;
using Registration.Api.Entities;
using Registration.Api.Repositories.Abstractions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Registration.Api.Repositories.Implementations
{
    public class RegistrationRepository : IRegistrationRepository
    {
        private readonly DataContext _context;

        public RegistrationRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<UserRegistrationForm>> GetAllUsersAsync()
        {
            return await _context.UserRegistration.ToListAsync();
        }

        public async Task<UserRegistrationForm> GetByIdAsync(string id)
        {
            var user = await _context.UserRegistration.FirstAsync(x => x.Id == id);
            return user;
        }

        public async Task<bool> CreateAsync(UserRegistrationForm formModel)
        {
            await _context.UserRegistration.AddAsync(formModel);
            await _context.SaveChangesAsync();


            return true;
        }

        public async Task<bool> UpdateAsync(string id, UserRegistrationForm model)
        {
            var user = await GetByIdAsync(id);
            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            user.MiddleName = model.MiddleName;
            user.Email = model.Email;
            user.PhoneNumber = model.PhoneNumber;
            user.AddressOne = model.AddressOne;
            user.AddressTwo = model.AddressTwo;
            user.City = model.City;
            user.State = model.State;
            user.Country = model.Country;

            _context.UserRegistration.Update(user);

            if (await _context.SaveChangesAsync() >= 1)
                return true;

            return false;
        }

        public async Task<bool> DeleteAsync(UserRegistrationForm model)
        {
            _context.UserRegistration.Remove(model);
            return await _context.SaveChangesAsync() >= 1;

        }

    }
}
