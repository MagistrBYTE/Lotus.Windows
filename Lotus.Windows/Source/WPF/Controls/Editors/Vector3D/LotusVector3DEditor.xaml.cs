using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

using Lotus.Core;
using Lotus.Maths;

using Xceed.Wpf.Toolkit.PropertyGrid;
using Xceed.Wpf.Toolkit.PropertyGrid.Editors;

namespace Lotus.Windows
{
    /** \addtogroup WindowsWPFControlsEditor
	*@{*/
    /// <summary>
    /// Элемент-редактор для редактирования свойства типа трехмерного вектора.
    /// </summary>
    public partial class LotusVector3DEditor : UserControl, ITypeEditor
    {
        #region Static fields
        /// <summary>
        /// Универсальный конвертор типа Vector3D между различными типами представлений.
        /// </summary>
        public static readonly Vector3DToVector3DConverter VectorConverter = new Vector3DToVector3DConverter();

        /// <summary>
        /// Текущие скопированное значение.
        /// </summary>
        public static Vector3D CopyValue
        {
            get { return _copyValue; }
        }

        private static Vector3D _copyValue = new();
        #endregion

        #region Declare DependencyProperty 
        /// <summary>
        /// Значение вектора.
        /// </summary>
        public static readonly DependencyProperty ValueProperty = DependencyProperty.Register(nameof(Value), typeof(Vector3D),
            typeof(LotusVector3DEditor), new FrameworkPropertyMetadata(Vector3D.Zero, OnValuePropertyChanged));
        #endregion

        #region DependencyProperty methods
        /// <summary>
        /// Изменение свойства зависимости.
        /// </summary>
        /// <param name="obj">Источник события.</param>
        /// <param name="args">Аргументы события.</param>
        private static void OnValuePropertyChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args)
        {
            var editor_vector = (LotusVector3DEditor)obj;
            Vector3D? value = (Vector3D)args.NewValue;
            if (value.HasValue)
            {
                editor_vector.IsEnabled = false;
                editor_vector.spinnerX.Value = value.Value.X;
                editor_vector.spinnerY.Value = value.Value.Y;
                editor_vector.spinnerZ.Value = value.Value.Z;
                editor_vector.IsEnabled = true;
            }
        }
        #endregion

        #region Fields
        protected internal PropertyItem _propertyItem;
        protected internal string _formatRadix;
        #endregion

        #region Properties
        /// <summary>
        /// Значение вектора.
        /// </summary>
        public Vector3D Value
        {
            get { return (Vector3D)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }
        #endregion

        #region Constructors
        /// <summary>
        /// Конструктор по умолчанию инициализирует объект класса предустановленными значениями.
        /// </summary>
        public LotusVector3DEditor()
        {
            InitializeComponent();
        }
        #endregion

        #region Create FrameworkElement 
        /// <summary>
        /// Элемент редактор свойства типа Vector3D.
        /// </summary>
        /// <param name="propertyItem">Параметры свойства.</param>
        /// <returns>Редактор.</returns>
        public FrameworkElement ResolveEditor(PropertyItem propertyItem)
        {
            var binding = new Binding(nameof(Value));
            binding.Source = propertyItem;
            binding.ValidatesOnExceptions = true;
            binding.ValidatesOnDataErrors = true;
            binding.Mode = propertyItem.IsReadOnly ? BindingMode.OneWay : BindingMode.TwoWay;
            binding.Converter = VectorConverter;
            binding.ConverterParameter = propertyItem.PropertyType;

            // Привязываемся к свойству
            BindingOperations.SetBinding(this, ValueProperty, binding);

            // Сохраняем объект
            _propertyItem = propertyItem;

            return this;
        }
        #endregion

        #region Event handlers 
        /// <summary>
        /// Обработчик события изменения координат X.
        /// </summary>
        /// <param name="sender">Источник события.</param>
        /// <param name="args">Аргументы события.</param>
        private void OnSpinnerX_ValueChanged(object sender, RoutedPropertyChangedEventArgs<object> args)
        {
            if (spinnerX.Value != null)
            {
                Value = new Vector3D(spinnerX.Value.Value, Value.Y, Value.Z);
            }
        }

        /// <summary>
        /// Обработчик события изменения координат Y.
        /// </summary>
        /// <param name="sender">Источник события.</param>
        /// <param name="args">Аргументы события.</param>
        private void OnSpinnerY_ValueChanged(object sender, RoutedPropertyChangedEventArgs<object> args)
        {
            if (spinnerY.Value != null)
            {
                Value = new Vector3D(Value.X, spinnerY.Value.Value, Value.Z);
            }
        }

        /// <summary>
        /// Обработчик события изменения координат Z.
        /// </summary>
        /// <param name="sender">Источник события.</param>
        /// <param name="args">Аргументы события.</param>
        private void OnSpinnerZ_ValueChanged(object sender, RoutedPropertyChangedEventArgs<object> args)
        {
            if (spinnerZ.Value != null)
            {
                Value = new Vector3D(Value.X, Value.Y, spinnerZ.Value.Value);
            }
        }

        /// <summary>
        /// Открытие контекстного меню.
        /// </summary>
        /// <param name="sender">Источник события.</param>
        /// <param name="args">Аргументы события.</param>
        private void OnButtonMenu_Click(object sender, RoutedEventArgs args)
        {
            ButtonMenu.ContextMenu.IsOpen = true;
            if (_copyValue != Vector3D.Zero)
            {
                miPaste.Header = "Вставить (" + _copyValue.ToString("F1") + ")";
            }
        }

        /// <summary>
        /// Установка разрядности - ноль цифр после запятой.
        /// </summary>
        /// <param name="sender">Источник события.</param>
        /// <param name="args">Аргументы события.</param>
        private void OnRadixZero_Checked(object sender, RoutedEventArgs args)
        {
            _formatRadix = "F0";
            spinnerX.FormatString = _formatRadix;
            spinnerY.FormatString = _formatRadix;
            spinnerZ.FormatString = _formatRadix;
        }

        /// <summary>
        /// Установка разрядности - одна цифра после запятой.
        /// </summary>
        /// <param name="sender">Источник события.</param>
        /// <param name="args">Аргументы события.</param>
        private void OnRadixOne_Checked(object sender, RoutedEventArgs args)
        {
            _formatRadix = "F1";
            spinnerX.FormatString = _formatRadix;
            spinnerY.FormatString = _formatRadix;
            spinnerZ.FormatString = _formatRadix;
        }

        /// <summary>
        /// Установка разрядности - две цифры после запятой.
        /// </summary>
        /// <param name="sender">Источник события.</param>
        /// <param name="args">Аргументы события.</param>
        private void OnRadixTwo_Checked(object sender, RoutedEventArgs args)
        {
            _formatRadix = "F2";
            spinnerX.FormatString = _formatRadix;
            spinnerY.FormatString = _formatRadix;
            spinnerZ.FormatString = _formatRadix;
        }

        /// <summary>
        /// Копирование вектора.
        /// </summary>
        /// <param name="sender">Источник события.</param>
        /// <param name="args">Аргументы события.</param>
        private void OnMenuItemCopyVector_Click(object sender, RoutedEventArgs args)
        {
            _copyValue = new Vector3D(spinnerX.Value.GetValueOrDefault(), spinnerY.Value.GetValueOrDefault(),
                spinnerZ.Value.GetValueOrDefault());
            if (_copyValue != Vector3D.Zero)
            {
                miPaste.Header = "Вставить (" + _copyValue.ToStringValue(_formatRadix) + ")";
            }
        }

        /// <summary>
        /// Вставка вектора.
        /// </summary>
        /// <param name="sender">Источник события.</param>
        /// <param name="args">Аргументы события.</param>
        private void OnMenuItemPasteVector_Click(object sender, RoutedEventArgs args)
        {
            spinnerX.Value = _copyValue.X;
            spinnerY.Value = _copyValue.Y;
            spinnerZ.Value = _copyValue.Y;
        }

        /// <summary>
        /// Установка значения по умолчанию вектора.
        /// </summary>
        /// <param name="sender">Источник события.</param>
        /// <param name="args">Аргументы события.</param>
        private void OnMenuItemSetDefaultVector_Click(object sender, RoutedEventArgs args)
        {
            if (_propertyItem != null)
            {
                for (var i = 0; i < _propertyItem.PropertyDescriptor.Attributes.Count; i++)
                {
                    var attr = _propertyItem.PropertyDescriptor.Attributes[i];
                    if (attr is LotusDefaultValueAttribute def_value)
                    {
                        var value = def_value.DefaultValue;

                        // Если все правильно
                        if (value != null && value.GetType() == _propertyItem.PropertyType)
                        {
                            // Конвертируем
                            Value = (Vector3D)VectorConverter.Convert(value, _propertyItem.PropertyType,
                                _propertyItem.PropertyType, CultureInfo.CurrentUICulture);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Очистка вектора.
        /// </summary>
        /// <param name="sender">Источник события.</param>
        /// <param name="args">Аргументы события.</param>
        private void OnMenuItemClearVector_Click(object sender, RoutedEventArgs args)
        {
            spinnerX.Value = 0;
            spinnerY.Value = 0;
            spinnerZ.Value = 0;
        }
        #endregion
    }
    /**@}*/
}