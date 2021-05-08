using System.Collections.Generic;
using System.Threading.Tasks;
using DTOs;
using entities;

namespace Interfaces
{
    public interface IUserRepository
    {
        void Update(AppUser user);
        Task<bool> SaveAllAsync();
        Task<IEnumerable<AppUser>> GetUsersAsync();
        Task<AppUser> GetUserByIdAsync(int id);
        Task<AppUser> GetUserByUsernameAsync(string username);
        Task<IEnumerable<MemberDato>> GetMembersAsync();
        Task<MemberDato> GetMemberAsync(string username);

        
       
    }
} 