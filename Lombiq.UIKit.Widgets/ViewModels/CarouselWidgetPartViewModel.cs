using Lombiq.UIKit.Widgets.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using OrchardCore.ContentManagement;

namespace Lombiq.UIKit.Widgets.ViewModels;
public class CarouselWidgetPartViewModel
{
    public bool Show { get; set; }

    [BindNever]
    public ContentItem ContentItem { get; set; }

}
