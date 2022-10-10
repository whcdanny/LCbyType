957. Prison Cells After N Days	
//C#		
		public static int[] prisonAfterNDays0(int[] cells, int n)
        {
            int prev, cur;
            for (int i = 0; i < n; i++)
            {
                prev = -1;
                for (int j = 0; j < cells.Length; j++)
                {
                    cur = cells[j];
                    if (j + 1 < cells.Length && prev == cells[j + 1])
                    {
                        cells[j] = 1;
                    }
                    else
                    {
                        cells[j] = 0;
                    }
                    prev = cur;
                }
            }
            return cells;
        }
		
		public static int[] prisonAfterNDays0(int[] cells, int n)
        {            
            int count = cells.Length;
            int[] res = new int[count];
            int prison = 0;
            for (int i = 0; i < 8; i++)
            {
                if (cells[i] == 1)
                {
                    prison += 1;
                }
                prison = prison << 1;
            }
            prison = prison >> 1;
            prison = prison & 255;

            int mask = 126;
            bool[] states = new bool[256];
            bool found = false;
            bool cycle = false;
            int cycleLen = 0;
            int[] clc = new int[256];
            clc[cycleLen] = prison;
            while (n > 0)
            {
                int left = prison >> 1;
                int right = prison << 1;
                int newPrison = ((left ^ right) ^ 255) & mask;
                if (states[newPrison])
                {
                    cycle = true;
                    prison = newPrison;
                    break;
                }
                states[newPrison] = true;
                if (newPrison == prison)
                {
                    found = true;
                    break;
                }
                prison = newPrison;
                clc[++cycleLen] = prison;
                n--;

            }
            if (!found && cycle)
            {
                int offset = n % cycleLen;
                if (cycleLen == 1)
                {

                }
                else
                {
                    if (offset == 0)
                    {
                        offset = cycleLen;
                    }
                    prison = clc[offset];
                }
            }
            for (int i = 7; i > -1; i--)
            {
                if ((prison & 1) == 1)
                {
                    res[i] = 1;
                }
                prison = prison >> 1;
            }
            return res;
        }