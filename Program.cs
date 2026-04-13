using System;
using System.Collections.Generic;
using System.Linq;

namespace Assignment_Advacned_c_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Exercise 1: Student Grade Manager

            List<int> grades = new List<int> { 85, 92, 78, 95, 88, 70, 100, 65 };

            Console.WriteLine("Grades:");
            foreach (var g in grades)
                Console.Write(g + " ");

            Console.WriteLine($"\nCount: {grades.Count}");
            Console.WriteLine($"First: {grades.First()}");
            Console.WriteLine($"Last: {grades.Last()}");

            grades.Sort();
            Console.WriteLine("\nSorted:");
            foreach (var g in grades)
                Console.Write(g + " ");

            var firstAbove90 = grades.FirstOrDefault(g => g > 90);
            Console.WriteLine($"\nFirst > 90: {firstAbove90}");

            var failing = grades.Where(g => g < 75).ToList();
            Console.WriteLine("Failing:");
            failing.ForEach(g => Console.Write(g + " "));

            grades.RemoveAll(g => g < 75);
            Console.WriteLine("\nAfter Removing Failing:");
            grades.ForEach(g => Console.Write(g + " "));

            Console.WriteLine($"\nContains 100: {grades.Contains(100)}");

            List<string> gradeStrings = grades.Select(g => $"Grade: {g}").ToList();
            Console.WriteLine("Formatted:");
            gradeStrings.ForEach(s => Console.WriteLine(s));

            #endregion

            #region Exercise 2: Leaderboard

            SortedDictionary<int, string> leaderboard = new SortedDictionary<int, string>
            {
                {500, "Ahmed"},
                {200, "Sara"},
                {800, "Ali"},
                {350, "Mona"}
            };

            Console.WriteLine("\nLeaderboard:");
            foreach (var item in leaderboard)
                Console.WriteLine($"{item.Key} -> {item.Value}");

            Console.WriteLine($"First Key: {leaderboard.First().Key}");
            Console.WriteLine($"First Value: {leaderboard.First().Value}");

            Console.WriteLine($"Contains 500: {leaderboard.ContainsKey(500)}");

            if (leaderboard.TryGetValue(999, out string player))
                Console.WriteLine(player);
            else
                Console.WriteLine("Score 999 not found");

            leaderboard.Remove(200);
            Console.WriteLine("After Remove:");
            foreach (var item in leaderboard)
                Console.WriteLine($"{item.Key} -> {item.Value}");

            #endregion

            #region Exercise 3: Phone Book

            Dictionary<string, string> phoneBook = new Dictionary<string, string>
            {
                {"Ahmed", "010"},
                {"Sara", "011"},
                {"Ali", "012"},
                {"Mona", "013"}
            };

            phoneBook["Omar"] = "014"; // add/update

            try
            {
                phoneBook.Add("Ahmed", "999");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            bool added = phoneBook.TryAdd("Ahmed", "999");
            Console.WriteLine($"TryAdd success: {added}");

            if (!phoneBook.ContainsKey("Youssef"))
                Console.WriteLine("Not Found");

            string number = phoneBook.GetValueOrDefault("Youssef", "Not Found");
            Console.WriteLine(number);

            Console.WriteLine("Keys:");
            Console.WriteLine(string.Join(", ", phoneBook.Keys));

            Console.WriteLine("Values:");
            Console.WriteLine(string.Join(", ", phoneBook.Values));

            #endregion

            #region Exercise 4: Unique Email Validator

            HashSet<string> emails = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
            {
                "ahmed@test.com",
                "AHMED@test.com",
                "sara@test.com",
                "Sara@Test.Com"
            };

            Console.WriteLine($"Unique Emails Count: {emails.Count}");

            HashSet<int> setA = new HashSet<int> { 1, 2, 3, 4, 5 };
            HashSet<int> setB = new HashSet<int> { 4, 5, 6, 7, 8 };

            var union = new HashSet<int>(setA);
            union.UnionWith(setB);
            Console.WriteLine("Union: " + string.Join(",", union));

            var intersect = new HashSet<int>(setA);
            intersect.IntersectWith(setB);
            Console.WriteLine("Intersect: " + string.Join(",", intersect));

            var except = new HashSet<int>(setA);
            except.ExceptWith(setB);
            Console.WriteLine("Except: " + string.Join(",", except));

            Console.WriteLine($"IsSubset: {new HashSet<int> { 1, 2 }.IsSubsetOf(setA)}");

            #endregion

            #region Exercise 5: Print Queue

            Queue<string> queue = new Queue<string>();
            queue.Enqueue("Report.pdf");
            queue.Enqueue("Invoice.pdf");
            queue.Enqueue("Letter.docx");
            queue.Enqueue("Resume.pdf");
            queue.Enqueue("Photo.jpg");

            Console.WriteLine("\nQueue:");
            foreach (var doc in queue)
                Console.WriteLine(doc);

            Console.WriteLine($"Count: {queue.Count}");
            Console.WriteLine($"Next: {queue.Peek()}");

            while (queue.Count > 0)
            {
                Console.WriteLine($"Printing: {queue.Dequeue()}");
            }

            if (!queue.TryDequeue(out string result))
                Console.WriteLine("Queue is empty");

            #endregion

            #region Exercise 6: Browser History

            Stack<string> history = new Stack<string>();

            history.Push("google.com");
            history.Push("github.com");
            history.Push("stackoverflow.com");
            history.Push("youtube.com");
            history.Push("claude.ai");

            Console.WriteLine($"Current: {history.Peek()}");

            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine($"Back from: {history.Pop()}");
            }

            Console.WriteLine($"Current after back: {history.Peek()}");

            history.Clear();
            if (!history.TryPop(out string page))
                Console.WriteLine("Stack is empty");

            #endregion
        }
    }
}