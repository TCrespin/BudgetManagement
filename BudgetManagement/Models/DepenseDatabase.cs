using SQLite;
using BudgetManagement.Models.Table;

namespace BudgetManagement.Models;

public class DepenseDatabase
{
    SQLiteAsyncConnection Database;
    public event Func<Task> IsModify;

    public DepenseDatabase()
    {

    }
    
    async Task Init()
    {
        if (Database is not null)
            return;
        Database = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
        var result = await Database.CreateTableAsync<Depense>();
    }

    public async Task<List<Depense>> GetDepensesAsync()
    {
        await Init();
        return await Database.Table<Depense>().OrderByDescending(x => x.Id).ToListAsync();
    }

    public async Task<Depense> GetDepenseAsync(int id)
    {
        await Init();
        return await Database.Table<Depense>().Where(x => x.Id == id).FirstOrDefaultAsync();
    }

    public async Task<int> SaveDepenseAsync(Depense depense)
    {
        await Init();
        int num;
        if (depense.Id != 0)
            num = await Database.UpdateAsync(depense);
        else
            num = await Database.InsertAsync(depense);
        await IsModify.Invoke();
        return num;
    }

    public async Task<int> DeleteDepenseAsync(Depense depense)
    {
        await Init();
        int num;
        num = await Database.DeleteAsync(depense);
        await IsModify.Invoke();
        return num;
    }
}
