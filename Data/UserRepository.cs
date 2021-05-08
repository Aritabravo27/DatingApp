using System.Collections.Generic;
using System.Threading.Tasks;
using DTOs;
using entities;
using Interfaces;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using System.Linq;
using AutoMapper.QueryableExtensions;

namespace Data
{
   public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public UserRepository(DataContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<MemberDato> GetMemberAsync(string username)
        {
            return await _context.Users
                .Where(x => x.UserName == username)
                .ProjectTo<MemberDato>(_mapper.ConfigurationProvider)
                .SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<MemberDato>> GetMembersAsync()
        {
            return await _context.Users 
                .ProjectTo<MemberDato>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public async Task<AppUser> GetUserByIdAsync(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<AppUser> GetUserByUsernameAsync(string username)
        {
            return await _context.Users
                .Include(p => p.Photos)
                .SingleOrDefaultAsync(x => x.UserName == username);
        }

        public async Task<IEnumerable<AppUser>> GetUsersAsync()
        {
            return await _context.Users
                .Include(p => p.Photos)
                .ToListAsync();
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public void Update(AppUser user)
        {
            _context.Entry(user).State = EntityState.Modified;
        }

        Task<MemberDato> IUserRepository.GetMemberAsync(string username)
        {
            throw new System.NotImplementedException();
        }

        Task<IEnumerable<MemberDato>> IUserRepository.GetMembersAsync()
        {
            throw new System.NotImplementedException();
        }
    }
}