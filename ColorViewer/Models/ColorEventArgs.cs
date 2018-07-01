using System;

namespace ColorViewer.Models
{
    internal sealed class ColorEventArgs : EventArgs
    {
        private readonly Color color;

        public ColorEventArgs(Color color)
        {
            this.color = color;

        }

        public Color Color => color;
    }
}