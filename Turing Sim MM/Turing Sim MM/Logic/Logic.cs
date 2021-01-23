using System;
using System.Collections.Generic;

namespace Turing_UI
{
    public class Logic
    {
        public struct Info : IEquatable<Info>
        {
            public List<string> instr;
            public int x;
            public List<char> arr;
            public List<Tuple<string, char, char, char, string>> log;

            public bool Equals(Info other)
            {
                throw new NotImplementedException();
            }
        }
        readonly Variables T = new Variables();
        public Info Machine(string file)
        {
            T.instr = FileReader.Text(file, T.instr);
            T.x = FileReader.Head(T.x, T.first, file);
            T.arr = FileReader.Tape(file, T.arr, T.z, T.first);
            T.log = FileReader.Duomenai(T.log, file, T.CState, T.NState, T.Pus, T.CSym, T.NSym, T.instr);
            return new Info { instr = T.instr, x = T.x, arr = T.arr, log = T.log };
        }
    }
}
