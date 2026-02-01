using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Markup.Xaml;
using Avalonia.Media.Imaging;
using PointerType = LiteSkinViewer3D.Shared.Enums.PointerType;

namespace BedrockBoot.Views.Pages.InstanceSubPage.DrawContent.UserConfigSubPage;

public partial class UserConfigSkin : UserControl
{
    public UserConfigSkin()
    {
        InitializeComponent();
        SkinViewer.Skin = new(@"D:\UserFiles\Desktop\BedrockBoot\src\BedrockBoot\Assets\Image\PlayerSkin\Steve.png");
        SkinViewer.PointerMoved += SkinViewer_PointerMoved;
        SkinViewer.PointerPressed += SkinViewer_PointerPressed;
        SkinViewer.PointerReleased += SkinViewer_PointerReleased;
    }
    private void SkinViewer_PointerReleased(object? sender, PointerReleasedEventArgs e) {
        var po = e.GetCurrentPoint(this);
        var pos = e.GetPosition(this);

        PointerType type = PointerType.None;
        if (po.Properties.IsLeftButtonPressed) {
            type = PointerType.PointerLeft;
        } else if (po.Properties.IsRightButtonPressed) {
            type = PointerType.PointerRight;
        }

        SkinViewer.UpdatePointerReleased(type, new((float)pos.X, (float)pos.Y));

    }

    private void SkinViewer_PointerPressed(object? sender, PointerPressedEventArgs e) {
        var po = e.GetCurrentPoint(this);
        var pos = e.GetPosition(this);

        PointerType type = PointerType.None;
        if (po.Properties.IsLeftButtonPressed) {
            type = PointerType.PointerLeft;
        } else if (po.Properties.IsRightButtonPressed) {
            type = PointerType.PointerRight;
        }

        SkinViewer.UpdatePointerPressed(type, new((float)pos.X, (float)pos.Y));
    }

    private void SkinViewer_PointerMoved(object? sender, PointerEventArgs e) {
        var po = e.GetCurrentPoint(this);
        var pos = e.GetPosition(this);

        PointerType type = PointerType.None;
        if (po.Properties.IsLeftButtonPressed) {
            type = PointerType.PointerLeft;
        } else if (po.Properties.IsRightButtonPressed) {
            type = PointerType.PointerRight;
        }

        SkinViewer.UpdatePointerMoved(type, new((float)pos.X, (float)pos.Y));
    }
}