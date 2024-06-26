using System;
using System.Windows;

using Lotus.Core;

namespace Lotus.Windows
{
    /** \addtogroup WindowsWPFExtension
	*@{*/
    /// <summary>
    /// Статический класс реализующий методы расширения для типа <see cref="Vector"/>.
    /// </summary>
    public static class XWindowsVectorExtension
    {
        /// <summary>
        /// Сериализация вектора в строку.
        /// </summary>
        /// <param name="vector">Двухмерный вектор.</param>
        /// <returns>Строка данных.</returns>
        public static string SerializeToString(this Vector vector)
        {
            return string.Format("{0};{1}", vector.X, vector.Y);
        }

        /// <summary>
        /// Десереализация двухмерного вектора из строки.
        /// </summary>
        /// <param name="data">Строка данных.</param>
        /// <returns>Двухмерный вектор.</returns>
        public static Vector DeserializeFromString(string data)
        {
            var vector = new Vector();
            var vector_data = data.Split(';');
            vector.X = XNumberHelper.ParseDouble(vector_data[0]);
            vector.Y = XNumberHelper.ParseDouble(vector_data[1]);
            return vector;
        }

        /// <summary>
        /// Аппроксимация равенства двухмерных векторов.
        /// </summary>
        /// <param name="vector">Первое значение.</param>
        /// <param name="other">Второе значение.</param>
        /// <param name="epsilon">Погрешность.</param>
        /// <returns>Статус равенства значений.</returns>
        public static bool Approximately(this Vector vector, Vector other, double epsilon)
        {
            if ((Math.Abs(vector.X - other.X) < epsilon) && (Math.Abs(vector.Y - other.Y) < epsilon))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Аппроксимация равенства двухмерных векторов.
        /// </summary>
        /// <param name="vector">Первое значение.</param>
        /// <param name="other">Второе значение.</param>
        /// <returns>Статус равенства значений.</returns>
        public static bool Approximately(this Vector vector, Vector other)
        {
            if ((Math.Abs(vector.X - other.X) < 0.001) && (Math.Abs(vector.Y - other.Y) < 0.001))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Преобразование в вектор Maths.Vector2D.
        /// </summary>
        /// <param name="vector">Вектор.</param>
        /// <returns>Вектор.</returns>
        public static Maths.Vector2D ToVector2D(this Vector vector)
        {
            return new Maths.Vector2D(vector.X, vector.Y);
        }

        /// <summary>
        /// Преобразование в вектор Maths.Vector2Df.
        /// </summary>
        /// <param name="vector">Вектор.</param>
        /// <returns>Вектор.</returns>
        public static Maths.Vector2Df ToVector2Df(this Vector vector)
        {
            return new Maths.Vector2Df((float)vector.X, (float)vector.Y);
        }
    }
    /**@}*/
}