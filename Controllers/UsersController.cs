using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data;
using entities;
using Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Controllers;
using DTOs;

namespace Controllers
{
    [Authorize]
    public class UsersController : BaseApiController
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public UsersController(IUserRepository userRepository, IMapper mapper)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }

       [HttpGet]
        public async Task<ActionResult<IEnumerable<MemberDato>>> GetUsers()
        {
           
           var users = await _userRepository.GetUsersAsync();

           var usersToReturn = _mapper.Map<IEnumerable<MemberDato>>(users);

            return Ok(usersToReturn);

            
        }


        [HttpGet("{username}")]
        public async Task<ActionResult<MemberDato>> GetUser(string username)
        {
            var user = await _userRepository.GetUserByUsernameAsync(username);

            return _mapper.Map<MemberDato>(user);
        }
    }
}