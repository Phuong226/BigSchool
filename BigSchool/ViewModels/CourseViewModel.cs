﻿using BigSchool.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BigSchool.ViewModels
{
    public class CourseViewModel
    {
        public int Place { get; set; }
        public int Date { get;set; }
        public string Time { get; set; }
        public byte Category { get; set; }
        public  IEnumerable <Category> Categories { get; set;  }

        public DateTime GetDateTime()
        {
            return DateTime.Parse(String.Format("{0} {1}", Date, Time));    
        }

    }
}