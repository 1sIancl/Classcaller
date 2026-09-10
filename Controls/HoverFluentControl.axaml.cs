using Avalonia.Animation;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Input;

namespace Classcaller.Controls;

public partial class HoverFluentControl : HoverControlBase
{
    protected override Button PrimaryButton => Button1;
    protected override Button SecondaryButton => Button2;
    protected override TextBlock CallTextBlock => CallText;
    protected override InputElement DragSurface => DragSurfacePanel;

    public HoverFluentControl()
    {
        InitializeComponent();
        SecondaryButton.Transitions = new Transitions
        {
            new BrushTransition
            {
                Property = TemplatedControl.ForegroundProperty,
                Duration = TimeSpan.FromMilliseconds(250)
            }
        };
        InitializeHoverControl();
    }

    protected override void ApplyThemeLayout(int hoverLayout)
    {
        bool isFullLayout = hoverLayout == 0;
        bool isMiniLayout = hoverLayout == 2;

        CallTextBlock.IsVisible = isFullLayout;
        PrimaryButton.Width = isFullLayout ? 88 : 56;

        // 界面圆角：统一应用到悬浮窗按钮，收敛到按钮半高（56/2=28）以内。
        var radius = new CornerRadius(ClampCornerRadius(28));
        PrimaryButton.CornerRadius = radius;
        SecondaryButton.IsVisible = !isMiniLayout;
        SecondaryButton.Width = 56;
        SecondaryButton.CornerRadius = radius;
    }
}
