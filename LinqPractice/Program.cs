using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;


namespace LinqPractice
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] names = { "Tom", "Dick", "Harry", "Mary", "Jay" };
            var query =
                from n in names
                where n.Contains("a")
                orderby n.Length
                select n.ToUpper();

            foreach (string name in query)
                WriteLine(name);

            var filterednames = names
                .Where(n => n.Length >= 4);
            foreach (string name in filterednames) WriteLine(name);

            var firstThree = names
                .ElementAt(3);
            WriteLine(firstThree);

            foreach (string name in firstThree) WriteLine(name);

            filterednames = from n in names
                            where n.Contains("a")
                            select n;

            var query = names
                .Where(n => n.Contains("a"))
                .OrderBy(n => n.Length)
                .Select(n => n.ToUpper());

            foreach (string name in query) writeline(name);

            IEnumerable<string> sortedByLength, sortedAlphabetically;
            sortedByLength = names.OrderBy(n => n.Length);
            foreach (string name in sortedByLength) WriteLine(name);
            sortedAlphabetically = names
                .OrderBy(n => n);
            foreach (string name in sortedAlphabetically) WriteLine(name);

            int[] numbers = { 10, 9, 8, 7, 6, };
            bool hasAnOddElement = numbers.Any(n => n % 2 != 0);
            WriteLine(hasAnOddElement);

            int[] numbers = { 10, 9, 8, 7, 6 };
            int firstNumber = numbers.First();
            WriteLine(firstNumber);
            int secondNumber = numbers.ElementAt(1);
            WriteLine(secondNumber);

            int[] seq1 = { 1, 2, 3 };
            int[] seq2 = { 3, 4, 5 };
            IEnumerable<int> concat = seq1.Concat(seq2);
            IEnumerable<int> union = seq1.Union(seq2);

            foreach (int i in union)
            {
                WriteLine(i);
            }

            Deferred execution:
            var numbers = new List<int>();
            numbers.Add(1);
            IEnumerable<int> query = numbers.Select(n => n * 10);
            numbers.Add(2);
            foreach (int n in query)
                Write(n + " | ");

            IEnumerable<char> query = "Not what you might expect";
            string vowels = "aeiou";
            foreach (char vowel in vowels)
                query = query.Where(c => c != vowel);
            foreach (var q in query)
                Write(q);

            IEnumerable<int> query = new int[] { 5, 12, 3 }.Where(n => n < 10)
                                                            .OrderBy(n => n)
                                                            .Select(n => n * 10);
            foreach (var q in query)
                WriteLine(q);

            string[] musicians = { "David Gilmour", "Roger Waters", "Rick Wright", "Nick Mason" };
            var query = musicians.OrderBy(m => m.Split().Last());
            foreach (var q in query)
                WriteLine(q);

            string[] names = { "Tom", "Dick", "Harry", "Mary", "Jay" };
            var outerQuery = names
                .Where(n => n.Length == names.OrderBy(n2 => n2.Length)
               .Select(n2 => n2.Length).First());
            foreach (var n in outerQuery)
                WriteLine(n);

            IEnumerable<string> outerQuery =
                from n in names
                where n.Length ==
                (from n2 in names orderby n2.Length select n2.Length).First()
                select n;
            foreach (var n in outerQuery)
                WriteLine(n);

            var query =
                from n in names
                select n.Replace("a", "").Replace("e", "").Replace("i", "")
                .Replace("o", "").Replace("u", "");
            query = from n in query where n.Length > 2 orderby n select n;
            foreach (var q in query)
                Write(q + " | ");

            var query =
                from n in names
                select n.Replace("a", "").Replace("e", "").Replace("i", "")
                .Replace("o", "").Replace("u", "")
            into noVowel
                where noVowel.Length > 2
                orderby noVowel
                select noVowel;
            foreach (var q in query)
                Write(q + " | ");

            string[] names = { "Tom", "Dick", "Harry", "Mary", "Jay" };
            var intermediate = from n in names
                               select new
                               {
                                   Original = n,
                                   Vowelless = n.Replace("a", "").Replace("e", "").Replace("i", "")
                                                       .Replace("o", "").Replace("u", "")
                               };
            var query = from item in intermediate
                        where item.Vowelless.Length > 2
                        select item.Original;
            foreach (var q in query)
                WriteLine(q);

            var query = from n in names
                        select new
                        {
                            Original = n,
                            Vowelless = n.Replace("a", "").Replace("e", "").Replace("i", "")
                                                .Replace("o", "").Replace("u", "")
                        }
                        into temp
                        where temp.Vowelless.Length > 2
                        select temp.Original;
            foreach (var q in query)
                WriteLine(q);

            var query = from n in names
                        let Vowelless = n.Replace("a", "").Replace("e", "").Replace("i", "")
                                         .Replace("o", "").Replace("u", "")
                        
                        where Vowelless.Length > 2
                        select n;
            foreach (var q in query)
                WriteLine(q);
            ReadLine();
        }
    }

    //class TempProjectionItem
    //{
    //    public string Original;
    //    public string Vowelless;

    //    static void Main()
    //    {
    //        string[] names = { "Tom", "Dick", "Harry", "Mary", "Jay" };

    //        IEnumerable<TempProjectionItem> temp =
    //            from n in names
    //            select new TempProjectionItem
    //            {
    //                Original = n,
    //                Vowelless = n.Replace("a", "").Replace("e", "").Replace("i", "")
    //                    .Replace("o", "").Replace("u", "")
    //            };
    //        var query = from item in temp
    //                    where item.Vowelless.Length > 2
    //                    select item.Original;

    //        foreach (var q in query)
    //            WriteLine(q);

    //        ReadLine();
    //    }

    //}

}
