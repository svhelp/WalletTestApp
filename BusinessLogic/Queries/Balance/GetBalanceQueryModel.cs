using System;

namespace BusinessLogic.Queries.Balance
{
    /// <summary>
    /// Модель для запроса баланса пользователя.
    /// </summary>
    public class GetBalanceQueryModel
    {
        /// <summary>
        /// Идентификатор пользователя.
        /// </summary>
        public Guid UserId { get; set; }
    }
}
