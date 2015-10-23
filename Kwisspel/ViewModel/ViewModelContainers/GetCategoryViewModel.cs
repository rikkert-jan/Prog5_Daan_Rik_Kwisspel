using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using DomainModel.Interfaces;
using GalaSoft.MvvmLight;

namespace Kwisspel.ViewModel.ViewModelContainers
{
    public class GetCategoryViewModel : ViewModelBase
    {
        private readonly ICategoryRepository _categoryRepository;

        private string _selectedCategory;
        public string SelectedCategory
        {
            get { return _selectedCategory; }
            set
            {
                _selectedCategory = value;
                RaisePropertyChanged("SelectedCategory");
            }
        }

        public ObservableCollection<CategoryViewModel> Categories { get; set; }

        public List<string>  CategoryNames { get; set; }

        public GetCategoryViewModel(ICategoryRepository repository)
        {
            _categoryRepository = repository;
            var categoryList = _categoryRepository.GetAll().Select(category => new CategoryViewModel(category)).ToList();

            Categories = new ObservableCollection<CategoryViewModel>(categoryList);
            CategoryNames = new List<string>();

            foreach (var category in Categories)
            {
                CategoryNames.Add(category.CategoryName);
            }
            SelectedCategory = CategoryNames.First();
        }
    }
}
