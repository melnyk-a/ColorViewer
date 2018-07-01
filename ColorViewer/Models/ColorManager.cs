using System;
using System.Collections.Generic;

namespace ColorViewer.Models
{
    internal sealed class ColorManager : IColorManager
    {
        private ICollection<Color> colors = new List<Color>();

        public IEnumerable<Color> Colors => colors;

        public event EventHandler<ColorEventArgs> ColorAdded;
        public event EventHandler<ColorEventArgs> ColorDeleted;

        public void AddColor(Color color)
        {
            colors.Add(color);
            OnColorAdded(new ColorEventArgs(color));
        }

        public bool Contains(string colorName)
        {
            bool isContain = false;
            foreach (var color in colors)
            {
                if (color.ToString().Equals(colorName))
                {
                    isContain = true;
                    break;
                }
            }
            return isContain;
        }

        public void DeleteColor(Color color)
        {
            if (colors.Remove(color))
            {
                OnColorDeleted(new ColorEventArgs(color));
            }
        }

        public void OnColorAdded(ColorEventArgs e)
        {
            ColorAdded?.Invoke(this, e);
        }

        public void OnColorDeleted(ColorEventArgs e)
        {
            ColorDeleted?.Invoke(this, e);
        }
    }
}