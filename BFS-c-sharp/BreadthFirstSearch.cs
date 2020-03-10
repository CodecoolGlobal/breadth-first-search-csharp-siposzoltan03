using System;
using System.Collections.Generic;
using System.Linq;
using BFS_c_sharp.Model;

namespace BFS_c_sharp
{
    public class BreadthFirstSearch
    {
        private class FriendDistance
        {
            public UserNode UserNode { get; set; }
            public int Distance { get; set; }
        }

        public static int GetMinimumDistance(UserNode userNode1, UserNode userNode2)
        {
            try
            {
                if (userNode1 == userNode2)
                    throw new ArgumentException("There are no distance.");


                if (userNode1.Friends.Contains(userNode2))
                    return 1;

                Queue<FriendDistance> queue = new Queue<FriendDistance>();
                HashSet<UserNode> checkedFriends = new HashSet<UserNode>();

                SeedQueueWithRootUserFriends(userNode1, queue);

                while (queue.Count > 0)
                {
                    var friendDistance = queue.Dequeue();
                    foreach (UserNode friend in friendDistance.UserNode.Friends)
                    {
                        if (friend == userNode2)
                        {
                            return friendDistance.Distance + 1;
                        }

                        if (!checkedFriends.Contains(friend))
                        {
                            AddFriendToQueue(queue, friend);
                            checkedFriends.Add(friend);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                // throw;
            }

            return 0;
        }

        private static void SeedQueueWithRootUserFriends(UserNode user, Queue<FriendDistance> queue)
        {
            foreach (UserNode friend in user.Friends)
            {
                AddFriendToQueue(queue, friend);
            }
        }

        public static List<UserNode> GetFriendsOfFriends(UserNode user, int depth)
        {
            if (depth < 1)
            {
                throw new ArgumentOutOfRangeException($"Depth must be at least 1!");
            }

            int currentDepth = 1;
            HashSet<UserNode> friends = new HashSet<UserNode>();
            Queue<FriendDistance> watchableFriends = new Queue<FriendDistance>();
            HashSet<UserNode> watchedFriends = new HashSet<UserNode>();

            foreach (UserNode friend in user.Friends)
            {
                friends.Add(friend);
                watchedFriends.Add(friend);
                if (depth > currentDepth)
                {
                    AddFriendToQueue(watchableFriends, friend, currentDepth);
                }
            }

            while (watchableFriends.Count > 0)
            {
                var friendDistance = watchableFriends.Dequeue();
                friends.Add(friendDistance.UserNode);
                if (friendDistance.Distance < depth)
                {
                    foreach (UserNode friend in friendDistance.UserNode.Friends)
                    {
                        if (!watchedFriends.Contains(friend))
                        {
                            AddFriendToQueue(watchableFriends, friend, currentDepth + 1);
                            watchedFriends.Add(friend);
                        }
                    }
                }
            }
            return friends.ToList();
        }


        private static void AddFriendToQueue(Queue<FriendDistance> queue, UserNode userNodeFriend, int distance = 1)
        {
            queue.Enqueue(new FriendDistance
            {
                UserNode = userNodeFriend,
                Distance = distance
            });
        }
    }
}