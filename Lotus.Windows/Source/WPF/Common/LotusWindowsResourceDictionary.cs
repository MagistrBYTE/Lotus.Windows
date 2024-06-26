using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;

namespace Lotus.Windows
{
    /** \addtogroup WindowsWPFCommon
	*@{*/
    /// <summary>
    /// Кэшированный словарь ресурсов.
    /// </summary>
    /// <remarks>
    /// Общий словарь ресурс является специализированным словарь ресурс, который загружает это содержимое 
    /// только один раз.Если второй экземпляр с тем же источником создан, он только объединяет ресурсы из кэша
    /// </remarks>
    public class SharedResourceDictionary : ResourceDictionary
    {
        #region Static fields
        /// <summary>
        /// Внутренний кэш загруженных словарей.
        /// </summary>
        private static Dictionary<Uri, ResourceDictionary> _sharedDictionaries = [];

        /// <summary>
        /// Значение, указывающее, является ли приложение в режиме разработки.
        /// </summary>
        private static bool _isInDesignerMode;
        #endregion

        #region Static properties 
        /// <summary>
        /// Общий кэш загруженных словарей.
        /// </summary>
        public static Dictionary<Uri, ResourceDictionary> SharedDictionaries
        {
            get { return _sharedDictionaries; }
        }
        #endregion

        #region Fields
        /// <summary>
        /// Локальные данные исходного URI.
        /// </summary>
        private Uri _sourceUri = default!;
        #endregion

        #region Properties
        /// <summary>
        /// Получает или задает идентификатор Uniform Resource (URI), для загрузки ресурсов.
        /// </summary>
        public new Uri Source
        {
            get { return _sourceUri; }
            set
            {
                _sourceUri = value;

                // Always load the dictionary by default in designer mode.
                if (!_sharedDictionaries.ContainsKey(value) || _isInDesignerMode)
                {
                    // If the dictionary is not yet loaded, load it by setting
                    // the source of the base class
                    base.Source = value;

                    // add it to the cache if we're not in designer mode
                    if (!_isInDesignerMode)
                    {
                        _sharedDictionaries.Add(value, this);
                    }
                }
                else
                {
                    // If the dictionary is already loaded, get it from the cache
                    MergedDictionaries.Add(_sharedDictionaries[value]);
                }
            }
        }
        #endregion

        #region Constructors
        /// <summary>
        /// Статический конструктор.
        /// </summary>
#pragma warning disable S3963 // "static" fields should be initialized inline
        static SharedResourceDictionary()
        {
            _isInDesignerMode = (bool)DesignerProperties.IsInDesignModeProperty.GetMetadata(typeof(DependencyObject)).DefaultValue;
        }
#pragma warning restore S3963 // "static" fields should be initialized inline
        #endregion
    }
    /**@}*/
}