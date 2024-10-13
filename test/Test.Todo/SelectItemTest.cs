using Todo.ViewModels;

namespace Test.Todo;

public class SelectItemTest
{
    [Fact]
    public void SelectItem_Change_CloseCommandCanExecute()
    {
        // Arrange
        var viewModel = new MainWindowViewModel();
        Assert.Equal(9, viewModel.Items.Count);

        Assert.False(viewModel.ClosePaneCommand.CanExecute(null));

        viewModel.SelectedItem = viewModel.Items[0];

        Assert.NotNull(viewModel.SelectedItem);

        Assert.True(viewModel.ClosePaneCommand.CanExecute(null));
        
        viewModel.ClosePaneCommand.Execute(null);
        
        Assert.Null(viewModel.SelectedItem);
    }
}