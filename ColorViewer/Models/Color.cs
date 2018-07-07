using System;

namespace ColorViewer.Models
{
    internal struct Color : ICloneable
    {
        // color[0] - alpha.
        // color[1] - red.
        // color[2] - green.
        // color[3] - blue.
        private readonly byte[] color;

        public Color(byte alpha, byte red, byte green, byte blue) : this()
        {
            color = new byte[4] { alpha, red, green, blue };
        }

        public byte Alpha
        {
            get => color[0];
            set => SetProperty(ref color[0], value);
        }

        public byte Blue
        {
            get => color[3];
            set => SetProperty(ref color[3], value);
        }

        public byte Green
        {
            get => color[2];
            set => SetProperty(ref color[2], value);
        }

        public byte Red
        {
            get => color[1];
            set => SetProperty(ref color[1], value);
        }

        public object Clone()
        {
            return new Color(color[0], color[1], color[2], color[3]);
        }

        private void SetProperty<T>(ref T oldValue, T newValue)
        {
            if (!oldValue?.Equals(newValue) ?? newValue != null)
            {
                oldValue = newValue;
            }
        }

        public override string ToString()
        {
            return $"#{ BitConverter.ToString(color).Replace("-", string.Empty)}";
        } 
    }
}