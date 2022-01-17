﻿using System;
using System.ComponentModel;
using System.Windows;

namespace CV19.Views.Windows
{
    public partial class StudentEditorWindow : Window
    {
        #region FirstName

        private static DependencyProperty FirstNameProperty = DependencyProperty.Register(
            nameof(FirstName),
            typeof(string),
            typeof(StudentsManagementWindow),
            new PropertyMetadata(null));

        public string FirstName { get; set; }

        #endregion

        #region LastName : string - Фамилия

        /// <summary>Фамилия</summary>
        public static readonly DependencyProperty LastNameProperty =
            DependencyProperty.Register(
                nameof(LastName),
                typeof(string),
                typeof(StudentsManagementWindow),
                new PropertyMetadata(default(string)));

        /// <summary>Фамилия</summary>
        //[Category("")]
        [Description("Фамилия")]
        public string LastName
        {
            get => (string)GetValue(LastNameProperty);
            set => SetValue(LastNameProperty, value);
        }

        #endregion

        #region Patronymic : string - Отчество

        /// <summary>Отчество</summary>
        public static readonly DependencyProperty PatronymicProperty =
            DependencyProperty.Register(
                nameof(Patronymic),
                typeof(string),
                typeof(StudentsManagementWindow),
                new PropertyMetadata(default(string)));

        /// <summary>Отчество</summary>
        //[Category("")]
        [Description("Отчество")]
        public string Patronymic
        {
            get => (string)GetValue(PatronymicProperty);
            set => SetValue(PatronymicProperty, value);
        }

        #endregion

        #region Rating : Double - Оценка

        /// <summary>Оценка</summary>
        public static readonly DependencyProperty RatingProperty =
            DependencyProperty.Register(
                nameof(Rating),
                typeof(double),
                typeof(StudentsManagementWindow),
                new PropertyMetadata(default(double)));

        /// <summary>Оценка</summary>
        //[Category("")]
        [Description("Оценка")]
        public double Rating
        {
            get => (double)GetValue(RatingProperty);
            set => SetValue(RatingProperty, value);
        }

        #endregion

        #region Birthday : DateTime - Дата рождения

        /// <summary>Дата рождения</summary>
        public static readonly DependencyProperty BirthdayProperty =
            DependencyProperty.Register(
                nameof(Birthday),
                typeof(DateTime),
                typeof(StudentsManagementWindow),
                new PropertyMetadata(default(DateTime)));

        /// <summary>Дата рождения</summary>
        //[Category("")]
        [Description("Дата рождения")]
        public DateTime Birthday
        {
            get => (DateTime)GetValue(BirthdayProperty);
            set => SetValue(BirthdayProperty, value);
        }

        #endregion

        public StudentEditorWindow() => InitializeComponent();
    }
}
