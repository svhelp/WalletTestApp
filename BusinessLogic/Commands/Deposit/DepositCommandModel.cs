using Core.Enums;
using System;

namespace BusinessLogic.Commands.Deposit
{
    /// <summary>
    /// Модель для команды пополнения счета.
    /// </summary>
    public class DepositCommandModel
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
