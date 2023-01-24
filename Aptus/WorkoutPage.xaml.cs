using Aptus.Models;
using Xamarin;
using Aptus.Data;
using System.Threading.Tasks;




namespace Aptus
{
    public partial class WorkoutPage : ContentPage
    {
        public WorkoutPage()
        {
            InitializeComponent();
        }

        private async void AddExerciseButton_Clicked(object sender, EventArgs e)
        {
            Color White = Color.FromRgb(255, 255, 255);
            Color Black = Color.FromRgb(0, 0, 0);
            string exerciseName = ExerciseNameEntry.Text;
            int sets = Convert.ToInt32(SetsEntry.Text);
            int reps = Convert.ToInt32(RepsEntry.Text);
            double weight = Convert.ToDouble(WeightEntry.Text);
            string muscleGroup = MuscleGroupEntry.Text;

            // Create a new exercise object
            Exercise exercise = new Exercise
            {
                Name = exerciseName,
                Sets = sets,
                Reps = reps,
                Weight = weight,
                MuscleGroup = muscleGroup
            };

            // Code to update the UI with the new exercise goes here

            // Create a new StackLayout to hold the exercise details and buttons
            StackLayout exerciseStackLayout = new StackLayout
            {
                Orientation = StackOrientation.Vertical,
                Margin = new Thickness(0, 0, 0, 10)
            };

            // Create a label to display the exercise details
            Label exerciseLabel = new Label
            {
                Text = $"{exercise.Name} - {exercise.Sets} sets of {exercise.Reps} reps at {exercise.Weight} kg",
                TextColor = White,
                VerticalOptions = LayoutOptions.Center,
                Margin = new Thickness(0, 0, 0, 0)
            };

            // Create a label to display the muscle group
            Label muscleGroupLabel = new Label
            {
                Text = exercise.MuscleGroup,
                TextColor = White,
                FontAttributes = FontAttributes.Bold,
                FontSize = 15,
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center,
                Margin = new Thickness(20, 0, 0, 20)
            };

            // Add the exerciseLabel, muscleGroupLabel and buttons to the exerciseStackLayout
            exerciseStackLayout.Children.Add(muscleGroupLabel);
            exerciseStackLayout.Children.Add(exerciseLabel);


            // Add the exerciseStackLayout to the ExerciseStackLayout
            ExerciseStackLayout.Children.Add(exerciseStackLayout);

            // Clear the Entry fields
            ExerciseNameEntry.Text = "";
            SetsEntry.Text = "";
            RepsEntry.Text = "";
            WeightEntry.Text = "";
            MuscleGroupEntry.Text = "";

        }
    }
}
