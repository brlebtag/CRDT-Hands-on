using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace GOCounterPeer2Peer.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    [ObservableProperty]
    private int _counterValue;

    [RelayCommand]
    private void Increment()
    {
        CounterValue++;
    }
}
