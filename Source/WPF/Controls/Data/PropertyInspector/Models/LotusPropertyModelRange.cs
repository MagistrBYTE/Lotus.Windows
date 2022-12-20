﻿//=====================================================================================================================
// Решение: LotusPlatform
// Проект: LotusWindows
// Раздел: Модуль пользовательского интерфейса
// Подраздел: Общие элементы управления
// Автор: MagistrBYTE aka DanielDem <dementevds@gmail.com>
//---------------------------------------------------------------------------------------------------------------------
/** \file LotusPropertyModelRange.cs
*		Модель отображения свойства объекта который имеет диапазон изменений.
*/
//---------------------------------------------------------------------------------------------------------------------
// Версия: 1.0.0.0
// Последнее изменение от 27.03.2022
//=====================================================================================================================
using System;
using System.Reflection;
using System.Collections.Generic;
//---------------------------------------------------------------------------------------------------------------------
using Lotus.Core;
//=====================================================================================================================
namespace Lotus
{
	namespace Windows
	{
		//-------------------------------------------------------------------------------------------------------------
		//! \addtogroup WindowsWPFControlsData
		/*@{*/
		//-------------------------------------------------------------------------------------------------------------
		/// <summary>
		/// Модель отображения свойства объекта который имеет диапазон изменений
		/// </summary>
		/// <typeparam name="TNumeric">Тип значения свойства</typeparam>
		//-------------------------------------------------------------------------------------------------------------
		public class PropertyModelRange<TNumeric> : PropertyModel<TNumeric>
		{
			#region ======================================= ДАННЫЕ ====================================================
			internal TNumeric mMinValue;
			internal TNumeric mMaxValue;
			#endregion

			#region ======================================= СВОЙСТВА ==================================================
			/// <summary>
			/// Минимальное значение
			/// </summary>
			public TNumeric MinValue
			{
				get { return (mMinValue); }
			}

			/// <summary>
			/// Максимальное значение
			/// </summary>
			public TNumeric MaxValue
			{
				get { return (mMaxValue); }
			}
			#endregion

			#region ======================================= КОНСТРУКТОРЫ ==============================================
			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Конструктор по умолчанию инициализирует объект класса предустановленными значениями
			/// </summary>
			//---------------------------------------------------------------------------------------------------------
			public PropertyModelRange()
			{
			}

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Конструктор инициализирует объект класса указанными параметрами
			/// </summary>
			/// <param name="property_info">Метаданные свойства</param>
			//---------------------------------------------------------------------------------------------------------
			public PropertyModelRange(PropertyInfo property_info)
				: base(property_info, TPropertyType.Numeric)
			{
				GetInfoFromAttributesRange();
			}

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Конструктор инициализирует объект класса указанными параметрами
			/// </summary>
			/// <param name="property_info">Метаданные свойства</param>
			/// <param name="property_desc">Список описания свойства</param>
			//---------------------------------------------------------------------------------------------------------
			public PropertyModelRange(PropertyInfo property_info, List<CPropertyDesc> property_desc)
				: base(property_info, property_desc, TPropertyType.Numeric)
			{
				GetInfoFromAttributesRange();
			}
			#endregion

			#region ======================================= ОБЩИЕ МЕТОДЫ ==============================================
			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Получение данных описание свойства с его атрибутов
			/// </summary>
			//---------------------------------------------------------------------------------------------------------
			protected void GetInfoFromAttributesRange()
			{
				if (mInfo != null)
				{
					LotusMinValueAttribute min_value = mInfo.GetAttribute<LotusMinValueAttribute>();
					if (min_value != null)
					{
						mMinValue = (TNumeric)(Object)min_value.MinValue;
					}
					else
					{
						FieldInfo field_info = typeof(TNumeric).GetField(nameof(MinValue), BindingFlags.Static | BindingFlags.Public);
						if (field_info != null)
						{
							mMinValue = (TNumeric)(Object)field_info.GetValue(null);
						}
					}

					LotusMaxValueAttribute max_value = mInfo.GetAttribute<LotusMaxValueAttribute>();
					if (max_value != null)
					{
						mMaxValue = (TNumeric)(Object)max_value.MaxValue;
					}
					else
					{
						FieldInfo field_info = typeof(TNumeric).GetField(nameof(MaxValue), BindingFlags.Static | BindingFlags.Public);
						if(field_info != null)
						{
							mMaxValue = (TNumeric)(Object)field_info.GetValue(null);
						}
					}
				}
			}
			#endregion
		}
		//-------------------------------------------------------------------------------------------------------------
		/*@}*/
		//-------------------------------------------------------------------------------------------------------------
	}
}
//=====================================================================================================================