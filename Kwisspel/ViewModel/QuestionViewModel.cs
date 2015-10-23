﻿using System.ComponentModel;
using System.Runtime.CompilerServices;
using DomainModel.Model;
using GalaSoft.MvvmLight.Ioc;
using Kwisspel.Annotations;

namespace Kwisspel.ViewModel
{
    public class QuestionViewModel
    {
        private Question _question;
        private int _numOfAnswers;

        public int QuestionId
        {
            get { return _question.QuestionId; }
            set
            {
                _question.QuestionId = value;
                OnPropertyChanged("QuestionId");
            }
        }

        public string QuestionText
        {
            get { return _question.Questiontext; }
            set
            {
                _question.Questiontext = value;
                OnPropertyChanged("Questiontext");
            }
        }

        public Category Category
        {
            get { return _question.Category; }
            set
            {
                _question.Category = value;
                OnPropertyChanged("Category");
            }
        }

        public int NumOfAnswers
        {
            get { return (_question.Answers != null) ? _question.Answers.Count : 0; }
            set
            {
                _numOfAnswers = value;
            }
        }

        public QuestionViewModel()
        {
            _question = new Question();
        }

        [PreferredConstructor]
        public QuestionViewModel(Question question)
        {
            _question = question;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
