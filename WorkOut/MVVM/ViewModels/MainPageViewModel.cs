using Microsoft.Xaml.Behaviors.Core;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WorkOut.MVVM.Models;
using WorkOut.MVVM.Views;

namespace WorkOut.MVVM.ViewModels
{
    public class MainPageViewModel
    {
        public ObservableCollection<Category> Categories { get; set; }
        public ObservableCollection<Exercise> Exercises { get; set; }

        public MainPageViewModel() 
        {
            LoadData();
            Calculation();
        }


        public ICommand NewExecerciseBtnCmd => new ActionCommand(NewExercisePageMethod);

        private void NewExercisePageMethod()
        {
            var model = new AddNew 
            {
                BindingContext = new AddNewViewModel { Exercises = this.Exercises, Categories = this.Categories }
            };
            Application.Current.MainPage.Navigation.PushAsync(model);
        }

        public void Calculation()
        {
            foreach (var category in Categories)
            {
                var ExerciseByCategory = Exercises.Where(x => x.CategoryId == category.Id).ToList();

                var pending = ExerciseByCategory.Where(x=> x.IsCompleted == false).ToList();
                category.PendingExercises = pending.Count();

                var CompletedExercises = ExerciseByCategory.Where(x=> x.IsCompleted == true).ToList();
                category.Percentage =(float)CompletedExercises.Count()/(float)ExerciseByCategory.Count();   
            }
        }
        private void LoadData()
        {
            Categories = new ObservableCollection<Category>() { 
            new Category{Id = 1, Title = "Abs" },
            new Category{Id = 2, Title = "Love Handle" },
            new Category{Id = 3, Title = "Glutes" },
            new Category{Id = 4, Title = "Hamstring" },
            new Category{Id = 5, Title = "Biceps" },
            new Category{Id = 6, Title = "Triceps" },
            new Category{Id = 7, Title = "Chest" },
            new Category{Id = 8, Title = "Cardio" },
            new Category{Id = 9, Title = "HIIT" },

            };

            Exercises = new ObservableCollection<Exercise>() 
            { 
             new Exercise{Name="Plank",CategoryId=1, IsCompleted = true},
             new Exercise{Name="Moutain Climber",CategoryId=1, IsCompleted = false},
             new Exercise{Name="Side Bend",CategoryId=2, IsCompleted = false},
             new Exercise{Name="Waist Rotate",CategoryId=2, IsCompleted = false},
             new Exercise{Name="Bridge",CategoryId=3, IsCompleted = false},
             new Exercise{Name="Feet Raise",CategoryId=4, IsCompleted = false},
             new Exercise{Name="Pushups",CategoryId=5, IsCompleted = false},


             new Exercise{Name="Plank Tap",CategoryId=5, IsCompleted = false},
             new Exercise{Name="Tri Dips",CategoryId=6, IsCompleted = false},
             new Exercise{Name="T-rotation",CategoryId=7, IsCompleted = false},
             new Exercise{Name="Running",CategoryId=8, IsCompleted = false},


             new Exercise{Name="Burpees",CategoryId=9, IsCompleted = false},


            };

            //throw new NotImplementedException();
        }
    }
}
