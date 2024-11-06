using System;
using System.Collections.Generic;

namespace FMS_PNP.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }

        // Навигационные свойства
        public ICollection<CustomerTransaction> CustomerTransactions { get; set; }
        public ICollection<Transaction> Transactions { get; set; }
    }

    public class CustomerTransaction
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }

        // Навигационные свойства
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
    }

    public class Transaction
    {
        public int TransactionID { get; set; }
        public DateTime Date { get; set; }
        public string FullName { get; set; }
        public string Category { get; set; }
        public string NameOfProduct { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal Summ { get; set; }
        public string FullNameAdm { get; set; }
        public bool ReturnOfGoods { get; set; }
        public int ProductId { get; set; }
        public int AdministratorId { get; set; }
        public int CustomerId { get; set; }

        // Навигационные свойства
        public Product Product { get; set; }
        public Administrator Administrator { get; set; }
        public Customer Customer { get; set; }
    }

    public class Administrator
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Login { get; set; }
        public string PasswordHash { get; set; }

        // Навигационные свойства
        public ICollection<Transaction> Transactions { get; set; }
    }

    public class Product
    {
        public int Id { get; set; }
        public string Category { get; set; }
        public string NameOfProduct { get; set; }
        public string Textile { get; set; }
        public string Season { get; set; }
        public string Color { get; set; }
        public int Size { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }

        // Навигационные свойства
        public ICollection<Transaction> Transactions { get; set; }
    }
}
