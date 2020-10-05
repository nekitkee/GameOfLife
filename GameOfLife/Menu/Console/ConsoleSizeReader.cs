﻿using System;
using System.Collections.Generic;
using System.Text;

namespace GameOfLife
{
    //Get grid size from console 
    public class ConsoleSizeReader : ISizeReader
    {
        public void GetSize(out uint rows, out uint columns)
        {
            var playerInput = Read();
            BindData(playerInput, out rows, out columns);
            Validate(rows, columns);
        }

        //Ask player to pass count of rows and columns
        private string[] Read()
        {
            Console.Write("\nEnter Height: ");
            string width = Console.ReadLine();
            Console.Write("Enter Width: ");
            string height = Console.ReadLine();
            return new string[] { width, height };
        }

        //Parse user input as unsigned integers
        private void BindData(string[] data ,out uint width , out uint height )
        {
            if (data.Length >= 2)
            {
                if (!uint.TryParse(data[0], out width) || !uint.TryParse(data[1], out height))
                {
                    throw new ArgumentException("Incorect Console Input");
                }
            }
            else
            {
                throw new ArgumentException("Incorrect input , waiting for 2 arguments");
            }
        }

        //Count of coulms and rows should be positive
        private void Validate(uint rows , uint columns)
        {
            if (rows < 1 || columns < 1)
            {
                throw new ArgumentException("Argumnents should be positive");
            }
        }
    }
}
