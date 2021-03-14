namespace BusinessLogic.Queries
{
    /// <summary>
    /// Базовый класс запроса.
    /// </summary>
    /// <typeparam name="T">Тип модели входных данных.</typeparam>
    /// <typeparam name="V">Тип результата.</typeparam>
    public abstract class QueryBase<T, V>
    {
        /// <summary>
        /// Выполнить запрос.
        /// </summary>
        /// <param name="model">Модель.</param>
        /// <returns>Результат.</returns>
        public QueryResult<V> Run(T model) 
        {
            if (!ValidateModel(model, out string errorMessage))
            {
                return new QueryResult<V>(errorMessage);
            }

            return Execute(model);
        }

        /// <summary>
        /// Валидировать модель.
        /// </summary>
        /// <param name="model">Модель.</param>
        /// <param name="errorMessage">Текст ошибки.</param>
        /// <returns>Результат проверки.</returns>
        protected virtual bool ValidateModel(T model, out string errorMessage)
        {
            errorMessage = string.Empty;
            return true;
        }

        /// <summary>
        /// Выполнить запрос.
        /// </summary>
        /// <param name="model">Модель.</param>
        /// <returns>Результат.</returns>
        protected abstract QueryResult<V> Execute(T model);
    }
}
