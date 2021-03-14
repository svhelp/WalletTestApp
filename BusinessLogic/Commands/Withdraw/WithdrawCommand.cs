using BusinessLogic.Contexts;
using Core.Enums;
using System;
using System.Linq;

namespace BusinessLogic.Commands.Withdraw
{
    /// <summary>
    /// Команда для снятия денег.
    /// </summary>
    public class WithdrawCommand : CommandBase<WithdrawCommandModel, CommandResult>
    {
        /// <inheritdoc />
        public WithdrawCommand(WalletContext context)
        {
            Context = context;
        }

        private WalletContext Context { get; }

        /// <inheritdoc />
        protected override bool ValidateModel(WithdrawCommandModel model, out string errorMessage)
        {
            errorMessage = string.Empty;

            if (model.UserId == null || model.UserId == default(Guid))
            {
                errorMessage = "Не указан идентификатор пользователя";
                return false;
            }

            if (!Context.UserEntities.Any(x => x.Id == model.UserId))
            {
                errorMessage = "Пользователь не найден";
                return false;
            }

            if (model.Amount < 0)
            {
                errorMessage = "Введена неверная сумма";
                return false;
            }

            if (model.Currency == CurrencyType.Undefined)
            {
                errorMessage = "Введена неверная валюта";
                return false;
            }

            return true;
        }

        /// <inheritdoc />
        protected override CommandResult Execute(WithdrawCommandModel model)
        {
            var correspongingWallet = Context.WalletEntities
                .FirstOrDefault(x => x.UserId == model.UserId && x.Currency == model.Currency);

            if (correspongingWallet == null)
            {
                return new CommandResult("У пользователя отсутствует счет в указанной валюте.");
            }

            if (correspongingWallet.Balance < model.Amount)
            {
                return new CommandResult("На счету пользователя недостаточно средств.");
            }

            correspongingWallet.Balance -= model.Amount;

            Context.WalletEntities.Update(correspongingWallet);
            Context.SaveChanges();

            return new CommandResult();
        }
    }
}
