using SQLite;
using BudgetManagement.Models.Table;

namespace BudgetManagement.Models;

public class UserDatabase
{
    SQLiteAsyncConnection Database;

    public UserDatabase()
    {

    }

    async Task Init()
    {
        if (Database is not null)
            return;
        Database = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
        var result = await Database.CreateTableAsync<Depense>();
    }

    public async Task<User> GetUserAsync(int id)
    {
        await Init();
        return await Database.Table<User>().Where(x => x.Id == id).FirstOrDefaultAsync();
    }

    public async Task<int> SaveUserAsync(User user)
    {
        await Init();
        if (user.Id != 0)
            return await Database.UpdateAsync(user);
        else
            return await Database.InsertAsync(user);
    }

    public async Task<int> DeleteUserAsync(User user)
    {
        await Init();
        return await Database.DeleteAsync(user);
    }

    public async Task<User?> ConnectUserAsync(string? password)
    {
        await Init();
        if (password == null)
            return null;
        return await Database.Table<User>().Where(x => x.Password == password).FirstOrDefaultAsync();
    }
}

