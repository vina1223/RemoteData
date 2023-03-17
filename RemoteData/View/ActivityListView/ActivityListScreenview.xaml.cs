using RemoteData.Model.ActivityList;
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
        _activityListViewModel.Nextpage += _activityListViewModel_Nextpage;

	}

    private async void _activityListViewModel_Nextpage(object sender, EventArgs e)
    {
		await Navigation.PushAsync(new AddActivityListView());
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