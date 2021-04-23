using System;

namespace Lab7
{
    class Program
    {
        static bool checkRat(string str)
        {
            string[] s_form = str.Split(' ');
            for (int i = 0; i < s_form.Length; i++)
            {
                if (s_form[i] == "из")
                    return true;
            }
                    for (int i = 0; i < str.Length; i++)
            {
                if (int.TryParse(str.Substring(i, 1), out int type) || str[i] == '.' || str[i] == ',' || str[i] == '/' || (str[i] == 'и' && str[i+1] == 'з'))
                    continue;
                else
                    return false;
            }
            return true;
        }

        static void checkPick(ref string str, int n)
        {
            bool isPicked = false;
            while (!isPicked)
            {
                for (int i = 0; i < n; i++)
                {
                    if (str == i.ToString())
                    {
                        isPicked = true;
                    }
                }
                if (isPicked == true)
                {
                    continue;
                }
                Console.WriteLine("Неверный ввод. Выберете действие из предложенных сверху: ");
                str = Console.ReadLine();
            }
        }
       static void Main(string[] args)
        {

            Console.WriteLine("Выберите действие: ");
            Console.WriteLine("0. Представление дроби в разных форматах\n" +
                              "1. Сложение дробей\n" +
                              "2. Вычитание дробей\n" +
                              "3. Умножение дробей\n" +
                              "4. Деление дробей\n" +
                              "5. Сравнение дробей");
            string wtd = Console.ReadLine();
            bool isPicked = false;
            while(!isPicked)
            {
                if (wtd == "0" || wtd == "1" || wtd == "2" || wtd == "3" || wtd == "4" || wtd == "5")
                {
                    isPicked = true;
                    continue;
                }
                Console.WriteLine("Неверный ввод. Выберете действие из предложенных сверху: ");
                wtd = Console.ReadLine();
            }
            switch (wtd)
            {
                case "0":
                    {
                        Console.Write("Введите рациональное число: ");
                        string _ratio = Console.ReadLine();
                        while(!checkRat(_ratio))
                        {
                            Console.WriteLine("Неправильный тип числа. Повторите ввод: ");
                            _ratio = Console.ReadLine();
                        }
                        Rational ratt = new Rational(_ratio);
                        Console.Write("Выберите формат представления числа: ");
                        Console.WriteLine("\n0. Десятичная дробь\n1. Обыкновенная дробь\n2. \"Специальный\" формат :)\n3. Приведение к целочисленному типу");
                        string pick = Console.ReadLine();
                        checkPick(ref pick, 4);
                        ratt.chooseFormat(pick);
                        if (pick == "3")
                        {
                            Console.WriteLine((int)ratt);
                        }
                        else
                        {
                            ratt.chooseFormat(pick);
                            Console.WriteLine(ratt.ToString());
                        }
                        break;
                    }
                case "1":
                    {
                        Console.WriteLine("Введите первую дробь: ");
                        string _ratio1 = Console.ReadLine();
                        while (!checkRat(_ratio1))
                        {
                            Console.WriteLine("Неправильный тип числа. Повторите ввод: ");
                            _ratio1 = Console.ReadLine();
                        }
                        Rational first = new Rational(_ratio1);
                        Console.WriteLine("Введите вторую дробь: ");
                        string _ratio2 = Console.ReadLine();
                        while (!checkRat(_ratio2))
                        {
                            Console.WriteLine("Неправильный тип числа. Повторите ввод: ");
                            _ratio2 = Console.ReadLine();
                        }
                        Rational second = new Rational(_ratio2);
                        Rational result = first + second;
                        Console.Write("Выберите формат представления числа: ");
                        Console.WriteLine("\n0. Десятичная дробь\n1. Обыкновенная дробь\n2. \"Специальный\" формат :)");
                        string pick = Console.ReadLine();
                        checkPick(ref pick, 3);
                        result.chooseFormat(pick);
                        Console.WriteLine("Результат сложения: ");
                        Console.WriteLine(result.ToString());
                        break;
                    }
                case "2":
                    {
                        Console.WriteLine("Введите первую дробь: ");
                        string _ratio1 = Console.ReadLine();
                        while (!checkRat(_ratio1))
                        {
                            Console.WriteLine("Неправильный тип числа. Повторите ввод: ");
                            _ratio1 = Console.ReadLine();
                        }
                        Rational first = new Rational(_ratio1);
                        Console.WriteLine("Введите вторую дробь: ");
                        string _ratio2 = Console.ReadLine();
                        while (!checkRat(_ratio2))
                        {
                            Console.WriteLine("Неправильный тип числа. Повторите ввод: ");
                            _ratio2 = Console.ReadLine();
                        }
                        Rational second = new Rational(_ratio2);
                        Rational result = first - second;
                        Console.Write("Выберите формат представления числа: ");
                        Console.WriteLine("\n0. Десятичная дробь\n1. Обыкновенная дробь\n2. \"Специальный\" формат :)");
                        string pick = Console.ReadLine();
                        checkPick(ref pick, 3);
                        result.chooseFormat(pick);
                        Console.WriteLine("Результат вычетания: ");
                        Console.WriteLine(result.ToString());
                        break;
                    }
                case "3":
                    {
                        Console.WriteLine("Введите первую дробь: ");
                        string _ratio1 = Console.ReadLine();
                        while (!checkRat(_ratio1))
                        {
                            Console.WriteLine("Неправильный тип числа. Повторите ввод: ");
                            _ratio1 = Console.ReadLine();
                        }
                        Rational first = new Rational(_ratio1);
                        Console.WriteLine("Введите вторую дробь: ");
                        string _ratio2 = Console.ReadLine();
                        while (!checkRat(_ratio2))
                        {
                            Console.WriteLine("Неправильный тип числа. Повторите ввод: ");
                            _ratio2 = Console.ReadLine();
                        }
                        Rational second = new Rational(_ratio2);
                        Rational result = first * second;
                        Console.Write("Выберите формат представления числа: ");
                        Console.WriteLine("\n0. Десятичная дробь\n1. Обыкновенная дробь\n2. \"Специальный\" формат (:))");
                        string pick = Console.ReadLine();
                        checkPick(ref pick, 3);
                        result.chooseFormat(pick);
                        Console.WriteLine("Результат умножения: ");
                        Console.WriteLine(result.ToString());
                        break;
                    }
                case "4":
                    {
                        Console.WriteLine("Введите первую дробь: ");
                        string _ratio1 = Console.ReadLine();
                        while (!checkRat(_ratio1))
                        {
                            Console.WriteLine("Неправильный тип числа. Повторите ввод: ");
                            _ratio1 = Console.ReadLine();
                        }
                        Rational first = new Rational(_ratio1);
                        Console.WriteLine("Введите вторую дробь: ");
                        string _ratio2 = Console.ReadLine();
                        while (!checkRat(_ratio2))
                        {
                            Console.WriteLine("Неправильный тип числа. Повторите ввод: ");
                            _ratio2 = Console.ReadLine();
                        }
                        Rational second = new Rational(_ratio2);
                        Rational result = first / second;
                        Console.Write("Выберите формат представления числа: ");
                        Console.WriteLine("\n0. Десятичная дробь\n1. Обыкновенная дробь\n2. \"Специальный\" формат (:))");
                        string pick = Console.ReadLine();
                        checkPick(ref pick, 3);
                        result.chooseFormat(pick);
                        Console.WriteLine("Результат деления: ");
                        Console.WriteLine(result.ToString());
                        break;
                    }
                case "5":
                    {
                        Console.WriteLine("Введите первую дробь: ");
                        string _ratio1 = Console.ReadLine();
                        while (!checkRat(_ratio1))
                        {
                            Console.WriteLine("Неправильный тип числа. Повторите ввод: ");
                            _ratio1 = Console.ReadLine();
                        }
                        Rational first = new Rational(_ratio1);
                        Console.WriteLine("Введите вторую дробь: ");
                        string _ratio2 = Console.ReadLine();
                        while (!checkRat(_ratio2))
                        {
                            Console.WriteLine("Неправильный тип числа. Повторите ввод: ");
                            _ratio2 = Console.ReadLine();
                        }
                        Rational second = new Rational(_ratio2);
                        Console.WriteLine("Результат: ");
                        if (first == second)
                        {
                            Console.WriteLine($"{first.ToString()} = {second.ToString()}");
                        }
                        else if (first < second)
                        {
                            Console.WriteLine($"{first.ToString()} < {second.ToString()}");
                        }
                        else if (first > second)
                        {
                            Console.WriteLine($"{first.ToString()} > {second.ToString()}");
                        }
                        break;
                    }
            }
        }
    }
}
