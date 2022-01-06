using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using Microsoft.Xaml.Behaviors;

namespace CV19WPFTest.Behaviors
{
    public class DragInCanvas : Behavior<UIElement>
    {
        private Point _StartPoint;
        private Canvas _Сanvas;

        protected override void OnAttached()
        {
            AssociatedObject.MouseLeftButtonDown += OnButtonDown;
            AssociatedObject.MouseMove -= OnMouseNove;
            AssociatedObject.MouseUp -= OnMousUp;
        }

        protected override void OnDetaching()
        {
            AssociatedObject.MouseLeftButtonDown -= OnButtonDown;
        }

        private void OnButtonDown(object sender, MouseButtonEventArgs E)
        {
            //if (_Сanvas is null)
            //{
            //    _Сanvas = VisualTreeHelper.GetParent(AssociatedObject) as Canvas;
            //    if(_Сanvas is null) return;
            //}

            //var canvas = _Canvas ??= VisualTreeHelper.GetParent(AssociatedObject) as Canvas;
            //          ==
            //var canvas = _Canvas ?? (_Canvas = VisualTreeHelper.GetParent(AssociatedObject) as Canvas);

            if ((_Сanvas ??= VisualTreeHelper.GetParent(AssociatedObject) as Canvas) is null)
                return;

            _StartPoint = E.GetPosition(AssociatedObject);
            AssociatedObject.CaptureMouse();
            AssociatedObject.MouseMove += OnMouseNove;
            AssociatedObject.MouseUp += OnMousUp;
        }

        private void OnMousUp(object sender, MouseButtonEventArgs e)
        {
            AssociatedObject.MouseMove -= OnMouseNove;
            AssociatedObject.MouseUp -= OnMousUp;
            AssociatedObject.ReleaseMouseCapture();
        }

        private void OnMouseNove(object sender, MouseEventArgs E)
        {
            var obj = AssociatedObject;
            var current_pos = E.GetPosition(_Сanvas);

            var delta = current_pos - _StartPoint;

            obj.SetValue(Canvas.LeftProperty, delta.X);
            obj.SetValue(Canvas.TopProperty, delta.Y);
        }
    }
}
