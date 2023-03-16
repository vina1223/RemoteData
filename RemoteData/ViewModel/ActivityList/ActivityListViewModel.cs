using RemoteData.HTTPModel.ActivityList;
using RemoteData.Model.ActivityList;
using RemoteData.Result.Recipe;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using CommunityToolkit.Maui.Core.Extensions;

namespace RemoteData.ViewModel.ActivityList
{
    public class ActivityListViewModel : INotifyPropertyChanged
    {
        public event EventHandler<MyResult> getEventHandler;
        private ObservableCollection<ActivityDetails> _Activitydetails;
        private ActivityListModel _ActivityModel;

        public ObservableCollection<ActivityDetails> ActivityDetails
        {
            get { return _Activitydetails; }
            set 
            { 
                _Activitydetails = value;
                OnPropertyChnaged();
            }

        }

        public ActivityListViewModel()
        {
            _ActivityModel =new ActivityListModel();
        }

        public async Task GetActivityListAsync()
        {
            var result = await _ActivityModel.GetActivityDetailsAsync();
            ActivityDetails = _ActivityModel.DetailsActivity.ToObservableCollection();
            getEventHandler?.Invoke(this,result);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChnaged([CallerMemberName] string propertyName = "")
        {
           PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));   

        }
    }
}
