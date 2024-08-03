using SQLite;
using Test.PrismMaui.Models;

namespace Test.PrismMaui.Services
{
  public class SqliteService : ISqliteService
  {
    private SQLiteAsyncConnection _db;

    public Task<Customer> GetCustomerAsync(int id)
    {
      throw new NotImplementedException();
    }

    public async Task<List<Customer>> GetCustomersAsync()
    {
      return await _db.Table<Customer>().ToListAsync();
    }

    public Task<List<Customer>> GetUnsubscribedAsync()
    {
      throw new NotImplementedException();
    }

    public async Task InitializeAsync()
    {
      if (_db is not null)
        return;

      _db = new(Constants.DatabasePath, Constants.Flags);
      var result = await _db.CreateTableAsync<Customer>();
    }

    public async Task<int> SaveAsync(Customer customer)
    {
      return await _db.InsertAsync(customer);
    }
  }
}
