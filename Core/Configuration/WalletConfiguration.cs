namespace Core.Configuration
{
    /// <summary>
    /// Конфигурация.
    /// </summary>
    public class WalletConfiguration : IWalletConfiguration
    {
        /// <summary>
        /// Адрес ресурса с курсами обмена.
        /// </summary>
        public string ExchangeRatesLink => "https://www.ecb.europa.eu/stats/eurofxref/eurofxref-daily.xml";
    }
}
