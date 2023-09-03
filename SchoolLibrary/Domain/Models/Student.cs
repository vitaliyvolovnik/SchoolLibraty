﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Student
    {
        public int Id { get; set; }

        public Person? Person { get; set; }
        public int? PersonId { get; set; }

        public int Class { get; set; }

        public bool IsVisible { get; set; }

        public ObservableCollection<Load> Loads { get; set; } = new();

    }
}
