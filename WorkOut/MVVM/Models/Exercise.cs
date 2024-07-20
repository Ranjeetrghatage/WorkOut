using Prism.Mvvm;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkOut.MVVM.Models
{
    [AddINotifyPropertyChangedInterface]
    public class Exercise 
    {
        public string  Name { get; set; }   
        public int CategoryId { get; set; }
        public bool IsCompleted { get; set; }

    }
}
