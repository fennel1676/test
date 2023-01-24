using System;
using System.Collections.Generic;
using System.Text;

namespace GlassCreate
{
    class BatchIDMaker
    {
        private char[] batchIDChars = new char[]
		{
			'0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H',
			'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z',
		};

        private int batchIDIndex1 = 0;
        private int batchIDIndex2 = 0;

        public BatchIDMaker()
        {
        }
        public BatchIDMaker(string batchID)
        {
            if (batchID.Length == 2)
            {
                for (int i = 0; i < batchIDChars.Length; i++)
                {
                    if (batchID[0] == batchIDChars[i]) batchIDIndex1 = i;
                    if (batchID[1] == batchIDChars[i]) batchIDIndex2 = i;
                }
            }
        }

        public string Now()
        {
            return batchIDChars[batchIDIndex1].ToString() + batchIDChars[batchIDIndex2].ToString();
        }
        public string Next()
        {
            batchIDIndex2++;
            if (batchIDIndex2 >= batchIDChars.Length)
            {
                batchIDIndex2 = 0;
                batchIDIndex1++;
                if (batchIDIndex1 >= batchIDChars.Length)
                {
                    batchIDIndex1 = 0;
                }
            }
            return Now();
        }

    }
}
