using Svendeprøve_projekt_BodyFitBlazor.Codes;
using Svendeprøve_projekt_BodyFitBlazor.Models;
using Svendeprøve_projekt_BodyFitBlazor.Repository;

namespace Svendeprøve_projekt_BodyFitBlazor.Services
{
    public class UserProfileService
    {
        private readonly IUserProfileRepository _userRepository;
        private readonly AESEncryption _aes;

        public UserProfileService(IUserProfileRepository userProfileRepository, AESEncryption aesEncryption)
        {
            _userRepository = userProfileRepository;
            _aes = aesEncryption;
        }

        public async Task<List<UserInfo>> GetProfile(string userEmail)
        {
            var profiles = await _userRepository.getAll(userEmail);
            //DecryptUserProfiles(profiles);
            return profiles;
        }

        public async Task<UserInfo> GetSingle(int Id)
        {
            var profile = await _userRepository.getSingle(Id);
            //DecryptUserProfile(profile);
            return profile;
        }

        public async Task DeleteProfile(int id)
        {
            await _userRepository.DeleteProfile(id);
        }

        public async Task CreateProfile(UserInfo userInfo)
        {
            //EncryptUserInfo(userInfo);
            await _userRepository.CreateItem(userInfo);
        }

        public async Task UpdateProfile(int Id, UserInfo userInfo)
        {
            //EncryptUserInfo(userInfo);
            await _userRepository.UpdateItem(Id, userInfo);
        }

        public async Task<List<int>> GetAllUserIds()
        {
            return await _userRepository.GetAllUserIds();
        }

        public async Task<bool> CheckIfIdExists(int id)
        {
            List<int> userIds = await GetAllUserIds();
            return userIds.Contains(id);
        }

        //private void EncryptUserInfo(UserInfo userInfo)
        //{
        //    userInfo.FirstName = _aes.EncryptString(userInfo.FirstName);
        //    userInfo.LastName = _aes.EncryptString(userInfo.LastName);
        //    userInfo.City = _aes.EncryptString(userInfo.City);
        //}

        //private void DecryptUserProfiles(List<UserInfo> profiles)
        //{
        //    foreach (var profile in profiles)
        //    {
        //        DecryptUserProfile(profile);
        //    }
        //}

        //private void DecryptUserProfile(UserInfo profile)
        //{
        //    profile.FirstName = _aes.DecryptString(profile.FirstName);
        //    profile.LastName = _aes.DecryptString(profile.LastName);
        //    profile.City = _aes.DecryptString(profile.City);

        //}
    }
}
