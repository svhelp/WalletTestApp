using Core.Enums;

namespace BusinessLogic.Models
{
    /// <summary>
    /// Модель баланса на кошельке.
    /// </summary>
    public class WalletBalanceModel
    {
        /// <summary>
        /// Валюта.
        /// </summary>
        public CurrencyType Currency { get; set; }

        /// <summary>
        /// Баланс.
        /// </summary>
        public decimal Balance { get; set; }
    }
}
