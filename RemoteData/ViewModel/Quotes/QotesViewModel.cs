using RemoteData.HTTPModel.Quotes;
using RemoteData.Model.Quotes;
using RemoteData.Result.Recipe;
using RemoteData.View.Quotes;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace RemoteData.ViewModel.Quotes
{
    public class QotesViewModel : INotifyPropertyChanged
    {
        public QuotesModel _quotesModel;

        public event EventHandler<MyResult> GetEventhandle;
        public ObservableCollection<QuotesDetails> _quotesList;

        public ObservableCollection<QuotesDetails> QuotesList
        {
            get { return _quotesList; }
            set 
            {
                _quotesList = value;
                OnPropertyChanged();
            }
        }

        public QotesViewModel() 
        {
            _quotesModel= new QuotesModel();
        }

        public async Task GetTaskAsync()
        {
            var result = await _quotesModel.GetQuotes();
            QuotesList = _quotesModel.Details;
            GetEventhandle?.Invoke(this, result);
        }


        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
