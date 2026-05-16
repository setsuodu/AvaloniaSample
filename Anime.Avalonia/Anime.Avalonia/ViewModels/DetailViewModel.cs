using Anime.Avalonia.Models;
using CommunityToolkit.Mvvm.Input;

namespace Anime.Avalonia.ViewModels;

public partial class DetailViewModel : ViewModelBase
{
    private readonly MainViewModel _mainVm;

    public AnimeModel Anime { get; }   // ← 原 Item 改成 AnimeModel

    public DetailViewModel(MainViewModel mainVm, AnimeModel anime)
    {
        _mainVm = mainVm;
        Anime = anime;
    }

    [RelayCommand]
    public void Back()
    {
        _mainVm.GoBack();
    }
}