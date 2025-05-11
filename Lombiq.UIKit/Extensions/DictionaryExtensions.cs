using System.Collections.Generic;
using System.Linq;

namespace Lombiq.UIKit.Extensions;

public static class DictionaryExtensions
{
    /// <summary>
    /// Appends unique words from <paramref name="classes"/> into <paramref name="dictionary"/> as an entry with the key
    /// of <c>"class"</c>, then returns <paramref name="dictionary"/> for easy chaining.
    /// </summary>
    public static IDictionary<string, object> WithClasses(this IDictionary<string, object> dictionary, IEnumerable<string> classes)
    {
        dictionary["class"] = string.Join(' ', classes
            .SelectMany(item => item.Split())
            .WhereNot(string.IsNullOrEmpty)
            .Distinct());
        return dictionary;
    }
}
