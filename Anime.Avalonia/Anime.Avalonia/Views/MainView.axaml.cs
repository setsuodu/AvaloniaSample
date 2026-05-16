using Avalonia;
using Avalonia.Controls;
using Anime.Avalonia.ViewModels;
using System;

namespace Anime.Avalonia.Views;

public partial class MainView : UserControl
{
    public MainView()
    {
        InitializeComponent();
    }

    protected override void OnAttachedToVisualTree(VisualTreeAttachmentEventArgs e)
    {
        base.OnAttachedToVisualTree(e);

        // 只保留物理返回键拦截，其余全删干净
        var topLevel = TopLevel.GetTopLevel(this);
        if (topLevel != null)
        {
            topLevel.BackRequested += (s, args) =>
            {
                if (DataContext is MainViewModel mainVm && mainVm.CanGoBack)
                {
                    Console.WriteLine(">>> [EVENT] 物理返回键触发");
                    mainVm.GoBack();
                    args.Handled = true;
                }
            };
        }
    }
}