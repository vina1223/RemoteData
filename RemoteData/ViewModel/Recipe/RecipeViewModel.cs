using RemoteData.HTTPModel.Recipe;
using RemoteData.Model.Recipe;
using RemoteData.Result.Recipe;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace RemoteData.ViewModel.Recipe
{
    public class RecipeViewModel : INotifyPropertyChanged
    {

        public event EventHandler<MyResult> GetEventHandler;
        private ObservableCollection<RecipeDetails> _RecipeDetails;
        private RecipeModel _recipeModel;
        public ObservableCollection <RecipeDetails> RecipeDetails
        {
            get { return _RecipeDetails; }
            set
            {
                _RecipeDetails= value;
                OnPropertyChanged();
            }
        }

        private bool _ActivityIndicator;
        public bool Activity
        {
            get { return _ActivityIndicator; }
            set
            {
                _ActivityIndicator= value;
                OnPropertyChanged();
            }
        }

        private bool _Refreshing;
        public bool Refreshing
        {
            get { return _Refreshing; }
            set
            {
                _Refreshing= value;
                OnPropertyChanged();
            }
        }

        public ICommand RefeshCommand { get; private set; }

        public RecipeViewModel()
        {
            _recipeModel = new RecipeModel();
            RefeshCommand = new Command(RefreshMethod);
        }
        public async Task GetTaskAsync()
        {
            Activity = true;
            var result = await _recipeModel.GetRecipeAsync();
            RecipeDetails = _recipeModel.Details;
            GetEventHandler?.Invoke(this, result);
            Activity= false;
        }

        public void RefreshMethod()
        {
            if(Refreshing == true)
            {
                _ = GetTaskAsync();
                Refreshing= false;
            }

        }


        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
