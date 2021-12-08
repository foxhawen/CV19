﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;
using CV19.Infrastructure.Commands;
using CV19.Models;
using CV19.Models.Decanat;
using CV19.ViewModels.Base;

namespace CV19.ViewModels
{
    internal class MainWindowViewModel : ViewModel
    {
        /*-------------------------------------------------------------------------------------------------------------*/

        public ObservableCollection<Group> Groups { get; }

        public object[] CompositeCollection { get; }

        #region SelectedCompositeValue : object - Выбранный непонятый элемент

        /// <summary>Выбранный непонятый элемент</summary>
        private object _SelectedCompositeValue;

        /// <summary>Выбранный непонятый элемент</summary>
        public object SelectedCompositeValue
        {
            get => _SelectedCompositeValue;
            set => Set(ref _SelectedCompositeValue, value);
        }

        #endregion

        #region SelectedGroup : Group - Выбранная группа

        /// <summary>Выбранная группа</summary>
        private Group _SelectedGroup;

        /// <summary>Выбранная группа</summary>
        public Group SelectedGroup
        {
            get => _SelectedGroup;
            set => Set(ref _SelectedGroup, value);
        }

        #endregion

        #region SelectedPageIndex : int - Номер выбранной вкладки

        /// <summary>Номер выбранной вкладки</summary>
        private int _SelectedPageIndex;

        /// <summary>Номер выбранной вкладки</summary>
        public int SelectedPageIndex
        {
            get => _SelectedPageIndex;
            set => Set(ref _SelectedPageIndex, value);
        }

        #endregion

        #region TestDataPoints : IEnumerable<DataPoint> - Тестовый набор донных для визуализации графиков

        /// <summary>Тестовый набор донных для визуализации графиков</summary>
        private IEnumerable<DataPoint> _TestDataPoints;

        /// <summary>Тестовый набор донных для визуализации графиков</summary>
        public IEnumerable<DataPoint> TestDataPoints
        {
            get => _TestDataPoints;
            set => Set(ref _TestDataPoints, value);
        }
        #endregion

        #region Заголовок окна

        private string _Title = "Анализ статистики CV19";
        /// <summary>Заголовок окна</summary>
        public string Titel
        {
            get => _Title;
            //set
            //{
            //    //if (Equals(_Title, value)) return;
            //    //_Title = value;
            //    //OnPropertyChanged();
            //    Set(ref _Title, value);
            //}
            set => Set(ref _Title, value);
        }

        #endregion

        #region Status : Status - Статус программы

        /// <summary>Статус программы</summary>
        private string _Status = "Готов!";

        /// <summary>Статус программы</summary>
        public string Status
        {
            get => _Status;
            set => Set(ref _Status, value);
        }

        #endregion

        /*-------------------------------------------------------------------------------------------------------------*/

        #region Команды

        #region CloseAplicationCommand

        public ICommand CloseAplicationCommand { get; }

        private bool CanCloseAplicationCommandExecute(object p) => true;
        public void OnCloseAplicationCommandExecuted(object p)
        {
            Application.Current.Shutdown();
        }

        #endregion

        #region ChangeTabIndexCommand

        public ICommand ChangeTabIndexCommand { get; }

        private bool CanChangeTabIndexCommandExecute(object p) => _SelectedPageIndex >= 0;

        private void OnChangeTabIndexCommandExecuted(object p)
        {
            if (p is null) return;
            SelectedPageIndex += Convert.ToInt32(p);
        }

        #endregion

        public ICommand CreateGroupCommand { get; }

        private bool CanCreateGroupCommandExecute(object p) => true;

        private void OnCreateGroupCommandExecuted(object p)
        {
            var group_max_index = Groups.Count + 1;
            var new_group = new Group
            {
                Name = $"Группа {group_max_index}",
                Students = new ObservableCollection<Student>()
            };
            Groups.Add(new_group);
        }

        #region DeleteGroupCommand

        public ICommand DeleteGroupCommand { get; }
        private bool CanDeleteGroupCommandExecute(object p) => p is Group group && Groups.Contains(group);

        private void OnDeleteGroupCommandExecuted(object p)
        {
            if (!(p is Group group)) return;
            var group_index = Groups.IndexOf(group);
            Groups.Remove(group);
            if (group_index < Groups.Count)
                SelectedGroup = Groups[group_index]; 
        }

        #endregion

        #endregion

        /*-------------------------------------------------------------------------------------------------------------*/

        public MainWindowViewModel()
        {
            #region Команды

            CloseAplicationCommand =
                new LambdaCommand(OnCloseAplicationCommandExecuted, CanCloseAplicationCommandExecute);

            ChangeTabIndexCommand =
                new LambdaCommand(OnChangeTabIndexCommandExecuted, CanChangeTabIndexCommandExecute);

            CreateGroupCommand = 
                new LambdaCommand(OnCreateGroupCommandExecuted, CanCreateGroupCommandExecute);
            DeleteGroupCommand = 
                 new LambdaCommand(OnDeleteGroupCommandExecuted, CanDeleteGroupCommandExecute);
            #endregion

            var data_points = new List<DataPoint>((int)(360 / 0.1));
            for (var x = 0d; x <= 360; x += 0.1)
            {
                const double to_rad = Math.PI / 180;
                var y = Math.Sin(x * to_rad);

                data_points.Add(new DataPoint { XValue = x, YValue = y });
            }

            TestDataPoints = data_points;

            var student_index = 1;
            var students = Enumerable.Range(1, 10).Select(i => new Student
            {
                Name = $"Name {student_index}",
                Surname = $"Surname {student_index}",
                Patronymic = $"Patronymic {student_index++}",
                Birthday = DateTime.Now,
                Rating = 0
            });

            var groups = Enumerable.Range(1, 20).Select(i => new Group
            {
                Name = $"Группа {i}",
                Students = new ObservableCollection<Student>(students)
            });
            Groups = new ObservableCollection<Group>(groups);

            var data_list = new List<Object>();

            data_list.Add("Hello World!");
            data_list.Add(42);
            var group = Groups[1];
            data_list.Add(group);
            data_list.Add(group.Students[0]);
            CompositeCollection = data_list.ToArray();
        }
        /*-------------------------------------------------------------------------------------------------------------*/
    }
}
