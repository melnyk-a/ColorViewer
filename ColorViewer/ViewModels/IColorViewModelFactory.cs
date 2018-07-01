using ColorViewer.Models;

namespace ColorViewer.ViewModels
{
    internal interface IColorViewModelFactory
    {
        ColorViewModel CreateUserViewModel(Color color);
    }
}