using System;
using System.Collections.Generic;

namespace ColorViewer.Models
{
    internal interface IColorManager
    {
        IEnumerable<Color> Colors { get; }

        event EventHandler<ColorEventArgs> ColorAdded;
        event EventHandler<ColorEventArgs> ColorDeleted;

        void AddColor(Color color);
        void DeleteColor(Color color);

        bool Contains(string colorName);
    }
}