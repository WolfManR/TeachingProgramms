﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfTestMailSender
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class WpfMailSender : Window
    {
        public WpfMailSender()
        {
            InitializeComponent();
            cbSenderSelect.ItemsSource = VariablesClass.Senders;
            cbSenderSelect.DisplayMemberPath = "Key";
            cbSenderSelect.SelectedValuePath = "Value";
            DBclass db = new DBclass();
            dgEmails.ItemsSource = db.Emails;
            cbSmtpSelect.ItemsSource = db.Smtps;
            cbSmtpSelect.DisplayMemberPath = "Key";
            cbSmtpSelect.SelectedValuePath = "Value";
        }

        private void miClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnClock_Click(object sender, RoutedEventArgs e)
        {
            tabControl.SelectedItem = tabPlanner;
        }

        private void btnSendAtOnce_Click(object sender, RoutedEventArgs e)
        {
            string strLogin = cbSenderSelect.Text;
            string strPassword = cbSenderSelect.SelectedValue.ToString();
            string smtpHost = cbSmtpSelect.Text;
            int smtpPort = int.Parse(cbSmtpSelect.SelectedValue.ToString());
            if (string.IsNullOrEmpty(strLogin))
            {
                new ErrorWindow("Выберите отправителя") { Owner = this }.ShowDialog();
                return;
            }
            if (string.IsNullOrEmpty(strPassword))
            {
                new ErrorWindow("Укажите пароль отправителя") { Owner = this }.ShowDialog();
                return;
            }

            EmailSendServiceClass emailSender = new EmailSendServiceClass(strLogin, strPassword,smtpHost,smtpPort);
            try
            {
                emailSender.SendMails((IQueryable<Email>)dgEmails.ItemsSource);
            }
            catch (Exception ex)
            {
                new ErrorWindow(Texts.ErrorMsg + ex.ToString()) {Owner=this }.ShowDialog();
            }
        }

        private void btnSend_Click(object sender, RoutedEventArgs e)
        {
            SchedulerClass sc = new SchedulerClass();
            TimeSpan tsSendTime = sc.GetSendTime(tbTimePicker.Text);
            if (tsSendTime == new TimeSpan())
            {
                new ErrorWindow("Некорректный формат даты") { Owner = this }.ShowDialog();
                return;
            }
            DateTime dtSendDateTime = (cldSchedulDateTimes.SelectedDate ?? DateTime.Today).Add(tsSendTime);
            if (dtSendDateTime < DateTime.Now)
            {
                new ErrorWindow("Дата и время отправки писем не могут быть раньше, чем настоящее время") { Owner = this }.ShowDialog();
                return;
            }
            EmailSendServiceClass emailSender = new EmailSendServiceClass(cbSenderSelect.Text, cbSenderSelect.SelectedValue.ToString());
            sc.SendEmails(dtSendDateTime, emailSender, (IQueryable<Email>)dgEmails.ItemsSource);
        }

        private void tscTabSwitcher_btnNextClick(object sender, RoutedEventArgs e)
        {
            if (tabControl.SelectedIndex+1 == tabControl.Items.Count-1)
            {
                tabControl.SelectedIndex++;
                tscTabSwitcher.IsHideBtnNext = true;
                tscTabSwitcher.IsHidebtnPrevious = false;
                return;
            }
            tabControl.SelectedIndex++;
        }

        private void tscTabSwitcher_btnPreviousClick(object sender, RoutedEventArgs e)
        {
            if (tabControl.SelectedIndex-1 == 0)
            {
                tabControl.SelectedIndex--;
                tscTabSwitcher.IsHideBtnNext = false;
                tscTabSwitcher.IsHidebtnPrevious = true;
                return;
            }
            tabControl.SelectedIndex--;
        }
    }
}
