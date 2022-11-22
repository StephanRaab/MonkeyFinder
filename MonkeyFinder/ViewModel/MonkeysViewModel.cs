﻿using System.Diagnostics;
using MonkeyFinder.Services;
using MonkeyFinder.Model;
using MonkeyFinder.View;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.Input;

namespace MonkeyFinder.ViewModel;

public partial class MonkeysViewModel : BaseViewModel
{
    public ObservableCollection<Monkey> Monkeys { get; } = new();
    MonkeyService monkeyService;

    public MonkeysViewModel(MonkeyService monkeyService)
    {
        Title = "Monkey Finder";
        this.monkeyService = monkeyService;
    }

    [RelayCommand]
    async Task GoToDetailsAsync(Monkey monkey)
    {
        if (monkey is null)
            return;
        await Shell.Current.GoToAsync($"{nameof(DetailsPage)}", true,
            new Dictionary<string, Object>
            {
                {"Monkey", monkey }
            });
    }

    [RelayCommand]
    async Task GetMonkeysAsync()
    {
        if (IsBusy)
            return;

        try
        {
            IsBusy = true;
            var monkeys = await monkeyService.GetMonkeys();

            if (Monkeys.Count != 0)
                Monkeys.Clear();

            foreach (var monkey in monkeys)
                Monkeys.Add(monkey);

        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Unable to get monkeys: {ex.Message}");
            await Shell.Current.DisplayAlert("Error!", ex.Message, "OK");
        }
        finally
        {
            IsBusy = false;
        }
    }
}