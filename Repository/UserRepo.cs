using Microsoft.EntityFrameworkCore;
using Svendeprøve_projekt_BodyFitBlazor.Data;
using Svendeprøve_projekt_BodyFitBlazor.Models;

namespace Svendeprøve_projekt_BodyFitBlazor.Repository
{
    public interface IUserProfileRepository
    {
        Task<List<UserInfo>> getAll(string UserId);
        Task<UserInfo> getSingle(int Id);
        Task<UserInfo> DeleteProfile(int Id);
        Task<UserInfo> CreateItem(UserInfo userInfo);
        Task<UserInfo> UpdateItem(int Id, UserInfo userInfo);
        Task<List<int>> GetAllUserIds();
    }

    public class UserRepo : IUserProfileRepository
    {
        private readonly DatabaseContext _context;

        public UserRepo(DatabaseContext context)
        {
            _context = context;
        }
        public async Task<List<UserInfo>> getAll(string UserId)
        {
            List<UserInfo> UserList = await _context.Users.Where(s => s.UserEmail == UserId).ToListAsync();      // .Users.Where(s => s.UserEmail == UserId).ToListAsync();
            return UserList;
        }
        public async Task<UserInfo> getSingle(int Id)
        {
            return await _context.Users.FindAsync(Id);
        }
        public async Task<UserInfo> DeleteProfile(int Id)
        {
            var item = _context.Users.Find(Id);
            if (item != null) { _context.Users.Remove(item); await _context.SaveChangesAsync(); }
            return item;
        }

        public async Task<UserInfo> CreateItem(UserInfo userInfo)
        {
            try
            {
                _context.Users.Add(userInfo);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }
            return userInfo;
        }
        public async Task<UserInfo> UpdateItem(int Id, UserInfo userInfo)
        {
            _context.Entry(userInfo).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return userInfo;
        }
        public async Task<List<int>> GetAllUserIds()
        {
            List<int> userIds = await _context.Users.Select(u => u.Id).ToListAsync();
            return userIds;
        }


    }
}
