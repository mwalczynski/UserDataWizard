using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserDataWizard.Models;

namespace UserDataWizard.ViewModels
{
    public class SummaryViewModel : BaseViewModel
    {
        public override int Id
        {
            get { return 5; }
        }

        public override string PageTitle
        {
            get { return "Podsumowanie"; }
        }

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

        public override bool IsTextBoxFilledCorrectly()
        {
            return true;
        }
    }
}
