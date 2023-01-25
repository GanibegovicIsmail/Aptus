using Aptus.Models;
using SQLite;
using Aptus.Data;

namespace Aptus
{
    public partial class EditExercisePage : ContentPage
    {
        Exercise exercise;
        public EditExercisePage(Exercise exercise)
        {
            InitializeComponent();
            this.exercise = exercise;
            BindingContext = exercise;
        }

        private void SaveChangesButton_Clicked(object sender, EventArgs e)
        {
            // code to update the exercise object with the new values
            exercise.Name = ExerciseNameEntry.Text;
            exercise.Sets = Convert.ToInt32(SetsEntry.Text);
            exercise.Reps = Convert.ToInt32(RepsEntry.Text);
            exercise.Weight = Convert.ToDouble(WeightEntry.Text);
            exercise.MuscleGroup = MuscleGroupEntry.Text;

            // code to update the exercise in the database goes here

            // navigate back to the previous page
            Navigation.PopAsync();
        }
    }
}
