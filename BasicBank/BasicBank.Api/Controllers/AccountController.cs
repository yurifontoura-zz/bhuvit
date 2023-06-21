using BasicBank.Application.Interface.Applications;
using BasicBank.Application.Interface.DTO;
using BasicBank.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BasicBank.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {
        readonly IAccountApplication _application;

        public AccountController(IAccountApplication application)
        {
            _application = application;
        }

        [HttpDelete]
        public JsonResult Delete(Guid id)
        {
            Envelope response = _application.DeleteAccount(id);

            return new JsonResult(response);
        }

        [HttpPost]
        public JsonResult Add(Account account)
        {
            TypedEnvelope<Account> response = _application.AddAccount(account);

            return new JsonResult(response);
        }

        [HttpPost]
        [Route("Deposit")]
        public JsonResult Deposit(Guid id, decimal amount)
        {
            TypedEnvelope<Account> response = _application.Deposit(id, amount);

            return new JsonResult(response);
        }

        [HttpPost]
        [Route("Withdraw")]
        public JsonResult Withdraw(Guid id, decimal amount)
        {
            TypedEnvelope<Account> response = _application.Withdraw(id, amount);

            return new JsonResult(response);
        }
    }
}
