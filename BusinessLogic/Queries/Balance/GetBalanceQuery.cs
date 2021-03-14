using AutoMapper;
using AutoMapper.QueryableExtensions;
using BusinessLogic.Contexts;
using BusinessLogic.Models;
using Dal.Entities;
using System;
using System.Linq;

namespace BusinessLogic.Queries.Balance
{
    /// <summary>
    /// Получить баланс пользователя.
    /// </summary>
    public class GetBalanceQuery : QueryBase<GetBalanceQueryModel, UserBalanceModel>
    {
        /// <inheritdoc />
        public GetBalanceQuery(WalletContext context) {
            Context = context;
        }

        private WalletContext Context { get; }

        /// <inheritdoc />
        protected override bool ValidateModel(GetBalanceQueryModel model, out string errorMessage)
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

            return true;
        }

        /// <inheritdoc />
        protected override QueryResult<UserBalanceModel> Execute(GetBalanceQueryModel model)
        {
            var configuration = new MapperConfiguration(cfg =>
                cfg.CreateMap<WalletEntity, WalletBalanceModel>());

            var userWallets = Context.WalletEntities
                .Where(w => w.UserId == model.UserId)
                .ProjectTo<WalletBalanceModel>(configuration)
                .ToList();

            var result = new UserBalanceModel
            {
                Wallets = userWallets
            };

            return new QueryResult<UserBalanceModel>
            {
                Data = result
            };
        }
    }
}
