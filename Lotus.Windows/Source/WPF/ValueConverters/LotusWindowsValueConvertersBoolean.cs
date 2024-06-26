using System;
using System.Globalization;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace Lotus.Windows
{
    /**
     * \defgroup WindowsWPFValueConverters Конвертеры данных
     * \ingroup WindowsWPF
     * \brief Конвертеры данных.
     * @{
     */
    /// <summary>
    /// Конвертер логического значения в соответствующую графическую пиктограмму.
    /// </summary>
    [ValueConversion(typeof(bool), typeof(BitmapSource))]
    public class BooleanToBitmapSourceConverter : IValueConverter
    {
        #region Properties
        /// <summary>
        /// Пиктограмма для истинного значения.
        /// </summary>
        public BitmapSource BitmapYes { get; set; }

        /// <summary>
        /// Пиктограмма для ложного значения.
        /// </summary>
        public BitmapSource BitmapNo { get; set; }
        #endregion

        #region Methods 
        /// <summary>
        /// Конвертация логического значения в тип Image.
        /// </summary>
        /// <param name="value">Значение.</param>
        /// <param name="targetType">Целевой тип.</param>
        /// <param name="parameter">Дополнительный параметр.</param>
        /// <param name="culture">Культура.</param>
        /// <returns>Тип Image.</returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var val = (bool)value;
            if (val)
            {
                return BitmapYes;
            }
            else
            {
                return BitmapNo;
            }
        }

        /// <summary>
        /// Конвертация типа Image в логическое значение.
        /// </summary>
        /// <param name="value">Значение.</param>
        /// <param name="targetType">Целевой тип.</param>
        /// <param name="parameter">Дополнительный параметр.</param>
        /// <param name="culture">Культура.</param>
        /// <returns>Логический тип.</returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null!;
        }
        #endregion
    }

    /// <summary>
    /// Конвертер логического значения в обратное значение.
    /// </summary>
    [ValueConversion(typeof(bool), typeof(bool))]
    public class BooleanInverseConverter : IValueConverter
    {
        #region Methods 
        /// <summary>
        /// Конвертация логического значения в обратное значение.
        /// </summary>
        /// <param name="value">Значение.</param>
        /// <param name="targetType">Целевой тип.</param>
        /// <param name="parameter">Дополнительный параметр.</param>
        /// <param name="culture">Культура.</param>
        /// <returns>Обратное значение.</returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var val = (bool)value;
            return !val;
        }

        /// <summary>
        /// Конвертация логического значения в обратное значение.
        /// </summary>
        /// <param name="value">Значение.</param>
        /// <param name="targetType">Целевой тип.</param>
        /// <param name="parameter">Дополнительный параметр.</param>
        /// <param name="culture">Культура.</param>
        /// <returns>братное значение.</returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var val = (bool)value;
            return val;
        }
        #endregion
    }

    /// <summary>
    /// Конвертер логического значения в три состояния выбора.
    /// </summary>
    [ValueConversion(typeof(bool), typeof(ToggleState))]
    public class BooleanToToggleStateConverter : IValueConverter
    {
        #region Methods 
        /// <summary>
        /// Конвертация логического значения в состояние выбора.
        /// </summary>
        /// <param name="value">Значение.</param>
        /// <param name="targetType">Целевой тип.</param>
        /// <param name="parameter">Дополнительный параметр.</param>
        /// <param name="culture">Культура.</param>
        /// <returns>Cостояние выбора.</returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool?)
            {
                var nullableBoolValue = (bool?)value;
                if (nullableBoolValue.HasValue)
                    return nullableBoolValue.Value ? ToggleState.On : ToggleState.Off;
                return ToggleState.Indeterminate;
            }
            else if (value is bool)
                return ((bool)value) ? ToggleState.On : ToggleState.Off;

            return ToggleState.Indeterminate;
        }

        /// <summary>
        /// Конвертация состояние выбора в логическое значение.
        /// </summary>
        /// <param name="value">Значение.</param>
        /// <param name="targetType">Целевой тип.</param>
        /// <param name="parameter">Дополнительный параметр.</param>
        /// <param name="culture">Культура.</param>
        /// <returns>Логическое значение.</returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is ToggleState toggleStat)
            {
                switch (toggleStat)
                {
                    case ToggleState.On:
                        return true;
                    case ToggleState.Off:
                        return false;
                }
            }
            return ToggleState.On;
        }
        #endregion
    }

    /// <summary>
    /// Конвертер логического значения в тип <see cref="Visibility"/>.
    /// </summary>
    [ValueConversion(typeof(bool), typeof(Visibility))]
    public class BooleanToVisibilityConverter : IValueConverter
    {
        #region Methods 
        /// <summary>
        /// Конвертация логического значения в состояние выбора.
        /// </summary>
        /// <param name="value">Значение.</param>
        /// <param name="targetType">Целевой тип.</param>
        /// <param name="parameter">Дополнительный параметр.</param>
        /// <param name="culture">Культура.</param>
        /// <returns>Cостояние выбора.</returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var status = (bool)value;
            if (status)
            {
                return Visibility.Visible;
            }
            else
            {
                return Visibility.Hidden;
            }
        }

        /// <summary>
        /// Конвертация состояние выбора в логическое значение.
        /// </summary>
        /// <param name="value">Значение.</param>
        /// <param name="targetType">Целевой тип.</param>
        /// <param name="parameter">Дополнительный параметр.</param>
        /// <param name="culture">Культура.</param>
        /// <returns>Логическое значение.</returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var status = (Visibility)value;
            if (status == Visibility.Visible)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion
    }

    /// <summary>
    /// Конвертер логического значения в тип <see cref="Visibility"/>.
    /// </summary>
    [ValueConversion(typeof(bool), typeof(Visibility))]
    public class BooleanInverseToVisibilityConverter : IValueConverter
    {
        #region Methods 
        /// <summary>
        /// Конвертация логического значения в состояние выбора.
        /// </summary>
        /// <param name="value">Значение.</param>
        /// <param name="targetType">Целевой тип.</param>
        /// <param name="parameter">Дополнительный параметр.</param>
        /// <param name="culture">Культура.</param>
        /// <returns>Cостояние выбора.</returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var status = (bool)value;
            if (!status)
            {
                return Visibility.Visible;
            }
            else
            {
                return Visibility.Hidden;
            }
        }

        /// <summary>
        /// Конвертация состояние выбора в логическое значение.
        /// </summary>
        /// <param name="value">Значение.</param>
        /// <param name="targetType">Целевой тип.</param>
        /// <param name="parameter">Дополнительный параметр.</param>
        /// <param name="culture">Культура.</param>
        /// <returns>Логическое значение.</returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var status = (Visibility)value;
            if (status == Visibility.Visible)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        #endregion
    }

    /// <summary>
    /// Конвертер логического значения в тип <see cref="Visibility"/>.
    /// </summary>
    [ValueConversion(typeof(bool?), typeof(Visibility))]
    public class BooleanNullToVisibilityConverter : IValueConverter
    {
        #region Methods 
        /// <summary>
        /// Конвертация логического значения в состояние выбора.
        /// </summary>
        /// <param name="value">Значение.</param>
        /// <param name="targetType">Целевой тип.</param>
        /// <param name="parameter">Дополнительный параметр.</param>
        /// <param name="culture">Культура.</param>
        /// <returns>Cостояние выбора.</returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var status = (bool?)value;
            if (status.HasValue && status.Value)
            {
                return Visibility.Visible;
            }
            else
            {
                return Visibility.Hidden;
            }
        }

        /// <summary>
        /// Конвертация состояние выбора в логическое значение.
        /// </summary>
        /// <param name="value">Значение.</param>
        /// <param name="targetType">Целевой тип.</param>
        /// <param name="parameter">Дополнительный параметр.</param>
        /// <param name="culture">Культура.</param>
        /// <returns>Логическое значение.</returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var status = (Visibility)value;
            if (status == Visibility.Visible)
            {
                return new bool?(true);
            }
            else
            {
                return new bool?(false);
            }
        }
        #endregion
    }

    /// <summary>
    /// Конвертер типа <see cref="Visibility"/> в логического значения.
    /// </summary>
    [ValueConversion(typeof(Visibility), typeof(bool?))]
    public class VisibilityToBooleanNullConverter : IValueConverter
    {
        #region Methods 
        /// <summary>
        /// Конвертация логического значения в состояние выбора.
        /// </summary>
        /// <param name="value">Значение.</param>
        /// <param name="targetType">Целевой тип.</param>
        /// <param name="parameter">Дополнительный параметр.</param>
        /// <param name="culture">Культура.</param>
        /// <returns>Cостояние выбора.</returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var status = (Visibility)value;
            if (status == Visibility.Visible)
            {
                return new bool?(true);
            }
            else
            {
                return new bool?(false);
            }
        }

        /// <summary>
        /// Конвертация состояние выбора в логическое значение.
        /// </summary>
        /// <param name="value">Значение.</param>
        /// <param name="targetType">Целевой тип.</param>
        /// <param name="parameter">Дополнительный параметр.</param>
        /// <param name="culture">Культура.</param>
        /// <returns>Логическое значение.</returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var status = (bool?)value;
            if (status.HasValue && status.Value)
            {
                return Visibility.Visible;
            }
            else
            {
                return Visibility.Hidden;
            }
        }
        #endregion
    }

    /// <summary>
    /// Конвертер логического значения в тип <see cref="Visibility"/>.
    /// </summary>
    [ValueConversion(typeof(bool), typeof(Visibility))]
    public class BooleanTrueToCollapsedConverter : IValueConverter
    {
        #region Methods 
        /// <summary>
        /// Конвертация логического значения в состояние выбора.
        /// </summary>
        /// <param name="value">Значение.</param>
        /// <param name="targetType">Целевой тип.</param>
        /// <param name="parameter">Дополнительный параметр.</param>
        /// <param name="culture">Культура.</param>
        /// <returns>Cостояние выбора.</returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var status = (bool)value;
            if (status)
            {
                return Visibility.Collapsed;
            }
            else
            {
                return Visibility.Visible;
            }
        }

        /// <summary>
        /// Конвертация состояние выбора в логическое значение.
        /// </summary>
        /// <param name="value">Значение.</param>
        /// <param name="targetType">Целевой тип.</param>
        /// <param name="parameter">Дополнительный параметр.</param>
        /// <param name="culture">Культура.</param>
        /// <returns>Логическое значение.</returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var status = (Visibility)value;
            if (status == Visibility.Collapsed)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion
    }

    /// <summary>
    /// Конвертер логического значения в тип <see cref="Visibility"/>.
    /// </summary>
    [ValueConversion(typeof(bool), typeof(Visibility))]
    public class BooleanFalseToCollapsedConverter : IValueConverter
    {
        #region Methods 
        /// <summary>
        /// Конвертация логического значения в состояние выбора.
        /// </summary>
        /// <param name="value">Значение.</param>
        /// <param name="targetType">Целевой тип.</param>
        /// <param name="parameter">Дополнительный параметр.</param>
        /// <param name="culture">Культура.</param>
        /// <returns>Cостояние выбора.</returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var status = (bool)value;
            if (status == false)
            {
                return Visibility.Collapsed;
            }
            else
            {
                return Visibility.Visible;
            }
        }

        /// <summary>
        /// Конвертация состояние выбора в логическое значение.
        /// </summary>
        /// <param name="value">Значение.</param>
        /// <param name="targetType">Целевой тип.</param>
        /// <param name="parameter">Дополнительный параметр.</param>
        /// <param name="culture">Культура.</param>
        /// <returns>Логическое значение.</returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var status = (Visibility)value;
            if (status == Visibility.Collapsed)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        #endregion
    }
    /**@}*/
}