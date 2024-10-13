using System.Collections.ObjectModel;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Ursa.Controls;

namespace Todo.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    [ObservableProperty] [NotifyCanExecuteChangedFor(nameof(AddNewItemCommand))]
    private string? _input;

    [ObservableProperty] [NotifyCanExecuteChangedFor(nameof(ClosePaneCommand))]
    private TodoItemViewModel? _selectedItem;

    public MainWindowViewModel()
    {
        Items = new ObservableCollection<TodoItemViewModel>(TodoItemHelper.CreateItems());
        AddNewItemCommand = new AsyncRelayCommand(AddNewItemMethod, CanAddNewItem);
        ClosePaneCommand = new RelayCommand(() => SelectedItem = null, () => SelectedItem != null);
    }

    public AsyncRelayCommand AddNewItemCommand { get; }
    public RelayCommand ClosePaneCommand { get; }

    public ObservableCollection<TodoItemViewModel> Items { get; set; }

    private async Task AddNewItemMethod()
    {
        var result = await MessageBox.ShowOverlayAsync("Do you want to add this item?", "Add Item",
            button: MessageBoxButton.YesNo);
        if (result == MessageBoxResult.No) return;
        Items.Add(new TodoItemViewModel
        {
            Title = Input
        });
        Input = string.Empty;
    }

    private bool CanAddNewItem()
    {
        return !string.IsNullOrWhiteSpace(Input);
    }
}