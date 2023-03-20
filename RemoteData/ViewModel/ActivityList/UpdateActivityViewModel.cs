using RemoteData.HTTPModel.ActivityList;
using RemoteData.Model.ActivityList;
using RemoteData.Result.Recipe;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RemoteData.ViewModel.ActivityList
{

    public class UpdateActivityViewModel : INotifyPropertyChanged
    {
        public event EventHandler<MyResult> UpdateEventHandler;
        public event PropertyChangedEventHandler PropertyChanged;

        private UpdateActivityModel _updateActivityModel;

        private string _Name;
        private string _DateTime;
        private bool _IsComplete;

        public string Name
        {
            get { return _Name; }
            set
            {
                _Name = value;
                OnPropertyChanged();
            }
        }

        public string DateTime
        {
            get { return _DateTime; }
            set
            {
                _DateTime = value;
                OnPropertyChanged();
            }
        }

        public bool IsComplete
        {
            get { return _IsComplete; }
            set
            {
                _IsComplete = value;
                OnPropertyChanged();
            }
        }

        public ActivityRequestModel _activityRequestModel;
        
        public ActivityRequestModel activityrequestmodel
        {
            get { return _activityRequestModel; }
            set
            {
                _activityRequestModel = value;
                OnPropertyChanged();
            }
        }

        public ICommand UpdateCommand { get; private set; }

        public UpdateActivityViewModel()
        {
            _updateActivityModel = new UpdateActivityModel();
            UpdateCommand = new Command(() => { _ = UpdatedetailsAsync(); });
        }

       public async Task UpdatedetailsAsync()
        {
            _updateActivityModel.Name = _Name;
            _updateActivityModel.DateTime = _DateTime;  
            _updateActivityModel.IsComplete = _IsComplete;

            var result = await _updateActivityModel.UpdateActivityDetailsAsync();
            UpdateEventHandler?.Invoke(this, result);
        }

        public void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
