using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserDataWizard.ViewModels
{
    public class FirstNameViewModel : AbstractWizardViewModel
    {
        public override int Id => 1;
        public override string PageTitle => "First Name";

        private string firstName;

        public string FirstName
        {
            get => firstName;
            set
            {
                firstName = value;
                OnPropertyChanged(nameof(FirstName));
                UserDataService.ChangeFirstName(firstName);
            }
        }

    }
}
