using System.Windows.Media;

namespace Lotus.Windows
{
    /**
     * \defgroup WindowsWPFExtension Методы расширения
     * \ingroup WindowsWPF
     * \brief Методы расширения.
     * @{
     */
    /// <summary>
    /// Статический класс реализующий методы расширения для типа <see cref="Color"/>.
    /// </summary>
    public static class XWindowsColorExtension
    {
        /// <summary>
        /// Сериализация цветового значения в строку.
        /// </summary>
        /// <param name="color">Цветовое значение.</param>
        /// <returns>Строка.</returns>
        public static string SerializeToString(this Color color)
        {
            return string.Format("{0},{1},{2},{3}", color.R, color.G, color.B, color.A);
        }

        /// <summary>
        /// Десереализация цветового значения из строки.
        /// </summary>
        /// <param name="data">Строка данных.</param>
        /// <returns>Цветовое значение.</returns>
        public static Color DeserializeFromString(string data)
        {
            var color = new Color();
            var color_data = data.Split(',');
            color.R = byte.Parse(color_data[0]);
            color.G = byte.Parse(color_data[1]);
            color.B = byte.Parse(color_data[2]);
            color.A = byte.Parse(color_data[3]);
            return color;
        }
    }
    /**@}*/
}