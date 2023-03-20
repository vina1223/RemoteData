using CommunityToolkit.Maui.Alerts;
using RemoteData.HTTPModel.ActivityList;
using RemoteData.Model.ActivityList;
using RemoteData.ViewModel.ActivityList;

namespace RemoteData.View.ActivityListView;

public partial class ActivityListScreenview : ContentPage
{
    private ActivityListViewModel _activityListViewModel;
    private UpdateActivityViewModel _UpdateActivityViewModel;
    private DeleteActivityListViewModel _deleteActivityListViewModel;
    public ActivityListScreenview()
    {
        InitializeComponent();
        GetInstance();
        BindEvent();
        _ = GetActivityList();
        _activityListViewModel.Nextpage += _activityListViewModel_Nextpage;
        _activityListViewModel.UpdatePage += _activityListViewModel_UpdatePage;

    }

    private async void _activityListViewModel_UpdatePage(object sender, EventArgs e)
    {

        await Navigation.PushAsync(new UpdateActivityListView());
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

    private void BindEvent()
    {
        _activityListViewModel.DeleteEventHandler += _deleteActivityListViewModel_DeleteEventHandler;
    }

    private void _deleteActivityListViewModel_DeleteEventHandler(object sender, Result.Recipe.MyResult e)
    {
        if(e.IsSucess)
        {
            Toast.Make(e.Message, CommunityToolkit.Maui.Core.ToastDuration.Short).Show();
        }
        else
        {
            Toast.Make(e.Message, CommunityToolkit.Maui.Core.ToastDuration.Short).Show();
        }
    }
}

