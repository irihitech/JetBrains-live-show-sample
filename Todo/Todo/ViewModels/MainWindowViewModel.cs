using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Todo.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    [ObservableProperty] private string? _input;

    [ObservableProperty] private TodoItemViewModel? _selectedItem;
    
    public ICommand AddNewItemCommand { get; }

    public MainWindowViewModel()
    {
        Items = new ObservableCollection<TodoItemViewModel>(TodoItemHelper.CreateItems());
        AddNewItemCommand = new RelayCommand(AddNewItemMethod);
    }

    public ObservableCollection<TodoItemViewModel> Items { get; set; }

    private void AddNewItemMethod()
    {
        Items.Add(new TodoItemViewModel
        {
            Title = Input
        });
    }
}