
using Lombiq.UIKit.Widgets.Constants;

namespace Lombiq.UIKit.Widgets.Settings;

public class CarouselWidgetPartSettings
{
    public bool Accessibility { get; set; } = DefaultValues.Accessibility;
    public bool AdaptiveHeight { get; set; } = DefaultValues.AdaptiveHeight;
    public bool Autoplay { get; set; } = DefaultValues.Autoplay;
    public int AutoplaySpeed { get; set; } = DefaultValues.AutoplaySpeed;
    public bool Arrows { get; set; } = DefaultValues.Arrows;
    public string AsNavFor { get; set; } = DefaultValues.AsNavFor;
    public string AppendArrows { get; set; } = DefaultValues.AppendArrows;
    public string AppendDots { get; set; } = DefaultValues.AppendDots;
    public string PrevArrow { get; set; } = DefaultValues.PrevArrow;
    public string NextArrow { get; set; } = DefaultValues.NextArrow;
    public bool CenterMode { get; set; } = DefaultValues.CenterMode;
    public string CenterPadding { get; set; } = DefaultValues.CenterPadding;
    public string CssEase { get; set; } = DefaultValues.CssEase;
    public bool Dots { get; set; } = DefaultValues.Dots;
    public string DotsClass { get; set; } = DefaultValues.DotsClass;
    public bool Draggable { get; set; } = DefaultValues.Draggable;
    public bool Fade { get; set; } = DefaultValues.Fade;
    public bool FocusOnSelect { get; set; } = DefaultValues.FocusOnSelect;
    public string Easing { get; set; } = DefaultValues.Easing;
    public float EdgeFriction { get; set; } = DefaultValues.EdgeFriction;
    public bool Infinite { get; set; } = DefaultValues.Infinite;
    public int InitialSlide { get; set; } = DefaultValues.InitialSlide;
    public string LazyLoad { get; set; } = DefaultValues.LazyLoad;
    public bool MobileFirst { get; set; } = DefaultValues.MobileFirst;
    public bool PauseOnFocus { get; set; } = DefaultValues.PauseOnFocus;
    public bool PauseOnHover { get; set; } = DefaultValues.PauseOnHover;
    public bool PauseOnDotsHover { get; set; } = DefaultValues.PauseOnDotsHover;
    public string RespondTo { get; set; } = DefaultValues.RespondTo;
    public int Rows { get; set; } = DefaultValues.Rows;
    public string Slide { get; set; } = DefaultValues.Slide;
    public int SlidesPerRow { get; set; } = DefaultValues.SlidesPerRow;
    public int SlidesToShow { get; set; } = DefaultValues.SlidesToShow;
    public int SlidesToScroll { get; set; } = DefaultValues.SlidesToScroll;
    public int Speed { get; set; } = DefaultValues.Speed;
    public bool Swipe { get; set; } = DefaultValues.Swipe;
    public bool SwipeToSlide { get; set; } = DefaultValues.SwipeToSlide;
    public bool TouchMove { get; set; } = DefaultValues.TouchMove;
    public int TouchThreshold { get; set; } = DefaultValues.TouchThreshold;
    public bool UseCss { get; set; } = DefaultValues.UseCss;
    public bool UseTransform { get; set; } = DefaultValues.UseTransform;
    public bool VariableWidth { get; set; } = DefaultValues.VariableWidth;
    public bool Vertical { get; set; } = DefaultValues.Vertical;
    public bool VerticalSwiping { get; set; } = DefaultValues.VerticalSwiping;
    public bool RightToLeft { get; set; } = DefaultValues.RightToLeft;
    public bool WaitForAnimate { get; set; } = DefaultValues.WaitForAnimate;
    public int ZIndex { get; set; } = DefaultValues.ZIndex;
}
