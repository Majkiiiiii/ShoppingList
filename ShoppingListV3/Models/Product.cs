using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace ShoppingListV3.Models
{
    public class Product : INotifyPropertyChanged
    {
        private string name;
        private int quantity;
        private string unit;
        private bool isBought;
        private string category;

        public string Name
        {
            get => name;
            set
            {
                if (name != value)
                {
                    name = value;
                    OnPropertyChanged(nameof(Name));
                }
            }
        }

        public int Quantity
        {
            get => quantity;
            set
            {
                if (quantity != value)
                {
                    quantity = value;
                    OnPropertyChanged(nameof(Quantity));
                }
            }
        }

        public string Unit
        {
            get => unit;
            set
            {
                if (unit != value)
                {
                    unit = value;
                    OnPropertyChanged(nameof(Unit));
                }
            }
        }

        public bool IsBought
        {
            get => isBought;
            set
            {
                if (isBought != value)
                {
                    isBought = value;
                    OnPropertyChanged(nameof(IsBought));
                }
            }
        }
        public string Category
        {
            get => category;
            set
            {
                if (category != value)
                {
                    category = value;
                    OnPropertyChanged(nameof(Category));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
