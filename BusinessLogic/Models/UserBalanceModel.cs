using System.Collections.Generic;

namespace BusinessLogic.Models
{
    /// <summary>
    /// Модель баланса пользователя.
    /// </summary>
    public class UserBalanceModel
    {
        /// <summary>
        /// Кошельки пользователя.
        /// </summary>
        public List<WalletBalanceModel> Wallets { get; set; }
    }
}
