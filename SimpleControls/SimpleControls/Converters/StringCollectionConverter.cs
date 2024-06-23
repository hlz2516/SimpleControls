using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace SimpleControls.Converters
{
    public class StringCollectionConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is IList<string> list && list.Any())
            {
                return string.Join(",", list);
            }
            return string.Empty; // 如果列表为空或者不是 IList<string>，返回空字符串
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                return value.ToString().Split(',').ToList();
            }
            return new List<string>();
        }
    }
}
