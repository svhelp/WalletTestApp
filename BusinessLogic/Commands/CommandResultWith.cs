namespace BusinessLogic.Commands
{
    /// <summary>
    /// Результат выполнения команды с данными.
    /// </summary>
    /// <typeparam name="T">Тип данных.</typeparam>
    public class CommandResultWith<T> : CommandResult
    {
        /// <summary>
        /// Конструктор.
        /// </summary>
        public CommandResultWith()
        {
            IsSuccessful = true;
        }

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="errorMessage">Сообщение об ошибке.</param>
        public CommandResultWith(string errorMessage)
        {
            IsSuccessful = false;
            ErrorMessage = errorMessage;
        }

        /// <summary>
        /// Данные.
        /// </summary>
        public T Data { get; set; }
    }
}
