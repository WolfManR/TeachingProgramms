﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace OrganizationEF.Models
{
    public class EntityBase : INotifyDataErrorInfo, INotifyPropertyChanged
    {
        [Key]
        public int Id { get; set; }
        [Timestamp]
        public byte[] Timestamp { get; set; }

        // Important to work with Nuget package PropertyChanged.Fody
        public bool IsChanged { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (propertyName != nameof(IsChanged)) IsChanged = true;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(string.Empty));
        }

        public readonly Dictionary<string, List<string>> _errors = new Dictionary<string, List<string>>();
        public bool HasErrors => _errors.Count != 0;
        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;
        public void OnErrorsChanged(string propertyName)
        {
            ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
        }

        public IEnumerable GetErrors(string propertyName)
        {
            if (string.IsNullOrEmpty(propertyName)) return _errors.Values;
            return _errors.ContainsKey(propertyName) ? _errors[propertyName] : null;
        }
        protected string[] GetErrorsFromAnnotations<T>(string propertyName, T value)
        {
            var results = new List<ValidationResult>();
            var vc = new ValidationContext(this, null, null) { MemberName = propertyName };
            var isValid = Validator.TryValidateProperty(value, vc, results);
            return (isValid) ? null : Array.ConvertAll(results.ToArray(), o => o.ErrorMessage);
        }

        protected void AddError(string propertyName, string error)
        {
            AddErrors(propertyName, new List<string> { error });
        }
        protected void AddErrors(string propertyName, IList<string> errors)
        {
            if (errors == null || errors.Count == 0) return;

            var changed = false;
            if (!_errors.ContainsKey(propertyName))
            {
                _errors.Add(propertyName, new List<string>());
                changed = true;
            }
            foreach (var err in errors)
            {
                if (_errors[propertyName].Contains(err)) continue;
                _errors[propertyName].Add(err);
                changed = true;
            }
            if (changed) OnErrorsChanged(propertyName);
        }

        protected void ClearErrors(string propertyName = "")
        {
            if (String.IsNullOrEmpty(propertyName)) _errors.Clear();
            else _errors.Remove(propertyName);
            OnErrorsChanged(propertyName);
        }
    }
}