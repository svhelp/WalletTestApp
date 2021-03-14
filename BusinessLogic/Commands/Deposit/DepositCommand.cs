using BusinessLogic.Contexts;
using Core.Enums;
using Dal.Entities;
using System;
using System.Linq;

namespace BusinessLogic.Commands.Deposit
{
    /// <summary>
    /// Команда для пополнения счета.
    /// </summary>
    public class DepositCommand : CommandBase<DepositCommandModel, CommandResult>
    {
        /// <inheritdoc />
        public DepositCommand(WalletContext context)
        {
            Context = context;
        }

        private WalletContext Context { get; }

        /// <inheritdoc />
        protected override bool ValidateModel(DepositCommandModel model, out string errorMessage)
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
        protected override CommandResult Execute(DepositCommandModel model)
        {
            var correspongingWallet = Context.WalletEntities
                .FirstOrDefault(x => x.UserId == model.UserId && x.Currency == model.Currency);

            if (correspongingWallet == null)
            {
                correspongingWallet = new WalletEntity
                {
                    UserId = model.UserId,
                    Currency = model.Currency,
                    Balance = 0,
                };
            }

            correspongingWallet.Balance += model.Amount;

            Context.WalletEntities.Update(correspongingWallet);
            Context.SaveChanges();

            return new CommandResult();
        }
    }
}
