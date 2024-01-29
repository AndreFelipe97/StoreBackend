using System.Text;
using Api.Domain.Entities;
using Api.Domain.Interfaces;
using Api.Domain.Interfaces.Services.Users;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace Api.Service.Services
{
    public class UserService(IRepository<UserEntity> repository) : IUserService
    {
        private IRepository<UserEntity> _repository = repository;

        public async Task<IEnumerable<UserEntity>> GetAll()
        {
            return await _repository.SelectAsync();
        }
        public async Task<UserEntity> Post(UserEntity user)
        {
            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: user.Password,
                salt: Encoding.UTF8.GetBytes("b784e6514020bb8aa3937c0d34e0410b"),
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 100000,
                numBytesRequested: 256 / 8));

            user.Password = hashed;

            return await _repository.InsertAsync(user);
        }
        public async Task<UserEntity?> Get(int id)
        {
            return await _repository.SelectAsync(id);
        }
        public async Task<UserEntity?> Put(UserEntity user)
        {
            return await _repository.UpdateAsync(user);
        }
        public async Task<bool> Delete(int id)
        {
            return await _repository.DeleteAsync(id);
        }
    }
}
