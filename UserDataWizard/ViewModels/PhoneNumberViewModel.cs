using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserDataWizard.ViewModels
{
    public class PhoneNumberViewModel : BaseViewModel
    {
        public override int Id
        {
            get { return 4; }
        }

        public override string PageTitle
        {
            get { return "Numer telefonu"; }
        }

        private string phoneNumber;

        public string PhoneNumber
        {
            get { return phoneNumber; }
            set
            {
                phoneNumber = value;
                OnPropertyChanged(nameof(PhoneNumber));
                UserDataService.ChangePhoneNumber(phoneNumber);
            }
        }

        public override bool IsTextBoxFilledCorrectly()
        {
            if (string.IsNullOrEmpty(phoneNumber))
            {
                Error = "Numer telefonu jest wymagany!";
                return false;
            }

            return true;
        }
    }
}
