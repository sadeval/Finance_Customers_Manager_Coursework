using System;


namespace FMS_PNP.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
    }

    // Модель CustomerTransaction
    public class CustomerTransaction
    {
        public int Id { get; set; }
        public string FullName { get; set; } // связь с клиентом может быть на основе FullName или Id (рекомендуется использовать Id)
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
    }
}
