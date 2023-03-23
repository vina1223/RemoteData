using RemoteData.ViewModel.Recipe;

namespace RemoteData.View;

public partial class Recipe : ContentPage
{
	private RecipeViewModel _ViewModel;
	public Recipe()
	{

		InitializeComponent();
		GetInstance();
		_=GetRecipeList();	
	}

	private void GetInstance()
	{
		_ViewModel = (RecipeViewModel)BindingContext;
	}
	private async Task GetRecipeList()
	{
		await _ViewModel.GetTaskAsync();
	}
}