using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace VacunAppFinal.Core
{
    public class ConvertidorRadioButton : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return value?.Equals(parameter);
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return value?.Equals(true) == true ? parameter : Binding.DoNothing;
        }
    }
}
