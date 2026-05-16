using Avalonia.Controls;
using Avalonia.Input;
using Anime.Avalonia.Models;
using Anime.Avalonia.ViewModels;

namespace Anime.Avalonia.Views;

public partial class ListView : UserControl
{
    public ListView()
    {
        InitializeComponent();
    }

    // 处理条目点击事件
    private void OnItemPointerPressed(object? sender, PointerPressedEventArgs e)
    {
        if (sender is Control control && control.DataContext is AnimeModel selectedAnime)
        {
            if (DataContext is ListViewModel vm)
            {
                // 触发 ViewModel 中的属性变更，进而执行跳转逻辑
                vm.SelectedItem = selectedAnime;
            }
        }
    }
}