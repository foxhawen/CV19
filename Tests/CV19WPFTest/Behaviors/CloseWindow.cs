using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Microsoft.Xaml.Behaviors;

namespace CV19WPFTest.Behaviors
{
    class CloseWindow : Behavior<Button>
    {
        protected override void OnAttached() => AssociatedObject.Click += OnButtonClick;
        

        protected override void OnDetaching() => AssociatedObject.Click -= OnButtonClick;


        private void OnButtonClick(object sender, RoutedEventArgs E)
        {
            var button = AssociatedObject;

            var window = FintVisualRoot(button) as Window;
            window?.Close();
        }

        private static DependencyObject FintVisualRoot(DependencyObject obj)
        {
            do
            {
                var parent = VisualTreeHelper.GetParent(obj);
                if (parent is null) return obj;
                obj = parent;
            } 
            while (true);
        }
    }
}
