using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using System.Windows.Media;
using DomainModel.Interfaces;
using DomainModel.Model;
using DomainModel.Repositories.Dummy;
using DomainModel.Repositories;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;

namespace Kwisspel.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private IQuizRepository quizRepository;

        private QuizViewModel _selectedQuiz;
        public QuizViewModel SelectedQuiz
        {
            get { return _selectedQuiz; }
            set
            {
                _selectedQuiz = value;
                RaisePropertyChanged("SelectedCategory");
            }
        }

        public ObservableCollection<QuizViewModel> Quizzes { get; set; }

        public ICommand AddQuiz { get; set; }
        public ICommand UpdateQuiz { get; set; }
        public ICommand ManageQuiz { get; set; }
        public ICommand PlayQuiz { get; set; }
        public ICommand DeleteQuizz { get; set; }

        public MainViewModel(IQuizRepository repository)
        {
            quizRepository = repository;
            var quizList = quizRepository.GetAll().Select(quiz => new QuizViewModel(quiz)).ToList();

            Quizzes = new ObservableCollection<QuizViewModel>(quizList);
            InitializeNewSelectedQuiz();

            AddQuiz = new RelayCommand(AddNewQuiz);
            UpdateQuiz = new RelayCommand(UpdateSelectedQuizName);
            ManageQuiz = new RelayCommand(ManageSelectedQuiz);
        }

        // Voegt nog niet toe aan repository
        public void AddNewQuiz()
        {
            QuizViewModel quizViewModel = new QuizViewModel();

            if (SelectedQuiz.QuizName != null)
            {
                if (!SelectedQuiz.QuizName.Trim().Equals(""))
                {
                    quizViewModel.QuizId = SelectedQuiz.QuizId;
                    quizViewModel.QuizName = SelectedQuiz.QuizName;
                    Quizzes.Add(quizViewModel);
                    InitializeNewSelectedQuiz();
                }
            }
        }

        // Update nog niet in repository
        public void UpdateSelectedQuizName()
        {
            _selectedQuiz.QuizName = SelectedQuiz.QuizName;
        }

        private void ManageSelectedQuiz()
        {
            QuizAdminWindow quizAdminWindow = new QuizAdminWindow();
            quizAdminWindow.Show();
        }

        private void InitializeNewSelectedQuiz()
        {
            SelectedQuiz = new QuizViewModel();
            SelectedQuiz.QuizId = Quizzes.Count+1;
        }
    }
}