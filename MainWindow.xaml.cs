using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Wpf.Ui.Controls;
using WinUserLauncher.Models;
using WinUserLauncher.ViewModels;

namespace WinUserLauncher
{
    public partial class MainWindow : FluentWindow
    {
        private MainWindowViewModel? _viewModel;

        public MainWindow()
        {
            InitializeComponent();
            Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            _viewModel = new MainWindowViewModel();
            DataContext = _viewModel;

            // 默认显示所有应用
            if (_viewModel != null)
            {
                AppsGrid.ItemsSource = _viewModel.SystemApps;
            }
        }

        private void OnCategoryClick(object sender, RoutedEventArgs e)
        {
            if (sender is NavigationViewItem item && item.Tag is string tag)
            {
                if (Enum.TryParse<AppCategory>(tag, out AppCategory category))
                {
                    FilterAppsByCategory(category);
                }
            }
        }

        private void OnShowAllClick(object sender, RoutedEventArgs e)
        {
            if (_viewModel != null)
            {
                AppsGrid.ItemsSource = _viewModel.SystemApps;
            }
        }

        private void FilterAppsByCategory(AppCategory category)
        {
            if (_viewModel != null)
            {
                var filteredApps = _viewModel.SystemApps.Where(app => app.Category == category);
                AppsGrid.ItemsSource = filteredApps;
            }
        }

        private void OnSearchTextChanged(object sender, AutoSuggestBoxTextChangedEventArgs e)
        {
            if (e.Reason == AutoSuggestionBoxTextChangeReason.UserInput)
            {
                var searchText = SearchBox.Text?.ToLower() ?? string.Empty;
                if (_viewModel != null)
                {
                    var filteredApps = _viewModel.SystemApps.Where(app =>
                        app.Name.ToLower().Contains(searchText) ||
                        app.Description.ToLower().Contains(searchText));
                    AppsGrid.ItemsSource = filteredApps;
                }
            }
        }

        private void OnAppClick(object sender, MouseButtonEventArgs e)
        {
            if (sender is Card card && card.Tag is SystemApp app)
            {
                if (_viewModel != null && _viewModel.LaunchAppCommand != null)
                {
                    if (_viewModel.LaunchAppCommand.CanExecute(app))
                    {
                        _viewModel.LaunchAppCommand.Execute(app);
                    }
                }
            }
        }
    }
}