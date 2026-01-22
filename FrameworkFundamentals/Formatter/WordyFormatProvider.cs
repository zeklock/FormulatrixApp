using System.Globalization;
using System.Text;

namespace FrameworkFundamentals.Formatter;

public class WordyFormatProvider : IFormatProvider, ICustomFormatter
{
    private readonly IFormatProvider _parent;

    public WordyFormatProvider()
        : this(CultureInfo.CurrentCulture)
    {
    }

    public WordyFormatProvider(IFormatProvider parent)
    {
        _parent = parent ?? CultureInfo.CurrentCulture;
    }

    public object? GetFormat(Type formatType)
    {
        return formatType == typeof(ICustomFormatter) ? this : null;
    }

    public string Format(string format, object arg, IFormatProvider prov)
    {
        // If the format isn't "W" (our custom format), defer to the parent provider
        if (arg == null || format != "W")
            return string.Format(_parent, "{0:" + format + "}", arg);

        // Custom logic for converting number digits to words
        StringBuilder result = new StringBuilder();
        string digitList = string.Format(CultureInfo.InvariantCulture, "{0}", arg); // Use invariant culture for consistent digits

        foreach (char digit in digitList)
        {
            switch (digit)
            {
                case '0': result.Append("zero "); break;
                case '1': result.Append("one "); break;
                case '2': result.Append("two "); break;
                case '3': result.Append("three "); break;
                case '4': result.Append("four "); break;
                case '5': result.Append("five "); break;
                case '6': result.Append("six "); break;
                case '7': result.Append("seven "); break;
                case '8': result.Append("eight "); break;
                case '9': result.Append("nine "); break;
                case '-': result.Append("minus "); break;
                case '.': result.Append("point "); break;
                default:
                    result.Append(digit).Append(' ');
                    break;
            }
        }

        return result.ToString();
    }
}
