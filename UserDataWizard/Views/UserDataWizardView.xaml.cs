using System.Windows.Controls;
using UserDataWizard.ViewModels;

namespace UserDataWizard.Views
{
    /// <summary>
    /// Interaction logic for UserDataWizardView.xaml
    /// </summary>
    public partial class UserDataWizardView : UserControl
    {
        private readonly WizardViewModel wizardViewModel;

        public UserDataWizardView()
        {
            InitializeComponent();

            wizardViewModel = new WizardViewModel();
            base.DataContext = wizardViewModel;
        }
    }
}
