﻿using RemoteData.HTTPModel.ActivityList;
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

        public event EventHandler Nextpage;
        public ActivityListViewModel()
        {
            _ActivityModel = new ActivityListModel();
            AddButton = new Command(Add);
            BackgroundColor();
        }

        public void Add()
        {
            Nextpage?.Invoke(this, new EventArgs());
        }


        public void BackgroundColor()
        {
            
           

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

