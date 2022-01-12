﻿using System;
using System.Collections.Generic;
using System.Text;
using CV19.Models.Decanat;

namespace CV19.Services.Students
{
    class StudentsManager
    {
        private readonly StudentsRepository _Students;
        private readonly GroupsRepository _Groups;

        public IEnumerable<Student> Student => _Students.GetAll();
        public IEnumerable<Group> Group => _Groups.GetAll();

        public StudentsManager(StudentsRepository Students, GroupsRepository Groups)
        {
            _Students = Students;
            _Groups = Groups;
        }
    }
}
