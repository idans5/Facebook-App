using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DP_HIT_2020A_Ex03.CommandFolder
{
    public class Menu : List<MenuItem>
    {
        public void StringAnalysisAndRunFunction(string i_Type)
        {
            foreach(MenuItem item in this)
            {
                if(item.Text == i_Type)
                {
                    item.CommandDeleage?.Invoke();
                }
            }
        }
    }
}
