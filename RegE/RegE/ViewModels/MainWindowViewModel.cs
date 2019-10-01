
using System;
using System.Text.RegularExpressions;
using ReactiveUI;
using RegE.Views;

namespace RegE.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private bool _isChecked;
        private string _inputText;
        private string _regText;
        private string _outputText;

        public string InputText
        {
            get => _inputText;
            set
            {
                this.RaiseAndSetIfChanged(ref _inputText, value); 
                if(_isChecked && !string.IsNullOrEmpty(_regText)) SetRowResult();
                else if(!string.IsNullOrEmpty(_regText)) SetNoRowResult();
            }
        }

        public string RegText
        {
            get => _regText;
            set
            {
                this.RaiseAndSetIfChanged(ref _regText, value);
                if(_isChecked) SetRowResult();
                else SetNoRowResult();
            }
        }

        public string OutputText
        {
            get => _outputText;
            set => this.RaiseAndSetIfChanged(ref _outputText , value);
        }

        public bool IsChecked
        {
            get => _isChecked;
            set => this.RaiseAndSetIfChanged(ref _isChecked,value);
        }

        public void ShowHelp()
        {
            new HelpWindow().Show();
        }

        private void SetNoRowResult()
        {
            OutputText = string.Join(Environment.NewLine,new Regex(_regText).Matches(_inputText));
        }

        private void SetRowResult()
        {
            var r = new Regex(_regText);
            var s = string.Empty;
            foreach (var line in _inputText.Split( Environment.NewLine,StringSplitOptions.RemoveEmptyEntries))
            {
               
                s += $"--{Environment.NewLine}";
                s+=string.Join(Environment.NewLine,r.Matches(line));
                s += $"{Environment.NewLine}--{Environment.NewLine}";
            }

            OutputText = s;
        }
    }
}