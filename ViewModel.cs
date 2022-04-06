using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace EasyMVVM
{
    public class ViewModel : DependencyObject, INotifyPropertyChanged
    {
        public ViewModel()
        {
            Model m = new Model();
            BoundProperty = m.GetData();
        }

        private ObservableCollection<string> _BackingProperty;

        public ObservableCollection<string> BoundProperty
        {
            get { return _BackingProperty; }
            set { _BackingProperty = value; PropChanged("BoundProperty"); }
        }

        //This event will be fired to notify any listeners of a change in a property value.
        public event PropertyChangedEventHandler PropertyChanged;
        //Tell WPF Binding that this property value has changed
        public void PropChanged(String propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
