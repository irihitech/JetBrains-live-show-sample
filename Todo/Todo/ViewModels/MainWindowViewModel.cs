using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

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
        AddNewItemCommand = new RelayCommand(AddNewItemMethod, CanAddNewItem);
        ClosePaneCommand = new RelayCommand(() => SelectedItem = null, () => SelectedItem != null);
    }

    public RelayCommand AddNewItemCommand { get; }
    public RelayCommand ClosePaneCommand { get; }

    public ObservableCollection<TodoItemViewModel> Items { get; set; }

    private void AddNewItemMethod()
    {
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