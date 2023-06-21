using BasicBank.Application.Interface.Applications;
using BasicBank.Application.Interface.DTO;
using BasicBank.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BasicBank.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        readonly IUserApplication _application;

        public UserController(IUserApplication application)
        {
            _application = application;
        }

        [HttpPut]
        public JsonResult AddUser(User user)
        {
            TypedEnvelope<User> response = _application.AddOrUpdateUser(user);

            return new JsonResult(response);
        }

        [HttpGet]
        public JsonResult GetUser(Guid id)
        {
            TypedEnvelope<User> response = _application.GetUserByID(id);

            return new JsonResult(response);
        }

        [HttpGet]
        [Route("GetAll")]
        public JsonResult GetAll()
        {
            TypedEnvelope<List<User>> response = _application.GetAll();

            return new JsonResult(response);
        }
    }
}
