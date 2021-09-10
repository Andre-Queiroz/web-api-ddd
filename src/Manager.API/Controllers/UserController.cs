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

        [HttpGet]
        [Route("/api/v1/users/get-all")]
        public async Task<IActionResult> Get()
        {
            try
            {
                var allUsers = await _userApplication.Get();

                return Ok(new ResultViewModel
                {
                    Message = "Usuários encontrados com sucesso.",
                    Success = true,
                    Data = allUsers
                });
            }
            catch (Exception)
            {
                return StatusCode(500, Responses.ApplicationErrorMessage());
            }
        }

        [HttpGet]
        [Route("/api/v1/users/get/{id}")]
        public async Task<IActionResult> Get(long id)
        {
            try
            {
                var user = await _userApplication.Get(id);

                if (user == null)
                    return Ok(new ResultViewModel
                    {
                        Message = "Nenhum usuário foi encontrado.",
                        Success = true,
                        Data = user
                    });

                return Ok(new ResultViewModel
                {
                    Message = "Usuário encontrado com sucesso.",
                    Success = true,
                    Data = user
                });
            }
            catch (Exception)
            {
                return StatusCode(500, Responses.ApplicationErrorMessage());
            }
        }

        [HttpGet]
        [Route("/api/v1/users/get-by-email")]
        public async Task<IActionResult> GetByEmail([FromQuery] string email)
        {
            try
            {
                var user = await _userApplication.GetByEmail(email);

                if (user == null)
                    return Ok(new ResultViewModel
                    {
                        Message = "Nenhum usuário foi encontrado.",
                        Success = true,
                        Data = user
                    });


                return Ok(new ResultViewModel
                {
                    Message = "Usuário encontrado com sucesso!",
                    Success = true,
                    Data = user
                });
            }
            catch (Exception)
            {
                return StatusCode(500, Responses.ApplicationErrorMessage());
            }
        }

        [HttpGet]
        [Route("/api/v1/users/search-by-name")]
        public async Task<IActionResult> SearchByName([FromQuery] string name)
        {
            try
            {
                var allUsers = await _userApplication.SearchByName(name);

                if (allUsers.Count == 0)
                    return Ok(new ResultViewModel
                    {
                        Message = "Nenhum usuário foi encontrado.",
                        Success = true,
                        Data = null
                    });

                return Ok(new ResultViewModel
                {
                    Message = "Usuário encontrado com sucesso.",
                    Success = true,
                    Data = allUsers
                });
            }
            catch (Exception)
            {
                return StatusCode(500, Responses.ApplicationErrorMessage());
            }
        }

        [HttpGet]
        [Route("/api/v1/users/search-by-email")]
        public async Task<IActionResult> SearchByEmail([FromQuery] string email)
        {
            try
            {
                var allUsers = await _userApplication.SearchByEmail(email);

                if (allUsers.Count == 0)
                {
                    return Ok(new ResultViewModel
                    {
                        Message = "Nenhum usuário foi encontrado.",
                        Success = true,
                        Data = null
                    });
                }
                return Ok(new ResultViewModel
                {
                    Message = "Usuário encontrado com sucesso.",
                    Success = true,
                    Data = allUsers
                });
            }
            catch (Exception)
            {

                throw;
            }
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

        [HttpPut]
        [Route("/api/v1/users/update")]
        public async Task<IActionResult> Update([FromBody] UpdateUserViewModel userViewModel)
        {
            try
            {
                var userDTO = _mapper.Map<UserDTO>(userViewModel);

                var userUpdated = await _userApplication.Update(userDTO);

                return Ok(new ResultViewModel
                {
                    Message = "Usuário atualizado com sucesso.",
                    Success = true,
                    Data = userUpdated
                });
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }

        [HttpDelete]
        [Route("/api/v1/users/remove/{id}")]
        public async Task<IActionResult> Remove(long id)
        {
            try
            {
                await _userApplication.Remove(id);

                return Ok(new ResultViewModel
                {
                    Message = "Usuário removido com sucesso.",
                    Success = true,
                    Data = null
                });
            }
            catch (Exception)
            {
                return StatusCode(500, Responses.ApplicationErrorMessage());
            }
        }
    }
}