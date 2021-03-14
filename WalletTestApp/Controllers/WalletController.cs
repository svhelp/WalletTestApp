using System;
using BusinessLogic.Commands;
using BusinessLogic.Commands.Convert;
using BusinessLogic.Commands.Deposit;
using BusinessLogic.Commands.Withdraw;
using BusinessLogic.Models;
using BusinessLogic.Queries;
using BusinessLogic.Queries.Balance;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace WalletTestApp.Controllers
{
    /// <summary>
    /// Контроллер по работе со счетами.
    /// </summary>
    [ApiController]
    [Route("Wallet")]
    public class WalletController : ControllerBase
    {
        /// <summary>
        /// Получить баланс пользователя.
        /// </summary>
        /// <param name="userId">Идентификатор пользователя.</param>
        /// <returns>Баланс.</returns>
        [HttpGet]
        [Route("Balance")]
        public QueryResult<UserBalanceModel> Balance(Guid userId)
        {
            var model = new GetBalanceQueryModel { UserId = userId };
            var getBalanceQuery = ActivatorUtilities.GetServiceOrCreateInstance<GetBalanceQuery>(HttpContext.RequestServices);
            var getBalanceQueryResult = getBalanceQuery.Run(model);

            return getBalanceQueryResult;
        }

        /// <summary>
        /// Снять деньги со счета.
        /// </summary>
        /// <param name="model">Модель.</param>
        /// <returns>Результат.</returns>
        [HttpPost]
        [Route("Withdraw")]
        public CommandResult Withdraw(WithdrawCommandModel model)
        {
            var withdrawCommand = ActivatorUtilities.GetServiceOrCreateInstance<WithdrawCommand>(HttpContext.RequestServices);
            var withdrawCommandResult = withdrawCommand.Run(model);

            return withdrawCommandResult;
        }

        /// <summary>
        /// Пополнить счет.
        /// </summary>
        /// <param name="model">Модель.</param>
        /// <returns>Результат.</returns>
        [HttpPost]
        [Route("Deposit")]
        public CommandResult Deposit(DepositCommandModel model)
        {
            var depositCommand = ActivatorUtilities.GetServiceOrCreateInstance<DepositCommand>(HttpContext.RequestServices);
            var depositCommandResult = depositCommand.Run(model);

            return depositCommandResult;
        }

        /// <summary>
        /// Конвертировать валюту.
        /// </summary>
        /// <param name="model">Модель.</param>
        /// <returns>Результат.</returns>
        [HttpPost]
        [Route("Convert")]
        public CommandResult Convert(ConvertCommandModel model)
        {
            var convertCommand = ActivatorUtilities.GetServiceOrCreateInstance<ConvertCommand>(HttpContext.RequestServices);
            var convertCommandResult = convertCommand.Run(model);

            return convertCommandResult;
        }
    }
}
