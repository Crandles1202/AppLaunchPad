using Microsoft.Extensions.Logging;

namespace AppLaunchPad.Services
{
    public interface IMeals
    {
        public void printOutInt();
    }

    public class Meals : IMeals
    {
        private readonly ILogger<Meals> _logger;

        public Meals(ILogger<Meals> logger)
        {
            _logger = logger;
        }

        public void printOutInt()
        {
            Console.WriteLine("This worked");
        }
    }
}
