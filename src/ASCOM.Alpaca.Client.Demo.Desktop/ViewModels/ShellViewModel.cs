using System;
using Caliburn.Micro;

namespace ASCOM.Alpaca.Client.Demo.Desktop.ViewModels
{
    public class ShellViewModel : Screen
    {
        private FilterWheelViewModel _filterWheelViewModel;

        public ShellViewModel(FilterWheelViewModel filterWheelViewModel)
        {
            _filterWheelViewModel = filterWheelViewModel ?? throw new ArgumentNullException(nameof(filterWheelViewModel));
        }

        public FilterWheelViewModel FilterWheelViewModel
        {
            get => _filterWheelViewModel;
            set
            {
                _filterWheelViewModel = value;
                NotifyOfPropertyChange(() => FilterWheelViewModel);
            }
        }
    }
}