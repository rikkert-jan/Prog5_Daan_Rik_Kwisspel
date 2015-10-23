using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using DomainModel.Interfaces;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;

namespace Kwisspel.ViewModel.ViewModelContainers
{
    public class MainViewModel : ViewModelBase
    {
        private IQuizRepository _quizRepository;

        private QuizViewModel _selectedQuiz;
        public QuizViewModel SelectedQuiz
        {
            get { return _selectedQuiz; }
            set
            {
                _selectedQuiz = value;
                RaisePropertyChanged("SelectedQuiz");
            }
        }

        public ObservableCollection<QuizViewModel> Quizzes { get; set; }

        public ICommand AddQuiz { get; set; }
        public ICommand UpdateQuiz { get; set; }
        public ICommand ManageQuiz { get; set; }
        public ICommand PlayQuiz { get; set; }
        public ICommand DeleteQuiz { get; set; }
        public ICommand ClearQuiz { get; set; }

        public MainViewModel(IQuizRepository repository)
        {
            _quizRepository = repository;
            var quizList = _quizRepository.GetAll().Select(quiz => new QuizViewModel(quiz)).ToList();

            Quizzes = new ObservableCollection<QuizViewModel>(quizList);

            AddQuiz = new RelayCommand(AddNewQuiz);
            UpdateQuiz = new RelayCommand(UpdateSelectedQuizName);
            ManageQuiz = new RelayCommand(ManageSelectedQuiz);
            ClearQuiz = new RelayCommand(ClearSelectedQuiz);

            SelectedQuiz = Quizzes.First();
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
                    SelectedQuiz = quizViewModel;
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

        private void ClearSelectedQuiz()
        {
            SelectedQuiz = new QuizViewModel();
            SelectedQuiz.QuizName = "";
            SelectedQuiz.QuizId = Quizzes.Count+1;
        }
    }
}