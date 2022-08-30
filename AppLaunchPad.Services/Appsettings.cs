using Microsoft.Extensions.Configuration;

namespace AppLaunchPad.Services
{
    public class Appsettings
    {
        public Appsettings(IConfiguration config) => config.Bind(this);
    }
}
