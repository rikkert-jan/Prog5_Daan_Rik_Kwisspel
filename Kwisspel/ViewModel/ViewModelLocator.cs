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

using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;

namespace Kwisspel.ViewModel
{

    public class ViewModelLocator
    {

        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
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

        // QuizViewModel
        public QuizViewModel Quiz
        {
            get
            {
                return ServiceLocator.Current.GetInstance<QuizViewModel>();
            }
        }

        // QuestionViewModel
        public QuestionViewModel Question
        {
            get
            {
                return ServiceLocator.Current.GetInstance<QuestionViewModel>();
            }
        }

        // CategoryViewModel
        public CategoryViewModel Category
        {
            get
            {
                return ServiceLocator.Current.GetInstance<CategoryViewModel>();
            }
        }

        // AnswerViewModel
        public AnswerViewModel Answer
        {
            get
            {
                return ServiceLocator.Current.GetInstance<AnswerViewModel>();
            }
        }



        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}