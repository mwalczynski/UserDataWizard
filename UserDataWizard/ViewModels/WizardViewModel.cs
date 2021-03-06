﻿using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using GalaSoft.MvvmLight.CommandWpf;
using UserDataWizard.Annotations;
using Prism.Commands;
using UserDataWizard.Service;

namespace UserDataWizard.ViewModels
{
    public class WizardViewModel : INotifyPropertyChanged
    {
        private readonly UserDataService userDataService = new UserDataService();

        private readonly int summaryId;

        private ReadOnlyCollection<BaseViewModel> steps;
        private BaseViewModel currentStep;

        public ICommand MovePrevoiusCommand { get; }
        public ICommand MoveNextCommand { get; }
        public ICommand FinishCommand { get; }
        public ICommand ChangeDataCommand { get; }

        public WizardViewModel()
        {
            CurrentStep = Steps.First(s => s.Id == 1);
            MovePrevoiusCommand = new RelayCommand(MovePrevoius, CanMovePrevoius);
            MoveNextCommand = new RelayCommand(MoveNext, CanMoveNext);
            FinishCommand = new RelayCommand(Finish, CanFinish);
            ChangeDataCommand = new RelayCommand(ChangeData, CanChangeData);

            summaryId = Steps.Max(s => s.Id);
        }

        private void MovePrevoius()
        {
            var currentStepId = CurrentStep.Id;
            var prevoiusStepId = currentStepId - 1;

            CurrentStep = Steps.First(s => s.Id == prevoiusStepId);
        }

        private bool CanMovePrevoius()
        {
            return !(IsFirstStep() || IsSummary());
        }

        private void MoveNext()
        {
            var currentStepId = CurrentStep.Id;
            var nextStepId = currentStepId + 1;

            CurrentStep = Steps.First(s => s.Id == nextStepId);
        }

        private bool CanMoveNext()
        {
            return !(IsLastStep() || IsSummary() || !IsStepValid());
        }

        private void Finish()
        {
            CurrentStep = Steps.First(s => s.Id == summaryId);
        }

        private bool CanFinish()
        {
            for (int i = 1; i < summaryId; i++)
            {
                var step = steps.First(s => i == s.Id);
                if (!step.IsValid())
                {
                    return false;
                }
            }
            return !IsSummary();
        }

        private void ChangeData()
        {
            userDataService.LoadNewData();
            CurrentStep = Steps.First(s => s.Id == 1);
        }

        private bool CanChangeData()
        {
            return IsSummary();
        }

        public ReadOnlyCollection<BaseViewModel> Steps
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
            var stepsList = new List<BaseViewModel>();
            stepsList.Add(new FirstNameViewModel());
            stepsList.Add(new SecondNameViewModel());
            stepsList.Add(new AddressViewModel());
            stepsList.Add(new PhoneNumberViewModel());
            stepsList.Add(new SummaryViewModel());

            steps = new ReadOnlyCollection<BaseViewModel>(stepsList);
        }

        public BaseViewModel CurrentStep
        {
            get { return currentStep; }
            set
            {
                if (value == currentStep)
                    return;

                if (currentStep != null)
                    currentStep.IsCurrentPage = false;

                currentStep = value;

                if (currentStep != null)
                    currentStep.IsCurrentPage = true;

                OnPropertyChanged(nameof(CurrentStep));
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
            return CurrentStep.Id == summaryId;
        }

        private bool IsStepValid()
        {
            return currentStep.IsValid();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
