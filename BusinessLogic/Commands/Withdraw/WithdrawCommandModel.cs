using Core.Enums;
using System;

namespace BusinessLogic.Commands.Withdraw
{
    /// <summary>
    /// Модель для снятия денег.
    /// </summary>
    public class WithdrawCommandModel
    {
        /// <summary>
        /// Идентификатор пользователя.
        /// </summary>
        public Guid UserId { get; set; }

        /// <summary>
        /// Размер пополнения.
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// Валюта.
        /// </summary>
        public CurrencyType Currency { get; set; }
    }
}
