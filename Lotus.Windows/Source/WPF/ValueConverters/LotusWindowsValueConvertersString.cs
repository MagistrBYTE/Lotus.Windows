﻿//=====================================================================================================================
// Проект: Модуль платформы Windows
// Раздел: Подсистема работы с WPF
// Подраздел: Конвертеры данных
// Автор: MagistrBYTE aka DanielDem <dementevds@gmail.com>
//---------------------------------------------------------------------------------------------------------------------
/** \file LotusWindowsValueConvertersString.cs
*		Конвертеры типа String в различные типы данных.
*/
//---------------------------------------------------------------------------------------------------------------------
// Версия: 1.0.0.0
// Последнее изменение от 27.03.2022
//=====================================================================================================================
using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media.Imaging;
//=====================================================================================================================
namespace Lotus
{
	namespace Windows
	{
		//-------------------------------------------------------------------------------------------------------------
		//! \addtogroup WindowsWPFValueConverters
		/*@{*/
		//-------------------------------------------------------------------------------------------------------------
		/// <summary>
		/// Конвертер строки(как пути) в источник изображения которое находится по данному пути
		/// </summary>
		//-------------------------------------------------------------------------------------------------------------
		[ValueConversion(typeof(String), typeof(BitmapSource))]
		public class StringToBitmapSourceConverter : IValueConverter
		{
			#region ======================================= СВОЙСТВА ==================================================
			/// <summary>
			/// Директория по умолчанию
			/// </summary>
			/// <remarks>
			/// Если значение установлено то комбинируется имя файла и путь директории
			/// </remarks>
			public String ImageDirectory { get; set; }
			#endregion

			#region ======================================= МЕТОДЫ ====================================================
			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Конвертер строки(как пути) в источник изображения
			/// </summary>
			/// <param name="value">Значение</param>
			/// <param name="target_type">Целевой тип</param>
			/// <param name="parameter">Дополнительный параметр</param>
			/// <param name="culture">Культура</param>
			/// <returns>Тип BitmapSource</returns>
			//---------------------------------------------------------------------------------------------------------
			public Object Convert(Object value, Type target_type, Object parameter, CultureInfo culture)
			{
				if (String.IsNullOrWhiteSpace(ImageDirectory))
				{
					try
					{
						return new BitmapImage(new Uri((String)value));
					}
					catch (Exception)
					{

						return null;
					}
					
				}
				else
				{
					String image_path = System.IO.Path.Combine(ImageDirectory, (String)value);
					return new BitmapImage(new Uri(image_path));
				}
			}

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Конвертация типа BitmapSource в путь
			/// </summary>
			/// <param name="value">Значение</param>
			/// <param name="target_type">Целевой тип</param>
			/// <param name="parameter">Дополнительный параметр</param>
			/// <param name="culture">Культура</param>
			/// <returns>Путь</returns>
			//---------------------------------------------------------------------------------------------------------
			public Object ConvertBack(Object value, Type target_type, Object parameter, CultureInfo culture)
			{
				return (null);
			}
			#endregion
		}
		//-------------------------------------------------------------------------------------------------------------
		/*@}*/
		//-------------------------------------------------------------------------------------------------------------
	}
}
//=====================================================================================================================