using System;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Manager.API.ViewModels;
using Manager.Application.Interfaces;
using AutoMapper;
using Manager.Application.Dto;
using Manager.API.Utilities;

namespace Manager.API.Controllers
{
    [ApiController] // O controlador da api recebe as requisições e repassa para as outras camadas
    public class UserController : ControllerBase
    {

        private readonly IMapper _mapper;
        private readonly IUserApplication _userApplication;

        public UserController(IMapper mapper, IUserApplication userApplication)
        {
            _mapper = mapper;
            _userApplication = userApplication;
        }

        [HttpPost]
        [Route("/api/v1/users/create")]
        public async Task<IActionResult> Create([FromBody] CreateUserViewModel userViewModel)
        {
            try
            {
                var userDTO = _mapper.Map<UserDTO>(userViewModel);
                var newUser = await _userApplication.Create(userDTO);
                
                return Ok(new ResultViewModel
                {
                    Message = "Usuário criado com sucesso.",
                    Success = true,
                    Data = newUser
                });
            }
            catch (Exception)
            {
                return StatusCode(500, Responses.ApplicationErrorMessage());
            }

        }





    }
}