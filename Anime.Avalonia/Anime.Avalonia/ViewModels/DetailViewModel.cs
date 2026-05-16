using Anime.Avalonia.Models;
using CommunityToolkit.Mvvm.Input;

namespace Anime.Avalonia.ViewModels;

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