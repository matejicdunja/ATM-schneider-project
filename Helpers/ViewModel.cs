using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM.Helpers
{
    public class ViewModel
    {
        protected static NavigationService _navigationService;

        public static void InitializeNavigationService(NavigationService navigationService)
        {
            _navigationService = navigationService;
        }
    }
}
