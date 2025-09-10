using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq;
using System.Net.Http.Headers;
using System.Numerics;
using System.Text;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Collections;
using System.Text.RegularExpressions;
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
        //Backlogs();
        //Lottery();
        //Coding();
        //Users_access();
        //UnfairClients();

        //actors();
        //ServerAnalyzer();

        StocksMonitoring();

        Console.WriteLine("Press any key...");
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
    } //Рекурсивная сумма
    static void Raiting() 
    {
        Dictionary<string, double[]> candidates = GetCandidates();
        //ICollection<string> keys = candidates.Keys;
        //foreach (string candidate in keys) Console.WriteLine($"{candidate}, {candidates[candidate].Length}");
        foreach (string candidate in SelectedCandidates(candidates)) Console.WriteLine(candidate);
        static Dictionary<string, double[]> GetCandidates()
        {
            Dictionary<string, double[]> dict = new Dictionary<string, double[]>();
            //string candidate;
            //while ((candidate = Console.ReadLine()) != null && candidate != "")
            //{
            //    var parts = candidate.Split(',');
            //    string name = parts[0];
            //    var scores = parts.Skip(1).Select(int.Parse).ToArray();
            //    dict[name] = scores;
            //}

            dict = new Dictionary<string, double[]>()
            {
                { "Ivanov", new double[] { 5, 6, 7, 8 } },
                { "Lisii", new double[] { 9, 8, 10, 9 } },
                { "Sokolova", new double[] { 5, 6, 8, 5 }},
                { "Tritonov", new double[] { 7, 2, 3, 4 }},
                { "Chernov", new double[] { 8, 8, 8, 8 }},
                { "Svetova", new double[] { 4, 5, 3, 6 }},
                { "Zayatz", new double[] { 5, 5, 5, 5 }},
                { "Rezhik", new double[] { 6, 6, 6, 6 }}
            };
            dict = new Dictionary<string, double[]>()
            {
                { "Zuev", new double[] { 5, 1 } },
                { "Krivin", new double[] { 2, 8 } },
                { "Grilina", new double[] { 8, 8 }},
                { "Qubrick", new double[] { 9, 1 }},
                { "Tikhonova", new double[] { 8, 8 }},
                { "Svetova", new double[] { 8, 7 }},
                { "Futova", new double[] { 5, 4 }},
                { "Shestakova", new double[] { 3, 9 }}
            };
            //dict = new Dictionary<string, double[]>()
            //{
            //    { "Svetova", new double[] { 8, 7 }},
            //    { "Futova", new double[] { 5, 4 }},
            //    { "Tikhonova", new double[] { 8, 8 }},
            //    //{ "Futova", new double[] { 5, 4 }}, //гарантируется, что фамилии уникальны
            //    { "Shestakova", new double[] {2, 9 }}
            //};
            //dict = new Dictionary<string, double[]>()
            //{
            //    { "Grivin", new double[] { 4, 5, 3, 2 } },
            //    { "Goptin", new double[] { 4, 5, 5, 4 } },
            //    { "Gewink", new double[] { 4, 5, 4, 5 }},
            //    { "Guliev", new double[] { 5, 5, 5, 5 }},
            //    { "Truvin", new double[] { 7, 8, 4, 2 }},
            //    { "Devina", new double[] { 8, 1, 2, 3 }}
            //};

            return dict;
        }
        static List<string> SelectedCandidates(Dictionary<string, double[]> candidates)
        {
            List<string> result = new List<string>();
            List<Human> cands = new List<Human>();
            ICollection<string> keys = candidates.Keys;
            foreach (string candidate in keys)
            {
                double[] numbers = candidates[candidate];
                double average = Math.Round(numbers.Average(), 1); //неправильное округление!

                if (average >= 5) cands.Add(new Human(candidate, average));
            }

            cands.Sort();
            System.Globalization.CultureInfo.CurrentCulture = System.Globalization.CultureInfo.GetCultureInfo("en-US"); // или using System.Globalization;

            foreach (Human h in cands)
            {
                //Console.WriteLine($"{h.Name}, {h.Rating:F2}");
                result.Add($"{h.Name},{h.Rating:F1}");
            }

            return result;
        }
    } //Рекрутер с видеосвязью
    class Human : IComparable<Human>
    {
        public string Name { get; set; }
        public double Rating { get; set; }
        public Human(string name, double rating)
        {
            Name = name;
            Rating = rating;
        }
        public int CompareTo(Human obj)
        {
            int result = -Rating.CompareTo(obj.Rating);
            if (result == 0) result = Name.CompareTo(obj.Name);
            return result;
        }
    }
    static void DominantNumbers() 
    {
        //string stockPrices = Console.ReadLine();
        string stockPrices = "1 21 4 7 5";
        stockPrices = "1 21 3 4 5";
        stockPrices = "1 21 34 45 5";

        string dominatePrices = GetdominatePrices(stockPrices);
        Console.WriteLine(dominatePrices);

        static string GetdominatePrices(string stockPrices)
        {
            List<int> numbers = stockPrices.Split(' ').Select(Int32.Parse).ToList(); //была опечатка ранее string[] вместо string
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
        static bool checkMax(int a, List<int> lst) //была опечатка ранее boll вместо boll
        {
            bool result = true;
            foreach (int i in lst)
            {
                if (lst[a] < i) result = false;
            }
            return result;
        }
    }  //Анализ финансовых рынков
    static void checkingPasswords()
    {
        //string inputString = Console.ReadLine();
        string inputString = "Password123 mus be secure. Use 1 digi and 1 uppercase letter.";
        StringAnalyzer analyzer = new StringAnalyzer(inputString);
        int count = analyzer.CountWordsWithDigits();

        if (count == 0) Console.WriteLine("Не обнаружено");
        else Console.WriteLine(count);
    } //Проверка ряда паролей
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
    static void actors()
    {
        List<string> inputData = new List<string>() {
            "Иванов::12345::175::1980  ",
            "  Петров::12445::175::1980",
            "::12345::175::1980",
            "Сидоров::12545::85::1980",
            "Смирнов::9999::175::1980",
            "Васильев::12645::175::1929",
            "Алексеев::12745::221::1980",
            "Николаев::10000::175::2011"
        };
        inputData = new List<string>() {
            "Павлов::12345::180::1990",
            " Белов::54321::220::1930",
            "Чернов::67890::90::2010",
            "Рыжов::98765::185::1995",
            "12345::10000::170::1980",
            "Дроздов::99999::89::1990",
            "Гусев::12345::221::1990",
            "Журавлев::54321::175::1929"
        };
        inputData = new List<string>() {
            "Зайцев::12745::180::1990",
            "Волков::54421::220::1930",
            "Егоров::67890::90::2010",
            "Комаров::98765::185::1995",
            "Тихонов::10000::170::1980",
            "Савельев::99999::220::1990",
            "Филиппов::12345::180::1990",
            "Макаров::54321::180::1929"
        };
        inputData = new List<string>() {
            "Смирнов::10000::90::1930",
            "::20000::170::1980",
            "Кузнецов::99999::220::2010",
            "Лисицын::1234::180::1995",
            "Медведев::12345::89::1990",
            "0рлов::54321::221::1990",
            "Соколов::67890::175::1929",
            "Воробьев::98765::185::2011"
        };
        inputData = new List<string>() {
            "Григорьев::10001::91::1931",
            "Иванова::9999::170::1980",
            "Петрова::100000::175::1990",
            "Сидоров::12345::220::1930",
            "Николаев::54321::90::2010",
            "Федоров::123::180::1995",
            "Козлов::67890::220::1929",
            "Новиков::98765::185::2011"
        };
        inputData = new List<string>() {
            "Соловьев::12345::180::1990::563",
            "Ворона::54321::220::1930",
            "Сорока::67890::90::2010",
            "Голубь::98765::185::1995::Ведущий::201",
            "Сокол::10000::170::1980",
            "0рёл::99999::220::1990",
            "Ястреб::12345::175::1990",
            "Коршун::54321::180::1929",
            "Жаворонок::123::185::1995",
            "Чайка::67890::89::1990",
            "Лебедь::98765::221::1990",
            "Аист::10000::175::2011"
        };

        ProcessingValidateActors proc = new ProcessingValidateActors(inputData);
        List<string> approved = (List<string>)proc.PrintValidActors();

        //выводить на эхкран, вроде, не просят. Но для проверки:
        if (approved.Count > 0) foreach (string a in approved) Console.WriteLine(a);
        else Console.WriteLine("none");
    } //Подбор актёров
    public class ProcessingValidateActors
    {
        List<string> inputData;
        public ProcessingValidateActors(List<string> input)
        {
            inputData = input;
        }
        public bool ValidateActor(string actorData)
        {
            string[] data = actorData.Trim().Split("::");

            if (data.Count() == 4 &&
                data[0].Length > 0 && data[0].Length <= 40 && Regex.IsMatch(data[0], "^[А-Яа-я]+$") &&
                int.TryParse(data[1], out int x) && x >= 10000 && x <= 99999 &&
                Convert.ToInt32(data[2]) >= 172 && Convert.ToInt32(data[2]) <= 190 && Convert.ToInt32(data[3]) >= 1960 && Convert.ToInt32(data[3]) <= 1990)
            {
                //Console.WriteLine($"Кандидат подходит: ФИО: {data[0]}, ID: {data[1]}, рост: {data[2]}, год рождения: {data[3]}");
                return true;
            }
            else return false;
        }
        public IList<string> PrintValidActors()
        {
            List<string> data = new List<string>();
            List<actorData> lst = new List<actorData>();

            foreach (string str in inputData)
            {
                if (ValidateActor(str))
                {
                    string[] actorData = str.Trim().Split("::");
                    lst.Add(new actorData(actorData[0], Convert.ToInt32(actorData[1]), Convert.ToInt32(actorData[2]), Convert.ToInt32(actorData[3])));
                }
            }

            lst.Sort();

            foreach (actorData actor in lst)
            {
                data.Add($"{actor.ActorID}->({actor.LastName}:{actor.Height}:{actor.Year})");
            }
            return data;
        }
    }
    class actorData : IComparable<actorData>
    {
        public string LastName { get; set; }
        public int ActorID { get; set; }
        public int Height { get; set; }
        public int Year { get; set; }
        public actorData(string lastName, int actorID, int height, int year)
        {
            LastName = lastName;
            ActorID = actorID;
            Height = height;
            Year = year;
        }
        int IComparable<actorData>.CompareTo(actorData obj)
        {
            int result = -Height.CompareTo(obj.Height);
            if (result == 0) result = Year.CompareTo(obj.Year);
            if (result == 0) result = ActorID.CompareTo(obj.ActorID);

            return result;
        }
    }

    static void ServerAnalyzer()
    {
        /*
         Задача выполнена, но классы CorrectService и FishingService не используются и созданы формально
         Нужно понять как именно будут вводиться данные. Сейчас предполагается, что данные вводятся в консоль
         до тех пор, пока вводится пустая строка
         */

        List<string> input = new List<string>();

        string str;
        do
        {
            str = Console.ReadLine();
            input.Add(str);

        } while (str != "");

        ServerLogAnalyzer analyzer = new ServerLogAnalyzer(input);
        List<string> l = analyzer.ProcessingServerLogs();
        foreach (string line in l) Console.WriteLine(line);
    } //Подозрительная активность на сервере
    interface IWriteServiceActivity
    {
        void PrintData();
    }
    class CorrectService : IWriteServiceActivity
    {
        public void PrintData()
        {
            Console.WriteLine("!");
        }
    }
    class FishingService : IWriteServiceActivity
    {
        public void PrintData()
        {
            Console.WriteLine("!");
        }
    }
    public class ServerLogAnalyzer
    {
        List<string> input;
        public ServerLogAnalyzer(List<string> inputData)
        {
            input = inputData;
        }
        public List<string> ProcessingServerLogs()
        {
            var strings = new List<string>();
            var lst = new List<LogRecord>();

            //проверяем корректность каждой записи
            foreach (string s in input)
            {
                string[] data = s.Trim(new char[] { ' ', '<', '>' }).Split(" ");

                if (data.Length == 3 &&
                    Regex.IsMatch(data[0], @"^service=""\d*""") &&
                    Regex.IsMatch(data[1], @"^data=""\w*""") &&
                    Regex.IsMatch(data[2], @"^action=""\w*"""))
                {
                    string serviceNumber = data[0].Substring("service=".Length).Trim('"');
                    string dataString = data[1].Substring("data=".Length).Trim('"');
                    string action = data[2].Substring("action=".Length).Trim('"');

                    LogRecord rec = new LogRecord(serviceNumber, dataString, action);

                    if (int.Parse(serviceNumber) >= 10000 && int.Parse(serviceNumber) <= 99999 &&
                        Regex.IsMatch(dataString, "^[A-Z]{9}$") && (action == "read" || action == "write"))
                    {
                        lst.Add(rec);
                    }
                }
            }

            SortedDictionary<string, List<int>> readWriteCounter = new SortedDictionary<string, List<int>>(new StringComparer()); //ключ, список из целых

            foreach (LogRecord r in lst)
            {
                if (!readWriteCounter.ContainsKey(r.ServiceNumber))
                {
                    readWriteCounter.Add(r.ServiceNumber, new List<int>() { 0, 0 });
                }
                if (r.Action == "read") readWriteCounter[r.ServiceNumber][0] += 1;
                if (r.Action == "write") readWriteCounter[r.ServiceNumber][1] += 1;
            }

            if (readWriteCounter.Count > 0)
            {
                foreach (KeyValuePair<string, List<int>> kv in readWriteCounter)
                {
                    if (kv.Value[1] * 100 / (kv.Value[1] + kv.Value[0]) >= 75) strings.Add($"Alert! {kv.Key} has suspicious activity");
                    else strings.Add($"{{\"service\":\"{kv.Key}\":\"read\":{kv.Value[0]}:\"write\":{kv.Value[1]}}}");
                }
            }
            else strings.Add("none");

            return strings;
        }
    }
    class StringComparer : IComparer<string>
    {
        public int Compare(string a, string b)
        {
            return a.CompareTo(b);
        }
    }
    class LogRecord
    {
        public string ServiceNumber { get; set; }
        public string DataString { get; set; }
        public string Action { get; set; }
        public LogRecord(string serviceNumber, string dataString, string action)
        {
            ServiceNumber = serviceNumber;
            DataString = dataString;
            Action = action;
        }
    }

    static void StocksMonitoring()
    {
        //тут важно определить, что получаем на вводе: одну строку с переносами, массив строк или список
        //рассмотрим вариант с массивом строк
        string[] input = {
            "AAPL::100::UP::10:00:00",
            "AAPL::120::UP::10:05:00",
            "GOOG::200::DOWN::10:10:00",
            "AAPL::110::DOWN::10:15:00",
            "GOOG::210::UP::10:05:00",
            "MSFT::150::UP::10:20:00",
            "AAPL::115::UP::10:10:00" };

        SharePriceSystem sps = new SharePriceSystem();
        List<string> output = (List<string>)sps.ProcessingInputLines(input.ToList());
        foreach(string line in output) Console.WriteLine(line);

    }
    public class SharePriceSystem
    {
        List<Stock> stocks = new List<Stock>();
        public event EventHandler PriceUp;
        public event EventHandler PriceDown;

        public SharePriceSystem()
        {

        }
        List<string> lst = new List<string>();
        public IList<string> ProcessingInputLines(IList<string> inputLines)
        {
            List<string> inputList = (List<string>)inputLines;
            

            foreach (string line in inputList)
            {
                string[] properties = line.Split("::");
                Stock st = new Stock(properties[0], int.Parse(properties[1]), properties[2], TimeOnly.Parse(properties[3]));

                //Predicate<string> callback = new Predicate<string>(isEqual);

                if (!stocks.Any((s) => s.Name == st.Name)) //если нет в списке
                {
                    //Console.WriteLine($"{st} добавлена в список");
                    stocks.Add(st);
                }
                else
                {
                    Stock old = stocks.Find((s) => s.Name == st.Name);

                    if (old.Time < st.Time)
                    {
                        int index = stocks.IndexOf(old);
                        stocks.RemoveAt(index);
                        stocks.Insert(index, st);

                        if (st.Change == "UP")
                        {
                            PriceUp;
                        }
                        if (st.Change == "DOWN")
                        {

                        }

                    }
                    
                }

                //Console.WriteLine(st);
            }

            foreach (Stock st in stocks) Console.WriteLine(st);

            return lst;
        }
    }
    public class Stock
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public string Change { get; set; }
        public TimeOnly Time { get; set; }
        public Stock(string name, int price, string change, TimeOnly time)
        {
            Name = name;
            Price = price;
            Change = change;
            Time = time;
        }
        public override string ToString()
        {
            return $"{Name}::{Price}::{Change}::{Time:HH:mm:ss}";
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
                result.Add($"- {i.Product}: {i.Quantity}");
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
    static void Backlogs()
    {
        //string studentsInfo = Console.ReadLine();
        //string scoresInfo = Console.ReadLine();
        string studentsInfo = "Анна,Математика,75;Анна,Химия,70;Борис,Математика,75;Борис,История,80;Евгений,Математика,50;Евгений,Химия,85";
        string scoresInfo = "Математика,80;Химия,90;История,90";
        //string studentsInfo = "Анна,Психология,8;Анна,Литература,9;Борис,Обществознание,8;";
        //string scoresInfo = "Психология,8;Литература,9;Обществознание,8";

        Dictionary<string, List<int>> courseScores = new Dictionary<string, List<int>>(); //словарь - предмет, оценки
        var studentRecords = studentsInfo.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries); //массив строк по ученик,предмет,балл
        foreach (var record in studentRecords) //для каждой записи ученика
        {
            var parts = record.Split(',');
            string studentName = parts[0]; //имя ученика
            string course = parts[1]; //предмет ученика
            int score = int.Parse(parts[2]); //балл ученика по предмету
            if (!courseScores.ContainsKey(course)) //если в словаре с предметами ещё нет предмета ученика, то 
                courseScores[course] = new List<int>(); //добавляем ключ и создаём пустой список с баллами
            courseScores[course].Add(score); //добавляем баллы ученика по предмету в список
            //[Математика],[85,75,95]
            //[Химия],[90,85]
            //[История],[80]
        }
        Dictionary<string, int> passingScores = new Dictionary<string, int>(); //словарь - предмет, проходной балл
        List<string> courseOrder = new List<string>(); //список предметов в порядке проходных баллов
        var scoreRecords = scoresInfo.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
        foreach (var scoreRecord in scoreRecords) //для каждой записи предметов и проходных баллов
        {
            var parts = scoreRecord.Split(',');
            string course = parts[0];
            int passing = int.Parse(parts[1]);
            passingScores[course] = passing; //предмет, балл
            courseOrder.Add(course); //добавляем предмет в список
        }

        List<string> result = GetCoursesWithoutDebts(courseScores, passingScores, courseOrder);

        if (result.Count == 0) Console.WriteLine("Пусто");
        else
        {
            foreach (var course in result) Console.WriteLine(course);
        }

        static List<string> GetCoursesWithoutDebts(Dictionary<string, List<int>> courseScores, Dictionary<string, int> passingScores, List<string> couseOrder)
        {
            List<string> list = new List<string>();

            foreach (var subject in couseOrder)
            {
                if (courseScores[subject].Min() > passingScores[subject]) //если минимальный балл больше требуемого балл, то
                {
                    list.Add(subject);
                }
            }
            return list;
        }
    }
    static void Lottery()
    {
        string inputString = Console.ReadLine();
        //string inputString = "153";
        string result = NextSmaller(inputString);
        Console.WriteLine(result);

        static string NextSmaller(string n)
        {
            string[] combinations = makeSequences(n); //создаём комбинации из заданных циферек
            int ind = Array.IndexOf(combinations, n); //индекс элемента в массиве
            if (ind == 0) return "-1";
            else if (combinations[ind - 1][0] == '0') return "-1"; //если предыдущий элемент начинается с нуля
            else return combinations[ind - 1]; //предыдущее значение
        }
        static string[] makeSequences(string numbers)
        {
            //нужно определить количество уникальных символов, чтобы понять количество комбинаций
            Dictionary<char, int> dic = new Dictionary<char, int>();
            foreach (char ch in numbers)
            {
                if (dic.ContainsKey(ch)) dic[ch]++;
                else dic[ch] = 1;
            }
            int N = fac(numbers.Length); //общее количество комбинаций это факториал числа неповторяющихся символов (числитель формулы)
            int D = 1; //считаем знаменатель формулы перестановки с повторами
            foreach (var e in dic) D = D * fac(e.Value);
            int amount = N / D; //формула перестановки с повторяющимися элементами

            string[] combinations = new string[amount]; //список комбинаций
            int n = 0; //счётчик добавленных в массив строк
            Random rnd = new Random(); //класс для случайных чисел
            while (n < amount) //пока не заполним массив
            {
                numbers = new string(numbers.OrderBy(x => rnd.Next()).ToArray<char>()); //создаём случайную последовательность из заданных цифр
                if (!combinations.Contains(numbers))
                {
                    combinations[n] = numbers; //добасляем в массив
                    n++;
                }
            }
            combinations = combinations.Order().ToArray<string>();
            return combinations;
        }
        static int fac(int x) //факториал числа
        {
            int amount = 1;
            for (int i = 1; i < x + 1; i++) amount *= i;
            return amount;
        }
    }
    static void Coding() //ЗАДАЧА НЕ РЕШЕНА (НЕ СОВПАДАЕТ ОТВЕТ)!
    {
        //string inputString = Console.ReadLine();
        //string inputString = "аааабвв";
        string inputString = "Птицы поют утром";
        //string inputString = "Солнце светит ярко на небе";
        string encodedString = EncodeString(inputString);
        Console.WriteLine(encodedString);

        static string EncodeString(string input)
        {
            //этот метод предоставляется условием и создаёт 34 последовательных числа
            List<string> GenerateBinaryNumbers(int n)
            {
                var binaryNumbers = new List<string>();
                for (int i = 1; i <= n; i++)
                {
                    binaryNumbers.Add(Convert.ToString(i, 2));
                }
                return binaryNumbers;
            }

            string text = input.ToLower();

            List<string> bnums = GenerateBinaryNumbers(34); //получаем 34 кода для символов в порядке возрастаня сложности

            foreach (string s in bnums) Console.WriteLine(s); //вывести коды по порядку

            Dictionary<char, int> symbols = new Dictionary<char, int>(); //сохраняем сиволы строки в словарь
            foreach (char ch in text)
            {
                if (!symbols.ContainsKey(ch)) symbols.Add(ch, 1); else symbols[ch] += 1;
            }
            symbols = (from p in symbols orderby p.Value ascending, p.Key descending select p).Reverse().ToDictionary(); //словарь сортируем по частоте символов

            foreach (KeyValuePair<char, int> p in symbols) Console.WriteLine($"{p.Key}:{p.Value}"); //вывести элементы словаря символов с частотой

            Dictionary<char, string> dic = new Dictionary<char, string>();

            for (int i = 0; i < symbols.Count; i++) dic.Add(symbols.ElementAt(i).Key, bnums[i]);

            foreach (KeyValuePair<char, string> p in dic) Console.WriteLine($"{p.Key} : {p.Value}"); //вывести символы и соответствующие коды

            string coded = string.Empty;
            foreach (char ch in text) coded += dic[ch] + ' '; //пробел прибавляется для наглядности
            return coded;
        }
    }
    static void Users_access()
    {
        var userManager = new UserManager();
        var inputLines = new List<string>();
        //inputLines.Add("add_user Alice 1");
        //inputLines.Add("add_user Bob 3");
        //inputLines.Add("add_user Charlie 3");
        //inputLines.Add("promote Alice");
        //inputLines.Add("promote Alice");
        //inputLines.Add("demote Alice");
        //inputLines.Add("get_users");

        //inputLines.Add("add_user Анна 3");
        //inputLines.Add("add_user Борис 2");
        //inputLines.Add("promote Анна");
        //inputLines.Add("get_users");
        //inputLines.Add("add_user Евгений 2");

        inputLines.Add("add_user Bob 3");
        inputLines.Add("add_user Charlie 2");
        inputLines.Add("remove_user Bob");
        inputLines.Add("remove_user Charlie");
        inputLines.Add("get_users");

        //string? line;
        //while ((line = Console.ReadLine()) != null)
        //{
        //    if (line == "") break;
        //    inputLines.Add(line);
        //}
        foreach (var command in inputLines)
        {
            string[] com = command.Split(' ');
            switch (com[0])
            {
                case "add_user":
                    userManager.AddUser(com[1], Convert.ToInt32(com[2]));
                    break;
                case "remove_user":
                    userManager.RemoveUser(com[1]);
                    break;
                case "promote":
                    userManager.Promote(com[1]);
                    break;
                case "demote":
                    userManager.Demote(com[1]);
                    break;
                case "get_users":
                    userManager.GetUsers();
                    break;
            }
        }
    }
    public class UserManager
    {
        private Dictionary<string, int> users = new Dictionary<string, int>(); //словарь для хранения пользователей и их доступа
        public UserManager AddUser(string name, int level = 1)
        {
            users.Add(name, level);
            //Console.WriteLine(users.Count);
            return this;
        }
        public UserManager RemoveUser(string name)
        {
            users.Remove(name);
            //Console.WriteLine(users.Count);
            return this;
        }
        public UserManager Promote(string name)
        {
            users[name] += 1;
            //Console.WriteLine($"{name}:{users[name]}");
            return this;
        }
        public UserManager Demote(string name)
        {
            if (users[name] > 0)
            {
                users[name] -= 1;
                //Console.WriteLine($"{name}:{users[name]}");
            }
            return this;
        }
        public void GetUsers()
        {
            if (users.Count > 0)
            {
                foreach (var user in users)
                {
                    Console.WriteLine($"{user.Key}: {user.Value}");
                }
            }
            else Console.WriteLine("Не найдено");
        }
    }
    static void UnfairClients() 
    {
        var inputLines = new List<string>();
        //string line;
        //while ((line = Console.ReadLine()) != null)
        //{
        //    if (line == "") break;
        //    inputLines.Add(line);
        //}
        inputLines.Add("5 2"); //месяц и количество клиентов, ожидающих выдачу заказа (не рассматривается?)
        inputLines.Add("10001:20001:accepted:15000:01-05-2024"); //id клиента:номер заказа:действие:сумма:дата
        inputLines.Add("10002:20002:rejected:25000:15-05-2024");
        inputLines.Add("10001:20003:rejected:35000:20-05-2024");
        inputLines.Add("10003:20004:rejected:10000:15-05-2024");
        inputLines.Add("10002:20005:rejected:15000:25-05-2024");
        //inputLines.Add("7 5");
        //inputLines.Add("10041:20041:accepted:45000:01-07-2024");
        //inputLines.Add("10042:20042:accepted:50000:05-07-2024");
        //inputLines.Add("10043:20043:accepted:55000:10-07-2024");
        //inputLines.Add("10044:20044:accepted:60000:15-07-2024");
        //inputLines.Add("10045:20045:accepted:65000:20-07-2024");
        //inputLines.Add("10046:20046:accepted:70000:25-07-2024");
        //inputLines.Add("10047:20047:accepted:75000:30-07-2024");
        //inputLines.Add("10048:20048:accepted:80000:31-07-2024");

        ProscessingClientData pcd = new ProscessingClientData();
        pcd.ProcessingInputLines(inputLines);

    } //недобросовестные клиенты
    public class ClientData
    {
        public string ClientID { set; get; }
        public int totalSum { set; get; }
        public int orderCount { set; get; }


        public ClientData(string client_id, int total_sum)
        {
            ClientID = client_id;
            totalSum = total_sum;
            orderCount++;
        }
    }
    public class ProscessingClientData //класс для обработки с методом ProcessingInputLines()
    {
        IList<string> list = new List<string>();
        int NClients;
        List<ClientData> clientDatas = new List<ClientData>();
        public IList<string> ProcessingInputLines(IList<string> inputLines)
        {
            for (int i = 0; i < inputLines.Count; i++)
            {
                if (i == 0) //обработка первой строки
                {
                    NClients = int.Parse(inputLines[i].Split(' ')[1]);
                }
                else //все последующие строки
                {
                    Span<string> data = inputLines[i].Trim().Split(':'); //получаем массив строк и преобразуем его в span<string>

                    if (data.Slice(2)[0] == "accepted")
                    {
                        clientDatas.Add(new ClientData(data[0], int.Parse(data[3])));
                        //Console.WriteLine(clientDatas.Last().orderCount);
                    }
                }
            }
            return list;
        }
        //ваш код
    }
}