using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp17
{
    internal class Program
    {
        static void Main(string[] args)
        {
            String stopWorld = "nein";
            String playerName;
            String password = "0000";
            int playerGold = 0;
            String consoleColor = "Black";

            while (stopWorld != "Esc")
            {

                switch (consoleColor)
                {
                    case "Black":
                        Console.BackgroundColor = ConsoleColor.Black;
                        break;
                    case "White":
                        Console.BackgroundColor = ConsoleColor.White;
                        break;
                    case "Red":
                        Console.BackgroundColor = ConsoleColor.Red;
                        break;
                    case "Blue":
                        Console.BackgroundColor = ConsoleColor.Blue;
                        break;
                    case "Green":
                        Console.BackgroundColor = ConsoleColor.Green;
                        break;
                }

                Console.Clear();

                Console.WriteLine("Программа-меню\nВот доступные команды:\n" +
                "SetPassword - Установить пароль программы\n" +
                "ChangePassword - Поменять пароль\n" +
                "ChangeConsoleColor - Поменять цвет консоли(Red,Blue,Black,White,Green)\n" +
                "SetYourName - Установить имя пользователя(только после ввода пароля)\n" +
                "SetGold - Установить количество голды в банке(только после ввода пароля)\n" +
                "GetGold - Получить количество голды в банке(только после ввода пароля)\n" +
                "Esc - Выйти из программы");

                String playerCommand;

                Console.Write("Введите команду:");
                playerCommand = Console.ReadLine();

                switch (playerCommand)
                {
                    case "SetPassword":
                        Console.Write("Введите новый пароль:");
                        password = Console.ReadLine();
                        if(password == "0000")
                        {
                            Console.WriteLine("Данный пароль зарезервирован программой, исользуйте другой!");
                        }
                        else
                        {
                            Console.WriteLine("Новый пароль установлен!");
                        }
                    break;

                    case "ChangePassword":
                        if(password != "0000")
                        {
                            String tempPassword;
                            Console.Write("Введите предыдущий пароль:");
                            tempPassword = Console.ReadLine();

                            if (tempPassword == password)
                            {
                                Console.WriteLine("Вы успешно ввели старый пароль! Введите новый пароль:");
                                password = Console.ReadLine();
                                Console.WriteLine($"Новый пароль: {password} успешно установлен!");
                            }
                            else
                            {
                                Console.WriteLine("Вы ошиблись с вводом старого пароля! Попробуйте ещё раз!");
                            }

                        }
                        else
                        {
                            Console.WriteLine("Пароль ещё не был создан, снчала создайте пароль!");
                        }
                    break;

                    case "ChangeConsoleColor":
                        String tempConsoleColor;
                        Console.Write("Введите желаемый цвет консоли:");
                        tempConsoleColor = Console.ReadLine();
                        if (tempConsoleColor == "Black" || tempConsoleColor == "White" || tempConsoleColor == "Red"
                            || tempConsoleColor == "Blue" || tempConsoleColor == "Green")
                        {
                            consoleColor = tempConsoleColor;

                        }
                        else
                        {
                            Console.WriteLine("Введённый цвет не корректен!");
                        }
                    break;

                    case "SetYourName":
                        if (password != "0000")
                        {
                            String tempPassword;
                            Console.Write("Введите пароль:");
                            tempPassword = Console.ReadLine();

                            if (tempPassword == password)
                            {
                                Console.Write("Вы успешно ввели пароль! Введите ваше Имя:");
                                playerName = Console.ReadLine();
                            }
                            else
                            {
                                Console.WriteLine("Вы ошиблись с вводом пароля! Попробуйте ещё раз!");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Пароль ещё не был создан, снчала создайте пароль!");
                        }
                    break;

                    case "SetGold":
                        if (password != "0000")
                        {
                            String tempPassword;
                            Console.Write("Введите пароль:");
                            tempPassword = Console.ReadLine();

                            if (tempPassword == password)
                            {
                                Console.Write("Вы успешно ввели пароль! Укажите, сколько Gold вы хотите положить на счёт:");
                                playerGold = Convert.ToInt32(Console.ReadLine());
                            }
                            else
                            {
                                Console.WriteLine("Вы ошиблись с вводом пароля! Попробуйте ещё раз!");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Пароль ещё не был создан, снчала создайте пароль!");
                        }
                        break;

                    case "GetGold":
                        if (password != "0000")
                        {
                            String tempPassword;
                            Console.Write("Введите пароль:");
                            tempPassword = Console.ReadLine();

                            if (tempPassword == password)
                            {
                                Console.WriteLine($"Вы успешно ввели пароль! Ваше текущее количество Gold:{playerGold}");
                            }
                            else
                            {
                                Console.WriteLine("Вы ошиблись с вводом пароля! Попробуйте ещё раз!");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Пароль ещё не был создан, снчала создайте пароль!");
                        }
                        break;
                    case "Esc":
                        Console.WriteLine("Спасибо за использование нашей программы! До свидания!");
                        stopWorld = "Esc";
                    break;
                    default:
                        Console.WriteLine("Введённая команда не корректна! Попробуйте ещё раз!");
                    break;
                }

                Console.WriteLine("Для продолжения нажмите любую клавишу.");
                Console.ReadLine();

            }

        }
    }
}
