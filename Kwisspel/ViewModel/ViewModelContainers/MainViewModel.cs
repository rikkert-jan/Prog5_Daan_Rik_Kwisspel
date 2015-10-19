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
                RaisePropertyChanged("SelectedQuiz");
            }
        }

        public ObservableCollection<QuizViewModel> Quizzes { get; set; }

        public ICommand AddQuiz { get; set; }
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
        }

        // Voegt nog niet toe aan repository
        public void AddNewQuiz()
        {
            if (SelectedQuiz.QuizName != null)
            {
                if (!SelectedQuiz.QuizName.Trim().Equals(""))
                {
                    _selectedQuiz.QuizId = SelectedQuiz.QuizId;
                    _selectedQuiz.QuizName = SelectedQuiz.QuizName;
                    Quizzes.Add(_selectedQuiz);
                    InitializeNewSelectedQuiz();
                }
            }
        }

        private void InitializeNewSelectedQuiz()
        {
            SelectedQuiz = new QuizViewModel();
            SelectedQuiz.QuizId = Quizzes.Count+1;
        }
    }
}