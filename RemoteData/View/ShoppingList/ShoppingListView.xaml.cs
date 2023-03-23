using RemoteData.ViewModel.ShoppingList;

namespace RemoteData.View.ShoppingList;

public partial class ShoppingListView : ContentPage
{
	private ShoppingListViewModel _viewModel;
	public ShoppingListView()
	{
		InitializeComponent();
		GetInstance();
		_ =GetShoppingList();
	}

	private void GetInstance()
	{
		_viewModel=(ShoppingListViewModel)BindingContext;
	}

	private async Task GetShoppingList()
	{
		await _viewModel.GetShoppingListAsync();
		await _viewModel.GetProductAsync();
	}

}