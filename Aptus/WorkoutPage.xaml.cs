using Aptus.Models;
using Xamarin;
using Aptus.Data;
using System.Threading.Tasks;
using SQLite;

namespace Aptus
{
    public partial class WorkoutPage : ContentPage
    {
        private SQLiteAsyncConnection _connection;
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
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center,
                Margin = new Thickness(0, 0, 0, 10)
            };

            // Create a "DELETE" button
            Button deleteButton = new Button
            {
                Text = "DELETE",
                TextColor = White,
                BackgroundColor = Color.FromHex("#AA364B51"),
                FontSize = 5,
                HorizontalOptions = LayoutOptions.Start,
                HeightRequest = 30
            };


            // Add Clicked event to the button
            deleteButton.Clicked += DeleteButton_Clicked;

            // Add the labels and button to the exerciseStackLayout
            exerciseStackLayout.Children.Add(muscleGroupLabel);
            exerciseStackLayout.Children.Add(exerciseLabel);
            exerciseStackLayout.Children.Add(deleteButton);

            // Add the exerciseStackLayout to the main ExerciseStackLayout
            ExerciseStackLayout.Children.Add(exerciseStackLayout);
        }

        void DeleteButton_Clicked(object sender, EventArgs e)
        {
            var button = (Button)sender;
            var exerciseStackLayout = (StackLayout)button.Parent;
            ExerciseStackLayout.Children.Remove(exerciseStackLayout);
        }

    }
}
