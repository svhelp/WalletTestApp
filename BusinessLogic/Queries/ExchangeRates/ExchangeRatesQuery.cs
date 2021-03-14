using BusinessLogic.Models;
using Core.Configuration;
using Core.Enums;
using Core.Helpers;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Net;
using System.Xml;

namespace BusinessLogic.Queries.ExchangeRates
{
    /// <summary>
    /// Получить курс валют.
    /// </summary>
    public class ExchangeRatesQuery : QueryBase<object, ExchangeRatesModel>
    {
        private const CurrencyType initialCurrency = CurrencyType.EUR;

        /// <inheritdoc />
        public ExchangeRatesQuery(IWalletConfiguration configuration)
        {
            Configuration = configuration;
        }

        private IWalletConfiguration Configuration { get; }

        /// <inheritdoc />
        protected override QueryResult<ExchangeRatesModel> Execute(object model)
        {
            var rates = new List<Tuple<CurrencyType, decimal>>();

            try
            {
                var request = WebRequest.Create(Configuration.ExchangeRatesLink);
                var response = request.GetResponse();

                using (Stream stream = response.GetResponseStream())
                {
                    XmlDocument xDoc = new XmlDocument();
                    xDoc.Load(stream);

                    var rateNodes = xDoc.GetElementsByTagName("Cube");
                    foreach (XmlNode rateNode in rateNodes)
                    {
                        if (rateNode.ChildNodes.Count > 0)
                        {
                            continue;
                        }

                        XmlNode currency = rateNode.Attributes.GetNamedItem("currency");
                        XmlNode rate = rateNode.Attributes.GetNamedItem("rate");

                        var currencyType = CurrencyMap.GetCurrencyType(currency.Value);

                        if (currencyType == CurrencyType.Undefined)
                        {
                            continue;
                        }

                        var parsedRate = new Tuple<CurrencyType, decimal>(currencyType, decimal.Parse(rate.Value, CultureInfo.InvariantCulture));
                        rates.Add(parsedRate);
                    }
                }

                response.Close();
            }
            catch (Exception e)
            {
                return new QueryResult<ExchangeRatesModel>(e.Message);
            }

            rates.Add(new Tuple<CurrencyType, decimal>(initialCurrency, 1));

            return new QueryResult<ExchangeRatesModel>
            {
                Data = new ExchangeRatesModel
                {
                    Rates = rates,
                },
            };
        }
    }
}
