//Leetcode 355. Design Twitter med
        //题意：设计一个简化版本的 Twitter，用户可以发布推文、关注/取消关注其他用户，并能够查看用户新闻动态中最近的 10 条推文。
        //实现 Twitter 类：
        //Twitter()：初始化你的 Twitter 对象。
        //void postTweet(int userId, int tweetId)：用户 userId 发布一条新推文，推文的 ID 是 tweetId。每次调用此函数时，都会使用唯一的 tweetId。
        //List<Integer> getNewsFeed(int userId)：检索用户 userId 新闻动态中最近的 10 条推文的推文 ID。新闻动态中的每个项目必须是用户关注的用户发布的推文或用户自己发布的推文。推文必须按照最近到最旧的顺序排列。
        //void follow(int followerId, int followeeId)：followerId 关注 followeeId。
        //void unfollow(int followerId, int followeeId)：followerId 取消关注 followeeId。
        //思路：PriorityQueue, 
        //当我们调用 PostTweet、Follow 和 Unfollow 时，存储所有用户映射和数据。
        //我使用了 LinkedList，因为我想使用 AddFirst，并使用 Linq 调用来获取前 10 项。您还可以使用任何其他集合（例如列表）来实现此目的，并获取最后添加的 10 个内容。
        //GetNewsFeed 是此处更复杂的调用：
        //- 首先，获取该用户的所有关注者（如果有）。
        //- 从每个关注者（如果有）中获取最多 10 条推文，并将它们合并
        //- 合并来自关注者的所有推文后，根据“日期”将它们放入 pq 中。这只是基于一个简单的全局计数器。如果您希望最新的出现在 pq 的顶部，请将优先级乘以 -1。
        //- 现在，将用户最近的 10 条推文（如果有）添加到优先级队列中。
        //- 现在，最多迭代优先级队列 10 次。
        //- 在每次迭代时，使项目出队并将其添加到列表中。
        //时间复杂度:发布推文的时间复杂度为 O(1)。关注和取消关注用户的时间复杂度为 O(1)。获取新闻动态的时间复杂度为 O(nlogk)，其中 n 是用户关注的用户数，k 是新闻动态的大小（这里为 10）。
        //空间复杂度：用户发布的推文需要存储在 userTweets 中，空间复杂度为 O(n)。用户关注的其他用户需要存储在 userFollows 中，空间复杂度也为 O(n)。其他额外的空间复杂度为 O(1)。
        public class Twitter
        {

            internal class Tweet
            {
                public int id { get; set; }
                public int date { get; set; }
            }

            private Dictionary<int, LinkedList<Tweet>> UserTweets { get; set; }
            private Dictionary<int, HashSet<int>> UserFollowees { get; set; }
            private int GlobalTweetOrder { get; set; }

            private const int TWEET_COUNT_PER_USER = 10;

            public Twitter()
            {
                UserTweets = new Dictionary<int, LinkedList<Tweet>>();
                UserFollowees = new Dictionary<int, HashSet<int>>();
                GlobalTweetOrder = 0;
            }

            public void PostTweet(int userId, int tweetId)
            {
                if (!UserTweets.ContainsKey(userId))
                {
                    var list = new LinkedList<Tweet>();
                    var tweet = new Tweet()
                    {
                        id = tweetId,
                        date = GlobalTweetOrder
                    };
                    list.AddFirst(tweet);
                    UserTweets.Add(userId, list);
                }
                else
                {
                    UserTweets[userId].AddFirst(new Tweet()
                    {
                        id = tweetId,
                        date = GlobalTweetOrder
                    });

                }
                GlobalTweetOrder++;
            }

            public IList<int> GetNewsFeed(int userId)
            {

                var pq = new PriorityQueue<int, int>();

                if (UserFollowees.ContainsKey(userId))
                {
                    var followees = UserFollowees[userId];
                    var tweetPool = new List<Tweet>();

                    foreach (var followee in followees)
                    {
                        if (UserTweets.ContainsKey(followee))
                        {
                            var followeeTweets = UserTweets[followee].Take(TWEET_COUNT_PER_USER);
                            tweetPool.AddRange(followeeTweets);
                        }
                    }

                    foreach (var followeeTweet in tweetPool)
                    {
                        pq.Enqueue(followeeTweet.id, followeeTweet.date * -1);
                    }
                }


                if (UserTweets.ContainsKey(userId))
                {
                    var userTweets = UserTweets[userId].Take(TWEET_COUNT_PER_USER);
                    foreach (var tweet in userTweets)
                    {
                        pq.Enqueue(tweet.id, tweet.date * -1);
                    }
                }
                var finalList = new List<int>();

                while (pq.Count > 0 && finalList.Count < 10)
                {
                    finalList.Add(pq.Dequeue());
                }

                return finalList;
            }

            public void Follow(int followerId, int followeeId)
            {
                if (!UserFollowees.ContainsKey(followerId))
                {
                    UserFollowees.Add(followerId, new HashSet<int>() { followeeId });
                }
                else
                {
                    UserFollowees[followerId].Add(followeeId);
                }
            }

            public void Unfollow(int followerId, int followeeId)
            {
                if (UserFollowees.ContainsKey(followerId))
                {
                    UserFollowees[followerId].Remove(followeeId);
                }
            }
        }