using BusinessLogic.Contexts;
using BusinessLogic.Queries.ExchangeRates;
using Core.Enums;
using Dal.Entities;
using System;
using System.Linq;

namespace BusinessLogic.Commands.Convert
{
    /// <summary>
    /// Команда для конвертации валюты.
    /// </summary>
    public class ConvertCommand : CommandBase<ConvertCommandModel, CommandResult>
    {
        /// <inheritdoc />
        public ConvertCommand(WalletContext context, ExchangeRatesQuery exchangeRatesQuery)
        {
            Context = context;
            ExchangeRatesQuery = exchangeRatesQuery;
        }

        private WalletContext Context { get; }
        private ExchangeRatesQuery ExchangeRatesQuery { get; }

        /// <inheritdoc />
        protected override bool ValidateModel(ConvertCommandModel model, out string errorMessage)
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

            if (model.InitialAmount < 0)
            {
                errorMessage = "Введена неверная сумма";
                return false;
            }

            if (model.InitialCurrency == CurrencyType.Undefined || model.TargetCurrency == CurrencyType.Undefined)
            {
                errorMessage = "Введена неверная валюта";
                return false;
            }

            return true;
        }

        /// <inheritdoc />
        protected override CommandResult Execute(ConvertCommandModel model)
        {
            WalletEntity correspongingWalletToWithdraw = Context.WalletEntities
                .FirstOrDefault(x => x.UserId == model.UserId && x.Currency == model.InitialCurrency);

            if (correspongingWalletToWithdraw == null)
            {
                return new CommandResult("У пользователя отсутствует счет в указанной валюте");
            }

            if (correspongingWalletToWithdraw.Balance < model.InitialAmount)
            {
                return new CommandResult("На счету пользователя недостаточно средств");
            }

            var exchangeRatesQueryResult = ExchangeRatesQuery.Run(null);
            if (!exchangeRatesQueryResult.IsSuccessful)
            {
                return new CommandResult(exchangeRatesQueryResult.ErrorMessage);
            }

            var exchangeRates = exchangeRatesQueryResult.Data;
            var initialRate = exchangeRates.Rates.FirstOrDefault(r => r.Item1 == model.InitialCurrency);
            var targetRate = exchangeRates.Rates.FirstOrDefault(r => r.Item1 == model.TargetCurrency);

            if (targetRate == null || initialRate == null)
            {
                return new CommandResult("Не найден курс перевода в указанную валюту");
            }

            decimal convertedAmount = model.InitialAmount / initialRate.Item2 * targetRate.Item2;

            var correspongingDepositWallet = Context.WalletEntities
                .FirstOrDefault(x => x.UserId == model.UserId && x.Currency == model.TargetCurrency);

            if (correspongingDepositWallet == null)
            {
                correspongingDepositWallet = new WalletEntity
                {
                    UserId = model.UserId,
                    Currency = model.TargetCurrency,
                    Balance = 0,
                };
            }

            correspongingWalletToWithdraw.Balance -= model.InitialAmount;
            correspongingDepositWallet.Balance += convertedAmount;

            Context.WalletEntities.Update(correspongingWalletToWithdraw);
            Context.WalletEntities.Update(correspongingDepositWallet);
            Context.SaveChanges();

            return new CommandResult();
        }
    }
}
