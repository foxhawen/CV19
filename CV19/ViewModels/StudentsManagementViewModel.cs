﻿using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using CV19.Infrastructure.Commands;
using CV19.Models.Decanat;
using CV19.Services.Students;
using CV19.ViewModels.Base;
using CV19.Views.Windows;

namespace CV19.ViewModels
{
    class StudentsManagementViewModel : ViewModel
    {
        private readonly StudentsManager _StudentsManager;

        public IEnumerable<Student> Students => _StudentsManager.Students;

        public IEnumerable<Group> Groups => _StudentsManager.Groups;

        #region Title : string - Заголовок окна

        /// <summary>Заголовок окна</summary>
        private string _Title = "Управление студентами";

        /// <summary>Заголовок окна</summary>
        public string Title
        {
            get => _Title;
            set => Set(ref _Title, value);
        }

        #endregion

        #region SelectedGroup : Group - Выбранная группа студентов

        /// <summary>Выбранная группа студентов</summary>
        private Group _SelectedGroup;

        /// <summary>Выбранная группа студентов</summary>
        public Group SelectedGroup
        {
            get => _SelectedGroup;
            set => Set(ref _SelectedGroup, value);
        }

        #endregion

        #region SelectedStudent : Student - Выбранный студент

        /// <summary>Выбранный студент</summary>
        private Student _SelectedStudent;


        /// <summary>Выбранный студент</summary>
        public Student SelectedStudent
        {
            get => _SelectedStudent;
            set => Set(ref _SelectedStudent, value);
        }

        #endregion

        #region Команды


        #region EditStudentCommand - Команда редактирования студента

        private ICommand _EditStudentCommand;

        /// <summary>Команда редактирования студента</summary>
        public ICommand EditStudentCommand => _EditStudentCommand ??= new LambdaCommand(OnEditStudentCommandExecutes, CanEditStudentCommandExecute);

        private static bool CanEditStudentCommandExecute(object p) => p is Student;

        private void OnEditStudentCommandExecutes(object p)
        {
            var student = (Student)p;

            var dlg = new StudentEditorWindow
            {
                FirstName = student.Name,
                LastName = student.Surname,
                Patronymic = student.Patronymic,
                Rating = student.Rating,
                Birthday = student.Birthday
            };

            if (dlg.ShowDialog() == true)
                MessageBox.Show("Пользователь выполнил редактирование");
            else
                MessageBox.Show("Пользователь отказался");
        }

        #endregion

        #region Command CreateNewStudentCommand - Создание нового студента

        /// <summary>Создание нового студента</summary>
        private ICommand _CreateNewStudentCommand;

        /// <summary>Создание нового студента</summary>
        public ICommand CreateNewStudentCommand => _CreateNewStudentCommand
            ??= new LambdaCommand(OnCreateNewStudentCommandExecuted, CanCreateNewStudentCommandExecute);

        /// <summary>Проверка возможности выполнения - Создание нового студента</summary>
        private static bool CanCreateNewStudentCommandExecute(object p) => p is Group;

        /// <summary>Логика выполнения - Создание нового студента</summary>
        public void OnCreateNewStudentCommandExecuted(object p)
        {
            var group = (Group)p;
        }

        #endregion

        #endregion

        public StudentsManagementViewModel(StudentsManager StudentsManager) => _StudentsManager = StudentsManager;
    }
}
