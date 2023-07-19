using System;
using System.Globalization;
using System.Windows.Data;

namespace TaskTracker
{
    public class DateTimeToFormattedStringConverter : IValueConverter
    {
        // 日付データをJSTのyyyy/MM/dd HH:mm:ssに変換する
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is DateTime dateTime)
            {
                TimeZoneInfo jstZone = TimeZoneInfo.FindSystemTimeZoneById("Tokyo Standard Time");
                DateTime jstTime = TimeZoneInfo.ConvertTime(dateTime, jstZone);
                return jstTime.ToString("yyyy/MM/dd HH:mm:ss");
            }
            return string.Empty;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

}
