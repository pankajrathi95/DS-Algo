﻿using System;
using System.Diagnostics;
using Prototype;

namespace DataStructures
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!!");
            var watch = new Stopwatch();
            watch.Start();
            //start here    

            // DecodeString decodeString = new DecodeString();
            // decodeString.DecodeTheString("3[a]2[bc]");

            string StartDate = "2020-02-25";
            DateTime dt = Convert.ToDateTime(StartDate);

            //end here
            watch.Stop();
            Console.WriteLine("Time Taken: " + watch.ElapsedMilliseconds + " ms");
        }
    }
}