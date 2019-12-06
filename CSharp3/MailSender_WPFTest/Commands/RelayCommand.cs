﻿using System;

namespace MailSender_WPFTest.Commands
{
    public class RelayCommand : BaseCommand
    {
        private readonly Action _execute;
        private readonly Func<bool> _canExecute;

        public RelayCommand() { }
        public RelayCommand(Action execute) : this(execute, null) { }
        public RelayCommand(Action execute, Func<bool> canExecute)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute;
        }

        public override bool CanExecute(object parameter) => _canExecute == null || _canExecute();
        public override void Execute(object parameter) { _execute(); }
    }
}