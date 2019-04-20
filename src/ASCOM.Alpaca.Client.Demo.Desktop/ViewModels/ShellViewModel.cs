using System;
using Caliburn.Micro;

namespace ASCOM.Alpaca.Client.Demo.Desktop.ViewModels
{
    public class ShellViewModel : Screen
    {
        private FilterWheelViewModel _filterWheelViewModel;
        private DomeViewModel _domeViewModel;

        public ShellViewModel(FilterWheelViewModel filterWheelViewModel, DomeViewModel domeViewModel)
        {
            _filterWheelViewModel = filterWheelViewModel ?? throw new ArgumentNullException(nameof(filterWheelViewModel));
            _domeViewModel = domeViewModel ?? throw new ArgumentNullException(nameof(domeViewModel));
        }

        public FilterWheelViewModel FilterWheelViewModel
        {
            get => _filterWheelViewModel;
            set
            {
                _filterWheelViewModel = value;
                NotifyOfPropertyChange(() => FilterWheelViewModel);
            }
        }public DomeViewModel DomeViewModel
        {
            get => _domeViewModel;
            set
            {
                _domeViewModel = value;
                NotifyOfPropertyChange(() => DomeViewModel);
            }
        }
    }
}