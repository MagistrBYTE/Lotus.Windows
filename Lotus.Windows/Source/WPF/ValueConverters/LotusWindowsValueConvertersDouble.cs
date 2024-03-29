﻿//=====================================================================================================================
// Проект: Модуль платформы Windows
// Раздел: Подсистема работы с WPF
// Подраздел: Конвертеры данных
// Автор: MagistrBYTE aka DanielDem <dementevds@gmail.com>
//---------------------------------------------------------------------------------------------------------------------
/** \file LotusWindowsValueConvertersDouble.cs
*		Конвертеры типа Double в различные типы данных.
*/
//---------------------------------------------------------------------------------------------------------------------
// Версия: 1.0.0.0
// Последнее изменение от 30.04.2023
//=====================================================================================================================
using System;
using System.Globalization;
using System.Windows.Data;
//---------------------------------------------------------------------------------------------------------------------
using Lotus.Core;
//=====================================================================================================================
namespace Lotus
{
	namespace Windows
	{
		//-------------------------------------------------------------------------------------------------------------
		/** \addtogroup WindowsWPFValueConverters
		*@{*/
		//-------------------------------------------------------------------------------------------------------------
		/// <summary>
		/// Конвертер вещественного типа в строку
		/// </summary>
		//-------------------------------------------------------------------------------------------------------------
		[ValueConversion(typeof(Double), typeof(String))]
		public class DoubleToStringConverter : IValueConverter
		{
			#region ======================================= МЕТОДЫ ====================================================
			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Конвертация вещественного типа в строковый тип
			/// </summary>
			/// <param name="value">Значение</param>
			/// <param name="targetType">Целевой тип</param>
			/// <param name="parameter">Дополнительный параметр</param>
			/// <param name="culture">Культура</param>
			/// <returns>Строка</returns>
			//---------------------------------------------------------------------------------------------------------
			public Object Convert(Object value, Type targetType, Object parameter, CultureInfo culture)
			{
				var val = (Double)value;

				if (parameter != null)
				{
					return val.ToString(parameter.ToString());
				}
				else
				{
					return val.ToString("G");
				}
			}

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Конвертация строкового типа в вещественный тип
			/// </summary>
			/// <param name="value">Значение</param>
			/// <param name="targetType">Целевой тип</param>
			/// <param name="parameter">Дополнительный параметр</param>
			/// <param name="culture">Культура</param>
			/// <returns>Вещественный тип</returns>
			//---------------------------------------------------------------------------------------------------------
			public Object ConvertBack(Object value, Type targetType, Object parameter, CultureInfo culture)
			{
				var str = (String)value;

				if (String.IsNullOrWhiteSpace(str))
				{
					return 0;
				}
				else
				{
					str = str.Trim();
					return XNumbers.ParseDouble(str);
				}
			}
			#endregion
		}

		//-------------------------------------------------------------------------------------------------------------
		/// <summary>
		/// Конвертер для изменения вещественного значения через параметр
		/// </summary>
		//-------------------------------------------------------------------------------------------------------------
		[ValueConversion(typeof(Double), typeof(Double))]
		public class DoubleOffsetConverter : IValueConverter
		{
			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Изменение вещественного значения через параметр
			/// </summary>
			/// <param name="value">Значение</param>
			/// <param name="targetType">Целевой тип</param>
			/// <param name="parameter">Дополнительный параметр</param>
			/// <param name="culture">Культура</param>
			/// <returns>Вещественный тип</returns>
			//---------------------------------------------------------------------------------------------------------
			public Object Convert(Object value, Type targetType, Object parameter, CultureInfo culture)
			{
				var val = (Double)value;

				if (parameter != null)
				{
					return val - XNumbers.ParseDouble(parameter.ToString()!);
				}
				else
				{
					return val;
				}
			}

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Изменение вещественного значения через параметр
			/// </summary>
			/// <param name="value">Значение</param>
			/// <param name="targetType">Целевой тип</param>
			/// <param name="parameter">Дополнительный параметр</param>
			/// <param name="culture">Культура</param>
			/// <returns>Вещественный тип</returns>
			//---------------------------------------------------------------------------------------------------------
			public Object ConvertBack(Object value, Type targetType, Object parameter, CultureInfo culture)
			{
				var val = (Double)value;

				if (parameter != null)
				{
					return val + XNumbers.ParseDouble(parameter.ToString()!);
				}
				else
				{
					return val;
				}
			}
		}
		//-------------------------------------------------------------------------------------------------------------
		/**@}*/
		//-------------------------------------------------------------------------------------------------------------
	}
}
//=====================================================================================================================