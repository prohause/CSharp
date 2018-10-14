using System;
using System.Text.RegularExpressions;

namespace Problem_01
{
    class Program
    {
        static void Main(string[] args)
        {
            var lines = int.Parse(Console.ReadLine());
            var data = 0;
            for (int i = 0; i < lines; i++)
            {
                var regex = new Regex(@"^s:([^\;]+);r:([^\;]+);m--(""[a-zA-Z ]+"")");
                var matcher = regex.Match(Console.ReadLine());
                if (!matcher.Success) continue;
                var sender = matcher.Groups[1].Value;
                var receiver = matcher.Groups[2].Value;
                var message = matcher.Groups[3].Value;

                foreach (var c in sender)
                {
                    if (char.IsDigit(c))
                    {
                        data += int.Parse(c.ToString());
                    }

                    if (char.IsLetter(c)||c.Equals(' '))
                    {
                        Console.Write(c);
                    }
                    
                }
                Console.Write(" ");
                Console.Write($"says {message} to ");

                foreach (var c in receiver)
                {
                    if (char.IsDigit(c))
                    {
                        data += int.Parse(c.ToString());
                    }

                    if (char.IsLetter(c) || c.Equals(' '))
                    {
                        Console.Write(c);
                    }

                }

                Console.WriteLine();
            }

            Console.WriteLine($"Total data transferred: {data}MB");
        }
    }
}
