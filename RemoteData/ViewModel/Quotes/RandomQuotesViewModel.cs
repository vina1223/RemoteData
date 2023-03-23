
using RemoteData.HTTPModel.Quotes;
using RemoteData.Model.Quotes;
using RemoteData.Result.Recipe;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RemoteData.ViewModel.Quotes
{
    public class RandomQuotesViewModel : INotifyPropertyChanged
    {
        public RandomQuotesModel _quotesModel;
        public event EventHandler<MyResult> GetEventHandel;

        private string _quotes;
        private string _author;
        public string Quotes
        {
            get { return _quotes; }
            set
            {
                _quotes = value;
                OnPropertyChanged();
            }
        }

        public string Authors
        {
            get { return _author; }
            set
            {
                _quotes = value;
                OnPropertyChanged();
            }
        }

        public ICommand ClickCommand { get; set; }

        public RandomQuotesViewModel()
        {
            _quotesModel= new RandomQuotesModel();
            ClickCommand = new Command(()=> { _=GetRandomQuotes();});
        }

        public async Task GetRandomQuotes()
        {
            var result = await _quotesModel.GetRandomQuotesList();
            Quotes = _quotesModel.Quotes;
            Authors = _quotesModel.Author;
            GetEventHandel?.Invoke(this, result);
        }


        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(propertyName, new PropertyChangedEventArgs(propertyName));
        }
    }
}
