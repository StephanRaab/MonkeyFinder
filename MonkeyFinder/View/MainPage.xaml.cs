﻿namespace MonkeyFinder;
using MonkeyFinder.ViewModel;

public partial class MainPage : ContentPage
{
	public MainPage(MonkeysViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}


