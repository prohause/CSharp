using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_02
{
    class Program
    {
        static void Main(string[] args)
        {
            string input;
            var allUsers = new Dictionary<string,Dictionary<string,long>>();
            var banned = new List<string>();
            while (!(input=Console.ReadLine()).Equals("end"))
            {
                if (input.StartsWith("ban"))
                {
                    var bannedUser = input.Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)[1];
                    //banned.Add(bannedUser);
                    if (!allUsers.ContainsKey(bannedUser)) continue;
                    allUsers.Remove(bannedUser);
                    
                }
                else
                {
                    var tokens = input.Split(" -> ");
                    var user = tokens[0];
                    var tag = tokens[1];
                    var likes = long.Parse(tokens[2]);

                    if (!allUsers.ContainsKey(user))
                    {
                        allUsers.Add(user,new Dictionary<string, long>());
                    }

                    if (!allUsers[user].ContainsKey(tag))
                    {
                        allUsers[user].Add(tag,0);
                    }

                    allUsers[user][tag] += likes;
                }
            }

            foreach (var user in allUsers.OrderByDescending(p=>p.Value.Values.Sum()).ThenBy(p=>p.Value.Count))
            {
                Console.WriteLine(user.Key);
                foreach (var tag in user.Value)
                {
                    Console.WriteLine($"- {tag.Key}: {tag.Value}");
                }
            }
        }
    }
}
