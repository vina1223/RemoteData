using CommunityToolkit.Maui.Core.Extensions;
using RemoteData.HTTPModel.ShoppingList;
using RemoteData.Model.ShoppingList;
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

namespace RemoteData.ViewModel.ShoppingList
{
    public class ShoppingListViewModel : INotifyPropertyChanged
    {
        public event EventHandler<MyResult> GetEventHandler;

        private ObservableCollection<string> _ShoppingDetails;
        private ObservableCollection<ShoppingDetails> _ProductList;
        private ShoppingListModel _ShoppingModel;
        private ProductListModel _ProductListModel;

        public ObservableCollection<string> MyShoppingDetails
        {
            get => _ShoppingDetails;
            set
            {
                _ShoppingDetails = value;
                OnPropertyChanged();
            }
        }

       public ObservableCollection<ShoppingDetails> ProductList
        {
            get => _ProductList;
            set
            {
                _ProductList = value;
                OnPropertyChanged();
            }
        }

        private string _ShoppinglistResponceModel;
        public string SelectedCategory
        {
            get => _ShoppinglistResponceModel;
            set
            {
                _ShoppinglistResponceModel = value;
                OnPropertyChanged();
            }
        }
        public ShoppingListViewModel()
        {
            _ShoppingModel = new ShoppingListModel();
            _ProductListModel = new ProductListModel();
            ClickCommand = new Command(() => { _ = GetProductAsync(); });  
        }
       

        public ICommand ClickCommand { get; private set; }

      
        public async Task GetShoppingListAsync()
        {
            var result = await _ShoppingModel.GetShoppingListDetailsAsync(); ;
            MyShoppingDetails = _ShoppingModel.ShoppingDetails.ToObservableCollection();
            SelectedCategory = MyShoppingDetails.FirstOrDefault();
            _ProductListModel.Category = SelectedCategory;
            GetEventHandler?.Invoke(this, result);
        }

        public async Task GetProductAsync()
        {
            var results = _ProductListModel.GetProductDetailsAsync();
            ProductList = _ProductListModel.ShoppingList.ToObservableCollection();
            _ProductListModel.Category = SelectedCategory;
            GetEventHandler?.Invoke(this, await results);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(propertyName, new PropertyChangedEventArgs(propertyName));  
        }
    }
}
