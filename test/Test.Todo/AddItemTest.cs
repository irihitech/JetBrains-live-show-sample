using Todo.ViewModels;

namespace Test.Todo;

public class AddItemTest
{
    [Fact]
    public async void ExecuteCommand_WillAddNewItem()
    {
        // Arrange
        var viewModel = new MainWindowViewModel();
        Assert.Equal(9, viewModel.Items.Count);

        Assert.False(viewModel.AddNewItemCommand.CanExecute(null));

        viewModel.Input = "Hello World";

        Assert.True(viewModel.AddNewItemCommand.CanExecute(null));
        await viewModel.AddNewItemCommand.ExecuteAsync(null);
        
        Assert.Equal(10, viewModel.Items.Count);
        Assert.Equal("Hello World", viewModel.Items.Last().Title);
    }
}