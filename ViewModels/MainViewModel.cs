using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using WpfTest.Data;
using WpfTest.Models;
using WpfTest.ViewModels;
using WpfTest.Views;

namespace WpfTest.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public DataContext context;
        private ObservableCollection<PatternModel> loadedPatternModels;
        private ICommand saveCommand;
        private FirstPage firstPage = new FirstPage();
        private SecondPage secondPage = new SecondPage();

        public Page CurrentPage
        {
            get => currentPage; set
            {
                currentPage = value;
                OnPropertyChanged(nameof(CurrentPage));
            }
        }



        public event PropertyChangedEventHandler? PropertyChanged;

        public ObservableCollection<PatternModel> LoadedPatternModels
        {
            get => loadedPatternModels;
            set
            {
                loadedPatternModels = value;
                OnPropertyChanged(nameof(LoadedPatternModels));
                //context.SaveChanges();
            }
        }
        // Create the OnPropertyChanged method to raise the event
        // The calling member's name will be used as the parameter.
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        public MainViewModel()
        {
            LoadedPatternModels = new ObservableCollection<PatternModel>();

            context = context ?? new DataContext();            
           

            LoadData();

        }

        private void SaveChanges()
        {
            context.SaveChanges();
            OnPropertyChanged(nameof(LoadedPatternModels));
        }

        private async void LoadData()
        {
            await context.PatternModels.LoadAsync();
            LoadedPatternModels = context.PatternModels.Local.ToObservableCollection();
        }

        private ICommand mUpdater;
        private Page currentPage;

        public ICommand SaveCommand
        {
            get
            {
                if (mUpdater == null)
                    mUpdater = new Updater(SaveChanges);
                return mUpdater;
            }
            set
            {
                mUpdater = value;
            }
        }

        
        
        private Updater pageCommand;
        public ICommand PageCommand => pageCommand ??= new Updater(Page1);

        private void Page1()
        {

            Debug.WriteLine("update page ");
            CurrentPage = firstPage;
        }
    }

    class Updater : ICommand
    {
        #region ICommand Members  
        private Action callback;

        public bool CanExecute(object parameter)
        {
            return true;
        }
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public void Execute(object parameter)
        {
            //Your Code  
            callback();
        }
        #endregion

        public Updater(Action action)
        {
            callback = action;
        }
    }
}
