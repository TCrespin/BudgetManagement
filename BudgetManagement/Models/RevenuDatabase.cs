using SQLite;
using BudgetManagement.Models.Table;

namespace BudgetManagement.Models;
public class RevenuDatabase
{
    SQLiteAsyncConnection Database;
    public event Func<Task> IsModify;
    public RevenuDatabase()
    {

    }

    async Task Init()
    {
        if (Database is not null)
            return;
        Database = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
        var result = await Database.CreateTableAsync<Revenu>();
    }

    public async Task<List<Revenu>> GetRevenusAsync()
    {
        await Init();
        return await Database.Table<Revenu>().OrderByDescending(x => x.Id).ToListAsync();
    }

    public async Task<Revenu> GetRevenuAsync(int id)
    {
        await Init();
        return await Database.Table<Revenu>().Where(x => x.Id == id).FirstOrDefaultAsync();
    }

    public async Task<int> SaveRevenuAsync(Revenu revenu)
    {
        await Init();
        int num;
        if (revenu.Id != 0)
            num = await Database.UpdateAsync(revenu);
        else
            num = await Database.InsertAsync(revenu);
        await IsModify.Invoke();
        return num;
    }

    public async Task<int> DeleteRevenuAsync(Revenu revenu)
    {
        await Init();
        int num;
        num = await Database.DeleteAsync(revenu);
        await IsModify.Invoke();
        return num;
    }
}
