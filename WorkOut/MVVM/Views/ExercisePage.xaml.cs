using WorkOut.MVVM.ViewModels;

namespace WorkOut.MVVM.Views;

public partial class ExercisePage : ContentPage
{
	MainPageViewModel vm = new MainPageViewModel();	
	public ExercisePage()
	{
		InitializeComponent();
		BindingContext = vm;
	}

    private void CheckBox_CheckedChanged(object sender, CheckedChangedEventArgs e)
    {
		vm.Calculation();
    }
}