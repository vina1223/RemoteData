using RemoteData.HTTPModel.ActivityList;
using RemoteData.Model.ActivityList;
using RemoteData.Result.Recipe;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using CommunityToolkit.Maui.Core.Extensions;
using System.Windows.Input;

namespace RemoteData.ViewModel.ActivityList
{
    public class ActivityListViewModel : INotifyPropertyChanged
    {
        public event EventHandler<MyResult> getEventHandler;
        private ObservableCollection<ActivityDetails> _Activitydetails;
        private ActivityListModel _ActivityModel;
        private ActivityDetails activity;
        private bool _changeBack;

        public bool ChangeBack
        {
            get { return _changeBack;}
            set
            {
                _changeBack = value;
                
                OnPropertyChnaged();
            }
        }
      

        public ObservableCollection<ActivityDetails> ActivityDetails
        {
            get { return _Activitydetails; }
            set
            {
                _Activitydetails = value;
                OnPropertyChnaged();
            }

        }

        private Color _ChangeColor;
        public Color ChangeColor
        {
            get { return _ChangeColor; }
            set
            {
                _ChangeColor = value;
                OnPropertyChnaged();
            }
        }

        private bool _ActivityIndicator;
        public bool Activity
        {
            get { return _ActivityIndicator; }
            set
            {
                _ActivityIndicator = value;
                OnPropertyChnaged();
            }
        }

        public ICommand AddButton { get; set; }
        public ICommand EditButton { get; set; }

        public event EventHandler Nextpage;
        public event EventHandler UpdatePage;
        public ActivityListViewModel()
        {
            _ActivityModel = new ActivityListModel();
            AddButton = new Command(Add);
            EditButton = new Command(Update);           
            _deleteActivityModel = new DeleteActivityModel();
            DeleteCommand = new Command(() => { _ = DeleteDetailsAsync(); });
            BackgroundColorChange();
        }

        public void Add()
        {
            Nextpage?.Invoke(this, new EventArgs());
        }

        public  void Update()
        {
            UpdatePage?.Invoke(this, new EventArgs());
        }
       
        public void BackgroundColorChange()
        {
            ChangeBack = activity.Complete;
            if (ChangeBack == true)
            {
                ChangeColor = Colors.Green;
            }
            else
            {
                ChangeColor = Colors.Red;
            }
        }


        public event EventHandler<MyResult> DeleteEventHandler;

        public DeleteActivityModel _deleteActivityModel;

        private int _id;
        public int Id
        {
            get => _id; 
            set
            {
                _id = value;
                OnPropertyChnaged();
            }
        }

        public ICommand DeleteCommand { get; private set; }

        public async Task DeleteDetailsAsync()
        {
           _deleteActivityModel.Id = _id;
            var result = await _deleteActivityModel.DeleteActivityDetailAsync();
            DeleteEventHandler?.Invoke(this, result);
        }



        public async Task GetActivityListAsync()
        {
            Activity = true;
            var result = await _ActivityModel.GetActivityDetailsAsync();
            ActivityDetails = _ActivityModel.DetailsActivity.ToObservableCollection();
            
            getEventHandler?.Invoke(this, result);
            Activity = false;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChnaged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        }
    }
}

