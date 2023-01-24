using System;

namespace Aptus
{
    public partial class WorkoutPage : ContentPage
    {
        public WorkoutPage()
        {
            InitializeComponent();
        }

        private void AddExerciseButton_Clicked(object sender, EventArgs e)
        {
            // Get the values entered by the user
            string exerciseName = ExerciseNameEntry.Text;
            int sets = Convert.ToInt32(SetsEntry.Text);
            int reps = Convert.ToInt32(RepsEntry.Text);
            double weight = Convert.ToDouble(WeightEntry.Text);

            // Create a new exercise object
            Exercise exercise = new Exercise
            {
                Name = exerciseName,
                Sets = sets,
                Reps = reps,
                Weight = weight
            };

            // Create a new label to display the exercise details
            Label exerciseLabel = new Label
            {
                Text = $"{exercise.Name} - {exercise.Sets} sets of {exercise.Reps} reps at {exercise.Weight} kg",
                
            };

            // Add the label to the ExerciseStackLayout
            ExerciseStackLayout.Children.Add(exerciseLabel);

            // Clear the entries
            ExerciseNameEntry.Text = "";
            SetsEntry.Text = "";
            RepsEntry.Text = "";
            WeightEntry.Text = "";
        }
    }

    public class Exercise
    {
        public string Name { get; set; }
        public int Sets { get; set; }
        public int Reps { get; set; }
        public double Weight { get; set; }
    }

    private void OnDeleteExerciseButtonClicked(object sender, EventArgs e)
    {
        // Get the button that was clicked
        var button = (Button)sender;

        // Get the parent stack layout of the button (the one that contains the exercise name and delete button)
        var exerciseStackLayout = (StackLayout)button.Parent;

        // Remove the exercise stack layout from the exercise stack layout
        ExerciseStackLayout.Children.Remove(exerciseStackLayout);
    }
}
