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
    public class EditQuizViewModel : ViewModelBase
    {
        private IQuestionRepository questionRepository;

        private QuestionViewModel _selectedQuestion;
        public QuestionViewModel SelectedQuestion
        {
            get { return _selectedQuestion; }
            set
            {
                _selectedQuestion = value;
                RaisePropertyChanged("SelectedQuestion");
            }
        }

        public ObservableCollection<QuestionViewModel> Questions { get; set; }

        public ICommand AddQuestion { get; set; }
        public ICommand UpdateQuestion { get; set; }
        public ICommand DeleteQuestion { get; set; }

        public EditQuizViewModel(IQuestionRepository repository)
        {
            questionRepository = repository;
            var questionList = questionRepository.GetAll().Select(question => new QuestionViewModel(question)).ToList();

            Questions = new ObservableCollection<QuestionViewModel>(questionList);
            InitializeNewSelectedQuestion();

            AddQuestion = new RelayCommand(AddNewQuestion);
            UpdateQuestion = new RelayCommand(UpdateSelectedQuestionzName);
        }

        // Voegt nog niet toe aan repository
        public void AddNewQuestion()
        {
            if (SelectedQuestion.QuestionText != null)
            {
                if (!SelectedQuestion.QuestionText.Trim().Equals(""))
                {
                    _selectedQuestion.QuestionId = SelectedQuestion.QuestionId;
                    _selectedQuestion.QuestionText = SelectedQuestion.QuestionText;
                    Questions.Add(_selectedQuestion);
                    InitializeNewSelectedQuestion();
                }
            }
        }

        // Update nog niet in repository
        public void UpdateSelectedQuestionzName()
        {
            _selectedQuestion.QuestionText = SelectedQuestion.QuestionText;
        }

        private void InitializeNewSelectedQuestion()
        {
            SelectedQuestion = new QuestionViewModel();
            SelectedQuestion.QuestionId = Questions.Count + 1;
        }
    }
}
