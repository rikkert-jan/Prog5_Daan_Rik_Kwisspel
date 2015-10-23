using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using DomainModel.Interfaces;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace Kwisspel.ViewModel.ViewModelContainers
{
    public class EditQuizViewModel : ViewModelBase
    {
        private IQuestionRepository questionRepository;
        private ICategoryRepository categoryRepository;

        private GetCategoryViewModel getCategoryViewModel;

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
        public ICommand ManageQuestion { get; set; }
        public ICommand DeleteQuestion { get; set; }
        public  ICommand ClearQuestion { get; set; }

        public EditQuizViewModel(IQuestionRepository questionRepository, ICategoryRepository categoryRepository, GetCategoryViewModel getCategoryViewModel)
        {
            this.questionRepository = questionRepository;
            var questionList = this.questionRepository.GetAll().Select(question => new QuestionViewModel(question)).ToList();

            this.categoryRepository = categoryRepository;

            Questions = new ObservableCollection<QuestionViewModel>(questionList);

            this.getCategoryViewModel = getCategoryViewModel;

            AddQuestion = new RelayCommand(AddNewQuestion);
            UpdateQuestion = new RelayCommand(UpdateSelectedQuestionzName);
            ManageQuestion = new RelayCommand(ManageSelectedQuestion);
            ClearQuestion = new RelayCommand(ClearSelectedQuestion);

            SelectedQuestion = Questions.First();
        }

        public void AddNewQuestion()
        {
            QuestionViewModel questionViewModel = new QuestionViewModel();
            if (SelectedQuestion.QuestionText != null)
            {
                if (!SelectedQuestion.QuestionText.Trim().Equals(""))
                {
                    questionViewModel.QuestionId = SelectedQuestion.QuestionId;
                    questionViewModel.QuestionText = SelectedQuestion.QuestionText;
                    questionViewModel.Category = categoryRepository.Get(getCategoryViewModel.SelectedCategory);
                    Questions.Add(questionViewModel);
                    SelectedQuestion = questionViewModel;
                }
            }
        }

        public void UpdateSelectedQuestionzName()
        {
            _selectedQuestion.QuestionText = SelectedQuestion.QuestionText;
            _selectedQuestion.Category = categoryRepository.Get(getCategoryViewModel.SelectedCategory);
        }

        private void ClearSelectedQuestion()
        {
            SelectedQuestion = new QuestionViewModel();
            SelectedQuestion.QuestionId = Questions.Count + 1;
        }

        private void ManageSelectedQuestion()
        {
            QuestionAdminWindow questionAdminWindow = new QuestionAdminWindow();
            questionAdminWindow.Show();
        }
    }
}
