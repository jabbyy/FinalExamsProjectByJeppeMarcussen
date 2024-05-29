using Svendeprøve_projekt_BodyFitBlazor.Models;
using Svendeprøve_projekt_BodyFitBlazor.Repository;

namespace Svendeprøve_projekt_BodyFitBlazor.Services
{
    public class UserProfileService
    {
        private readonly IUserProfileRepository _userRepository;

        public UserProfileService(IUserProfileRepository userProfileRepository)
        {
            _userRepository = userProfileRepository;
        }

        public async Task<List<UserInfo>> GetProfile(string userEmail)
        {
            return await _userRepository.getAll(userEmail);
        }

        public async Task<UserInfo> GetSingle(int Id)
        {
            return await _userRepository.getSingle(Id);
        }

        public async Task DeleteProfile(int id)
        {
            await _userRepository.DeleteProfile(id);
        }

        public async Task CreateProfile(UserInfo userInfo)
        {
            await _userRepository.CreateItem(userInfo);
        }

        public async Task UpdateProfile(int Id, UserInfo userInfo)
        {
            await _userRepository.UpdateItem(Id, userInfo);
        }
    }
}
