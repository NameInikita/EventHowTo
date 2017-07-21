using System;
using System.Threading;

namespace ConsoleApplication1
{
    class Counter
    {
        //Синтаксис по сигнатуре метода, на который мы создаем делегат: 
        //delegate <выходной тип> ИмяДелегата(<тип входных параметров>);
        //Здесь на void Message(). Он должен запуститься, когда условие выполнится.

        public delegate void MyDelegate();

        //Событие OnCountEvent c типом делегата MyDelegate.
        //синтаксис: public event <НазваниеДелегата> <НазваниеСобытия>

        public event MyDelegate OnCountEvent;

        public void CountMethod()
        {
            for (int k = 0; k < 30; k++)
            {
                Console.WriteLine(k);
                Thread.Sleep(50);

                if (k == 10)
                {
                    OnCountEvent();
                }
            }
        }
    }
    class Hendler1
    {
        public void Message()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Опа-па");
                Thread.Sleep(200);
            }
        }
    }
    class Hendler2
    {
        public void Message()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Левой, левой, раз, два, три");
                Thread.Sleep(200);
            }
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Counter count = new Counter();
            Hendler1 hen1 = new Hendler1();
            Hendler2 hen2 = new Hendler2();

            //Подписались на событие
            count.OnCountEvent += hen1.Message;
            count.OnCountEvent += hen2.Message;

            //Запускаю метод счетчик
            count.CountMethod();

            Console.ReadKey();

        }
    }
}

