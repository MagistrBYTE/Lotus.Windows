﻿//=====================================================================================================================
// Проект: Модуль для отображения изображений
// Раздел: Элементы управления
// Автор: MagistrBYTE aka DanielDem <dementevds@gmail.com>
//---------------------------------------------------------------------------------------------------------------------
/** \file LotusRibbonTabImageEditor.xaml.cs
*		Контекстная вкладка ленты для просмотра свойств и редактирования изображения.
*/
//---------------------------------------------------------------------------------------------------------------------
// Версия: 1.0.0.0
// Последнее изменение от 30.04.2023
//=====================================================================================================================
using System;
using System.Windows;
//---------------------------------------------------------------------------------------------------------------------
using Fluent;
//=====================================================================================================================
namespace Lotus
{
	namespace Windows
	{
		//-------------------------------------------------------------------------------------------------------------
		/**
         * \defgroup WindowsViewerImageControls Элементы управления
         * \ingroup WindowsViewerImage
         * \brief Элементы управления.
         * @{
         */
		//-------------------------------------------------------------------------------------------------------------
		/// <summary>
		/// Контекстная вкладка ленты для просмотра свойств и редактирования изображения
		/// </summary>
		//-------------------------------------------------------------------------------------------------------------
		public partial class LotusRibbonTabImageEditor : RibbonTabItem
		{
			#region ======================================= ОПРЕДЕЛЕНИЕ СВОЙСТВ ЗАВИСИМОСТИ ===========================
			/// <summary>
			/// Основной редактор изображения
			/// </summary>
			public static readonly DependencyProperty ImageViewEditorProperty = DependencyProperty.Register(nameof(ImageViewEditor),
				typeof(LotusViewerImage),
				typeof(LotusRibbonTabImageEditor),
				new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.None));
			#endregion

			#region ======================================= ДАННЫЕ ====================================================
			#endregion

			#region ======================================= СВОЙСТВА ==================================================
			/// <summary>
			/// Основной редактор изображения
			/// </summary>
			public LotusViewerImage ImageViewEditor
			{
				get { return (LotusViewerImage)GetValue(ImageViewEditorProperty); }
				set { SetValue(ImageViewEditorProperty, value); }
			}
			#endregion

			#region ======================================= КОНСТРУКТОРЫ ==============================================
			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Конструктор по умолчанию инициализирует объект класса предустановленными значениями
			/// </summary>
			//---------------------------------------------------------------------------------------------------------
			public LotusRibbonTabImageEditor()
			{
				InitializeComponent();
				SetResourceReference(StyleProperty, typeof(RibbonTabItem));
			}
			#endregion

			#region ======================================= ОБЩИЕ МЕТОДЫ ==============================================
			#endregion

			#region ======================================= ОБРАБОТЧИКИ СОБЫТИЙ =======================================
			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Загрузка вкладки ленты
			/// </summary>
			/// <param name="sender">Источник события</param>
			/// <param name="args">Аргументы события</param>
			//---------------------------------------------------------------------------------------------------------
			private void OnRibbonTabImageEditor_Loaded(Object sender, RoutedEventArgs args)
			{
				// Method intentionally left empty.
			}

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Открытие файла
			/// </summary>
			/// <param name="sender">Источник события</param>
			/// <param name="args">Аргументы события</param>
			//---------------------------------------------------------------------------------------------------------
			private void OnButtonOpen_Click(Object sender, RoutedEventArgs args)
			{
				if (ImageViewEditor != null)
				{
					ImageViewEditor.OpenFile(null, null);
				}
			}

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Открытие файла в программе Notepad
			/// </summary>
			/// <param name="sender">Источник события</param>
			/// <param name="args">Аргументы события</param>
			//---------------------------------------------------------------------------------------------------------
			private void OnButtonOpenNotepad_Click(Object sender, RoutedEventArgs args)
			{
				// Method intentionally left empty.
			}

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Сохранение файла
			/// </summary>
			/// <param name="sender">Источник события</param>
			/// <param name="args">Аргументы события</param>
			//---------------------------------------------------------------------------------------------------------
			private void OnButtonSave_Click(Object sender, RoutedEventArgs args)
			{
				if (ImageViewEditor != null)
				{
					ImageViewEditor.SaveFile();
				}
			}

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Сохранение файла под новым именем
			/// </summary>
			/// <param name="sender">Источник события</param>
			/// <param name="args">Аргументы события</param>
			//---------------------------------------------------------------------------------------------------------
			private void OnButtonSaveAs_Click(Object sender, RoutedEventArgs args)
			{
				if (ImageViewEditor != null)
				{
					ImageViewEditor.SaveAsFile(null, null);
				}
			}

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Выбор маски отображения
			/// </summary>
			/// <param name="sender">Источник события</param>
			/// <param name="args">Аргументы события</param>
			//---------------------------------------------------------------------------------------------------------
			private void OnRadioChannelImage_Checked(Object sender, RoutedEventArgs args)
			{
				if (ImageViewEditor != null)
				{
					if (radioChannelOriginal.IsChecked.GetValueOrDefault())
					{
						ImageViewEditor.SetViewOriginal();
					}

					if (radioChannelAlpha.IsChecked.GetValueOrDefault())
					{
						ImageViewEditor.SetViewAlpha();
					}

					if (radioChannelNoTransparent.IsChecked.GetValueOrDefault())
					{
						ImageViewEditor.SetViewNoTransparent();
					}
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