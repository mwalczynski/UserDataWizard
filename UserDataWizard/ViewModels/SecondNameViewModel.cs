using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using UserDataWizard.Annotations;

namespace UserDataWizard.ViewModels
{
    public class SecondNameViewModel : BaseViewModel
    {
        public override int Id
        {
            get { return 2; }
        }

        public override string PageTitle
        {
            get { return "Nazwisko"; }
        }

        private string secondName;

        public string SecondName
        {
            get { return secondName; }
            set
            {
                secondName = value;
                OnPropertyChanged(nameof(SecondName));
                UserDataService.ChangeSecondName(secondName);
            }
        }
        public override string Validate()
        {
            string validationMessage = "";
            if (string.IsNullOrEmpty(secondName))
            {
                validationMessage = "Nazwisko jest wymagane!";
            }

            return validationMessage;
        }
    }
}
