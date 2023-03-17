﻿using RemoteData.View;
using RemoteData.View.ActivityListView;
using RemoteData.ViewModel.Recipe;
using System.Xml;

namespace RemoteData;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage =new NavigationPage(new ActivityListScreenview());
	}
}
