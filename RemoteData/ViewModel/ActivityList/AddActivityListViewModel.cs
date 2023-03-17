using RemoteData.EndPoint.AvitvityList;
using RemoteData.Model.ActivityList;
using RemoteData.Result.Recipe;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace RemoteData.ViewModel.ActivityList
{
    public class AddActivityListViewModel : INotifyPropertyChanged
    {
        public event EventHandler<MyResult> UpdateEventHandler;

        private AddActivityListModel  _activityModel;

        private string _Name;
        private string _DateTime;
        private bool _Complete;





        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
