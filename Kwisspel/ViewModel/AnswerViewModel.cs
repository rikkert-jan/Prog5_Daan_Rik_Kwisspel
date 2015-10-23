using System.ComponentModel;
using System.Runtime.CompilerServices;
using DomainModel.Model;
using GalaSoft.MvvmLight.Ioc;
using Kwisspel.Annotations;

namespace Kwisspel.ViewModel
{
    public class AnswerViewModel
    {
        private Answer _answer;
        private bool _isCorrect;

        public int AnswerId
        {
            get { return _answer.AnswerId; }
            set
            {
                _answer.AnswerId = value;
                OnPropertyChanged("AnswerId");
            }
        }

        public string AnswerText
        {
            get { return _answer.AnswerText; }
            set
            {
                _answer.AnswerText = value;
                OnPropertyChanged("AnswerText");
            }
        }

        public bool IsCorrect
        {
            get { return _isCorrect; }
            set
            {
                _isCorrect = value;
                OnPropertyChanged("IsCorrect");
            }
        }

        public AnswerViewModel()
        {
            _answer = new Answer();
        }

        [PreferredConstructor]
        public AnswerViewModel(Answer answer)
        {
            _answer = answer;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
