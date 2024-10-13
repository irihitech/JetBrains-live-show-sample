using System;
using System.Collections.Generic;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Todo.ViewModels;

public partial class TodoItemViewModel : ObservableObject
{
    [ObservableProperty] private string? _description;
    [ObservableProperty] private DateTime? _dueDate;
    [ObservableProperty] private bool _isDone;
    [ObservableProperty] private bool _isImportant;
    [ObservableProperty] private string? _title;
}

internal static class TodoItemHelper
{
    private static TodoItemViewModel Create(string title, string? description, DateTime? dueDate,
        bool isImportant = false)
    {
        return new TodoItemViewModel
        {
            Title = title,
            Description = description,
            DueDate = dueDate,
            IsImportant = isImportant
        };
    }

    public static List<TodoItemViewModel> CreateItems()
    {
        return
        [
            Create("直播彩排", "准备好直播所需的所有材料", new DateTime(2024, 10, 15), true),
            Create("演示项目源代码", "确保项目源代码已经准备好并上传至Github", new DateTime(2024, 10, 14), true),
            Create("PPT", "准备好直播所需的所有PPT", new DateTime(2024, 10, 14)),
            Create("提供互动问题", "准备好直播所需的所有Demo", new DateTime(2024, 10, 14)),
            Create("更新Ursa", "准备Ursa 10月份的更新", new DateTime(2024, 10, 31)),
            Create("准备下一场分享", "开始筹备1026黄浦论坛的分享", new DateTime(2024, 10, 20)),
            Create("给小小买猫粮", null, new DateTime(2024, 10, 18)),
            Create("抢购演唱会门票", "抢购熊猫堂上海演唱会门票", new DateTime(2024, 10, 15)),
            Create("准备工作周报", "准备好周报的所有内容", new DateTime(2024, 10, 14))
        ];
    }
}