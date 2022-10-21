
namespace RpgEditor.Pages.DataManagers;
public class DataManagerBase<T> : ComponentBase where T : BaseData
{
    [Inject] protected GameDataManager GameDataManager { get; set; } = default!;
    [Inject] protected DialogService DialogService { get; set; } = default!;

    protected GameDataSet<T> DataSet => GameDataManager.GetDataSet<T>();
    protected IQueryable<T> Data => DataSet.Queryable();
    protected T? Edit { get; set; }

    protected virtual void StartEdit(T? data)
    {
        Edit = data;
    }

    protected async Task Delete(T data)
    {
        var confirm = await DialogService.Confirm(
            "Record will be permanently deleted",
            "Delete Record?"
        );
        if (confirm.GetValueOrDefault())
        {
            DataSet.Delete(data);
            Edit = null;
        }
    }

    protected async Task SubmitForm()
    {
        if (Edit is null) return;

        var duplicate = Data.FirstOrDefault(d => d.Name == Edit.Name && d.Id != Edit.Id);
        if (duplicate != null)
        {
            var confirm = await DialogService.Confirm(
                "Saving will overwrite the existing record",
                "Record exists with this name",
                new() { OkButtonText = "Save" }
            );
            if (confirm ?? false)
                DataSet.Delete(duplicate);
            else
                return;
        }

        DataSet.Upsert(Edit);
        Edit = null;
    }
}
