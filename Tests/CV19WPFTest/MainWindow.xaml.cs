using System;
using System.Threading;
using System.Windows;

namespace CV19WPFTest
{
    public partial class MainWindow 
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void StartButton_Click(object sender, RoutedEventArgs E)
        {
            new Thread(ComputeValue).Start();
        }

        private void ComputeValue()
        {
            var value = LongProcess(DateTime.Now);
            if (ResultBlock.Dispatcher.CheckAccess())
                ResultBlock.Text = value;
            else
                ResultBlock.Dispatcher.Invoke(() => ResultBlock.Text = value);
            //ResultBlock.Dispatcher.BeginInvoke(new Action(() => ResultBlock.Text = value));
        }

        private static string LongProcess(DateTime Time)
        {
            Thread.Sleep(3000);

            return $"Value {Time}";
        }
    }
}
