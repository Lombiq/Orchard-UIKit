using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Lombiq.UIKit.Extensions;

public static class AttributeExtension
{
    /// <summary>
    /// Returns <see langword="true"/> if the given model property has <see cref="RequiredAttribute"/> on it. This
    /// is required because a value type's <see cref="ModelMetadata.IsRequired"/> default is <see langword="true"/>.
    /// </summary>
    /// <remarks><para>For more info see
    /// https://stackoverflow.com/questions/8364009/how-to-disable-modelmetadata-isrequired-from-always-being-true-for-non-nullable/17275026.
    /// </para></remarks>
    public static bool RequiredAttributeExists(this ModelMetadata metaData) =>
        (!metaData.ModelType.IsValueType && metaData.IsRequired)
        || (metaData.ModelType.IsValueType
            && metaData
                .ContainerType
                .GetProperty(metaData.PropertyName)
                .GetCustomAttributes(typeof(RequiredAttribute), inherit: false)
                .Any());
}
