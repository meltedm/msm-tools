using Avalonia;
using Avalonia.Controls;

namespace Startup;

internal abstract class UiGlobal : AvaloniaObject
{
    public static readonly string TransparencyEnabled = nameof(TransparencyEnabled);
    public static readonly AttachedProperty<bool> TransparencyEnabledProperty = AvaloniaProperty.RegisterAttached<UiGlobal, Control, bool>(nameof(TransparencyEnabled), true, true);
    public static void SetTransparencyEnabled(Control obj, bool value) => obj.SetValue(TransparencyEnabledProperty, value);
    public static bool GetTransparencyEnabled(Control obj) => obj.GetValue(TransparencyEnabledProperty);
}