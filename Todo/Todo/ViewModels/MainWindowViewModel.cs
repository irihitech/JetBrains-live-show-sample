using System.Collections.Generic;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Todo.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    [ObservableProperty] private string? _input;

    [ObservableProperty] private TodoItemViewModel? _selectedItem;

    public MainWindowViewModel()
    {
        Items = TodoItemHelper.CreateItems();
    }

    public List<TodoItemViewModel> Items { get; set; }

    public void AddNewItemMethod()
    {
        Items.Add(new TodoItemViewModel
        {
            Title = Input
        });
    }
}