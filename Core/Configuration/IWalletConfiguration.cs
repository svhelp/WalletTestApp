namespace Core.Configuration
{
    /// <summary>
    /// Конфигурация.
    /// </summary>
    public interface IWalletConfiguration
    {
        /// <summary>
        /// Адрес ресурса с курсами обмена.
        /// </summary>
        string ExchangeRatesLink { get; }
    }
}