using System;
using System.Collections.Generic;

namespace Turing_UI
{
    public class Variables
    {
        public List<Tuple<string, char, char, char, string>> log = new List<Tuple<string, char, char, char, string>>();
        public string tekstas { get; set; }
        public string file { get; set; }
        public string[] name = new string[5];
        public List<string> instr = new List<string>();
        public string[] first;
        public string CState { get; set; }
        public string NState { get; set; }
        public char Pus { get; set; }
        public char CSym { get; set; }
        public char NSym { get; set; }
        public int x { get; set; }
        public string ats;
        public string z { get; set; }
        public List<char> arr = new List<char>();
        public int h;
        public bool Stop = false;
        public string ATS;

    }
}
