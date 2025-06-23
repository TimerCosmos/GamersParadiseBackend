using System;
using DataBaseLayer;
using Interfaces;
using Microsoft.AspNetCore.Mvc;
using Models.DataBase;
using Models.DTO;
using Models.Exceptions;
using Services;

namespace GamersParadise.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GamersController(IUnitOfWork unitOfWork) : ControllerBase
    {
        private readonly GamersService userService = new(unitOfWork);
        [HttpPost]
        [Route("RegisterUser")]
        public async Task<GenericResponse> RegisterUser([FromBody] Users user)
        {
            try
            {
                string action = await Task.FromResult(userService.RegisterUser(user));
                if (action == "Success")
                {
                    return new() { Status = true, Response = new() { Success = true, Data = user } };
                }
                else
                {
                    return new() { Status = true, Response = new() { Success = false, Data = action } };
                }
            }
            catch (Exception)
            {
                return new() { Status = false, Error = new() { Description = "Some error occurred" } };
            }
        }
        [HttpGet]
        [Route("UserLogin")]
        public async Task<GenericResponse> UserLogin(string email, string password)
        {
            try
            {
                var user = await Task.FromResult(userService.UserLogin(email, password));
                return new() { Status = true, Response = new() { Success = true, Data = user } };
            }
            catch (UserNotFoundException ex)
            {
                return new() { Status = true, Response = new() { Success = false, Data = ex.Message } };
            }
            catch (Exception)
            {
                return new() { Status = false, Error = new() { Description = "Some error occurred" } };
            }
        }
        [HttpGet]
        [Route("GetPostReactionTypes")]
        public async Task<GenericResponse> ReturnPostReactionTypes()
        {
            try
            {
                var reactionTypes = await Task.FromResult(userService.ReturnPostReactionTypes());
                return new() { Status = true, Response = new() { Success = true, Data = reactionTypes } };
            }
            catch (Exception)
            {
                return new() { Status = false, Error = new() { Description = "Some error occurred" } };
            }
        }
    }
}
