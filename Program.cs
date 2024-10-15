namespace Zadanie_10_5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Zadanie 1
            try
            {
                Console.WriteLine("Консольный калькулятор");

                Logger logger = new Logger();//Zadanie 2

                logger.Error("Тест ошибки");//Zadanie 2

                Console.Write("Введите первое число:");
                int first = Convert.ToInt32(Console.ReadLine());

                logger.Event("Тест события");//Zadanie 2

                Console.Write("Введите второе число:");
                int second = Convert.ToInt32(Console.ReadLine());

                Calc calc = new Calc();

                long result = calc.CalcAdd(first, second);

                Console.WriteLine("Cумма " + first + " и " + second + " равна " + result + ".");
                
            }

            catch (System.DivideByZeroException)
            {
                Console.WriteLine("Ошибка:На ноль делить нельзя");
            }

            catch (Exception ex) when (ex.Message == "Ошибка в блоке if")
            {
                Console.WriteLine("Неизвестный оператор.");
            }

            catch (System.FormatException)
            {
                Console.WriteLine("Ошибка:Введите число");
            }

            catch (System.OverflowException)
            {
                Console.WriteLine("Ошибка:Введено слишком большое число");
            }

            catch (Exception ex)
            {
                Console.WriteLine("Произошла непредвиденная ошибка в приложении.");

                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.ToString());// отображение кода ошибки
            }
        }

        public interface ICalc
        {
            public long CalcAdd(int a, int b);
        }

        public class Calc : ICalc
        {
            public long CalcAdd(int a, int b)
            { return a + b; }
        }
        //Zadanie 2
        public interface ILogger
        {
            void Error(string message);
            void Event(string message);
        }

        public class Logger : ILogger
        {
            public void Error(string message) { Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine(message); Console.ForegroundColor = ConsoleColor.Gray; }
            public void Event(string message) { Console.ForegroundColor = ConsoleColor.Blue; Console.WriteLine(message); Console.ForegroundColor = ConsoleColor.Gray; }
        }


    }
}
