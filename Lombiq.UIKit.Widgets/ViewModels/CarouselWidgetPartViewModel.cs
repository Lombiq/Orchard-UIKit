using Microsoft.AspNetCore.Mvc.ModelBinding;
using OrchardCore.ContentManagement;

namespace Lombiq.UIKit.Widgets.ViewModels;
public class CarouselWidgetPartViewModel
{
    [BindNever]
    public ContentItem? ContentItem { get; set; }
}
