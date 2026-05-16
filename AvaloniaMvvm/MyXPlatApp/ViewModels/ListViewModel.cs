using System;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using MyXPlatApp.Models;

namespace MyXPlatApp.ViewModels;

public partial class ListViewModel : ViewModelBase
{
    private readonly MainViewModel _mainVm;

    [ObservableProperty]
    private ObservableCollection<Item> _items;

    [ObservableProperty]
    private Item? _selectedItem;

    public ListViewModel(MainViewModel mainVm)
    {
        _mainVm = mainVm;
        _items = new ObservableCollection<Item>
        {
            new Item(".NET 10 特性一览", "这里是 A 的详情内容"),
            new Item("Avalonia 11 技巧", "这里是 B 的详情内容"),
            new Item("跨平台 UI 指南", "这里是 C 的详情内容"),
            new Item("跨平台 UI 指南", "这里是 D 的详情内容"),
            new Item("跨平台 UI 指南", "这里是 E 的详情内容"),
            new Item("跨平台 UI 指南", "这里是 F 的详情内容"),
            new Item("跨平台 UI 指南", "这里是 G 的详情内容"),
            new Item("跨平台 UI 指南", "这里是 H 的详情内容"),
            new Item("跨平台 UI 指南", "这里是 I 的详情内容"),
            new Item("跨平台 UI 指南", "这里是 J 的详情内容"),
            new Item("跨平台 UI 指南", "这里是 K 的详情内容"),
            new Item("跨平台 UI 指南", "这里是 L 的详情内容"),
            new Item("跨平台 UI 指南", "这里是 M 的详情内容"),
            new Item("跨平台 UI 指南", "这里是 N 的详情内容"),
            new Item("跨平台 UI 指南", "这里是 O 的详情内容"),
            new Item("跨平台 UI 指南", "这里是 P 的详情内容"),
            new Item("跨平台 UI 指南", "这里是 Q 的详情内容"),
            new Item("跨平台 UI 指南", "这里是 R 的详情内容"),
            new Item("跨平台 UI 指南", "这里是 S 的详情内容"),
            new Item("跨平台 UI 指南", "这里是 T 的详情内容")
        };
    }

    partial void OnSelectedItemChanged(Item? value)
    {
        if (value != null)
        {
            // 日志：看看点了没
            Console.WriteLine($">>> [LOG] 点击了: {value.Title}");

            _mainVm.GoToDetail(value);

            // 重点！跳转后必须置空，否则返回后无法二次点击
            SelectedItem = null;
        }
    }
}