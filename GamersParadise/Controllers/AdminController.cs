using Interfaces;
using Microsoft.AspNetCore.Mvc;
using Models.DataBase;
using Models.DTO;
using Services;

namespace GamersParadise.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AdminController(IUnitOfWork unitOfWork) : ControllerBase
    {
        private readonly AdminService _adminService = new(unitOfWork);
        [HttpPost]
        [Route("AddPostReactionType")]
        public async Task<GenericResponse> AddPostReactionType([FromBody] PostReactionTypes postReactionType)
        {
            try
            {
                string action = await Task.FromResult(_adminService.AddPostReactionType(postReactionType));
                if (action == "Success")
                {
                    var reactionTypes = await Task.FromResult(_adminService.ReturnPostReactionTypes());
                    return new() { Status = true, Response = new() { Success = true, Data = reactionTypes } };
                }
                else
                {
                    return new() { Status = true, Response = new() { Success = false, Data = action } };
                }
            }
            catch (Exception)
            {
                return new() { Status = false, Error = new() { Description = "Some error occured" } };
            }
        }
        [HttpGet]
        [Route("ReturnPostReactionTypes")]
        public async Task<GenericResponse> ReturnPostReactionTypes()
        {
            try
            {
                var reactionTypes = await Task.FromResult(_adminService.ReturnPostReactionTypes());
                return new() { Status = true, Response = new() { Success = true, Data = reactionTypes } };
            }
            catch (Exception)
            {
                return new() { Status = false, Error = new() { Description = "Some error occured" } };
            }
        }
        [HttpPost]
        [Route("AddRole")]
        public async Task<GenericResponse> AddRole([FromBody] Roles role)
        {
            try
            {
                string action = await Task.FromResult(_adminService.AddRole(role));
                if(action == "Success")
                {
                    var Roles = await Task.FromResult(_adminService.ReturnRoles());
                    return new() { Status = true, Response = new() { Success = true, Data = Roles } };
                }
                else
                {
                    return new() { Status = true, Response = new() { Success = false, Data = action } };
                }
            }
            catch (Exception)
            {
                return new() { Status = false, Error = new() { Description = "Some error occured" } };
            }
        }
        [HttpGet]
        [Route("ReturnRole")]
        public async Task<GenericResponse> ReturnRoles()
        {
            try
            {
                var Roles = await Task.FromResult(_adminService.ReturnRoles());
                return new() { Status = true, Response = new() { Success = true, Data = Roles } };
            }
            catch (Exception)
            {
                return new() { Status = false, Error = new() { Description = "Some error occured" } };
            }
        }
    }
}
