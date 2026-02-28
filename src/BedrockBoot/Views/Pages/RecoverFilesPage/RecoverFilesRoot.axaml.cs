using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Material.Avalonia.Controls;
using OnePointUI.Avalonia.Styling.Controls.OnePointControls.Navigation;

namespace BedrockBoot.Views.Pages.RecoverFilesPage;

public partial class RecoverFilesRoot : UserControl
{
    public static NavigationFrame NavigationFrameStatic { get; set; }

    public RecoverFilesRoot()
    {
        InitializeComponent();
        NavigationFrameStatic = this.NavigationFrame;
        NavigationFrameStatic.NavigateTo(new RecoverFilesWellcom());
    }
}