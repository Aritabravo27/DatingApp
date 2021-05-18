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
using System.Security.Claims;

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
             var users = await _userRepository.GetMembersAsync();

            return Ok(users);

            
        }


        [HttpGet("{username}")]
        public async Task<ActionResult<MemberDato>> GetUser(string username)
        {
           return await _userRepository.GetMemberAsync(username);

            
        }

        [HttpPut]
         public async Task<ActionResult> UpdateUser(MemberUpdateDto memberUpdateDto)
        {
            var username = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var user = await _userRepository.GetUserByUsernameAsync(username);

            _mapper.Map(memberUpdateDto, user);

            _userRepository.Update(user);

            if (await _userRepository.SaveAllAsync()) return NoContent();

            return BadRequest("Failed to update user");
        }
    }
}