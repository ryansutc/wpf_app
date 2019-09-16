using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for UserControl.xaml
    /// </summary>
    public partial class TestView : UserControl
    {
        private BackgroundWorker backgroundWorker = new BackgroundWorker();
        public TestView()
        {
            InitializeComponent();
            backgroundWorker.WorkerReportsProgress = true;
            backgroundWorker.ProgressChanged += MyProgressChanged;
            backgroundWorker.DoWork += DoWork;
            // not required
            backgroundWorker.RunWorkerCompleted += BackgroundWorker_RunWorkerCompleted;
        }
        
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            backgroundWorker.RunWorkerAsync();
        }

        private void MyProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            // this is called on the UI thread:
            progressBar.Value = e.ProgressPercentage;
        }

        private void BackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // this is called on the UI thread when the DoWork method completes
            // so it's a good place to hide busy indicators
            MessageBox.Show("Work was complete");
        }

        private void DoWork(object sender, DoWorkEventArgs e)
        {
            for (int i = 0; i <= 100; i++)
            {
                // Simulate long running work
                Thread.Sleep(100);
                backgroundWorker.ReportProgress(i);
            }
        }
    }
}
