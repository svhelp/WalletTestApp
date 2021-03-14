using Core.Enums;
using System.Collections.Generic;

namespace Core.Helpers
{
    /// <summary>
    /// Конвертор строк в enum.
    /// </summary>
    public static class CurrencyMap
    {
        private static Dictionary<string, CurrencyType> map = new Dictionary<string, CurrencyType>
        {
            {"USD", CurrencyType.USD },
            {"EUR", CurrencyType.EUR },
            {"RUB", CurrencyType.RUB },
        };

        /// <summary>
        /// Получить тип валюты по названию.
        /// </summary>
        /// <param name="type">Название.</param>
        /// <returns>Тип.</returns>
        public static CurrencyType GetCurrencyType(string type)
        {
            if (!map.ContainsKey(type))
            {
                return CurrencyType.Undefined;
            }

            return map[type];
        }
    }
}
