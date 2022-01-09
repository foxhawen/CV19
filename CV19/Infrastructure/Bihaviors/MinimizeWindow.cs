using System.Windows;
using System.Windows.Controls;
using Microsoft.Xaml.Behaviors;

namespace CV19.Infrastructure.Bihaviors
{
    class MinimizeWindow : Behavior<Button>
    {
        protected override void OnAttached() => AssociatedObject.Click += OnButtonClick;

        protected override void OnDetaching() => AssociatedObject.Click -= OnButtonClick;

        private void OnButtonClick(object sender, RoutedEventArgs E)
        {
            if (!(AssociatedObject.FintVisualRoot() is Window window)) return;

            window.WindowState = WindowState.Minimized;
        }
    }
}