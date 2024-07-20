using Microsoft.Xaml.Behaviors.Core;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WorkOut.MVVM.Models;

namespace WorkOut.MVVM.ViewModels
{
    public class AddNewViewModel
    {
        public string Exercise { get; set; }

        public ObservableCollection<Exercise> Exercises { get; set; }

        public ObservableCollection<Category> Categories { get; set; }

        public ICommand ExerciseAddBtnCmd => new ActionCommand(AddExerciseMethod);
        public ICommand ExerciseCateforyBtnCmd => new ActionCommand(CategoryExerciseMethod);

        private async void CategoryExerciseMethod()
        {
            var categoryTitle = await Application.Current.MainPage.DisplayPromptAsync("Add New Category","Category Name",maxLength:100);
            this.Categories.Add(new Category { Id = this.Categories.Max(x => x.Id) + 1, Title = categoryTitle });
            //throw new NotImplementedException();
        }

        public void AddExerciseMethod()
        {
            var selected = this.Categories.Where(x=> x.IsSelected == true).FirstOrDefault();
            if (selected != null)
            {
                var exercise = new Exercise
                {
                    Name = this.Exercise,
                    CategoryId = selected.Id
                };

                this.Exercises.Add(exercise);
                Application.Current.MainPage.Navigation.PopAsync();

            }
            else
            {
                Application.Current.MainPage.DisplayAlert("Category Null", "Choose Category", "OK");
            }

        }




    }
}
