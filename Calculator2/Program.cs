﻿using System;

namespace Calculator2
{
    class Program
    {
        enum Operation
        {
            init,
            max,
            min,
            sum,
            midAr,
            midGeo,
            matrixMulNum,
            matrixTransp,
            esc
        }

        static void Main(string[] args)
        {
            Operation oper;
            int[,] mas = new int[0,0];

            while (true)
            {
                oper = getOperation();

                if (oper == Operation.esc) break;
                if (oper != Operation.init && mas.Length == 0)
                {
                    Console.WriteLine("Что ты собрался делать с пустым массивом ??? Введи массив сначала");
                    continue;
                }

                switch (oper)
                {
                    case Operation.init:
                        {
                            int count,count2;
                            Console.Write("Введите размерность массива (для двумерного массива напишите размерность через пробел): ");
                            string str = Console.ReadLine();
                            string [] masStr = Console.ReadLine().Split(' ');

                            count = int.Parse(masStr[0]);
                            count2 = masStr.Length > 1 ? int.Parse(masStr[1]) : 1;
                            mas = new int[count,count2];

                            Console.Write("Введите массив указанной размерности через пробел в одну строку (двумерный массив вводить слева-направо сверху-вниз): ");
                            count = 0;
                            count2 = 0;
                            foreach (string num in Console.ReadLine().Split(' '))
                            {
                                mas[count++,count2] = int.Parse(num);
                                if (count > mas.GetLength(0))
                                {
                                    count = 0;
                                    count2++;
                                }
                            }
                        }; break;
                    case Operation.max:
                        {
                            int max = mas[0,0];
                            foreach (int elem in mas) max = elem > max ? elem : max;
                            Console.WriteLine("Максимальный элемент: " + max);
                        }; break;
                    case Operation.min:
                        {
                            int min = mas[0,0];
                            foreach (int elem in mas) if (elem < min) min = elem;
                            Console.WriteLine("Минимальный элемент: " + min);
                        }; break;
                    case Operation.sum:
                        {
                            int sum = 0;
                            foreach (int elem in mas) sum += elem;
                            Console.WriteLine("Сумма элементов массива: " + sum);
                        }
                        break;
                    case Operation.midAr:
                        {
                            int sum = 0;
                            foreach (int elem in mas) sum += elem;
                            Console.WriteLine("Среднее арифметическое массива: " + sum/mas.Length);
                        }; break;
                    case Operation.midGeo:
                        {
                            int mul = 1;
                            foreach (int elem in mas) mul *= elem;
                            Console.WriteLine("Среднее геометрическое массива: " + Math.Pow(mul, 1 / mas.Length));
                        }
                        break;
                    case Operation.matrixMulNum:
                        {
                            Console.Write("Введите число, на которое будет умножена матрица: ");
                            int num = int.Parse(Console.ReadLine());

                            for(int i = 0; i < mas.GetLength(1); i ++)
                            {
                                for (int j = 0; j < mas.GetLength(0); j++)
                                {
                                    mas[i, j] *= num;
                                    Console.Write(mas[i, j] + " ");
                                }
                                Console.WriteLine();
                            }    
                        }break;
                }
                Console.WriteLine("Нажмите любую кнопку чтобы продолжить");
                Console.ReadKey(false);
            }
            Console.Clear();
            Console.WriteLine("ВВы вышли из калькулятора");
            Console.ReadKey();
        }

        static Operation getOperation()
        {
            ConsoleKeyInfo oper;
            string operMas = "123456" + (char)ConsoleKey.Escape;

            Console.Clear();
            Console.WriteLine("Список операций:");
            Console.WriteLine("Ввод массива: 1\n" +
                              "Поиск максимума: 2\n" +
                              "Поиск минимума: 3\n" +
                              "Расчёт суммы всех чисел: 4\n" +
                              "Расчёт среднеарифметического: 5\n" +
                              "Расчёт среднегеометрического: 6\n" +
                              "Произведение матрицы на число: 7n" +
                              "Транспонирование матрицы: 8n" +
                              "Выход: esc");
            Console.WriteLine();
            Console.Write("Введите операцию из перечисленных: ");
            oper = Console.ReadKey(false);
            Console.Clear();
            while (!operMas.Contains(oper.KeyChar))
            {
                Console.Clear();
                Console.WriteLine("Вы ввели не валидную операцию!");
                Console.Write("Введите операцию из перечисленных: ");
                oper = Console.ReadKey();
            }
            switch (oper.KeyChar)
            {
                case '1': return Operation.init;
                case '2': return Operation.max;
                case '3': return Operation.min;
                case '4': return Operation.sum;
                case '5': return Operation.midAr;
                case '6': return Operation.midGeo;
                case '7': return Operation.matrixMulNum;
                case '8': return Operation.matrixTransp;
                case (char)ConsoleKey.Escape: return Operation.esc;
            }
            throw new Exception();
        }
    }
}
