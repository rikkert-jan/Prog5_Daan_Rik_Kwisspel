using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using DomainModel.Interfaces;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace Kwisspel.ViewModel.ViewModelContainers
{
    public class EditQuestionViewModel : ViewModelBase
    {
        private IAnswerRepository _repository;

        private AnswerViewModel _selectedAnswer;
        public AnswerViewModel SelectedAnswer
        {
            get { return _selectedAnswer; }
            set
            {
                _selectedAnswer = value;
                RaisePropertyChanged("SelectedCategory");
            }
        }

        public ObservableCollection<AnswerViewModel> Answers { get; set; }

        public ICommand AddAnswer { get; set; }
        public ICommand UpdateAnswer { get; set; }
        public ICommand DeleteAnswer { get; set; }

        public EditQuestionViewModel(IAnswerRepository repository)
        {
            this._repository = repository;
            var answerList = this._repository.GetAll().Select(answer => new AnswerViewModel(answer)).ToList();

            Answers = new ObservableCollection<AnswerViewModel>(answerList);
            InitializeNewSelectedAnswer();

            AddAnswer = new RelayCommand(AddNewAnswer);
            UpdateAnswer = new RelayCommand(UpdateSelectedAnswerName);
        }

        public void AddNewAnswer()
        {
            AnswerViewModel answerViewModel = new AnswerViewModel();
            if (SelectedAnswer.AnswerText != null)
            {
                if (!SelectedAnswer.AnswerText.Trim().Equals(""))
                {
                    answerViewModel.AnswerId = SelectedAnswer.AnswerId;
                    answerViewModel.AnswerText = SelectedAnswer.AnswerText;
                    answerViewModel.IsCorrect = SelectedAnswer.IsCorrect;
                    Answers.Add(answerViewModel);
                    InitializeNewSelectedAnswer();
                }
            }
        }

        public void UpdateSelectedAnswerName()
        {
            _selectedAnswer.AnswerText = SelectedAnswer.AnswerText;
            _selectedAnswer.IsCorrect = SelectedAnswer.IsCorrect;
        }

        private void InitializeNewSelectedAnswer()
        {
            SelectedAnswer = new AnswerViewModel();
            SelectedAnswer.AnswerId = Answers.Count + 1;
        }

    }
}
