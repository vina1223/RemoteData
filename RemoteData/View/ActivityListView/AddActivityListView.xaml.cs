using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using RemoteData.ViewModel.ActivityList;

namespace RemoteData.View.ActivityListView;

public partial class AddActivityListView : ContentPage
{
	private AddActivityListViewModel _activityListViewModel;

	public AddActivityListView()
	{
		InitializeComponent();
		getInstance();
		BindEvent();
    }

	private void getInstance()
	{
		_activityListViewModel = (AddActivityListViewModel)BindingContext;
	}

	private void BindEvent()
	{
        _activityListViewModel.UpdateEventHandler += _activityListViewModel_UpdateEventHandler;
	}

    private void _activityListViewModel_UpdateEventHandler(object sender, Result.Recipe.MyResult e)
    {
        if(e.IsSucess)
		{
			Toast.Make(e.Message, ToastDuration.Short).Show();
		}
		else
		{
			Toast.Make(e.Message,ToastDuration.Short).Show();
		}
    }
}