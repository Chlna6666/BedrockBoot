using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using BedrockBoot.Base.Entry.Game;
using BedrockBoot.Views.Pages.InstanceSubPage.DrawContent.UserConfigSubPage;

namespace BedrockBoot.Views.Pages.InstanceSubPage.DrawContent;

public partial class InstanceUserConfig : UserControl
{
    public VersionConfig VersionConfig { get; set; }
    public InstanceUserConfig()
    {
        InitializeComponent();
    }

    public InstanceUserConfig(VersionConfig versionConfig) : this()
    {
        VersionConfig = versionConfig;
        UpdateUI();
    }

    private void UpdateUI()
    {
        NavigationFrame.NavigateTo(new UserConfigSkin());   
    }

    private void UserChooseBox_OnSelectionChanged(object? sender, SelectionChangedEventArgs e)
    {
        
    }
}