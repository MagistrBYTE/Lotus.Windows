using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

using Lotus.Core;

namespace Lotus.Windows
{
    /** \addtogroup WindowsWPFValueConverters
	*@{*/
    /// <summary>
    /// Конвертер цветового значения в сплошную кисть.
    /// </summary>
    [ValueConversion(typeof(Color), typeof(Brush))]
    public class ColorToBrushConverter : IValueConverter
    {
        #region Methods 
        /// <summary>
        /// Конвертация цветового значения в сплошную кисть.
        /// </summary>
        /// <param name="value">Значение.</param>
        /// <param name="targetType">Целевой тип.</param>
        /// <param name="parameter">Дополнительный параметр.</param>
        /// <param name="culture">Культура.</param>
        /// <returns>Объект тип <see cref="Brush"/>.</returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is Color color)
            {
                return XWindowsColorManager.GetBrushByColor(color);
            }
            else
            {
                var color_null = value as Color?;
                if (color_null.HasValue)
                {
                    return XWindowsColorManager.GetBrushByColor(color_null.Value);
                }
            }

            return Brushes.White;
        }

        /// <summary>
        /// Конвертация кисти в цветовое значение.
        /// </summary>
        /// <param name="value">Значение.</param>
        /// <param name="targetType">Целевой тип.</param>
        /// <param name="parameter">Дополнительный параметр.</param>
        /// <param name="culture">Культура.</param>
        /// <returns>Объект тип <see cref="Color"/>.</returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null!;
        }
        #endregion
    }

    /// <summary>
    /// Конвертер цветового значения в стандартный тип цвета.
    /// </summary>
    [ValueConversion(typeof(Color), typeof(TColor))]
    public class ColorToColorTypeConverter : IValueConverter
    {
        #region Methods 
        /// <summary>
        /// Конвертация цветового значения в стандартный тип цвета.
        /// </summary>
        /// <param name="value">Значение.</param>
        /// <param name="targetType">Целевой тип.</param>
        /// <param name="parameter">Дополнительный параметр.</param>
        /// <param name="culture">Культура.</param>
        /// <returns>Объект тип <see cref="TColor"/>.</returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is Color color)
            {
                return new TColor(color.R, color.G, color.B, color.A);
            }
            else
            {
                var color_null = value as Color?;
                if (color_null.HasValue)
                {
                    var color1 = color_null.Value;
                    return new TColor(color1.R, color1.G, color1.B, color1.A);
                }
            }

            return XColors.White;
        }

        /// <summary>
        /// Конвертация стандартного типа цвета в цветовое значение.
        /// </summary>
        /// <param name="value">Значение.</param>
        /// <param name="targetType">Целевой тип.</param>
        /// <param name="parameter">Дополнительный параметр.</param>
        /// <param name="culture">Культура.</param>
        /// <returns>Объект тип <see cref="Color"/>.</returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is TColor color)
            {
                return Color.FromArgb(color.A, color.R, color.G, color.B);
            }
            else
            {
                var color_null = value as Color?;
                if (color_null.HasValue)
                {
                    return Color.FromArgb(color_null.Value.A, color_null.Value.R, color_null.Value.G, color_null.Value.B);
                }
            }

            return Colors.White;
        }
        #endregion
    }
    /**@}*/
}