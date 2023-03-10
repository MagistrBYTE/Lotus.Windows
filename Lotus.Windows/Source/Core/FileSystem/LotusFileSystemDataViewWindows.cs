//=====================================================================================================================
// Проект: Модуль платформы Windows
// Раздел: Имплементация модуля базового ядра
// Подраздел: Подсистема файловой системы
// Автор: MagistrBYTE aka DanielDem <dementevds@gmail.com>
//---------------------------------------------------------------------------------------------------------------------
/** \file LotusFileSystemDataViewWindows.cs
*		Специализация элементов отображения для работы с объектам файловой системы для Windows.
*/
//---------------------------------------------------------------------------------------------------------------------
// Версия: 1.0.0.0
// Последнее изменение от 27.03.2022
//=====================================================================================================================
using System;
using System.Windows.Media;
//=====================================================================================================================
namespace Lotus
{
	namespace Core
	{
		//-------------------------------------------------------------------------------------------------------------
		//! \addtogroup CoreFileSystem
		/*@{*/
		//-------------------------------------------------------------------------------------------------------------
		/// <summary>
		/// Класс реализующий элемент отображения для элемента файловой системы для Windows
		/// </summary>
		//-------------------------------------------------------------------------------------------------------------
		public class CViewItemFSWindows : ViewItemHierarchy<ILotusFileSystemEntity>
		{
			#region ======================================= ДАННЫЕ ====================================================
			protected internal ImageSource mIconSource;
			#endregion

			#region ======================================= СВОЙСТВА ==================================================
			/// <summary>
			/// Графическая иконка связанная с данным элементом файловой системы
			/// </summary>
			public ImageSource IconSource
			{
				get
				{
					if (mIconSource == null)
					{
						String full_name = DataContext.FullName;
						if (full_name.IsExists())
						{
							mIconSource = Windows.XWindowsLoaderBitmap.GetIconFromFileTypeFromShell(full_name,
								(UInt32)(Windows.TShellAttribute.Icon | Windows.TShellAttribute.SmallIcon));
							mIconSource = Windows.XWindowsLoaderBitmap.GetIconFromFileTypeFromExtract(full_name);
						}
					}

					return (mIconSource);
				}
				set
				{
					mIconSource = value;
				}
			}
			#endregion

			#region ======================================= КОНСТРУКТОРЫ ==============================================
			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Конструктор по умолчанию инициализирует объект класса предустановленными значениями
			/// </summary>
			//---------------------------------------------------------------------------------------------------------
			public CViewItemFSWindows()
				: this(String.Empty)
			{

			}

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Конструктор инициализирует объект класса указанными параметрами
			/// </summary>
			/// <param name="name">Имя модели</param>
			//---------------------------------------------------------------------------------------------------------
			public CViewItemFSWindows(String name)
				: base(name)
			{
				SetContextMenu();
				mIsNotify = true;
			}

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Конструктор инициализирует объект класса указанными параметрами
			/// </summary>
			/// <param name="data_context">Данные</param>
			//---------------------------------------------------------------------------------------------------------
			public CViewItemFSWindows(ILotusFileSystemEntity data_context)
				: base(data_context)
			{
				SetContextMenu();
				mIsNotify = true;
			}

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Конструктор инициализирует объект класса указанными параметрами
			/// </summary>
			/// <param name="data_context">Данные</param>
			/// <param name="parent_item">Родительский узел</param>
			//---------------------------------------------------------------------------------------------------------
			public CViewItemFSWindows(ILotusFileSystemEntity data_context, ILotusViewItemHierarchy parent_item)
				: base(data_context, parent_item)
			{
				SetContextMenu();
				mIsNotify = true;
			}
			#endregion

			#region ======================================= ОБЩИЕ МЕТОДЫ ==============================================
			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Установка контекстного меню
			/// </summary>
			//---------------------------------------------------------------------------------------------------------
			public virtual void SetContextMenu()
			{
				mUIContextMenu = new CUIContextMenuWindows();
				mUIContextMenu.ViewItem = this;
				mUIContextMenu.AddItem("Показать в проводнике", (ILotusViewItem view_item) =>
				{
					Windows.XNative.ShellExecute(IntPtr.Zero,
						"explore",
						DataContext.FullName,
						"",
						"",
						Windows.TShowCommands.SW_NORMAL);
				});
				mUIContextMenu.AddItem(CUIContextMenuWindows.Remove.Duplicate());
			}

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Открытие контекстного меню
			/// </summary>
			/// <param name="context_menu">Контекстное меню</param>
			//---------------------------------------------------------------------------------------------------------
			public override void OpenContextMenu(System.Object context_menu)
			{
				if (context_menu is System.Windows.Controls.ContextMenu window_context_menu)
				{
					((CUIContextMenuWindows)mUIContextMenu).SetCommandsDefault(window_context_menu);
				}
			}

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Построение дочерней иерархии согласно источнику данных
			/// </summary>
			//---------------------------------------------------------------------------------------------------------
			public override void BuildFromDataContext()
			{
				Clear();
				CCollectionViewFSWindows.BuildFromParent(this, mOwner);
			}
			#endregion
		}

		//-------------------------------------------------------------------------------------------------------------
		/// <summary>
		/// Коллекция для отображения элементов файловой системы для Windows
		/// </summary>
		//-------------------------------------------------------------------------------------------------------------
		public class CCollectionViewFSWindows : CollectionViewHierarchy<CViewItemFSWindows, ILotusFileSystemEntity>
		{
			#region ======================================= КОНСТРУКТОРЫ ==============================================
			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Конструктор по умолчанию инициализирует объект класса предустановленными значениями
			/// </summary>
			//---------------------------------------------------------------------------------------------------------
			public CCollectionViewFSWindows()
				: base(String.Empty)
			{

			}

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Конструктор инициализирует объект класса указанными параметрами
			/// </summary>
			/// <param name="name">Имя коллекции</param>
			//---------------------------------------------------------------------------------------------------------
			public CCollectionViewFSWindows(String name)
				: base(name)
			{
			}

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Конструктор инициализирует объект класса указанными параметрами
			/// </summary>
			/// <param name="name">Имя коллекции</param>
			/// <param name="source">Источник данных</param>
			//---------------------------------------------------------------------------------------------------------
			public CCollectionViewFSWindows(String name, ILotusFileSystemEntity source)
				: base(name, source)
			{
			}
			#endregion
		}
		//-------------------------------------------------------------------------------------------------------------
		/*@}*/
		//-------------------------------------------------------------------------------------------------------------
	}
}
//=====================================================================================================================