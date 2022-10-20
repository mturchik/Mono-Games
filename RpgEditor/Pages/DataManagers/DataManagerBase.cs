using Microsoft.AspNetCore.Components;

namespace RpgEditor.Pages.DataManagers;
public class DataManagerBase<T> : ComponentBase where T : BaseData
{
    [Inject] protected GameDataManager GameDataManager { get; set; } = default!;

    protected GameDataSet<T> DataSet => GameDataManager.GetDataSet<T>();
    protected IQueryable<T> Data => DataSet.Queryable();
    protected T? Edit { get; set; }

    protected virtual void StartEdit(T? data)
    {
        Edit = data;
    }

    protected void Delete(T data)
    {
        DataSet.Delete(data);
        Edit = null;
    }

    protected void SubmitForm()
    {
        if (Edit is null) return;
        DataSet.Upsert(Edit);
        Edit = null;
    }
}
