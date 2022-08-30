using AppLaunchPad.Models;
using Microsoft.Extensions.Logging;
using System.Data.SqlClient;

namespace AppLaunchPad.Services
{
    public interface IMeals
    {
        public MealsModel GetMeals();
    }

    public class Meals : IMeals
    {
        private readonly ILogger<Meals> _logger;

        public Meals(ILogger<Meals> logger)
        {
            _logger = logger;
        }

        public MealsModel GetMeals()
        {
            var connectionString = "Server=tcp:chuckslaunchpadserver.database.windows.net,1433;Initial Catalog=LaunchPadDB;Persist Security Info=False;User ID=crandles;Password=Valerie55!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            var queryString = "Select * From MealIdeas";
            var Meal = new MealsModel();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Create the Command and Parameter objects.
                SqlCommand command = new SqlCommand(queryString, connection);
                //command.Parameters.AddWithValue("@pricePoint", paramValue);

               
                // Open the connection in a try/catch block.
                // Create and execute the DataReader, writing the result
                // set to the console window.
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        //Console.WriteLine("\t{0}\t{1}\t{2}\t{3}\t{4}\t{5}",
                        //    reader[0], reader[1], reader[2], reader[3], reader[4], reader[5]);
                        Meal.mealsID =            (int)reader[0];
                        Meal.mealsDescription =   (string)reader[1];
                        Meal.mealsProtien =       (string)reader[2];
                        Meal.mealsCarb =          (string)reader[3];
                        Meal.mealsVeggie =        (string)reader[4];
                        Meal.mealsFat =           (string)reader[5];
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }                
            }
            return Meal;
        }
    }
}
