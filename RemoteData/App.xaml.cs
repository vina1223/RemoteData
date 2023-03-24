﻿using RemoteData.View;
using RemoteData.View.ActivityListView;
using RemoteData.View.Employee;
using RemoteData.View.Login;
using RemoteData.View.Quotes;
using RemoteData.View.ShoppingList;
using RemoteData.View.WhatsappTabbedPage;
using RemoteData.ViewModel.Recipe;
using System.Xml;

namespace RemoteData;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage =new AddEmployeeView();

	}
}
