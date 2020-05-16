using Acr.UserDialogs;

namespace MusicPlayer.ViewModel
{
    public class ViewModelBase : ExtendedBindableObject
    {
        private bool _isBusy;
        public bool IsBusy
        {
            get
            {
                return _isBusy;
            }
            set
            {
                _isBusy = value;

                if (IsBusy)
                    UserDialogs.Instance.ShowLoading();
                else
                    UserDialogs.Instance.HideLoading();

                RaisePropertyChanged(() => IsBusy);
            }
        }
    }
}
