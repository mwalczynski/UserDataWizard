using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using GalaSoft.MvvmLight.CommandWpf;
using UserDataWizard.Annotations;
using Prism.Commands;

namespace UserDataWizard.ViewModels
{
    class WizardViewModel : INotifyPropertyChanged
    {
        private ReadOnlyCollection<AbstractWizardViewModel> steps;
        private AbstractWizardViewModel currentStep;

        public ICommand MovePrevoiusCommand { get; }
        public ICommand MoveNextCommand { get; }
        public ICommand FinishCommand { get; }

        private ICommand cancelCommand;



        public WizardViewModel()
        {
            CurrentStep = Steps.First(s => s.Id == 1);
            MovePrevoiusCommand = new RelayCommand(MovePrevoius, CanMovePrevoius);
            MoveNextCommand = new RelayCommand(MoveNext, CanMoveNext);
            FinishCommand = new RelayCommand(Finish, CanFinish);
        }

        private void MovePrevoius()
        {
            var currentStepId = CurrentStep.Id;
            var prevoiusStepId = currentStepId - 1;

            CurrentStep = Steps.First(s => s.Id == prevoiusStepId);
        }

        private bool CanMovePrevoius()
        {
            return !IsFirstStep() && !IsSummary();
        }

        private void MoveNext()
        {
            var currentStepId = CurrentStep.Id;
            var nextStepId = currentStepId + 1;

            CurrentStep = Steps.First(s => s.Id == nextStepId);
        }

        private bool CanMoveNext()
        {
            return !IsLastStep() && !IsSummary();
        }

        private void Finish()
        {
            CurrentStep = Steps.First(s => s.Id == 5);
        }

        private bool CanFinish()
        {
            return true && !IsSummary();
        }

        public ReadOnlyCollection<AbstractWizardViewModel> Steps
        {
            get
            {
                if (steps == null)
                    LoadSteps();

                return steps;
            }
        }

        private void LoadSteps()
        {
            var stepsList = new List<AbstractWizardViewModel>();
            stepsList.Add(new FirstNameViewModel());
            stepsList.Add(new SecondNameViewModel());
            stepsList.Add(new AddressViewModel());
            stepsList.Add(new PhoneNumberViewModel());
            stepsList.Add(new SummaryViewModel());

            steps = new ReadOnlyCollection<AbstractWizardViewModel>(stepsList);
        }

        public AbstractWizardViewModel CurrentStep
        {
            get => currentStep;
            private set
            {
                if (value == currentStep)
                    return;

                if (currentStep != null)
                    currentStep.IsCurrentPage = false;

                currentStep = value;

                if (currentStep != null)
                    currentStep.IsCurrentPage = true;

                this.OnPropertyChanged(nameof(CurrentStep));
            }
        }

        private bool IsFirstStep()
        {
            return CurrentStep.Id == 1;
        }

        private bool IsLastStep()
        {
            return CurrentStep.Id == 4;
        }

        private bool IsSummary()
        {
            return CurrentStep.Id == 5;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
