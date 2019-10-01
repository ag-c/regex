using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace RegE.Views
{
    public class HelpWindow : Window
    {
        public HelpWindow()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}