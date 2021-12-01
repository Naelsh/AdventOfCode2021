using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021.Input
{
    public class InputHandler
    {
        private StreamReader _reader;

        public InputHandler(string filePath)
        {
            _reader = new StreamReader(filePath);
        }


        public string[] GetSingleColumnInputToList()
        {
            string result = _reader.ReadToEnd();
            return result.Replace("\r", "").Split("\n");
        }
    }
}
