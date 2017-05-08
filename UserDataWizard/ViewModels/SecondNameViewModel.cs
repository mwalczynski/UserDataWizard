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
            get
            {
                secondName = UserDataService.GetSecondName();
                return secondName;
            }
            set
            {
                secondName = value;
                OnPropertyChanged(nameof(SecondName));
                UserDataService.ChangeSecondName(secondName);
            }
        }
        public override string Validate()
        {
            var validationMessage = "";

            if (string.IsNullOrEmpty(secondName))
            {
                validationMessage = "Nazwisko jest wymagane!\n";
            }
            else if (!ValidationMethods.StartWithCapitalLetters(secondName))
            {
                validationMessage = "Nazwisko musi zaczynać się od wielkiej litery!\n";
            }
            else if (ValidationMethods.ContainsNumber(secondName))
            {
                validationMessage = "Nazwisko nie może zawierać cyfr!\n";
            }
            else if (ValidationMethods.ContainsSpecialCharacters(secondName))
            {
                validationMessage = "Nazwisko nie może zawierać znaków specjalnych!\n";
            }
            else if (secondName.Length > 20)
            {
                validationMessage = "Nazwisko musi zawierać maksymalnie 20 znaków!\n";
            }

            return validationMessage;
        }
    }
}
