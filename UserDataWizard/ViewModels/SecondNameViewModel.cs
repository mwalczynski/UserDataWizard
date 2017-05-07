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
    public class SecondNameViewModel : AbstractWizardViewModel
    {
        public override int Id => 2;

        public override string PageTitle => "Second Name";

        private string secondName;

        public string SecondName
        {
            get => secondName;
            set
            {
                secondName = value;
                OnPropertyChanged(nameof(SecondName));
                UserDataService.ChangeSecondName(secondName);
            }
        }
    }
}
