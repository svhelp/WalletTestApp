namespace BusinessLogic.Commands
{
    /// <summary>
    /// Базовый класс команды.
    /// </summary>
    /// <typeparam name="T">Класс входных данных.</typeparam>
    /// <typeparam name="V">Класс выходных данных.</typeparam>
    public abstract class CommandBase<T, V> where V : CommandResult
    {
        /// <summary>
        /// Выполнить команду.
        /// </summary>
        /// <param name="model">Модель.</param>
        /// <returns>Результат.</returns>
        public CommandResult Run(T model) 
        {
            if (!ValidateModel(model, out string errorMessage))
            {
                return new CommandResult(errorMessage);
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
        /// Выполнить команду.
        /// </summary>
        /// <param name="model">Модель.</param>
        /// <returns>Результат.</returns>
        protected abstract CommandResult Execute(T model);
    }
}
