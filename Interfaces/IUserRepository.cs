using System.Collections.Generic;
using System.Threading.Tasks;
using DTOs;
using entities;
using Helpers;

namespace Interfaces
{
    public interface IUserRepository
    {
        void Update(AppUser user);
        Task<bool> SaveAllAsync();
        Task<IEnumerable<AppUser>> GetUsersAsync();
        Task<AppUser> GetUserByIdAsync(int id);
        Task<AppUser> GetUserByUsernameAsync(string username);
        Task<PagedList<MemberDato>> GetMembersAsync(UserParams userParams);
        Task<MemberDato> GetMemberAsync(string username);

        
       
    }
} 