/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocator xmlns:vm="clr-namespace:Kwisspel"
                           x:Key="Locator" />
  </Application.Resources>
  
  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"

  You can also use Blend to do all this with the tool's support.
  See http://www.galasoft.ch/mvvm
*/

using DomainModel.Interfaces;
using DomainModel.Repositories;
using DomainModel.Repositories.Dummy;
using GalaSoft.MvvmLight.Ioc;
using Kwisspel.ViewModel.ViewModelContainers;
using Microsoft.Practices.ServiceLocation;

namespace Kwisspel.ViewModel
{

    public class ViewModelLocator
    {

        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
            SimpleIoc.Default.Register<IQuizRepository, DummyQuizRepository>();
            SimpleIoc.Default.Register<IQuestionRepository, DummyQuestionRepository>();
            SimpleIoc.Default.Register<ICategoryRepository, DummyCategoryRepository>();
            SimpleIoc.Default.Register<IAnswerRepository, DummyAnswerRepository>();

            //SimpleIoc.Default.Register<IQuizRepository, QuizRepository>();
            //SimpleIoc.Default.Register<IQuestionRepository, QuestionRepository>();
            //SimpleIoc.Default.Register<ICategoryRepository, CategoryRepository>();
            //SimpleIoc.Default.Register<IAnswerRepository, AnswerRepository>();

            SimpleIoc.Default.Register<EditQuizViewModel>();
            SimpleIoc.Default.Register<EditQuestionViewModel>();
            SimpleIoc.Default.Register<GetCategoryViewModel>();

            SimpleIoc.Default.Register<QuizViewModel>();
            SimpleIoc.Default.Register<QuestionViewModel>();
            SimpleIoc.Default.Register<CategoryViewModel>();
            SimpleIoc.Default.Register<AnswerViewModel>();
            SimpleIoc.Default.Register<MainViewModel>();
        }

        // MainViewModel
        public MainViewModel Main
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainViewModel>();
            }
        }

        // EditQuizViewModel
        public EditQuizViewModel Quiz
        {
            get
            {
                return ServiceLocator.Current.GetInstance<EditQuizViewModel>();
            }
        }

        // EditQuestionViewModel
        public EditQuestionViewModel Question
        {
            get
            {
                return ServiceLocator.Current.GetInstance<EditQuestionViewModel>();
            }
        }

        public GetCategoryViewModel Category
        {
            get
            {
                return ServiceLocator.Current.GetInstance<GetCategoryViewModel>();
            }
        }


        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}