406. Queue Reconstruction by Height
//C#
		public static int[][] ReconstructQueue(int[][] people)
        {
            List<int[]> list = new List<int[]>();
            foreach (int[] data in people)
                list.Add(data);
            list.Sort((a, b) =>
            {
                if (a[0] == b[0])
                    return a[1] - b[1]; 
                return b[0] - a[0];      
            });
            List<int[]> que = new List<int[]>();
            for (int i = 0; i < list.Count; i++)
            {
                int position = list[i][1];
                que.Insert(position, list[i]);                
            }
            return que.ToArray();
        }