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

        public QuizViewModel Quiz { get; set; }

        public ObservableCollection<QuizViewModel>  Quizzes { get; set; }

        public ICommand AddQuiz { get; set; }
        public ICommand ManageQuiz { get; set; }
        public ICommand PlayQuiz { get; set; }
        public ICommand DeleteQuizz { get; set; }

        public MainViewModel()
        {
            //quizRepository = repository;
            quizRepository = new DummyQuizRepository();
            var quizList = quizRepository.GetAll().ToList().Select(quiz => new QuizViewModel(quiz));

            Quiz = new QuizViewModel();
            Quizzes = new ObservableCollection<QuizViewModel>(quizList);
        }
    }
}