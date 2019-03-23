using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CodeCamp.NewFeatures.Models
{
    public abstract class Vehicle : INotifyPropertyChanged
    {
        private string _name;
        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }

        private string _manufacturer;
        public string Manufacturer
        {
            get => _manufacturer;
            set => SetProperty(ref _manufacturer, value);
        }

        public Vehicle(string name, string manufacturer) => (_name, _manufacturer) = (name, manufacturer);



        public event PropertyChangedEventHandler PropertyChanged;

        public abstract void Go();


        private bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string? propertyName = null)
        {
            if (Equals(storage, value))
                return false;
            storage = value;
            //System.Diagnostics.Debug.WriteLine($"Setting Property: ${this}:${propertyName} => {value}");
            OnPropertyChanged(propertyName);
            return true;
        }

        protected virtual void OnPropertyChanged(string? propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName ?? ""));
        }
    }
}