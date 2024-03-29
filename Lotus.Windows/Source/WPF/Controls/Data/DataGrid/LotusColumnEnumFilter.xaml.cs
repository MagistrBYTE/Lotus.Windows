﻿//=====================================================================================================================
// Проект: Модуль платформы Windows
// Раздел: Подсистема работы с WPF
// Подраздел: Элементы интерфейса
// Группа: Элементы для работы с данными
// Автор: MagistrBYTE aka DanielDem <dementevds@gmail.com>
//---------------------------------------------------------------------------------------------------------------------
/** \file LotusColumnEnumFilter.xaml.cs
*		Элемент служащий для формирования элемента запроса для перечисляемых типов данных.
*/
//---------------------------------------------------------------------------------------------------------------------
// Версия: 1.0.0.0
// Последнее изменение от 30.04.2023
//=====================================================================================================================
using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
//=====================================================================================================================
namespace Lotus
{
	namespace Windows
	{
		//-------------------------------------------------------------------------------------------------------------
		/** \addtogroup WindowsWPFControlsData
		*@{*/
		//-------------------------------------------------------------------------------------------------------------
		/// <summary>
		/// Элемент служащий для формирования элемента запроса для перечисляемых типов данных
		/// </summary>
		//-------------------------------------------------------------------------------------------------------------
		public partial class LotusColumnEnumFilter : UserControl
		{
			#region ======================================= ОПРЕДЕЛЕНИЕ СВОЙСТВ ЗАВИСИМОСТИ ===========================
			/// <summary>
			/// Элемент запроса для перечисляемых данных
			/// </summary>
			public static readonly DependencyProperty QueryItemProperty = DependencyProperty.Register(nameof(QueryItem),
				typeof(CQueryItemEnum), typeof(LotusColumnEnumFilter),
				new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsRender));
			#endregion

			#region ======================================= МЕТОДЫ СВОЙСТВ ЗАВИСИМОСТИ ================================
			#endregion

			#region ======================================= СВОЙСТВА ==================================================
			/// <summary>
			/// Элемент запроса для перечисляемых данных
			/// </summary>
			public CQueryItemEnum QueryItem
			{
				get { return (CQueryItemEnum)GetValue(QueryItemProperty); }
				set { SetValue(QueryItemProperty, value); }
			}
			#endregion

			#region ======================================= КОНСТРУКТОРЫ ==============================================
			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Конструктор по умолчанию инициализирует объект класса предустановленными значениями
			/// </summary>
			//---------------------------------------------------------------------------------------------------------
			public LotusColumnEnumFilter()
			{
				InitializeComponent();
				QueryItem = new CQueryItemEnum();
			}
			#endregion

			#region ======================================= ОБРАБОТЧИКИ СОБЫТИЙ =======================================
			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Загрузка элемента отображения 
			/// </summary>
			/// <param name="sender">Источник события</param>
			/// <param name="args">Аргументы события</param>
			//---------------------------------------------------------------------------------------------------------
			private void OnUserControl_Loaded(Object sender, RoutedEventArgs args)
			{
				// Method intentionally left empty.
			}

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Выбор фильтра
			/// </summary>
			/// <param name="sender">Источник события</param>
			/// <param name="args">Аргументы события</param>
			//---------------------------------------------------------------------------------------------------------
			private void OnCheckBox_Checked(Object sender, RoutedEventArgs args)
			{
				if (sender is CheckBox check_box)
				{
					// Если нет то добавляем
					if (QueryItem.FiltredItems.Contains(check_box.Content) == false)
					{
						QueryItem.FiltredItems.Add(check_box.Content);
						QueryItem.NotifyPropertyChanged(CQueryItem.PropertyArgsSQLQueryItem);
						comboBoxSourceItems.Text = QueryItem.JoinFiltredItems();
					}
				}
			}

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Отмена выбора фильтра
			/// </summary>
			/// <param name="sender">Источник события</param>
			/// <param name="args">Аргументы события</param>
			//---------------------------------------------------------------------------------------------------------
			private void OnCheckBox_Unchecked(Object sender, RoutedEventArgs args)
			{
				if (sender is CheckBox check_box)
				{
					// Если есть то удаляем
					var index = QueryItem.FiltredItems.IndexOf(check_box.Content);
					if (index > -1)
					{
						QueryItem.FiltredItems.RemoveAt(index);
						QueryItem.NotifyPropertyChanged(CQueryItem.PropertyArgsSQLQueryItem);
						comboBoxSourceItems.Text = QueryItem.JoinFiltredItems();
					}
				}
			}

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Выбор фильтра
			/// </summary>
			/// <param name="sender">Источник события</param>
			/// <param name="args">Аргументы события</param>
			//---------------------------------------------------------------------------------------------------------
			private void OnComboBoxSourceItems_Selected(Object sender, SelectionChangedEventArgs args)
			{
				comboBoxSourceItems.Text = QueryItem.JoinFiltredItems();
			}
			#endregion
		}
		//-------------------------------------------------------------------------------------------------------------
		/**@}*/
		//-------------------------------------------------------------------------------------------------------------
	}
}
//=====================================================================================================================