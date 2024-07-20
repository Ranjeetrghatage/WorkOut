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
    public class Category 
    {
       public int Id { get; set; }
       public string Title { get; set; }
       public int PendingExercises { get; set; }
       public float Percentage { get; set; }

        public bool IsSelected { get; set; }    

    }
}
