using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.Generic;
using Anime.Avalonia.Models;

namespace Anime.Avalonia.ViewModels;

public partial class MainViewModel : ViewModelBase
{
    [ObservableProperty]
    private ViewModelBase? _currentPage;

    [ObservableProperty]
    private bool _isTransitionReversed = false;   // ← 必须加

    private readonly Stack<ViewModelBase> _history = new();

    public MainViewModel()
    {
        CurrentPage = new ListViewModel(this);
    }

    public bool CanGoBack => _history.Count > 0;

    public void GoToDetail(AnimeModel item)
    {
        System.Diagnostics.Debug.WriteLine($"🔍 点击了: {item.Title}");
        _history.Push(CurrentPage!);
        IsTransitionReversed = false;     // 前进：右→左
        CurrentPage = new DetailViewModel(this, item);
    }

    public void GoBack()
    {
        if (CanGoBack)
        {
            IsTransitionReversed = true;  // 后退：左→右
            CurrentPage = _history.Pop();
        }
    }
}