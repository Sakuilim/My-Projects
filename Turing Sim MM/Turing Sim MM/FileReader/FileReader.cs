using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;

namespace Turing_UI
{
    public class FileReader
    {
        public static void Clear(List<Tuple<string, char, char, char, string>> log, int x, string BoxT, List<char> arr, List<string> instr, int h, bool Stop, string ATS)
        {
            h = 0;
            ATS = String.Empty;
            BoxT = String.Empty;
            instr.Clear();
            log.Clear();
            arr.Clear();
        }
        public static List<string> Text(string failas, List<string> instr)
        {
            var lines = File.ReadAllLines(failas).Where(arg => !string.IsNullOrWhiteSpace(arg));
            lines = lines.Skip(2).ToArray();
            foreach (string line in lines)
            {
                instr.Add(line);
            }
            return instr;
        }
        public static List<Tuple<string, char, char, char, string>> Duomenai(List<Tuple<string, char, char, char, string>> log, string Duomenas, string CState, string NState, char Pus, char CSym, char NSym, List<string> instr)
        {
            foreach (string line in instr)
            {
                string[] bits = line.Split(' ');
                CState = bits[0];
                CSym = char.Parse(bits[1]);
                NSym = char.Parse(bits[2]);
                Pus = char.Parse(bits[3]);
                NState = bits[4];
                log.Add(new Tuple<string, char, char, char, string>(CState, CSym, NSym, Pus, NState));
            }
            return log;
        }
        public static List<char> Tape(string Duomenas, List<char> arr, string z, string[] first)
        {
            first = File.ReadAllLines(Duomenas);
            z = first[0];
            z.ToCharArray();
            for (int i = 0; i < z.Length; i++)
            {
                arr.Add(z[i]);
            }
            return arr;
        }
        public static int Head(int x, string[] first, string file)
        {
            first = File.ReadAllLines(file);
            if (first[1].Length == 1)
            {
                x = int.Parse(first[1]);
            }
            else
            {
                x = 0;
            }
            return x;
        }
        public static IEnumerable<string> Veiksmas(List<Tuple<string, char, char, char, string>> log, int x, string BoxT, List<char> arr, List<string> instr, int h, bool Stop, string ATS, CancellationToken token)
        {
            while (Stop == false)
            {
                BoxT = String.Empty;
                for (int l = 0; l < arr.Count; l++)
                {
                    if (l == x)
                    {
                        BoxT += '[';
                        BoxT += arr[l];
                        BoxT += ']';
                    }
                    else
                    {
                        BoxT += arr[l];
                    }
                }
                ATS = BoxT;
                if (log[h].Item4 == 'R')
                {
                    x = x + 1;
                }
                else if (log[h].Item4 == 'L')
                {
                    x = x - 1;
                }
                if (x > arr.Count || x < 0 || log.Count == 0)
                {
                    Clear(log, x, BoxT, arr, instr, h, Stop, ATS);
                    Stop = true;

                }
                if (Stop == false)
                {
                    for (int i = 0; i < log.Count; i++)
                    {
                        if (log[h].Item5 == log[i].Item1 && arr[x] == log[i].Item2)
                        {
                            h = i;
                            i = log.Count;
                        }
                    }
                    if (arr[x] == log[h].Item2)
                    {
                        arr[x] = log[h].Item3;
                    }
                    else
                    {

                        Stop = true;
                    }
                }
                yield return ATS;
                if (token.IsCancellationRequested)
                {
                    Clear(log, x, BoxT, arr, instr, h, Stop, ATS);
                    break;
                }
            }
        }
    }
}
