using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Lombiq.UIKit.Extensions
{
    public static class AttributeExtension
    {
        /// <summary>
        /// Returns true if the given model property has <see cref="RequiredAttribute"/> on it. This is required because
        /// a value type <see cref="ModelMetadata.IsRequired"/> default is true.
        /// </summary>
        /// For more info see https://stackoverflow.com/questions/8364009/how-to-disable-modelmetadata-isrequired-from-always-being-true-for-non-nullable/17275026
        public static bool RequiredAttrExists(this ModelMetadata metaData)
        {
            if (!metaData.ModelType.IsValueType && metaData.IsRequired)
            {
                return true;
            }
            else if (metaData.ModelType.IsValueType
                && metaData.ContainerType.GetProperty(metaData.PropertyName).GetCustomAttributes(typeof(RequiredAttribute), false).Any())
            {
                return true;
            }

            return false;
        }
    }
}
