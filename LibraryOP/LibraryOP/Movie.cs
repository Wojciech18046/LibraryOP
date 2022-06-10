﻿using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryOP
{
    public class Movie: LibraryItem
    {

        public string Genre { get; }
        public int Duration { get; }
        public string Director { get; }


        public Movie(int barCode, string name, string genre, int duration, string director) : base(barCode, name)
        {
            Genre = genre;
            Duration = duration;
            Director = director;

        }


    }
}