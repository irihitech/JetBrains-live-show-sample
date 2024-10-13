﻿using System.Collections.Generic;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Todo.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    public List<TodoItemViewModel> Items { get; set; }
    
    [ObservableProperty] private TodoItemViewModel? _selectedItem;

    public MainWindowViewModel()
    {
        Items = TodoItemHelper.CreateItems();
    }
}