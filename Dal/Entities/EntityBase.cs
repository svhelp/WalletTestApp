using System;

namespace Dal.Entities
{
    /// <summary>
    /// Базовый класс сущности БД.
    /// </summary>
    public abstract class EntityBase
    {
        /// <summary>
        /// Идентификатор.
        /// </summary>
        public Guid Id { get; set; }
    }
}
