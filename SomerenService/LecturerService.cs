﻿using SomerenDAL;
using SomerenModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomerenService
{
    public class LecturerService
    {
        private LecturerDao lecturerdb;

        public LecturerService()
        {
            lecturerdb = new LecturerDao();
        }

        public List<Teacher> GetLecturers()
        {
            List<Teacher> lecturers = lecturerdb.GetAllLecturers();
            return lecturers;
        }

    }
}
