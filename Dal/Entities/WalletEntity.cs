using Core.Enums;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dal.Entities
{
    /// <summary>
    /// Сущность кошелька.
    /// </summary>
    public class WalletEntity : EntityBase
    {
        /// <summary>
        /// Валюта.
        /// </summary>
        public CurrencyType Currency { get; set; }

        /// <summary>
        /// Баланс.
        /// </summary>
        public decimal Balance { get; set; }

        /// <summary>
        /// Идентификатор пользователя.
        /// </summary>
        [ForeignKey(nameof(User))]
        public Guid UserId { get; set; }

        /// <summary>
        /// Пользователь.
        /// </summary>
        public virtual UserEntity User { get; set; }
    }
}
