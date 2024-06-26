using System;
using System.Windows;
using System.Windows.Media.Animation;

namespace Lotus.Windows
{

    /**
     * \defgroup WindowsWPF Подсистема работы с WPF
     * \ingroup Windows
     * \brief Подсистема работы с WPF содержит код с WPF и сопутствующей инфраструктуры.
     * \defgroup WindowsWPFCommon Общая подсистема
     * \ingroup WindowsWPF
     * \brief Общая подсистема.
     * @{
     */
    /// <summary>
    /// Статический класс для упрощения работы с анимацией.
    /// </summary>
    public static class XAnimationHelper
    {
        /// <summary>
        /// Запускает анимацию вещественного типа определенного значения на свойства зависимостей.
        /// </summary>
        /// <param name="animatable_element">Элемент.</param>
        /// <param name="dependency_property">Свойство зависимости.</param>
        /// <param name="to_value">Целевое значение.</param>
        /// <param name="animation_duration">Продолжительность в секундах.</param>
        public static void StartAnimation(UIElement animatable_element, DependencyProperty dependency_property, double to_value,
            double animation_duration)
        {
            StartAnimation(animatable_element, dependency_property, to_value, animation_duration, null);
        }

        /// <summary>
        /// Запускает анимацию вещественного типа определенного значения на свойства зависимостей.
        /// Вы можете передать в обработчик событий для вызова, когда анимация завершена.
        /// </summary>
        /// <param name="animatable_element">Элемент.</param>
        /// <param name="dependency_property">Свойство зависимости.</param>
        /// <param name="to_value">Целевое значение.</param>
        /// <param name="animation_duration">Продолжительность в секундах.</param>
        /// <param name="completed_handler">Обработчик события окончания анимации.</param>
        public static void StartAnimation(UIElement animatable_element, DependencyProperty dependency_property, double to_value,
            double animation_duration, EventHandler? completed_handler)
        {
            var fromValue = (double)animatable_element.GetValue(dependency_property);

            var animation = new DoubleAnimation();
            animation.From = fromValue;
            animation.To = to_value;
            animation.Duration = TimeSpan.FromSeconds(animation_duration);

            animation.Completed += delegate (object? sender, EventArgs args)
            {
                //
                // When the animation has completed bake final value of the animation
                // into the property.
                //
                animatable_element.SetValue(dependency_property, animatable_element.GetValue(dependency_property));
                CancelAnimation(animatable_element, dependency_property);

                completed_handler?.Invoke(sender, args);
            };

            animation.Freeze();
            animatable_element.BeginAnimation(dependency_property, animation);
        }

        /// <summary>
        /// Отмена любых анимации, которые работают на свойства зависимостей.
        /// </summary>
        /// <param name="animatable_element">Элемент.</param>
        /// <param name="dependency_property">Свойство зависимости.</param>
        public static void CancelAnimation(UIElement animatable_element, DependencyProperty dependency_property)
        {
            animatable_element.BeginAnimation(dependency_property, null);
        }
    }
    /**@}*/
}