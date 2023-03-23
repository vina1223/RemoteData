using RemoteData.ViewModel.Quotes;

namespace RemoteData.View.Quotes;

public partial class QuotesView : ContentPage
{
	private QotesViewModel _quotesViewModel;
	public QuotesView()
	{
		InitializeComponent();
		GetInstance();
		_ = GetTask();
	}

	public void GetInstance()
	{
		_quotesViewModel = (QotesViewModel)BindingContext;
	}

	public async Task GetTask()
	{
	    await  _quotesViewModel.GetTaskAsync();
	}
}