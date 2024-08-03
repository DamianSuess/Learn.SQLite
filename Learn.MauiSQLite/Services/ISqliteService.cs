using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.PrismMaui.Models;

namespace Test.PrismMaui.Services
{
  public interface ISqliteService
  {
    Task InitializeAsync();

    Task<List<Customer>> GetCustomersAsync();

    Task<List<Customer>> GetUnsubscribedAsync();

    Task<Customer> GetCustomerAsync(int id);

    Task<int> SaveAsync(Customer customer);
  }
}
