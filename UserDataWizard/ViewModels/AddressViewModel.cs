using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserDataWizard.ViewModels
{
    public class AddressViewModel : BaseViewModel
    {
        public override int Id
        {
            get { return 3; }
        }

        public override string PageTitle
        {
            get { return "Adres"; }
        }

        private string address;

        public string Address
        {
            get
            {
                address = UserDataService.GetAddress();
                return address;
            }
            set
            {
                address = value;
                OnPropertyChanged(nameof(Address));
                UserDataService.ChangeAddress(address);
            }
        }
        public override string Validate()
        {
            string validationMessage = "";
            if (string.IsNullOrEmpty(address))
            {
                validationMessage = "Adres jest wymagany!";
            }
            else if (address.Length < 3)
            {
                validationMessage = "Adres jest za krótki!";
            }

            return validationMessage;
        }
    }
}
