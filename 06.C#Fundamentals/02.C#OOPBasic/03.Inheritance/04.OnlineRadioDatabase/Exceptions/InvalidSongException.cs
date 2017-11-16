﻿using System;

namespace _4.OnlineRadioDatabase
{
    public class InvalidSongException : Exception
    {
        private const string Message = "Invalid song.";

        public InvalidSongException()
            : base(Message)
        {             
        }

        public InvalidSongException(string message)
            : base(message)
        {
        }


    }
}
