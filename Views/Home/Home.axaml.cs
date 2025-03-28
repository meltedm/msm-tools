using ViewModels;
using Avalonia.Controls;
using Avalonia.Interactivity;

namespace Views;

public partial class Home : Window
{
    public Home()
    {
        InitializeComponent();
        DataContext = new HomeViewModel();
    }

    private void NewProjectButton_Click(object? sender, RoutedEventArgs e)
    {
        if (DataContext is not HomeViewModel viewModel) return;
        viewModel.CreateNewProject();
    }

    private void SearchProjectsButton_Click(object? sender, RoutedEventArgs e)
    {
        if (DataContext is not HomeViewModel viewModel) return;
        viewModel.CreateNewProject();
    }

    private void ProjectsListBox_SelectionChanged (object? sender, SelectionChangedEventArgs e)
    {
        OpenSelectedButton.IsEnabled = ProjectsListBox.SelectedItem != null;
    }
}