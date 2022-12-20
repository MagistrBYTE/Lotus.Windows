﻿//=====================================================================================================================
// Проект: Модуль платформы Windows
// Раздел: Подсистема работы с WPF
// Подраздел: Элементы интерфейса
// Группа: Элементы для работы с данными
// Автор: MagistrBYTE aka DanielDem <dementevds@gmail.com>
//---------------------------------------------------------------------------------------------------------------------
/** \file LotusColumnNumberFilter.xaml.cs
*		Элемент служащий для формирования элемента запроса для числовых типов данных.
*/
//---------------------------------------------------------------------------------------------------------------------
// Версия: 1.0.0.0
// Последнее изменение от 27.03.2022
//=====================================================================================================================
using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
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
		/// Элемент служащий для формирования элемента запроса для строковых типов данных
		/// </summary>
		//-------------------------------------------------------------------------------------------------------------
		public partial class LotusColumnNumberFilter : UserControl
		{
			#region ======================================= ОПРЕДЕЛЕНИЕ СВОЙСТВ ЗАВИСИМОСТИ ===========================
			/// <summary>
			/// Элемент запроса для числовых данных
			/// </summary>
			public static readonly DependencyProperty QueryItemProperty = DependencyProperty.Register(nameof(QueryItem),
				typeof(CQueryItemNumber), typeof(LotusColumnNumberFilter),
				new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsRender));
			#endregion

			#region ======================================= МЕТОДЫ СВОЙСТВ ЗАВИСИМОСТИ ================================
			#endregion

			#region ======================================= СВОЙСТВА ==================================================
			/// <summary>
			/// Элемент запроса для числовых данных
			/// </summary>
			[Browsable(false)]
			public CQueryItemNumber QueryItem
			{
				get { return (CQueryItemNumber)GetValue(QueryItemProperty); }
				set { SetValue(QueryItemProperty, value); }
			}
			#endregion

			#region ======================================= КОНСТРУКТОРЫ ==============================================
			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Конструктор по умолчанию инициализирует объект класса предустановленными значениями
			/// </summary>
			//---------------------------------------------------------------------------------------------------------
			public LotusColumnNumberFilter()
			{
				InitializeComponent();
				QueryItem = new CQueryItemNumber();
				QueryItem.BindingComboBoxToComparisonOperator(comboOperator);
			}
			#endregion

			#region ======================================= ОБРАБОТЧИКИ СОБЫТИЙ =======================================
			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Выбор оператора сравнения
			/// </summary>
			/// <param name="sender">Источник события</param>
			/// <param name="args">Аргументы события</param>
			//---------------------------------------------------------------------------------------------------------
			private void OnComboOperator_SelectionChanged(Object sender, SelectionChangedEventArgs args)
			{
				//if(QueryItem.ComparisonOperator == TComparisonOperator.Between)
				//{
				//	textOperator.Visibility = Visibility.Visible;
				//	textValueRight.Visibility = Visibility.Visible;
				//}
				//else
				//{
				//	textOperator.Visibility = Visibility.Collapsed;
				//	textValueRight.Visibility = Visibility.Collapsed;
				//}
			}
			#endregion
		}
		//-------------------------------------------------------------------------------------------------------------
		/*@}*/
		//-------------------------------------------------------------------------------------------------------------
	}
}
//=====================================================================================================================