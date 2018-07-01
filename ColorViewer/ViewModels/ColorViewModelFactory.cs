using ColorViewer.Models;

namespace ColorViewer.ViewModels
{
    internal sealed class ColorViewModelFactory : IColorViewModelFactory
    {
        private readonly IColorManager colorManager;

        public ColorViewModelFactory(IColorManager colorManager)
        {
            this.colorManager = colorManager;
        }

        public ColorViewModel CreateUserViewModel(Color color)
        {
            return new ColorViewModel(color, colorManager);
        }
    }
}