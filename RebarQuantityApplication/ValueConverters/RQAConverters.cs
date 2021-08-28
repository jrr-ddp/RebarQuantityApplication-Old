using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows;
using System.Windows.Data;
using System.Globalization;
using System.Collections.ObjectModel;

using System.Windows.Markup;

namespace RebarQuantityApplication
{
    public class DataValueToString : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            DateTime inputDT = (DateTime)value;
            string ConvertedStringValue;
            int ReturnParameterValue = int.Parse((string)parameter);
            switch (ReturnParameterValue)
            {
                case 1: //Return Only Day String
                    ConvertedStringValue = inputDT.ToString("ddd");
                    break;
                case 2:
                default: //Return only Date String
                    ConvertedStringValue = inputDT.ToString("dd-MMM");
                    break;
                case 3: //Return Month String
                    ConvertedStringValue = inputDT.ToString("MMMM");
                    break;
                case 4: //Return Year String
                    ConvertedStringValue = inputDT.ToString("yyyy");
                    break;
                case 5: //Return Month,Year String
                    ConvertedStringValue = inputDT.ToString("MMMM, yyyy");
                    break;
                case 6: //Return Custom Complete time
                    ConvertedStringValue = inputDT.ToString("dd-MMMM-yyyy h:mm tt");
                    break;
                case 7: //Return Date 
                    ConvertedStringValue = inputDT.ToString("dd");
                    break;
            }

            return ConvertedStringValue;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

   
    public abstract class BaseValueConverter<T> : MarkupExtension, IValueConverter
       where T : class, new()
    {

        #region Private Members

        /// <summary>
        ///  A single static instance of this value converter
        /// </summary>
        private static T Converter = null;

        #endregion


        #region Markup Extension Methods
        /// <summary>
        /// Provides a ststic instance of the value converter
        /// </summary>
        /// <param name="serviceProvider"></param>
        /// <returns></returns>

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            //if (mConverter == null)
            //    mConverter = new T();
            //return mConverter;

            return Converter ?? (Converter = new T());
        }

        #endregion

        #region Value Converter Methods

        /// <summary>
        /// The method to convert one type to another
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>

        public abstract object Convert(object value, Type targetType, object parameter, CultureInfo culture);


        /// <summary>
        /// The method to convert a value back to it's source type
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public abstract object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture);

        #endregion
    }

    public class BooleanToVisibilityConverter : BaseValueConverter<BooleanToVisibilityConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (parameter == null)
                return (bool)value ? Visibility.Hidden : Visibility.Visible;
            else
                return (bool)value ? Visibility.Visible : Visibility.Hidden;
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class VisibilityToBoolean : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Visibility iVisibleStatus = (Visibility)value;

            switch (iVisibleStatus)
            {
                case Visibility.Collapsed:
                    return false;
                case Visibility.Visible:
                default:
                    return true;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class MultiValueBindingConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            int InputParameter = int.Parse((string)parameter);

            object UnClonedObject = values as object; //Try to modify the codes later to provide a deepcopy
            if (InputParameter == 2) return UnClonedObject;
            return values.Clone(); //Clone provides shallow copy
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class DoubleToString : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string Result = (string)value;
            return Result;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string Input = (string)value;
            return Input;
        }
    }

    public class BooleanToBorderThicknessConverter : BaseValueConverter<BooleanToBorderThicknessConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (parameter == null)
                return (bool)value ? 2 : 0;
            else
                return (bool)value ? 0 : 2;
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

   

    public class NulltoEmptyConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null) return "";
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class VerificationConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }

    public class ViewDisplayToVisibility : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int input = (int)value;
            switch (input)
            {
                case 1:
                    return Visibility.Visible;
                default:
                    return Visibility.Collapsed;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }


    public class StringToVisibility : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string input = (string)value;
            if (string.IsNullOrEmpty(input) == true || input == "") return Visibility.Collapsed;
            return Visibility.Visible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class InverseBoolean : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool inputvalue = (bool)value;
            return !(inputvalue);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
