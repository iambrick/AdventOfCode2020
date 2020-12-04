using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace AdventOfCode
{
    class DayFour
    {

        public String FileName { get; set; }

        public DayFour()
        {
            FileName = "4input.txt";
        }

        public int CountValid()
        {
            int count = 0;
            Passport curr = new Passport();
            string[] lines = File.ReadAllLines(FileName);
            foreach (string line in lines)
            {
                if(line.Length == 0)//Check if its valid, then make a new passport
                {
                    if (curr.IsValid())
                    {
                        count++;
                    }
                    curr = new Passport();
                }
                else
                {
                    string[] splitValues = line.Split(' ');
                    foreach (string value in splitValues)
                    {
                        string[] keyValue = value.Split(':');
                        switch (keyValue[0])
                        {
                            case "byr":
                                curr.BYR = keyValue[1];
                                break;
                            case "iyr":
                                curr.IYR = keyValue[1];
                                break;
                            case "eyr":
                                curr.EYR = keyValue[1];
                                break;
                            case "hgt":
                                curr.HGT = keyValue[1];
                                break;
                            case "hcl":
                                curr.HCL = keyValue[1];
                                break;
                            case "ecl":
                                curr.ECL = keyValue[1];
                                break;
                            case "pid":
                                curr.PID = keyValue[1];
                                break;
                            case "cid":
                                curr.CID = keyValue[1];
                                break;
                            default:
                                break;
                        }
                            
                    }
                }//else
            }
            return count;
        }
    }

    class Passport
    {
        public string BYR { get; set; }
        public string IYR { get; set; }
        public string EYR { get; set; }
        public string HGT { get; set; }
        public string HCL { get; set; }
        public string ECL { get; set; }
        public string PID { get; set; }
        public string CID { get; set; }

        public Passport()
        {
            BYR = null;
            IYR = null;
            EYR = null;
            HGT = null;
            HCL = null;
            ECL = null;
            PID = null;
            CID = null;
        }

        public bool IsValid()
        {
            return BYRValid() && IYRValid() && EYRValid() && HGTValid() && HCLValid() && ECLValid() && PIDValid();
        }

        public bool BYRValid()
        {
            if (BYR == null)
                return false;
            return int.Parse(BYR) >= 1920 && int.Parse(BYR) <= 2002;
        }

        public bool IYRValid()
        {
            if (IYR == null)
                return false;
            return int.Parse(IYR) >= 2010 && int.Parse(IYR) <= 2020;
        }

        public bool EYRValid()
        {
            if (EYR == null)
                return false;
            return int.Parse(EYR) >= 2020 && int.Parse(EYR) <= 2030;
        }

        public bool HGTValid()
        {
            if (HGT == null)
                return false;
            else
            {
                string height;
                if (HGT.EndsWith("cm"))
                {
                    height = HGT.Substring(0, HGT.Length - 2);
                    return int.Parse(height) >= 150 && int.Parse(height) <= 193;
                }
                if (HGT.EndsWith("in"))
                {
                    height = HGT.Substring(0, HGT.Length - 2);
                    return int.Parse(height) >= 59 && int.Parse(height) <= 76;
                }
            }
            return false;
        }

        public bool HCLValid()
        {
            if (HCL == null)
                return false;
            else
            {
                if (HCL.Length != 7)
                    return false;
                string hexValue = HCL.Substring(1);
                char[] hexArray = hexValue.ToCharArray();
                foreach(char hex in hexArray)
                {
                    return((hex >= '0' && hex <= '9') || (hex >= 'a' && hex <= 'f'));
                    
                }
            }
            return true;
        }

        public bool ECLValid()
        {

            string[] possibleColours = { "amb", "blu", "brn", "gry", "grn", "hzl", "oth" };
            if (ECL == null)
                return false;

            bool valid = false;
            foreach(string clr in possibleColours)
            {
                if (clr.Equals(ECL))
                    valid = true;
            }
            
            return valid;
        }

        public bool PIDValid()
        {
            if (PID == null)
                return false;

            if (PID.Length != 9)
                return false;

            return true;
        }
    }
}
