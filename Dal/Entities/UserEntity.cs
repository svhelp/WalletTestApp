using System.Collections.Generic;

namespace Dal.Entities
{
    /// <summary>
    /// ПОльзователь.
    /// </summary>
    public class UserEntity : EntityBase
    {
        /// <summary>
        /// Имя.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Кошельки.
        /// </summary>
        public virtual ICollection<WalletEntity> Wallets { get; set; }
    }
}
