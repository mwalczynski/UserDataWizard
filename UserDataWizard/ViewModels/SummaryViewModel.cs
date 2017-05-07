using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserDataWizard.Models;

namespace UserDataWizard.ViewModels
{
    class SummaryViewModel : AbstractWizardViewModel
    {
        public override int Id => 5;

        public override string PageTitle => "Summary";

        private UserDataModel userData;

        public UserDataModel UserData
        {
            get
            {
                if (userData == null)
                {
                    userData = UserDataService.GetUserData();
                }
                return userData;
            }
        }
    }
}
