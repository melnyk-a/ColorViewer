using ColorViewer.ViewModels;
using System.Windows;

namespace ColorViewer.Views
{
    /// <summary>
    /// Interaction logic for MainWindowView.xaml
    /// </summary>
    internal sealed partial class MainWindowView : Window
    {
        public MainWindowView(MainWindowViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}