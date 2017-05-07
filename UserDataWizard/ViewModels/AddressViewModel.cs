using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserDataWizard.ViewModels
{
    public class AddressViewModel : AbstractWizardViewModel
    {
        public override int Id => 3;

        public override string PageTitle => "Address";

        private string address;

        public string Address
        {
            get
            {
                return address;
            }
            set
            {
                address = value;
                OnPropertyChanged(nameof(Address));
                UserDataService.ChangeAddress(address);
            }
        }
    }
}
