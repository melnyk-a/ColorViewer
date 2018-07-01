using ColorViewer.Models;
using System.Windows.Input;

namespace ColorViewer.ViewModels
{
    internal sealed class ColorViewModel
    {
        private readonly Color color;
        private readonly IColorManager colorManager;
        private readonly ICommand deleteCommand;
        
        public ColorViewModel(Color color, IColorManager colorManager)
        {
            this.color = color;
            this.colorManager = colorManager;

            deleteCommand = new DelegeteCommand(Delete);
        }

        public string ColorHexName => color.ToString();

        public ICommand DeleteCommand => deleteCommand;

        public void Delete()
        {
            colorManager.DeleteColor(color);
        }
    }
}