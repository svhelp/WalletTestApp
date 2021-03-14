using Dal.Entities;
using Microsoft.EntityFrameworkCore;

namespace BusinessLogic.Contexts
{
    /// <summary>
    /// Контекст БД.
    /// </summary>
    public class WalletContext : DbContext
    {
        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="options">Параметры.</param>
        public WalletContext(DbContextOptions<WalletContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        /// <summary>
        /// Список пользователей.
        /// </summary>
        public DbSet<UserEntity> UserEntities { get; set; }

        /// <summary>
        /// Список кошельков.
        /// </summary>
        public DbSet<WalletEntity> WalletEntities { get; set; }

        /// <inheritdoc />
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data source=D:\\Mobile.db");
        }
    }
}
