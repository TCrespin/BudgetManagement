using BudgetManagement.Models.Table;
using SQLite;

namespace BudgetManagement.Models;

public class EpargneDatabase
{
    SQLiteAsyncConnection Database;

    public EpargneDatabase()
    {

    }

    async Task Init()
    {
        if (Database is not null)
            return;

        Database = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
        var result = await Database.CreateTableAsync<Epargne>();
    }

    public async Task<List<Epargne>> GetEpargnesAsync()
    {
        await Init();
        return await Database.Table<Epargne>().ToListAsync();
    }

    public async Task<Epargne> GetEpargneAsync(int id)
    {
        await Init();
        return await Database.Table<Epargne>().Where(x => x.Id == id).FirstOrDefaultAsync();
    }

    public async Task<int> SaveEpargneAsync(Epargne epargne)
    {
        await Init();
        if (epargne.Id != 0)
            return await Database.UpdateAsync(epargne);
        else
            return await Database.InsertAsync(epargne);
    }

    public async Task<int> DeleteEpargneAsync(Epargne epargne)
    {
        await Init();
        return await Database.DeleteAsync(epargne);
    }
}
