namespace BusinessLogic.Commands
{
    /// <summary>
    /// результат выполнения команды.
    /// </summary>
    public class CommandResult
    {
        /// <summary>
        /// Конструктор.
        /// </summary>
        public CommandResult() 
        {
            IsSuccessful = true;
        }

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="errorMessage">Сообщение об ошибке.</param>
        public CommandResult(string errorMessage)
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
    }
}
