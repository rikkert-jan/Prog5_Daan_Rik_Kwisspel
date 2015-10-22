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
    public class CategoryViewModel
    {
        private Category _category;

        public int CategoryId
        {
            get { return _category.CategoryId; }
            set
            {
                _category.CategoryId = value;
                OnPropertyChanged("CategoryId");
            }
        }

        public string CategoryName
        {
            get { return _category.CategoryName; }
            set
            {
                _category.CategoryName = value;
                OnPropertyChanged("CategoryName");
            }
        }

        [PreferredConstructor]
        public CategoryViewModel(Category category)
        {
            _category = category;
        }

        public CategoryViewModel()
        {
            _category = new Category();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

