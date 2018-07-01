using ColorViewer.Models;
using ColorViewer.ViewModels;
using ColorViewer.Views;
using Ninject;
using System;
using System.Windows;

namespace ColorViewer
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    internal sealed partial class App : Application
    {
        private readonly Lazy<IKernel> container;

        public App()
        {
            container = new Lazy<IKernel>(CreateContainer);
        }

        private IKernel CreateContainer()
        {
            var container = new StandardKernel();
            container.Bind<IColorManager>().To<ColorManager>().InSingletonScope();
            container.Bind<IColorViewModelFactory>().To<ColorViewModelFactory>().InSingletonScope();
            return container;
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var view = container.Value.Get<MainWindowView>();
            view.Show();
        }
    }
}