using System.Windows;
using System.Windows.Controls;

using Lotus.Core;

namespace Lotus.Windows
{

    /** \addtogroup CoreFileSystem
	*@{*/
    /// <summary>
    /// Селектор шаблона данных для отображения иерархии элементов.
    /// </summary>
    public class CFileSystemEntityDataSelector : DataTemplateSelector
    {
        #region Static fields
        /// <summary>
        /// Глобальный экземпляр селектора.
        /// </summary>
        public static readonly CFileSystemEntityDataSelector Instance = (Application.Current.Resources["FileSystemEntityDataSelectorKey"] as CFileSystemEntityDataSelector)!;
        #endregion

        #region Fields
        /// <summary>
        /// Шаблон для представления диска.
        /// </summary>
        public DataTemplate Disk { get; set; }

        /// <summary>
        /// Шаблон для представления директории.
        /// </summary>
        public DataTemplate Directory { get; set; }

        /// <summary>
        /// Шаблон для представления файла.
        /// </summary>
        public DataTemplate File { get; set; }

        /// <summary>
        /// Шаблон для представления неизвестного узла.
        /// </summary>
        public DataTemplate Unknow { get; set; }
        #endregion

        #region Main methods
        /// <summary>
        /// Выбор шаблона привязки данных.
        /// </summary>
        /// <param name="item">Объект.</param>
        /// <param name="container">Контейнер.</param>
        /// <returns>Нужный шаблон.</returns>
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            if (item is ViewModelFSFileWin view_model)
            {
                if (view_model.Model is CFileSystemDirectory)
                {
                    return Directory;
                }

                if (view_model.Model is CFileSystemFile)
                {
                    return File;
                }
            }

            return Unknow;
        }
        #endregion
    }
    /**@}*/
}