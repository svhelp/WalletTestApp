using BusinessLogic.Commands;
using BusinessLogic.Commands.CreateUser;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace WalletTestApp.Controllers
{
    /// <summary>
    /// Контроллер по работе с пользователями.
    /// </summary>
    [ApiController]
    [Route("User")]
    public class UserController : ControllerBase
    {
        /// <summary>
        /// Создать пользователя.
        /// </summary>
        /// <param name="userId">Идентификатор пользователя.</param>
        /// <returns>Баланс.</returns>
        [HttpPost]
        [Route("CreateUser")]
        public CommandResult CreateUser(CreateUserCommandModel model)
        {
            var createUserCommend = ActivatorUtilities.GetServiceOrCreateInstance<CreateUserCommand>(HttpContext.RequestServices);
            var createUserCommendResult = createUserCommend.Run(model);

            return createUserCommendResult;
        }
    }
}
