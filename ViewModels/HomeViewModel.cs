using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ViewModels;

public class HomeViewModel : INotifyPropertyChanged
{
    #region Properties

    private string _title = "Move Space Tools | Home";

    public string Title
    {
        get => _title;
        set
        {
            if (_title != value)
            {
                _title = value;
                OnPropertyChanged();
            }
        }
    }

    #endregion

    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    #region Commands

    public void CreateNewProject()
    {
        Title = "Creating new project...";
    }

    #endregion
}
