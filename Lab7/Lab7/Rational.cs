using System;
using System.Collections.Generic;
using System.Text;

namespace Lab7
{
    class Rational : IComparable, IEquatable<Rational>
    {
        public int n;
        public int m;
        private string finalResult { get; set; }

        public Rational(string num)
        {
            defineFormat(num);
            finalResult = num;
        }
        public Rational(int a, int b)
        {
            n = a;
            m = b;
            finalResult = $"{n}/{m}";
        }

        public bool Equals(Rational other)
        {
            Contract();
            other.Contract();
            if (other.ToString() == null)
                return false;
            
            if (this.m == other.m && this.n == other.m)
                return true;
            
            return false;
        }

        public int CompareTo(object obj)
        {
            this.Contract();
            if (obj == null) return 1;

            Rational other = obj as Rational;
            if (other.ToString() != null)
                return (this.n * other.m).CompareTo(other.n * this.m);
            else
                return 2;
        }
        public void defineFormat(string num) //определение формата по введенной строке
        {
            int format = 2;  //по дефолту стоит 2 - для целочисленного типа
            for(int i = 0; i < num.Length; i++)
            {
                if (num[i] == '/')
                {
                    format = 0;
                    break;
                }
                else if(num[i] == '.' || num[i] == ',')
                {
                    format = 1;
                    break;
                }
            }

            //если предыдущий код не нашел ни точки, ни запятой, ни знака деления, то дальше идет проверка на "специальный" формат
            string[] s_form = num.Split(' ');
            for (int i = 0; i < s_form.Length; i++)
            {
                if(s_form[i] == "из")
                {
                    if(int.TryParse(s_form[i-1], out int type))
                    {
                        n = int.Parse(s_form[i - 1]);
                    } 
                    else if (int.TryParse(s_form[i-2], out int type2))
                    {
                        n = int.Parse(s_form[i - 2]);
                    }
                    else if (int.TryParse(s_form[i - 3], out int type3))
                    {
                        n = int.Parse(s_form[i - 3]);
                    }
                    else
                    {
                        throw new Exception();
                    }
                    m = int.Parse(s_form[i + 1]);
                    return;
                }
            }

            //далее идет разбивка (если строка с точкой(запятой) или со знаком деления)
            StringBuilder _temp = new StringBuilder();
            int pos = 0;
            for (int i = 0; i < num.Length; i++)
            {
                if (num[i] == '/' || num[i] == '.' || num[i] == ',')
                {
                    pos = i + 1;
                    break;
                }
                else
                {
                    _temp.Append(num[i]);
                }
            }
            string temp = _temp.ToString();
            int a = int.Parse(temp);   //первая часть строки, ДО точки(запятой) или знака деления

            StringBuilder _temp2 = new StringBuilder();
            for (int i = pos; i < num.Length; i++)
            {
                _temp2.Append(num[i]);
            }
            string temp2 = _temp2.ToString();
            int b = int.Parse(temp2); //ну и соотвественно та часть строки после точки(запятой) или знака деления

            if (format == 0) //если строка содержит знак деления
            {
                n = a;
                m = b;                
            } 
            else if (format == 1) //если была введена десятичная дробь
            {
                int pdten = (int)Math.Pow(10, temp2.Length);
                if (a > 0)  
                {
                    n = b + (pdten * a);
                } else
                {
                    n = b;
                }
                m = pdten;
                chooseFormat("0");
            } 
            else //если было введено целое число
            {
               n = a;
               m = 1;
            }
        }
        public int chooseFormat(string pick)
        {
            Contract();
            switch(pick)
            {
                case "0": finalResult = ((double) n / m).ToString(); break;
                case "2": finalResult = $"Всемирный конгресс математиков оценивает данную дробь на {n} из {m}"; break; 
                default: finalResult = $"{n}/{m}"; break;
            }
            return 0;
        }

        public void Contract()
        {
            for (int i = 2; i < 10; i++)
            {
                if (n % i == 0 && m % i == 0)
                {
                    n = n / i;
                    m = m / i;
                }
            }
        }
        public override string ToString()
        {
            return finalResult;
        }

        public static Rational operator +(Rational a, Rational b)
        {
            if(a.m == b.m)
            {
                return new Rational(a.n + b.n, a.m);
            } 
            else
            {
                return new Rational((a.n * b.m) + (a.m * b.n), a.m * b.m);
            }
        }

        public static Rational operator -(Rational a, Rational b)
        {
            if (a.m == b.m)
            {
                return new Rational(a.n - b.n, a.m);
            }
            else
            {
                return new Rational((a.n * b.m) - (a.m * b.n), a.m * b.m);
            }
        }

        public static Rational operator *(Rational a, Rational b)
        {
            return new Rational(a.n * b.n, a.m * b.m);
        }

        public static Rational operator /(Rational a, Rational b)
        {
            return new Rational(a.n * b.m, a.m * b.n);
        }

        public static Rational operator -(Rational a)
        {
            return new Rational(-a.n, a.m);
        }

        public static Rational operator ++(Rational a)
        {
            return new Rational(a.n + a.m, a.m);
        }

        public static bool operator >(Rational a, Rational b)
        {
            int _t = a.CompareTo(b);
            if (_t == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool operator <(Rational a, Rational b)
        {
            int _t = a.CompareTo(b);
            if (_t == -1)
            {
                return true;
            } else
            {
                return false;
            }
        }
        public static bool operator ==(Rational a, Rational b)
        {
            return a.Equals(b);
        }

        public static bool operator !=(Rational a, Rational b)
        {
            return !a.Equals(b);
        }

        public static explicit operator int(Rational a)
        {
            double _d = (double)a;
            double mod = _d - Math.Truncate(_d);
            if(mod >= 0.5)
            {
                return (a.n / a.m) + 1;
            } 
            else
            {
                return a.n / a.m;
            }
        }

        public static implicit operator Rational(double a)
        {
            return new Rational(a.ToString());
        }

        public static implicit operator Rational(int a)
        {
            return new Rational(a, 1);
        }

        public static explicit operator double(Rational a)
        {
            return (double) a.n / a.m;
        }
    }
}
