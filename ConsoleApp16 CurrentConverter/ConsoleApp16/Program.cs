using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrentConverter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            float usd;
            float rub;
            float btc;
            String playerChoise;
            float usdToRub = 77.5f;
            float usdToBtc = 0.000026f;
            float btcToRub = (1/usdToBtc)*usdToRub;

            Console.WriteLine("Проверяем свои корманы...");
            Console.Write("Сколько у нас долларов: ");

            usd = Convert.ToSingle(Console.ReadLine());

            Console.Write("Сколько у нас рублей: ");

            rub = Convert.ToSingle(Console.ReadLine());

            Console.Write("Сколько у нас биткоинов: ");

            btc = Convert.ToSingle(Console.ReadLine());

            Console.WriteLine("С этим запасом денег идём в обменник!\n.................................");
            Console.WriteLine("Приветствую Вас в нашем обменнике валют!");
            Console.WriteLine($"Вот курс на сегодня:\nUSD\\RUB = {usdToRub}\n" +
                $"USD\\BITCOIN = {usdToBtc.ToString("F6")}\nBITCOIN\\RUB = {btcToRub}");
            Console.WriteLine("Нажмите любую клавишу что бы начать обмен.");
            Console.WriteLine("Если хотите сразу выйти, введите \"Да\".");

            playerChoise = Console.ReadLine();

            while (playerChoise != "Да")
            {
                char currencyPair;
                float changeAmount;

                Console.WriteLine($"Баланс ваших кошельков:\n1.USD = {usd}\n2.RUB = {rub}\n3.BITCOIN = {btc}");
                Console.WriteLine("Выберите валютную пару:" +
                    "\n1.USD\\RUB" +
                    "\n2.USD\\BTC" +
                    "\n3.RUB\\USD" +
                    "\n4.RUB\\BTC" +
                    "\n5.BTC\\USD" +
                    "\n6.BTC\\RUB");

                currencyPair = Convert.ToChar(Console.ReadLine()); 

                switch (currencyPair)
                {
                    case '1':
                        Console.Write("Введите кол-во USD которое хотите конвертировать в RUB:");
                        changeAmount = Convert.ToSingle(Console.ReadLine());
                        if(changeAmount <= usd)
                        {
                            float tempCurrensy = changeAmount * usdToRub;
                            usd -= changeAmount;
                            rub += changeAmount * usdToRub;
                            Console.WriteLine($"Вы успешно обменяли {changeAmount} USD на {tempCurrensy} RUB!");
                        }
                        else
                        {
                            Console.WriteLine("У вас не достаточно средств!");
                        }
                        break;
                    case '2':
                        Console.Write("Введите кол-во USD которое хотите конвертировать в BTC:");
                        changeAmount = Convert.ToSingle(Console.ReadLine());
                        if (changeAmount <= usd)
                        {
                            float tempCurrensy = changeAmount * usdToBtc;
                            usd -= changeAmount;
                            btc += changeAmount * usdToBtc;
                            Console.WriteLine($"Вы успешно обменяли {changeAmount} USD на {tempCurrensy} BTC!");
                        }
                        else
                        {
                            Console.WriteLine("У вас не достаточно средств!");
                        }
                        break;
                    case '3':
                        Console.Write("Введите кол-во RUB которое хотите конвертировать в USD:");
                        changeAmount = Convert.ToSingle(Console.ReadLine());
                        if (changeAmount <= rub)
                        {
                            float tempCurrensy = changeAmount * (1/usdToRub);
                            rub -= changeAmount;
                            usd += changeAmount * (1 / usdToRub);
                            Console.WriteLine($"Вы успешно обменяли {changeAmount} RUB на {tempCurrensy} USD!");
                        }
                        else
                        {
                            Console.WriteLine("У вас не достаточно средств!");
                        }
                        break;
                    case '4':
                        Console.Write("Введите кол-во RUB которое хотите конвертировать в BTC:");
                        changeAmount = Convert.ToSingle(Console.ReadLine());
                        if (changeAmount <= rub)
                        {
                            float tempCurrensy = changeAmount * 1/btcToRub;
                            rub -= changeAmount;
                            btc += changeAmount * 1 / btcToRub;
                            Console.WriteLine($"Вы успешно обменяли {changeAmount} RUB на {tempCurrensy} BTC!");
                        }
                        else
                        {
                            Console.WriteLine("У вас не достаточно средств!");
                        }
                        break;
                    case '5':
                        Console.Write("Введите кол-во BTC которое хотите конвертировать в USD:");
                        changeAmount = Convert.ToSingle(Console.ReadLine());
                        if (changeAmount <= btc)
                        {
                            float tempCurrensy = changeAmount * 1/usdToBtc;
                            btc -= changeAmount;
                            usd += changeAmount * 1 / usdToBtc;
                            Console.WriteLine($"Вы успешно обменяли {changeAmount} BTC на {tempCurrensy} USD!");
                        }
                        else
                        {
                            Console.WriteLine("У вас не достаточно средств!");
                        }
                        break;
                    case '6':
                        Console.Write("Введите кол-во BTC которое хотите конвертировать в RUB:");
                        changeAmount = Convert.ToSingle(Console.ReadLine());
                        if (changeAmount <= btc)
                        {
                            float tempCurrensy = changeAmount * btcToRub;
                            btc -= changeAmount;
                            usd += changeAmount * btcToRub;
                            Console.WriteLine($"Вы успешно обменяли {changeAmount} BTC на {tempCurrensy} RUB!");
                        }
                        else
                        {
                            Console.WriteLine("У вас не достаточно средств!");
                        }
                        break;
                }
                
                Console.WriteLine($"Ваш текущий баланс кошельков:\n1.USD = {usd}\n2.RUB = {rub}\n3.BITCOIN = {btc}");
                Console.WriteLine("Нажмите любую клавишу что бы продолжить обмен. Если хотите уйти, введите \"Да\". ");

                playerChoise = Console.ReadLine();
            }
            Console.WriteLine("Всего, хорошего! Заходите к нам в следующий раз!");
        }
    }
}
