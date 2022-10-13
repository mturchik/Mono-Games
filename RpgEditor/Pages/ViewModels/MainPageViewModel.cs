using System.Windows.Input;

namespace RpgEditor.Pages.ViewModels;
public class MainPageViewModel
{
    public ICommand NavigationCommand { private set; get; }

    public MainPageViewModel()
    {
        NavigationCommand = new Command<string>(
            execute: (string route) =>
            {
                Shell.Current.GoToAsync(route);
            },
            canExecute: (string route) => true
        );
    }
}
