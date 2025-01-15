using System;

namespace FreeView.ViewModels
{
    public class DataContextPropertyChangedEventArgs : EventArgs
    {
        public DataContextPropertyChangedEventArgs(string propertyName, object value)
        {
            PropertyName = propertyName;
            Value = value;
        }
        public string PropertyName { get; set; }
        public object Value { get; set; }
    }
}