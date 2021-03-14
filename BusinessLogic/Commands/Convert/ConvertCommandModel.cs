using Core.Enums;
using System;

namespace BusinessLogic.Commands.Convert
{
    /// <summary>
    /// Модель для конвертации валюты.
    /// </summary>
    public class ConvertCommandModel
    {
        /// <summary>
        /// Идентификатор пользователя.
        /// </summary>
        public Guid UserId { get; set; }

        /// <summary>
        /// Исходная валюта.
        /// </summary>
        public CurrencyType InitialCurrency { get; set; }

        /// <summary>
        /// Целевая валюта.
        /// </summary>
        public CurrencyType TargetCurrency { get; set; }

        /// <summary>
        /// Количество конвертируемых денег в изначальной валюте.
        /// </summary>
        public decimal InitialAmount { get; set; }
    }
}
