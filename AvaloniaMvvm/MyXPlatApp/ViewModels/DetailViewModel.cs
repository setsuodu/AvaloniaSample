using CommunityToolkit.Mvvm.Input;
using MyXPlatApp.Models;

namespace MyXPlatApp.ViewModels;

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