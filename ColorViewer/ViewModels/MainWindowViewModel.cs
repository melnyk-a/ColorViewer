using ColorViewer.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace ColorViewer.ViewModels
{
    internal sealed class MainWindowViewModel : INotifyPropertyChanged
    {
        private readonly DelegeteCommand addCommand;
        private readonly IColorManager colorManager;
        private readonly ICollection<KeyValuePair<string, ColorViewModel>> colors = new ObservableCollection<KeyValuePair<string, ColorViewModel>>();
        private readonly IColorViewModelFactory viewModelFactory;
        private Color currentColor;

        public MainWindowViewModel(IColorManager colorManager, IColorViewModelFactory viewModelFactory)
        {
            this.viewModelFactory = viewModelFactory;
            this.colorManager = colorManager;

            addCommand = new DelegeteCommand(AddColor, NotContain);

            currentColor = new Color(255, 0, 0, 0);

            PropertyChanged += (sender, e) =>
              {
                  if (e.PropertyName.Equals(nameof(Alpha)) ||
                      e.PropertyName.Equals(nameof(Red)) ||
                      e.PropertyName.Equals(nameof(Green)) ||
                      e.PropertyName.Equals(nameof(Blue)))
                  {
                      OnPropertyChanged(new PropertyChangedEventArgs(nameof(ColorName)));
                      addCommand.RaiseCanExevuteChanged();
                  }
              };

            colorManager.ColorAdded += (sender, e) =>
              {
                  colors.Add(new KeyValuePair<string, ColorViewModel>
                      (e.Color.ToString(), viewModelFactory.CreateUserViewModel((e.Color))));
                  addCommand.RaiseCanExevuteChanged();
              };

            colorManager.ColorDeleted += (sender, e) =>
            {
                foreach (var color in colors)
                {
                    if (color.Key.Equals(e.Color.ToString()))
                    {
                        colors.Remove(color);
                        break;
                    }
                }
            };
        }

        public ICommand AddCommand => addCommand;

        public byte Alpha
        {
            get => currentColor.Alpha;
            set
            {
                if (currentColor.Alpha != value)
                {
                    currentColor.Alpha = value;
                    OnPropertyChanged(new PropertyChangedEventArgs(nameof(Alpha)));
                }
            }
        }

        public byte Blue
        {
            get => currentColor.Blue;
            set
            {
                if (currentColor.Blue != value)
                {
                    currentColor.Blue = value;
                    OnPropertyChanged(new PropertyChangedEventArgs(nameof(Blue)));
                }
            }
        }

        public string ColorName
        {
            get => currentColor.ToString();
        }

        public IEnumerable<KeyValuePair<string, ColorViewModel>> Colors => colors;

        public byte Green
        {
            get => currentColor.Green;
            set
            {
                if (currentColor.Green != value)
                {
                    currentColor.Green = value;
                    OnPropertyChanged(new PropertyChangedEventArgs(nameof(Green)));
                }
            }
        }

        public byte Red
        {
            get => currentColor.Red;
            set
            {
                if (currentColor.Red != value)
                {
                    currentColor.Red = value;
                    OnPropertyChanged(new PropertyChangedEventArgs(nameof(Red)));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void AddColor()
        {
            colorManager.AddColor((Color)currentColor.Clone());
        }

        private bool NotContain()
        {
            return !colorManager.Contains(currentColor.ToString());
        }

        private void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            PropertyChanged?.Invoke(this, e);
        }

        private void SetProperty<T>(ref T oldValue, T newValue, [CallerMemberName] string propertyName = null)
        {
            if (!oldValue?.Equals(newValue) ?? newValue != null)
            {
                oldValue = newValue;
                OnPropertyChanged(new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}