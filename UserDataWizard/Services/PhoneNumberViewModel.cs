using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserDataWizard.ViewModels
{
    public class PhoneNumberViewModel : AbstractWizardViewModel
    {
        public override int Id => 4;

        public override string PageTitle => "Phone Number";

        private string phoneNumber;

        public string PhoneNumber
        {
            get => phoneNumber;
            set
            {
                phoneNumber = value;
                OnPropertyChanged(nameof(PhoneNumber));
                UserDataService.ChangePhoneNumber(phoneNumber);
            }
        }
    }
}
