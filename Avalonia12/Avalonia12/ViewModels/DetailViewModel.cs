using Avalonia12.Models;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace Avalonia12.ViewModels;

public partial class DetailViewModel : ViewModelBase
{
    private readonly MainViewModel _mainVm;

    public Item Item { get; }

    public DetailViewModel(MainViewModel mainVm, Item item)
    {
        _mainVm = mainVm;
        Item = item;
    }

    [RelayCommand]
    public void Back()
    {
        _mainVm.GoBack();
    }
}