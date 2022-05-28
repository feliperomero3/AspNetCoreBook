using Microsoft.AspNetCore.Mvc;

namespace SportsStore.ViewComponents
{
    public class NavigationMenuViewComponent : ViewComponent
    {
        public string Invoke()
        {
            return "Hello from the Navigation View Component.";
        }
    }
}
