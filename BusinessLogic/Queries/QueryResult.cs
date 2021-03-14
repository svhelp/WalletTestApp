namespace BusinessLogic.Queries
{
    /// <summary>
    /// Результат запроса.
    /// </summary>
    public class QueryResult<T>
    {
        /// <summary>
        /// Конструктор.
        /// </summary>
        public QueryResult()
        {
            IsSuccessful = true;
        }

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="errorMessage">Сообщение об ошибке.</param>
        public QueryResult(string errorMessage)
        {
            IsSuccessful = false;
            ErrorMessage = errorMessage;
        }

        /// <summary>
        /// Успешен ли запрос.
        /// </summary>
        public bool IsSuccessful { get; set; }

        /// <summary>
        /// Сообщение об ошибке.
        /// </summary>
        public string ErrorMessage { get; set; }

        /// <summary>
        /// Результат.
        /// </summary>
        public T Data { get; set; }
    }
}
