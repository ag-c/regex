using Avalonia;
using Avalonia.Markup.Xaml;

namespace RegE
{
    public class App : Application
    {
        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}