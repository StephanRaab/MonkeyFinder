using System;
using CommunityToolkit.Mvvm.ComponentModel;
using MonkeyFinder.Model;
namespace MonkeyFinder.ViewModel;


[QueryProperty("Monkey", "Monkey")]
public partial class MonkeyDetailsViewModel : BaseViewModel
{
    [ObservableProperty]
    Monkey monkey;

	public MonkeyDetailsViewModel()
	{
		//Title = this.monkey.Name;
	}
}

