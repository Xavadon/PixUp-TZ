using System;
using UnityEngine;

public static class DateTimeExtensions
{
    public static DateTime TryConvertToDateTime(this string dateString)
    {
        string format = "yyyy-MM-dd HH:mm:ss";
        DateTime dateTime;

        if (DateTime.TryParseExact(dateString, format, System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out dateTime))
            return dateTime;

        throw new InvalidTimeZoneException();
    }
}