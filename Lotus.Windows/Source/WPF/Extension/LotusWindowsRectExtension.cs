﻿//=====================================================================================================================
// Проект: Модуль платформы Windows
// Раздел: Подсистема работы с WPF
// Подраздел: Методы расширения
// Автор: MagistrBYTE aka DanielDem <dementevds@gmail.com>
//---------------------------------------------------------------------------------------------------------------------
/** \file LotusWindowsRectExtension.cs
*		Методы расширения для работы с типом Rect.
*/
//---------------------------------------------------------------------------------------------------------------------
// Версия: 1.0.0.0
// Последнее изменение от 30.04.2023
//=====================================================================================================================
using System;
using System.Windows;
//---------------------------------------------------------------------------------------------------------------------
using Lotus.Core;
//=====================================================================================================================
namespace Lotus
{
	namespace Windows
	{
		//-------------------------------------------------------------------------------------------------------------
		/** \addtogroup WindowsWPFExtension
		*@{*/
		//-------------------------------------------------------------------------------------------------------------
		/// <summary>
		/// Статический класс реализующий методы расширения для типа <see cref="Rect"/>
		/// </summary>
		//-------------------------------------------------------------------------------------------------------------
		public static class XWindowsRectExtension
		{
			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Сериализация прямоугольника в строку
			/// </summary>
			/// <param name="rect">Прямоугольник</param>
			/// <returns>Строка данных</returns>
			//---------------------------------------------------------------------------------------------------------
			public static String SerializeToString(this Rect rect)
			{
				return String.Format("{0};{1};{2};{3}", rect.X, rect.Y, rect.Width, rect.Height);
			}

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Десереализация прямоугольника из строки
			/// </summary>
			/// <param name="data">Строка данных</param>
			/// <returns>Прямоугольник</returns>
			//---------------------------------------------------------------------------------------------------------
			public static Rect DeserializeFromString(String data)
			{
				var rect = new Rect();
				var rect_data = data.Split(';');
				rect.X = XNumbers.ParseDouble(rect_data[0]);
				rect.Y = XNumbers.ParseDouble(rect_data[1]);
				rect.Width = XNumbers.ParseDouble(rect_data[2]);
				rect.Height = XNumbers.ParseDouble(rect_data[3]);
				return rect;
			}

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Проверка на попадание точки в область прямоугольника
			/// </summary>
			/// <param name="rect">Прямоугольник</param>
			/// <param name="point">Проверяемая точка</param>
			/// <returns>Статус попадания</returns>
			//---------------------------------------------------------------------------------------------------------
			public static Boolean Contains(this Rect rect, Lotus.Maths.Vector2Df point)
			{
				return rect.X <= point.X && rect.X + rect.Width >= point.X && rect.Y <= point.Y && rect.Y + rect.Height >= point.Y;
			}

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Проверка на попадание точки в область прямоугольника
			/// </summary>
			/// <param name="rect">Прямоугольник</param>
			/// <param name="point">Проверяемая точка</param>
			/// <returns>Статус попадания</returns>
			//---------------------------------------------------------------------------------------------------------
			public static Boolean Contains(this Rect rect, Lotus.Maths.Vector2D point)
			{
				return rect.X <= point.X && rect.X + rect.Width >= point.X && rect.Y <= point.Y && rect.Y + rect.Height >= point.Y;
			}
		}
		//-------------------------------------------------------------------------------------------------------------
		/**@}*/
		//-------------------------------------------------------------------------------------------------------------
	}
}
//=====================================================================================================================