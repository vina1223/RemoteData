using RemoteData.EndPoint.AvitvityList;
using RemoteData.Model.ActivityList;
using RemoteData.Result.Recipe;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RemoteData.ViewModel.ActivityList
{
    public class AddActivityListViewModel : INotifyPropertyChanged
    {
        public event EventHandler<MyResult> UpdateEventHandler;

        private AddActivityListModel  _activityModel;

        private string _Name;
        private string _DateTime;
        private bool _Complete;

        public string Name
        {
            get => _Name; 
            set
            {
                _Name = value;
                OnPropertyChanged();
            }
        }
        public string DateTime
        {
            get => _DateTime; 
            set
            {
                _DateTime = value;
                OnPropertyChanged();
            }
        }
        public bool Complete
        {
            get => _Complete; 
            set
            {
                _Complete = value;
                OnPropertyChanged();
            }
        }

        public ICommand AddActivityCommand { get; private set; }
        public AddActivityListViewModel()
        {
           _activityModel = new AddActivityListModel();
            AddActivityCommand = new Command(() => { _ = AddActivityDetails(); });
        }

        public async Task AddActivityDetails()
        {
            _activityModel.Name = _Name;
            _activityModel.DataTime = _DateTime;
            _activityModel.IsComplete = _Complete;
            var result = await _activityModel.AddActivityDetailsAsync();
           UpdateEventHandler?.Invoke(this, result);
        }



        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
