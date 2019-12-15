using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace TabSwitcher
{
    /// <summary>
    /// Логика взаимодействия для Scheduler.xaml
    /// </summary>
    public partial class Scheduler: UserControl
    {
        
        public Scheduler()
        {
            InitializeComponent();
        }

        public DateTime Date
        {
            get { return (DateTime)GetValue(DateProperty); }
            set { SetValue(DateProperty, value); }
        }
        public static readonly DependencyProperty DateProperty = DependencyProperty.Register("Date", typeof(DateTime), typeof(Scheduler), new PropertyMetadata(default(DateTime)));


        public ICommand RemoveCommand
        {
            get { return (ICommand)GetValue(RemoveCommandProperty); }
            set { SetValue(RemoveCommandProperty, value); }
        }

        // Using a DependencyProperty as the backing store for RemoveCommand.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty RemoveCommandProperty =
            DependencyProperty.Register("RemoveCommand", typeof(ICommand), typeof(Scheduler), new PropertyMetadata(default(ICommand)));

        public ICommand OpenLetterWindowCommand
        {
            get { return (ICommand)GetValue(OpenLetterWindowCommandProperty); }
            set { SetValue(OpenLetterWindowCommandProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty OpenLetterWindowCommandProperty =
            DependencyProperty.Register("OpenLetterWindowCommand", typeof(ICommand), typeof(Scheduler), new PropertyMetadata(default(ICommand)));

    }
}
