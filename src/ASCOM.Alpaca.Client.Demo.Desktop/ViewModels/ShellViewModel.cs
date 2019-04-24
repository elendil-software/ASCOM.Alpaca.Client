using System;
using Caliburn.Micro;

namespace ASCOM.Alpaca.Client.Demo.Desktop.ViewModels
{
    public class ShellViewModel : Screen
    {
        private FilterWheelViewModel _filterWheelViewModel;
        private DomeViewModel _domeViewModel;
        private SafetyMonitorViewModel _safetyMonitorViewModel;
        private CameraViewModel _cameraViewModel;
        private FocuserViewModel _focuserViewModel;
        private ObservingConditionsViewModel _observingConditionsViewModel;
        private RotatorViewModel _rotatorViewModel;

        public ShellViewModel(FilterWheelViewModel filterWheelViewModel, 
                                DomeViewModel domeViewModel,
                                SafetyMonitorViewModel safetyMonitorViewModel,
                                CameraViewModel cameraViewModel,
                                FocuserViewModel focuserViewModel,
                                ObservingConditionsViewModel observingConditionsViewModel,
                                RotatorViewModel rotatorViewModel)
        {
            _filterWheelViewModel = filterWheelViewModel ?? throw new ArgumentNullException(nameof(filterWheelViewModel));
            _domeViewModel = domeViewModel ?? throw new ArgumentNullException(nameof(domeViewModel));
            _safetyMonitorViewModel = safetyMonitorViewModel ?? throw new ArgumentNullException(nameof(safetyMonitorViewModel));
            _cameraViewModel = cameraViewModel ?? throw new ArgumentNullException(nameof(cameraViewModel));
            _focuserViewModel = focuserViewModel ?? throw new ArgumentNullException(nameof(focuserViewModel));
            _observingConditionsViewModel = observingConditionsViewModel ?? throw new ArgumentNullException(nameof(observingConditionsViewModel));
            _rotatorViewModel = rotatorViewModel ?? throw new ArgumentNullException(nameof(rotatorViewModel));
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
        
        public DomeViewModel DomeViewModel
        {
            get => _domeViewModel;
            set
            {
                _domeViewModel = value;
                NotifyOfPropertyChange(() => DomeViewModel);
            }
        }
        
        public SafetyMonitorViewModel SafetyMonitorViewModel
        {
            get => _safetyMonitorViewModel;
            set
            {
                _safetyMonitorViewModel = value;
                NotifyOfPropertyChange(() => SafetyMonitorViewModel);
            }
        }
        
        public CameraViewModel CameraViewModel
        {
            get => _cameraViewModel;
            set
            {
                _cameraViewModel = value;
                NotifyOfPropertyChange(() => CameraViewModel);
            }
        }
        
        public FocuserViewModel FocuserViewModel
        {
            get => _focuserViewModel;
            set
            {
                _focuserViewModel = value;
                NotifyOfPropertyChange(() => FocuserViewModel);
            }
        }
        
        public ObservingConditionsViewModel ObservingConditionsViewModel
        {
            get => _observingConditionsViewModel;
            set
            {
                _observingConditionsViewModel = value;
                NotifyOfPropertyChange(() => ObservingConditionsViewModel);
            }
        }
        
        public RotatorViewModel RotatorViewModel
        {
            get => _rotatorViewModel;
            set
            {
                _rotatorViewModel = value;
                NotifyOfPropertyChange(() => RotatorViewModel);
            }
        }
    }
}