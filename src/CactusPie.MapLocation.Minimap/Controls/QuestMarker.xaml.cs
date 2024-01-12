using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using CactusPie.MapLocation.Common.Requests.Data;
using CactusPie.MapLocation.Minimap.Events;

namespace CactusPie.MapLocation.Minimap.Controls;

[DebuggerDisplay("{CustomQuestData.NameText}")]
public partial class QuestMarker : UserControl
{
    public QuestMarker(CustomQuestData customQuestData)
    {
        CustomQuestData = customQuestData;
        InitializeComponent();
    }

    public bool IsDescriptionVisible { get; private set; }

    public CustomQuestData CustomQuestData { get; }

    public event EventHandler<QuestMarkerDescriptionVisibilityChangedEventArgs>? DescriptionVisibilityChanged;

    private void QuestButton_OnClick(object sender, RoutedEventArgs e)
    {
        ToggleDescriptionVisibility();
    }

    private void DescriptionButton_OnClick(object sender, RoutedEventArgs e)
    {
        ToggleDescriptionVisibility();
    }

    private void ToggleDescriptionVisibility()
    {
        DescriptionButton.Visibility =
            DescriptionButton.Visibility == Visibility.Visible ? Visibility.Hidden : Visibility.Visible;
        IsDescriptionVisible = DescriptionButton.Visibility == Visibility.Visible;
        OnDescriptionVisibilityChanged(new QuestMarkerDescriptionVisibilityChangedEventArgs(IsDescriptionVisible));
    }

    private void OnDescriptionVisibilityChanged(QuestMarkerDescriptionVisibilityChangedEventArgs e)
    {
        EventHandler<QuestMarkerDescriptionVisibilityChangedEventArgs>? handler = DescriptionVisibilityChanged;
        handler?.Invoke(this, e);
    }
}