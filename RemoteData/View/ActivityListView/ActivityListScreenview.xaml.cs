using RemoteData.ViewModel.ActivityList;

namespace RemoteData.View.ActivityListView;

public partial class ActivityListScreenview : ContentPage
{
	private ActivityListViewModel _activityListViewModel;
	public ActivityListScreenview()
	{
		InitializeComponent();
		GetInstance();
		_=GetActivityList();

	}

	private void GetInstance()
	{
		_activityListViewModel = (ActivityListViewModel)BindingContext;
	}

	private async Task GetActivityList()
	{
		await _activityListViewModel.GetActivityListAsync();
	}
}