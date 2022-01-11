﻿using CV19.Models.Decanat;
using CV19.Services.Base;

namespace CV19.Services
{
    class StudentsRepository : RepositoryInMemory<Student>
    {
        protected override void Update(Student Source, Student Destination)
        {
            Destination.Name = Source.Name;
            Destination.Surname = Source.Surname;
            Destination.Patronymic = Source.Patronymic;
            Destination.Birthday = Source.Birthday;
            Destination.Rating = Source.Rating;
        }
    }

    class GroupsRepository : RepositoryInMemory<Group>
    {
        protected override void Update(Group Source, Group Destination)
        {
            Destination.Name = Source.Name;
            Destination.Desctiption = Source.Desctiption;
        }
    }
}
