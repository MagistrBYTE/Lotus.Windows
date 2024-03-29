﻿//=====================================================================================================================
// Проект: Модуль платформы Windows
// Раздел: Подсистема работы с WPF
// Подраздел: Общая подсистема
// Автор: MagistrBYTE aka DanielDem <dementevds@gmail.com>
//---------------------------------------------------------------------------------------------------------------------
/** \file LotusWindowsColorManager.cs
*		Менеджер для работы с цветом и сплошными кистями WPF.
*/
//---------------------------------------------------------------------------------------------------------------------
// Версия: 1.0.0.0
// Последнее изменение от 30.04.2023
//=====================================================================================================================
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows.Media;
//=====================================================================================================================
namespace Lotus
{
	namespace Windows
	{
		//-------------------------------------------------------------------------------------------------------------
		/** \addtogroup WindowsWPFCommon
		*@{*/
		//-------------------------------------------------------------------------------------------------------------
		/// <summary>
		/// Статический класс для работы с цветом и сплошными кистями
		/// </summary>
		//-------------------------------------------------------------------------------------------------------------
		public static class XWindowsColorManager
		{
			#region ======================================= ДАННЫЕ ====================================================
			/// <summary>
			/// Словарь цветов по имени цвета
			/// </summary>
			public static readonly List<KeyValuePair<String, Color>> KnownColors = [];

			/// <summary>
			/// Словарь сплошных кистей по имени цвета
			/// </summary>
			public static readonly List<KeyValuePair<String, SolidColorBrush>> KnownBrushes = [];
			#endregion

			#region ======================================= МЕТОДЫ ====================================================
			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Инициализация данных
			/// </summary>
			//---------------------------------------------------------------------------------------------------------
			public static void Init()
			{
				Type color_type = typeof(Colors);
				Type brush_type = typeof(Brushes);

				PropertyInfo[] arr_colors = color_type.GetProperties(BindingFlags.Public | BindingFlags.Static);
				PropertyInfo[] arr_brushes = brush_type.GetProperties(BindingFlags.Public | BindingFlags.Static);

				for (var i = 0; i < arr_colors.Length; i++)
				{
					KnownColors.Add(new KeyValuePair<String, Color>(arr_colors[i].Name, (Color)arr_colors[i].GetValue(null, null)!));
				}

				for (var i = 0; i < arr_brushes.Length; i++)
				{
					KnownBrushes.Add(new KeyValuePair<String, SolidColorBrush>(arr_brushes[i].Name,
						(SolidColorBrush)arr_brushes[i].GetValue(null, null)!));
				}
			}

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Получение имени цвета или пустой строки
			/// </summary>
			/// <param name="color">Цвет</param>
			/// <returns>Имя цвета</returns>
			//---------------------------------------------------------------------------------------------------------
			public static String GetKnownColorName(Color color)
			{
				var result = String.Empty;

				for (var i = 0; i < KnownColors.Count; i++)
				{
					if (Color.AreClose(KnownColors[i].Value, color))
					{
						return KnownColors[i].Key;
					}
				}

				return result;
			}

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Получение имени сплошной кисти или пустой строки
			/// </summary>
			/// <param name="brush">Сплошная кисть</param>
			/// <returns>Имя кисти</returns>
			//---------------------------------------------------------------------------------------------------------
			public static String GetKnownBrushName(SolidColorBrush brush)
			{
				var result = String.Empty;

				for (var i = 0; i < KnownColors.Count; i++)
				{
					if (Color.AreClose(KnownBrushes[i].Value.Color, brush.Color))
					{
						return KnownColors[i].Key;
					}
				}

				return result;
			}

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Получение цвета через имя
			/// </summary>
			/// <param name="color_name">Стандартное имя цвета</param>
			/// <returns>Найденный цвет или белый цвет если не нашли</returns>
			//---------------------------------------------------------------------------------------------------------
			public static Color GetColorByName(String color_name)
			{
				Color result = Colors.White;

				if (KnownColors != null)
				{
					for (var i = 0; i < KnownColors.Count; i++)
					{
						if (KnownColors[i].Key == color_name)
						{
							return KnownColors[i].Value;
						}
					}
				}

				return result;
			}

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Получение кисти через имя
			/// </summary>
			/// <param name="brush_name">Стандартное имя кисти</param>
			/// <returns>Найденную кисть или белый цвет кисти если не нашли</returns>
			//---------------------------------------------------------------------------------------------------------
			public static SolidColorBrush GetBrushByName(String brush_name)
			{
				SolidColorBrush result = Brushes.White;

				if (KnownBrushes != null)
				{

					for (var i = 0; i < KnownBrushes.Count; i++)
					{
						if (KnownBrushes[i].Key == brush_name)
						{
							return KnownBrushes[i].Value;
						}
					}
				}

				return result;
			}

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Получение кисти через цвет
			/// </summary>
			/// <param name="color">Цвет</param>
			/// <returns>Найденную кисть или новую кисть на основе цвета</returns>
			//---------------------------------------------------------------------------------------------------------
			public static SolidColorBrush GetBrushByColor(Color color)
			{
				if (KnownBrushes != null)
				{
					for (var i = 0; i < KnownBrushes.Count; i++)
					{
						if (Color.AreClose(KnownBrushes[i].Value.Color, color))
						{
							return KnownBrushes[i].Value;
						}
					}

					return new SolidColorBrush(color);
				}
				else
				{
					return Brushes.White;
				}
			}
			#endregion
		}
		//-------------------------------------------------------------------------------------------------------------
		/**@}*/
		//-------------------------------------------------------------------------------------------------------------
	}
}
//=====================================================================================================================