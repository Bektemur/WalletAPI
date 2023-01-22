using Microsoft.EntityFrameworkCore;
using WalletAPI.Model;

namespace WalletAPI
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Wallet> Wallet { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Operation> Operation { get; set; }
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            var customer1 = new Customer() { FirstName = "Пётр", LastName = "Сидоров", Patronymic = "Олегович", Name = "Сидоров Пётр Олегович", Id = 1 };
            var customer2 = new Customer() { FirstName = "Музаффар", LastName = "Усманов", Patronymic = "Шавкатович", Name = "Усманов Музаффар Шавкатович", Id = 2 };
            var customer3 = new Customer() { FirstName = "Лола", LastName = "Усманова", Patronymic = "Юсуповна", Name = "Усманова Лола Юсуповна", Id = 3 };
            var customer4 = new Customer() { FirstName = "Надежда", LastName = "Смирнова", Patronymic = "Николаевна", Name = "Смирнова Надежда Николаевна", Id = 4 };
            var wallet1 = new Wallet() { Name = "Кошелёк 1", Account = "2261684300342121200", Balance = 0,  Id = 1, CustomerId = 1, IsIdentified = true };
            var wallet2 = new Wallet() { Name = "Кошелёк 2", Account = "2261684300214141200", Balance = 460, Id = 2, CustomerId = 2, IsIdentified = false };
            var wallet3 = new Wallet() { Name = "Кошелёк 2", Account = "2261684300897141200", Balance = 16000, Id = 3, CustomerId = 3, IsIdentified = true };
            var operation1 = new Operation() { Amount = 1000, Time = new DateTime(2022, 1, 15),  Id = 1, WalletId = 3 };
            var operation2 = new Operation() { Amount = 2000, Time = new DateTime(2023, 1, 10),  Id = 2, WalletId = 3 };
            var operation3 = new Operation() { Amount = 1000, Time = new DateTime(2023, 1, 10),  Id = 3, WalletId = 3 };
            var operation4 = new Operation() { Amount = 12000, Time = new DateTime(2023, 1, 18), Id = 4, WalletId = 3 };
            var operation5 = new Operation() { Amount = 100, Time = new DateTime(2018, 1, 18), Id = 5, WalletId = 2 };
            var operation6 = new Operation() { Amount = 100, Time = new DateTime(2023, 1, 18), Id = 6, WalletId = 2 };
            var operation7 = new Operation() { Amount = 260, Time = new DateTime(2023, 1, 18), Id = 7, WalletId = 2 };

            builder.Entity<Customer>().HasData(customer1,customer2, customer3, customer4);
            builder.Entity<Wallet>().HasData(wallet1, wallet2, wallet3);
            builder.Entity<Operation>().HasData(operation1, operation2, operation3, operation4, operation5, operation6, operation7);
            
        }

       
    }
}
