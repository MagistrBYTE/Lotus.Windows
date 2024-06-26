using System;
using System.Runtime.InteropServices;

namespace Lotus.Windows
{

    /** \addtogroup WindowsCommonNative
	*@{*/
    /// <summary>
    /// Структура для описания точки Win32.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct Win32Point
    {
        /// <summary>
        /// Координата по X.
        /// </summary>
        public int X;

        /// <summary>
        /// Координата по Y.
        /// </summary>
        public int Y;
    };

    /// <summary>
    /// Структура для описания размера Win32.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct Win32Size
    {
        /// <summary>
        /// Ширина.
        /// </summary>
        public int Width;

        /// <summary>
        /// Высота.
        /// </summary>
        public int Height;
    }

    /// <summary>
    /// Структура для описания перемещаемой иконки.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct ShDragImage
    {
        /// <summary>
        /// Размер иконки.
        /// </summary>
        public Win32Size SizeDragImage;

        /// <summary>
        /// Смещение.
        /// </summary>
        public Win32Point Offset;

        /// <summary>
        /// Указатель на данные.
        /// </summary>
        public IntPtr DragImage;

        /// <summary>
        /// Цветовой ключ.
        /// </summary>
        public int ColorKey;
    }

    /// <summary>
    /// Структура для хранения информации о файле.
    /// </summary>
    public struct ShellFileInfo
    {
        /// <summary>
        /// Дескриптор иконки связанный с данным типом файла.
        /// </summary>
        public IntPtr IconHandle;

        /// <summary>
        /// Индекс иконки в списке.
        /// </summary>
        public int IconIndex;

        /// <summary>
        /// Атрибуты файла.
        /// </summary>
        public uint Attributes;

        /// <summary>
        /// Путь к файлу.
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
        public string DisplayName;

        /// <summary>
        /// Имя типа файла.
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 80)]
        public string TypeName;
    };

    /// <summary>
    /// Параметры открытия приложения.
    /// </summary>
    public enum TShowCommands : uint
    {
        SW_HIDE = 0,
        SW_SHOWNORMAL = 1,
        SW_NORMAL = 1,
        SW_SHOWMINIMIZED = 2,
        SW_SHOWMAXIMIZED = 3,
        SW_MAXIMIZE = 3,
        SW_SHOWNOACTIVATE = 4,
        SW_SHOW = 5,
        SW_MINIMIZE = 6,
        SW_SHOWMINNOACTIVE = 7,
        SW_SHOWNA = 8,
        SW_RESTORE = 9,
        SW_SHOWDEFAULT = 10,
        SW_FORCEMINIMIZE = 11,
        SW_MAX = 11
    }

    /// <summary>
    /// Параметры(атрибуты) открытия.
    /// </summary>
    [Flags]
    public enum TShellAttribute : uint
    {
        LargeIcon = 0,              // 0x000000000
        SmallIcon = 1,              // 0x000000001
        OpenIcon = 2,               // 0x000000002
        ShellIconSize = 4,          // 0x000000004
        Pidl = 8,                   // 0x000000008
        UseFileAttributes = 16,     // 0x000000010
        AddOverlays = 32,           // 0x000000020
        OverlayIndex = 64,          // 0x000000040
        Others = 128,               // Not defined, really?
        Icon = 256,                 // 0x000000100  
        DisplayName = 512,          // 0x000000200
        TypeName = 1024,            // 0x000000400
        Attributes = 2048,          // 0x000000800
        IconLocation = 4096,        // 0x000001000
        ExeType = 8192,             // 0x000002000
        SystemIconIndex = 16384,    // 0x000004000
        LinkOverlay = 32768,        // 0x000008000 
        Selected = 65536,           // 0x000010000
        AttributeSpecified = 131072 // 0x000020000
    }
    /**@}*/
}