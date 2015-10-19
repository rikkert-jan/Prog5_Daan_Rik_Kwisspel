using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using DomainModel.Model;
using GalaSoft.MvvmLight.Ioc;
using Kwisspel.Annotations;

namespace Kwisspel.ViewModel
{
    public class QuizViewModel : INotifyPropertyChanged
    {
        private Quiz _quiz;
        private int _numOfQuestions;

        public int QuizId
        {
            get { return _quiz.QuizId; }
            set
            {
                _quiz.QuizId = value;
                OnPropertyChanged("QuizId");
            }
        }

        public string QuizName
        {
            get { return _quiz.QuizName; }
            set
            {
                _quiz.QuizName = value;
                OnPropertyChanged("QuizName");
            }
        }

        public int NumOfQuestions
        {
            get { return (_quiz.Questions != null) ? _quiz.Questions.Count : 0; }
            set
            {
                _numOfQuestions = value;
            }
        }

        public QuizViewModel()
        {
            _quiz = new Quiz();
        }

        [PreferredConstructor]
        public QuizViewModel(Quiz quiz)
        {
            _quiz = quiz;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
