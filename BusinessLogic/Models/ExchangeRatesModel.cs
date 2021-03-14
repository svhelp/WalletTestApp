using Core.Enums;
using System;
using System.Collections.Generic;

namespace BusinessLogic.Models
{
    /// <summary>
    /// Курс валют.
    /// </summary>
    public class ExchangeRatesModel
    {
        /// <summary>
        /// Курсы.
        /// </summary>
        public List<Tuple<CurrencyType, decimal>> Rates { get; set; }
    }
}
