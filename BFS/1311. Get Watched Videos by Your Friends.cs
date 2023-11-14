//Leetcode 1311. Get Watched Videos by Your Friends med
//题意：有一个社交网络，其中每个用户都有一个 friend 列表，表示他们的朋友。视频被分为多个级别，每个级别都有一组被观看的用户。给定用户的 id 和级别 K，要找到所有观看相同级别视频的用户，并按字典顺序对结果进行排序。
//思路：BFS 进行层次遍历。根据k先找到需要找的层级，然后将这一层friends看到的所有电影存下，然后根据观看次数从小到大排序；
//时间复杂度: 假设用户总数为 N，视频总数为 M。BFS 的时间复杂度为 O(N)。对用户的 friend 列表进行排序的时间复杂度为 O(NlogN)。统计视频观看次数的时间复杂度为 O(M)。对视频进行排序的时间复杂度为 O(MlogM)。总体时间复杂度为 O(N + NlogN + M + MlogM)。
//空间复杂度：使用 HashSet 存储与目标用户直接或间接连接的用户，空间复杂度为 O(N)。使用 Queue 存储用户的 friend 列表，空间复杂度为 O(N)。使用 HashMap 存储视频的观看次数，空间复杂度为 O(M)。总体空间复杂度为 O(N + N + M)。
        public IList<string> WatchedVideosByFriends(IList<IList<string>> watchedVideos, int[][] friends, int id, int level)
        {
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(id);
            HashSet<int> visited = new HashSet<int>();
            visited.Add(id);

            while (level > 0 && queue.Count > 0)
            {
                int size = queue.Count;
                for (int i = 0; i < size; i++)
                {
                    int curr = queue.Dequeue();
                    foreach (int friend in friends[curr])
                    {
                        if (!visited.Contains(friend))
                        {
                            queue.Enqueue(friend);
                            visited.Add(friend);
                        }
                    }
                }
                level--;
            }

            Dictionary<string, int> videoCount = new Dictionary<string, int>();
            while (queue.Count > 0)
            {
                int curr = queue.Dequeue();
                foreach (string video in watchedVideos[curr])
                {
                    videoCount[video] = videoCount.GetValueOrDefault(video, 0) + 1;
                }
            }

            List<string> result = videoCount.Keys.ToList();
            result.Sort((a, b) => {
                int countA = videoCount[a];
                int countB = videoCount[b];
                return countA == countB ? a.CompareTo(b) : countA - countB;
            });

            return result;
        }
