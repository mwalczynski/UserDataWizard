using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserDataWizard.ViewModels
{
    public class FirstNameViewModel : BaseViewModel
    {
        public override int Id
        {
            get { return 1; }
        }

        public override string PageTitle
        {
            get { return "Imię"; }
        }

        private string firstName;

        public string FirstName
        {
            get { return firstName; }
            set
            {
                firstName = value;
                OnPropertyChanged(nameof(FirstName));
                UserDataService.ChangeFirstName(firstName);
            }
        }

        public override bool IsTextBoxFilledCorrectly()
        {
            Error = "";
            if (string.IsNullOrEmpty(firstName))
            {
                Error = "Imię jest wymagane!";
                return false;
            }

            return true;
        }
    }
}
