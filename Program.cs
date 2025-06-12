using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq;

class Program
{
    static void Main()
    {
        //Exam();
        //Geometry();
        //SymbolsHiding();
        //Survey();
        //Raiting();
        //DominantNumbers();
        //checkingPasswords();
        //ReportMaker();


        Console.ReadKey();
    }

   

    static void Exam()
    {
        //string scoreString = Console.ReadLine();
        //string scoreName = Console.ReadLine();
        string scoreString = "60,70,34";
        string scoreName = "Marina,Vasya,Ilya";

        List<string> passedStudents = FilterPassedtudents(scoreString, scoreName);
        if (passedStudents.Count > 0)
        {
            foreach (string student in passedStudents)
            {
                Console.WriteLine($"{student}");
            }
        }
        else Console.WriteLine("Никто");

        static List<string> FilterPassedtudents(string scoreString, string scoreName)
        {
            List<string> passed = new List<string>();
            string[] scores = scoreString.Split(',');
            string[] names = scoreName.Split(',');
            for (int i = 0; i < scores.Length; i++)
            {
                if (Convert.ToInt32(scores[i]) >= 35)
                {
                    passed.Add(names[i]);
                }
            }
            return passed;
        }
    }
    static void Geometry()
    {
        //string sideString = Console.ReadLine().Trim();
        string sideString = "5 1 4";
        string answer = isRightTriangle(sideString) ? "Да" : "Нет";
        Console.WriteLine(answer);

        static bool isRightTriangle(string sideString)
        {
            string[] sidesStr = sideString.Split(' ');
            int[] sides = new int[sidesStr.Length];
            for (int i = 0; i < sidesStr.Length; i++)
            {
                sides[i] = Convert.ToInt32(sidesStr[i]);
            }
            Array.Sort(sides);
            Array.Reverse(sides);
            if (Math.Pow(sides[0], 2) == Math.Pow(sides[1], 2) + Math.Pow(sides[2], 2)) return true;
            else return false;
        }
    }
    static void SymbolsHiding()
    {
        //string stringToMask = Console.ReadLine();
        string stringToMask = "78";
        string result = Mask(stringToMask);
        Console.WriteLine(result);

        static string Mask(string stringToMask)
        {
            string newString = string.Empty;
            if (stringToMask.Length > 4)
            {
                for (int i = 0; i < stringToMask.Length; i++)
                {
                    if (i < stringToMask.Length - 4) newString += "#";
                    else newString += stringToMask[i];
                }
            }
            else newString = stringToMask;
            return newString;
        }
    }
    static void Survey()
    {
        //string inpupString = Console.ReadLine();
        string inpupString = "3";
        int result = DigitalRoot(int.Parse(inpupString));
        Console.WriteLine(result);

        static int DigitalRoot(int n)
        {
            int result = n;
            int vremResult = 0;
            do
            {
                vremResult = 0;
                for (int i = 0; i < result.ToString().Length; i++) // result = 18
                {
                    vremResult += Convert.ToInt32(result.ToString()[i].ToString());
                }
                result = vremResult;

            } while (vremResult >= 10);
            return result;
        }
    }
    static void Raiting()
    {
        Dictionary<string, int[]> candidates = GetCandidates();

        //ICollection<string> keys = candidates.Keys;
        //foreach (string candidate in keys) Console.WriteLine($"{candidate}, {candidates[candidate].Length}");

        foreach (string candidate in SelectedCandidates(candidates)) Console.WriteLine(candidate);

        static Dictionary<string, int[]> GetCandidates()
        {
            Dictionary<string, int[]> dict = new Dictionary<string, int[]>();
            string candidate;

            //while ((candidate = Console.ReadLine()) != null && candidate != "")
            //{
            //    var parts = candidate.Split(',');
            //    string name = parts[0];
            //    var scores = parts.Skip(1).Select(int.Parse).ToArray();
            //    dict[name] = scores;
            //}

            dict.Add("Ivanov", new int[] { 5, 6, 8, 5 });
            dict.Add("Lisii", new int[] { 9, 8, 10, 9 });
            dict.Add("Sokolova", new int[] { 5, 6, 8, 5 });
            dict.Add("Tritonov", new int[] { 7, 2, 3, 4 });
            dict.Add("Chernov", new int[] { 8, 8, 8, 8 });
            dict.Add("Svetova", new int[] { 4, 5, 3, 6 });
            dict.Add("Zayatz", new int[] { 5, 6, 8, 5 });
            dict.Add("Rezhik", new int[] { 6, 6, 8 });

            return dict;
        }
        static List<string> SelectedCandidates(Dictionary<string, int[]> candidates)
        {
            List<string> result = new List<string>();

            List<Human> cands = new List<Human>();

            ICollection<string> keys = candidates.Keys;
            foreach (string candidate in keys)
            {
                int[] numbers = candidates[candidate];
                double average = Math.Round(numbers.Average(), 1);

                if (average >= 5)
                {
                    cands.Add(new Human(candidate, average));
                }
                //Console.WriteLine($"Имя: {candidate}, Средний балл: {average}");
            }

            cands.Sort();
            cands.Reverse();

            CultureInfo.CurrentCulture = System.Globalization.CultureInfo.GetCultureInfo("en-US");

            foreach (Human h in cands)
            {
                //Console.WriteLine($"{h.Name}, {h.Rating:F2}");
                result.Add($"{h.Name},{h.Rating:F2}");
            }

            return result;
        }
    }
    class Human : IComparable
    {
        public string Name { get; set; }
        public double Rating { get; set; }
        public Human(string name, double rating)
        {
            Name = name;
            Rating = rating;
        }
        public int CompareTo(object obj)
        {
            Human human = obj as Human;
            return Rating.CompareTo(human.Rating);
        }
    }
    static void DominantNumbers()
    {
        //string stockPrices = Console.ReadLine();
        string stockPrices = "1 21 34 45 5";
        string dominatePrices = GetdominatePrices(stockPrices);
        Console.WriteLine(dominatePrices);

        static string GetdominatePrices(string stockPrices)
        {
            List<int> numbers = stockPrices.Split(' ').Select(Int32.Parse).ToList();
            string choosen = string.Empty;

            for (int i = 0; i < numbers.Count; i++)
            {
                int current = numbers[i];
                if (checkMax(i, numbers)) choosen += current + " ";
                numbers.RemoveAt(i);
                i--;
            }
            choosen = choosen.TrimEnd();
            return choosen;
        }
        static bool checkMax(int a, List<int> lst)
        {
            bool result = true;
            foreach (int i in lst)
            {
                if (lst[a] < i) result = false;
            }
            return result;
        }
    }
    static void checkingPasswords()
    {
        //string inputString = Console.ReadLine();
        string inputString = "Password123 mus be secure. Use 1 digi and 1 uppercase letter.";
        StringAnalyzer analyzer = new StringAnalyzer(inputString);
        int count = analyzer.CountWordsWithDigits();

        if (count == 0) Console.WriteLine("Не обнаружено");
        else Console.WriteLine(count);
    }
    class StringAnalyzer
    {
        private string text;
        public StringAnalyzer(string text)
        {
            this.text = text;
        }
        public int CountWordsWithDigits()
        {
            string[] words = text.Split(' ');
            var result = from p in words where char.IsUpper(p[0]) && p.Any(char.IsDigit) select p;
            return result.Count();
        }
    }
    static void ReportMaker()
    {
        //string inputData = Console.ReadLine();
        string inputData = "2023-03-01:Лампа:8;2023-03-20:Ключи:7;2023-04-25:Фонарь:6";
        List<string> report = GenerateMonthlyReport(inputData);
        foreach (string line in report) Console.WriteLine(line);

        static List<string> GenerateMonthlyReport(string data)
        {
            List<string> result = new List<string>(); //пока не используется
            List<Item> products = new List<Item>();

            string[] sales = data.Split(';'); //массив, содержащий все товары

            foreach (string sale in sales)
            {
                string[] dateNameAmount = sale.Split(":");
                Item item = new Item(dateNameAmount[0], dateNameAmount[1], dateNameAmount[2]);
                products.Add(item);
            }
            products = products.OrderBy(p => p.MonthNumber).ThenBy(p => p.Product).ToList();
            string currentMonth = "";
            foreach (Item i in products)
            {
                if (i.Month != currentMonth)
                {
                    currentMonth = i.Month;
                    result.Add(i.Month + ":");
                }
                result.Add($"-{i.Product}:{i.Quantity}:{i.MonthNumber}");
            }

            return result;
        }
    }
    class Item
    {
        public string Date { get; set; }
        public string Product { get; set; }
        public int Quantity { get; set; }
        public string Month
        {
            get
            {
                var months = new Dictionary<string, string>
                {
                    { "01", "Январь" },
                    { "02", "Февраль" },
                    { "03", "Март" },
                    { "04", "Апрель" },
                    { "05", "Май" },
                    { "06", "Июнь" },
                    { "07", "Июль" },
                    { "08", "Август" },
                    { "09", "Сентябрь" },
                    { "10", "Октябрь" },
                    { "11", "Ноябрь" },
                    { "12", "Декабрь" }
                };
                string m = Date.Split('-')[1];
                return months.ContainsKey(m) ? months[m] : "Неизвестный месяц";
            }
        }
        public int MonthNumber
        {
            get
            {
                return int.Parse(this.Date.Split('-')[1]);
            }
        }
        public Item(string date, string product, string quantity)
        {
            Date = date;
            Product = product;
            Quantity = int.Parse(quantity);
        }
    }

}