using Microsoft.AspNetCore.Components;

namespace Svendeprøve_projekt_BodyFitBlazor.Codes
{
    public class NavigationClass
    {
        public void ReloadPage(NavigationManager manager, string uri)
        {
            manager.NavigateTo(uri, true);
        }
    }
}
