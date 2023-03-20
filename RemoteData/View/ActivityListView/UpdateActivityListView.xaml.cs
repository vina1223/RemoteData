using CommunityToolkit.Maui.Alerts;
using RemoteData.ViewModel.ActivityList;

namespace RemoteData.View.ActivityListView;

public partial class UpdateActivityListView : ContentPage
{
	private UpdateActivityViewModel viewModel;

	public UpdateActivityListView()
	{
		InitializeComponent();
		GetInstance();
		BindEvent();
	}

	public  void GetInstance()
	{
		viewModel = (UpdateActivityViewModel)BindingContext;
	}

	private void BindEvent()
	{
        viewModel.UpdateEventHandler += ViewModel_UpdateEventHandler;
	}

	private void ViewModel_UpdateEventHandler(object sender, Result.Recipe.MyResult e)
	{
		if (e.IsSucess)
		{
			Toast.Make(e.Message, CommunityToolkit.Maui.Core.ToastDuration.Short).Show();

		}
		else
		{
			Toast.Make(e.Message, CommunityToolkit.Maui.Core.ToastDuration.Short).Show();
		}
    }
}