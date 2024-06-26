using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Lotus.Windows
{
    /** \addtogroup WindowsWPFControlsSpecial
	*@{*/
    /// <summary>
    /// Элемент для выбора цвета.
    /// </summary>
    public partial class LotusColorPicker : UserControl
    {
        #region Declare DependencyProperty 
        /// <summary>
        /// Свойство цвет.
        /// </summary>
        public static readonly DependencyProperty ColorProperty = DependencyProperty.Register(nameof(Color),
            typeof(Color), typeof(LotusColorPicker),
            new FrameworkPropertyMetadata(Colors.Black, new PropertyChangedCallback(OnColorChanged)));

        /// <summary>
        /// Красная компонента цвета.
        /// </summary>
        public static readonly DependencyProperty RedProperty = DependencyProperty.Register(nameof(Red),
            typeof(byte), typeof(LotusColorPicker),
            new FrameworkPropertyMetadata(new PropertyChangedCallback(OnColorRGBChanged)));

        /// <summary>
        /// Зеленая компонента цвета.
        /// </summary>
        public static readonly DependencyProperty GreenProperty = DependencyProperty.Register(nameof(Green),
            typeof(byte), typeof(LotusColorPicker),
            new FrameworkPropertyMetadata(new PropertyChangedCallback(OnColorRGBChanged)));

        /// <summary>
        /// Синия компонента цвета.
        /// </summary>
        public static readonly DependencyProperty BlueProperty = DependencyProperty.Register(nameof(Blue),
            typeof(byte), typeof(LotusColorPicker),
            new FrameworkPropertyMetadata(new PropertyChangedCallback(OnColorRGBChanged)));

        /// <summary>
        /// Событие изменения цвета.
        /// </summary>
        public static readonly RoutedEvent ColorChangedEvent = EventManager.RegisterRoutedEvent(nameof(ColorChanged),
            RoutingStrategy.Bubble, typeof(RoutedPropertyChangedEventHandler<Color>), typeof(LotusColorPicker));
        #endregion

        #region DependencyProperty methods
        /// <summary>
        /// Обработчик события изменения цвета.
        /// </summary>
        /// <param name="sender">Источник события.</param>
        /// <param name="args">Аргументы события.</param>
        private static void OnColorChanged(DependencyObject sender, DependencyPropertyChangedEventArgs args)
        {
            var new_сolor = (Color)args.NewValue;
            var color_picker = (LotusColorPicker)sender;
            color_picker.Red = new_сolor.R;
            color_picker.Green = new_сolor.G;
            color_picker.Blue = new_сolor.B;
        }

        /// <summary>
        /// Обработчик события изменения компонентов цвета.
        /// </summary>
        /// <param name="sender">Источник события.</param>
        /// <param name="args">Аргументы события.</param>
        private static void OnColorRGBChanged(DependencyObject sender, DependencyPropertyChangedEventArgs args)
        {
            var color_picker = (LotusColorPicker)sender;
            var color = color_picker.Color;
            if (args.Property == RedProperty)
                color.R = (byte)args.NewValue;
            else if (args.Property == GreenProperty)
                color.G = (byte)args.NewValue;
            else if (args.Property == BlueProperty)
                color.B = (byte)args.NewValue;

            color_picker.Color = color;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Цвет.
        /// </summary>
        public Color Color
        {
            get { return (Color)GetValue(ColorProperty); }
            set { SetValue(ColorProperty, value); }
        }

        /// <summary>
        /// Красная компонента цвета.
        /// </summary>
        public byte Red
        {
            get { return (byte)GetValue(RedProperty); }
            set { SetValue(RedProperty, value); }
        }

        /// <summary>
        /// Зеленая компонента цвета.
        /// </summary>
        public byte Green
        {
            get { return (byte)GetValue(GreenProperty); }
            set { SetValue(GreenProperty, value); }
        }

        /// <summary>
        /// Синия компонента цвета.
        /// </summary>
        public byte Blue
        {
            get { return (byte)GetValue(BlueProperty); }
            set { SetValue(BlueProperty, value); }
        }

        /// <summary>
        /// Событие изменения цвета.
        /// </summary>
        public event RoutedPropertyChangedEventHandler<Color> ColorChanged
        {
            add { AddHandler(ColorChangedEvent, value); }
            remove { RemoveHandler(ColorChangedEvent, value); }
        }
        #endregion

        #region Constructors
        /// <summary>
        /// Конструктор по умолчанию инициализирует объект класса предустановленными значениями.
        /// </summary>
        public LotusColorPicker()
        {
            InitializeComponent();
        }
        #endregion
    }
    /**@}*/
}