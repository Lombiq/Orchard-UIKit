namespace Lombiq.UIKit.Widgets.Settings;

public class CarouselWidgetPartSettings
{
    public bool Acessibility { get; set; } = true;
    public bool AdaptiveHeight { get; set; }
    public bool AutoPlay { get; set; }
    public bool Arrows { get; set; } = true;
    public bool CenterMode { get; set; }
    public string CenterPadding { get; set; } = "50px";
    public bool Dots { get; set; } = true;
    public string DotsClass { get; set; } = string.Empty;
    public bool Draggable { get; set; } = true;
    public bool Fade { get; set; } = true;
}
