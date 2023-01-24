using Aptus.Models;
using Xamarin;

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
            Color White = Color.FromRgb(255, 255, 255);
            Color Blue = Color.FromRgb(0, 0, 0);
            // Get the values entered by the user
            string exerciseName = ExerciseNameEntry.Text;
            int sets = Convert.ToInt32(SetsEntry.Text);
            int reps = Convert.ToInt32(RepsEntry.Text);
            double weight = Convert.ToDouble(WeightEntry.Text);
            string muscleGroup = BodyPartEntry.Text;

            // Create a new exercise object
            Exercise exercise = new Exercise
            {
                Name = exerciseName,
                Sets = sets,
                Reps = reps,
                Weight = weight,
                MuscleGroup = muscleGroup
            };

            // Create a new StackLayout to hold the exercise details and buttons
            StackLayout exerciseStackLayout = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                Margin = new Thickness(0, 0, 0, 20)
            };

            // Create a label to display the exercise details
            Label exerciseLabel = new Label
            {
                Text = $"{exercise.Name} - {exercise.Sets} sets of {exercise.Reps} reps at {exercise.Weight} kg",
                TextColor = White,
                VerticalOptions = LayoutOptions.Center
            };

            // Create a label to display the muscle group
            Label muscleGroupLabel = new Label
            {
                Text = exercise.MuscleGroup,
                TextColor = White,
                VerticalOptions = LayoutOptions.Center,
                Margin = new Thickness(10, 0, 0, 0)
            };

            // Create a delete button
            Button deleteButton = new Button
            {
                Text = "Delete",
                TextColor = White,
                BackgroundColor = Blue,
                WidthRequest = 80,
                HeightRequest = 30,
                VerticalOptions = LayoutOptions.Center
            };

            // Create an edit button
            Button editButton = new Button
            {
                Text = "Edit",
                TextColor = White,
                BackgroundColor = Blue,
                WidthRequest = 80,
                HeightRequest = 30,
                VerticalOptions = LayoutOptions.Center
            };

            // Add the exercise details and buttons to the exerciseStackLayout
            exerciseStackLayout.Children.Add(exerciseLabel);
            exerciseStackLayout.Children.Add(muscleGroupLabel);
            exerciseStackLayout.Children.Add(deleteButton);
            exerciseStackLayout.Children.Add(editButton);

            // Add the exerciseStackLayout to the ExerciseStackLayout
            ExerciseStackLayout.Children.Add(exerciseStackLayout);

            // Clear the Entry fields
            ExerciseNameEntry.Text = "";
            SetsEntry.Text = "";
            RepsEntry.Text = "";
            WeightEntry.Text = "";
            BodyPartEntry.Text = "";
        }
    }
}

