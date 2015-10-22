using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModel.Interfaces;
using GalaSoft.MvvmLight;

namespace Kwisspel.ViewModel.ViewModelContainers
{
    public class GetCategoryViewModel : ViewModelBase
    {
        private readonly ICategoryRepository categoryRepository;

        private CategoryViewModel _selectedCategory;
        public CategoryViewModel SelectedCategory
        {
            get { return _selectedCategory; }
            set
            {
                _selectedCategory = value;
                RaisePropertyChanged("SelectedCategory");
            }
        }

        public ObservableCollection<CategoryViewModel> Categories { get; set; }


        public GetCategoryViewModel(ICategoryRepository repository)
        {
            categoryRepository = repository;
            var categoryList = categoryRepository.GetAll().Select(category => new CategoryViewModel()).ToList();

            Categories = new ObservableCollection<CategoryViewModel>(categoryList);
        }
    }
}
