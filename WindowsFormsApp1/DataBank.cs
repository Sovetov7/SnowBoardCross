using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    internal static class DataBank
    {
        public static string choice; //ImportForm

        public static int countParticipantsInQual; //ImportForm

        public static string[,] qualArrayMale; //ImportForm
        public static string[,] qualArrayFemale; //ImportForm
        public static int qualArrayColumns;

        public static int countParticipantsInWeb; //DistrForm
        public static int countParticipantsInGroup; 
        public static int countGroup; 

        public static int[,] groupsQualArrayParticipants; //DistrForm

        public static string[,] tourArray; //tourWeb

    }
}
