using BusinessLogic.Contexts;
using Dal.Entities;
using System;

namespace BusinessLogic.Commands.CreateUser
{
    /// <summary>
    /// Команда для создания пользователя.
    /// </summary>
    public class CreateUserCommand : CommandBase<CreateUserCommandModel, CommandResultWith<Guid>>
    {
        /// <inheritdoc/>
        public CreateUserCommand(WalletContext context)
        {
            Context = context;
        }

        private WalletContext Context { get; }

        /// <inheritdoc/>
        protected override CommandResult Execute(CreateUserCommandModel model)
        {
            var userToAdd = new UserEntity
            {
                Name = model.Name,
            };

            Context.UserEntities.Add(userToAdd);
            Context.SaveChanges();

            return new CommandResultWith<Guid> { Data = userToAdd.Id };
        }
    }
}
