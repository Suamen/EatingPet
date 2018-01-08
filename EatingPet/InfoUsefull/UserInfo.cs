using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EatingPet.InfoUsefull
{
    public class UserInfo
    {
    
        private int passWord;
        public string Familier;

        public int PassWord
        {
            get { return passWord; }
            set { passWord = value; }
        }
         public string Fichier (string passWord)
        {
            return  System.IO.File.ReadAllText($"{passWord}");
        }
    }
}
