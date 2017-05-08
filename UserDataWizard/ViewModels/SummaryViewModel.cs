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

        private string firstName;
        private string secondName;
        private string address;
        private string phoneNumber;

        public string FirstName
        {
            get
            {
                firstName = UserDataService.GetFirstName();
                return firstName;
            }
        }
        public string SecondName
        {
            get
            {
                secondName = UserDataService.GetSecondName();
                return secondName;
            }
        }
        public string Address
        {
            get
            {
                address = UserDataService.GetAddress();
                return address;
            }
        }
        public string PhoneNumber
        {
            get
            {
                phoneNumber = UserDataService.GetPhoneNumber();
                return phoneNumber;
            }
        }

        public override string Validate()
        {
            return "";
        }
    }
}
