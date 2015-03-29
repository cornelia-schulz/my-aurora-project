using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAuroraProject
{
    public class ForecastInfo
    {
        private string _pageContents;
        public ForecastInfo(string pageContents)
        {
            _pageContents = pageContents;
        }



        private static string getInfoBetween(string strSource, string strStart, string strEnd)
        {
            int Start, End;
            if (strSource.Contains(strStart) && strSource.Contains(strEnd))
            {
                Start = strSource.IndexOf(strStart, 0) + strStart.Length;
                End = strSource.IndexOf(strEnd, Start);
                return strSource.Substring(Start, End - Start);
            }
            else
            {
                return "No info found today";
            }
        }
    }
}
