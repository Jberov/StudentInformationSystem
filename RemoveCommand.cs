using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfExample
{
    public class RemoveCommand
    {

        public bool CanExecute(object parameter)
        {
            var nameList = parameter as NamesList;
            return nameList != null && nameList.SelectedName != null;
        }
        public void Execute(object parameter)
        {
            var nameList = parameter as NamesList;
            var oldName = nameList.SelectedName;
            nameList.Names.Remove(oldName);
        }
    }
}
