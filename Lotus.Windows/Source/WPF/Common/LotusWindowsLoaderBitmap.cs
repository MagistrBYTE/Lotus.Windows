﻿//=====================================================================================================================
// Проект: Модуль платформы Windows
// Раздел: Подсистема работы с WPF
// Подраздел: Общая подсистема
// Автор: MagistrBYTE aka DanielDem <dementevds@gmail.com>
//---------------------------------------------------------------------------------------------------------------------
/** \file LotusWindowsLoaderBitmap.cs
*		Статический класс для реализации методов загрузки BitmapSource из различных источников.
*/
//---------------------------------------------------------------------------------------------------------------------
// Версия: 1.0.0.0
// Последнее изменение от 30.04.2023
//=====================================================================================================================
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Media.Imaging;
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
		/// Статический класс для реализации методов загрузки <see cref="BitmapSource"/> из различных источников
		/// </summary>
		//-------------------------------------------------------------------------------------------------------------
		public static class XWindowsLoaderBitmap
		{
			#region ======================================= ДАННЫЕ ====================================================
			/// <summary>
			/// Словарь иконок файла по имени расширения
			/// </summary>
			public static readonly Dictionary<String, BitmapSource> IconFilesExtension = new Dictionary<string, BitmapSource>();
			#endregion

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Загрузка изображения из ресурсов сборки
			/// </summary>
			/// <param name="resource_name">Имя ресурса</param>
			/// <returns>Изображение</returns>
			//---------------------------------------------------------------------------------------------------------
			public static BitmapSource? LoadBitmapFromResource(String resource_name)
			{
				var image = Properties.Resources.ResourceManager.GetObject(resource_name);
				if (image is System.Drawing.Bitmap source)
				{

					var h_bitmap = source.GetHbitmap();
					var result = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(h_bitmap, IntPtr.Zero,
						Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());

					XNative.DeleteObject(h_bitmap);

					return result;
				}

				return null;
			}

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Загрузка изображения из ресурсов сборки
			/// </summary>
			/// <param name="resource_manager">Менеджер ресурсов</param>
			/// <param name="resource_name">Имя ресурса</param>
			/// <returns>Изображение</returns>
			//---------------------------------------------------------------------------------------------------------
			public static BitmapSource? LoadBitmapFromResource(System.Resources.ResourceManager resource_manager, String resource_name)
			{
				var image = resource_manager.GetObject(resource_name);

				if (image is System.Drawing.Bitmap source)
				{
					var h_bitmap = source.GetHbitmap();
					var result = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(h_bitmap, IntPtr.Zero,
						Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());

					XNative.DeleteObject(h_bitmap);

					return result;
				}

				return null;
			}

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Загрузка изображения из файла
			/// </summary>
			/// <param name="file_name">Имя файла</param>
			/// <returns>Изображение</returns>
			//---------------------------------------------------------------------------------------------------------
			public static BitmapSource LoadBitmapFromFile(String file_name)
			{
				var file_stream = new FileStream(file_name, FileMode.Open, FileAccess.Read);

				var bitmap = new BitmapImage(new Uri(file_name));
				bitmap.BeginInit();
				bitmap.StreamSource = file_stream;
				bitmap.EndInit();

				file_stream.Close();

				return bitmap;
			}

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Создание объекта BitmapSource из стандартного дескриптора изображения
			/// </summary>
			/// <param name="h_bitmap">Дескриптор изображения</param>
			/// <returns>Объект BitmapSource</returns>
			//---------------------------------------------------------------------------------------------------------
			public static BitmapSource CreateFromHBitmap(IntPtr h_bitmap)
			{
				var result = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(h_bitmap, IntPtr.Zero,
					Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());

				XNative.DeleteObject(h_bitmap);

				return result;
			}

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Создание объекта BitmapSource из стандартного дескриптора изображения
			/// </summary>
			/// <param name="h_bitmap">Дескриптор изображения</param>
			/// <param name="width">Требуемая ширина изображения</param>
			/// <param name="height">Требуемая высота изображения</param>
			/// <returns>Объект BitmapSource</returns>
			//---------------------------------------------------------------------------------------------------------
			public static BitmapSource CreateFromHBitmap(IntPtr h_bitmap, Int32 width, Int32 height)
			{
				var result = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(h_bitmap, IntPtr.Zero,
					Int32Rect.Empty, BitmapSizeOptions.FromWidthAndHeight(width, height));

				XNative.DeleteObject(h_bitmap);

				return result;
			}

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Получение иконки файла связанного с типом файла
			/// </summary>
			/// <param name="file_name">Имя файла</param>
			/// <param name="flags">Флаги получения иконок </param>
			/// <returns>Изображение</returns>
			//---------------------------------------------------------------------------------------------------------
			public static BitmapSource GetIconFromFileTypeFromShell(String file_name, UInt32 flags)
			{
				var ext = Path.GetExtension(file_name);
				if (String.IsNullOrEmpty(ext) == false && IconFilesExtension.TryGetValue(ext, out BitmapSource? bitmap_source))
				{
					return bitmap_source;
				}

				XNative.SHGetFileInfo(file_name, 0, ref XNative.ShellFileInfoDefault,
					(UInt32)Marshal.SizeOf(XNative.ShellFileInfoDefault), flags);

				//The icon is returned in the hIcon member of the shinfo struct
				var icon = System.Drawing.Icon.FromHandle(XNative.ShellFileInfoDefault.IconHandle);

				var h_bitmap = icon.ToBitmap().GetHbitmap();
				var result = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(h_bitmap, IntPtr.Zero,
					Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());

				XNative.DeleteObject(h_bitmap);

				if (String.IsNullOrEmpty(ext) == false)
				{
					IconFilesExtension.Add(ext, result);
				}

				return result;
			}

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Получение иконки файла связанного с типом файла
			/// </summary>
			/// <param name="file_name">Имя файла</param>
			/// <returns>Изображение</returns>
			//---------------------------------------------------------------------------------------------------------
			public static BitmapSource GetIconFromFileTypeFromExtract(String file_name)
			{
				if (Path.HasExtension(file_name))
				{
					var sysicon = System.Drawing.Icon.ExtractAssociatedIcon(file_name);
					if (sysicon != null)
					{
						var bmp_src = System.Windows.Interop.Imaging.CreateBitmapSourceFromHIcon(
							sysicon.Handle,
							Int32Rect.Empty,
							BitmapSizeOptions.FromEmptyOptions());
						sysicon.Dispose();

						return bmp_src;
					}
				}

				return GetIconFromFileTypeFromShell(file_name, (UInt32)(TShellAttribute.Icon | TShellAttribute.SmallIcon));

			}
		}
		//-------------------------------------------------------------------------------------------------------------
		/**@}*/
		//-------------------------------------------------------------------------------------------------------------
	}
}
//=====================================================================================================================