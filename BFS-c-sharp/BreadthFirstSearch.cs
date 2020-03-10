using System;
using System.Collections.Generic;
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

                foreach (UserNode friend in userNode1.Friends)
                {
                    AddFriendToQueue(queue, friend);
                }

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

        
        
        
        
        private static void AddFriendToQueue(Queue<FriendDistance> queue, UserNode userNodeFriend)
        {
            queue.Enqueue(new FriendDistance
            {
                UserNode = userNodeFriend,
                Distance = 1
            });
        }
    }
}