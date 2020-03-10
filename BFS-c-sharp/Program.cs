using BFS_c_sharp.Model;
using System;
using System.Collections.Generic;

namespace BFS_c_sharp
{
    class Program
    {
        static void Main(string[] args)
        {
            RandomDataGenerator generator = new RandomDataGenerator();
            List<UserNode> users = generator.Generate();

            // Console.WriteLine("" + users[0] 
            //                      + users[0] + "Distance is:" 
            //                      + BreadthFirstSearch.GetMinimumDistance(users[0], users[0]));
            // Console.WriteLine("" + users[1] 
            //                      + users[28] + "Distance is:" 
            //                      + BreadthFirstSearch.GetMinimumDistance(users[1], users[28]));

            List<UserNode> friendsOfFriendsDepth1 = BreadthFirstSearch.GetFriendsOfFriends(users[0], 1);
            foreach (var friend in friendsOfFriendsDepth1)
            {
                Console.WriteLine(friend);
            }

            Console.WriteLine("<--------------------------------------------------->");
            List<UserNode> friendsOfFriendsDepth2 = BreadthFirstSearch.GetFriendsOfFriends(users[0], 2);
            foreach (var friend in friendsOfFriendsDepth2)
            {
                Console.WriteLine(friend);
            }


            // foreach (var user in users)
            // {
            //     Console.WriteLine(user);
            //     foreach (UserNode friend in user.Friends)
            //     {
            //         Console.Write(friend.FirstName +" " + friend.LastName + " | ");
            //     }
            //
            //     Console.WriteLine("");
            // }

            Console.WriteLine("Done");
            Console.ReadKey();
        }
    }
}
