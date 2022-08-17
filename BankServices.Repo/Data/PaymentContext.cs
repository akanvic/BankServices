using BankServices.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankServices.Repo.Data
{
    public class PaymentContext : DbContext
    {
        public PaymentContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<TransactionHistory> TransactionHistories { get; set; }
    }
}
