using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FightWithBoss
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int stepCounter = 0;

            Random random = new Random();
            bool isPlayerMakeAction;
            int playerMinHealth = 15000;
            int playerMaxHealth = 20000;
            int playerHealth = random.Next(playerMinHealth, playerMaxHealth);
            int playerCurrentHealth = playerHealth;
            int playerMinDamage = 2000;
            int playerMaxDamage = 5000;
            int playerDamage = random.Next(playerMinDamage, playerMaxDamage);
            int playerArmor = 25;
            float playerArmorProcent = (100 - playerArmor) / 100;
            int playerMana = 1000;
            int playerCurrentMana = playerMana;
            byte playerChoice;
            int playerMinPassiveHealthRegen = 150;
            int playerMaxPassiveHealthRegen = 200;
            int playerPassiveHealthRegen = random.Next(playerMinPassiveHealthRegen, playerMaxPassiveHealthRegen);
            int playerMinPassiveManaRegen = 50;
            int playerMaxPassiveManaRegen = 100;
            int playerPassiveManaRegen = random.Next(playerMinPassiveManaRegen, playerMaxPassiveManaRegen);

            bool isArmorgedonUsing = false;
            int armorgedonBonusArmor = 25;
            int armorgedonTry = 3;
            int armorgedonStepDuration = 3;
            int armorgedonReloading = 5;
            int armorgedonStepCounter = -5;
            int armorgedonManaCost = 150;

            bool isSaintShieldUsing = false;
            bool isSaintShieldIsUsed = false;
            int saintShieldManaCost = 300;
            int saintShieldArmorBonus = 100;
            int saintShiledBuferArmor = playerArmor;

            int saintStrikeManaCost = 100;
            float saintStrikeDamageMultiplier = 1.5f;

            bool isSaintSactifaceUsing = false;
            int saintSactifaceDamageMultiplier = 2;
            int saintSacrifaceManaCost = 400;
            int saintSacrifaceHealthCost = 100;

            bool isGodArmorBlessingUsing = false;
            int godArmorBlessingLimit = 50;
            int godArmorBlessingManaCost = 800;
            int godArmorBlessingUp = 1;
            int godArmorBlessingMinChance = 0;
            int godArmorBlessingMaxChance = 3;

            int isSaintHealingManaCostUsing = 600;
            
            int saintHealingMin = 1800;
            int saintHealingMax = 3500;

            int bossMinHealth = 160000;
            int bossMaxHealth = 200000;
            int bossHealth = random.Next(bossMinHealth, bossMaxHealth);
            int bossMinBossDamage = 1000;
            int bossMaxBossDamage = 2000;
            int bossDamage = random.Next(bossMinBossDamage, bossMaxBossDamage);
            int bossMinArmor = 10;
            int bossMaxArmor = 15;
            int bossArmor = random.Next(bossMinArmor, bossMaxArmor);
            float bossArmorPercent = (100 - bossArmor) / 100;
            int bossMinMana = 400;
            int bossMaxMana = 500;
            int bossMana = random.Next(bossMinMana, bossMaxMana);
            int bossMinHpInfo = 3;
            int bossMaxHpInfo = 6;
            int bossHpInfo = random.Next(bossMinHpInfo, bossMaxHpInfo);
            int bossHpInfoStep = random.Next(bossMinHpInfo, bossMaxHpInfo);

            bool isBossToxicStrikeUsing = false;
            int bossToxicStrikeCooldawn = 2;
            int bossToxicStrikeArmorDamage = 10;
            int bossToxicStrikeManaCost = 30;
            int bossToxicStrikeStepCounter = bossToxicStrikeCooldawn;

            bool isBossBonesArmorUsing = false;
            int bossBonesArmorValue = 10;
            int bossBonesArmorCooldawn = 5;
            int bossBonesArmorManaCost = 30;
            int bossBonesArmorStepCounter = bossBonesArmorCooldawn;

            float damageSpikesCoefficient = 0.1f;         
            
            Console.WriteLine("Извилистая дорога выводит вас в логово матери-пауков, Ильмеры.");
            Console.WriteLine("Вы - Палладин Оакис, поклявшийся истребить зло!");
            Console.WriteLine("В порыве праведной ярости вы бросате вызов злобной паучихе!");
            Console.WriteLine("Нажмите любую клавишу для начала боя!");
            Console.ReadLine();

            while (playerCurrentHealth > 0 && bossHealth > 0)
            {
                stepCounter++;

                Console.Clear();
                Console.BackgroundColor = ConsoleColor.Green;
                Console.WriteLine($"HP: {playerCurrentHealth}\\{playerHealth}");
                Console.BackgroundColor = ConsoleColor.Blue;
                Console.WriteLine($"MP: {playerCurrentMana}\\{playerMana}");
                Console.BackgroundColor = ConsoleColor.Black;
                Console.WriteLine($"ATK: {playerDamage}\nDEF: {playerArmor}");
                Console.WriteLine($"Вы востанавливаете по {playerPassiveHealthRegen}HP и {playerPassiveManaRegen}MP каждый ход");
                Console.WriteLine("Текущие активные эффекты:");

                Console.BackgroundColor= ConsoleColor.Yellow;
                if (isArmorgedonUsing)
                    Console.WriteLine($"Armogedon(+{armorgedonBonusArmor}Def)");
                if (isSaintSactifaceUsing)
                    Console.WriteLine($"Святая жертвенность(-{saintSacrifaceHealthCost}HP\\ход, +100% урона)");
                if (isGodArmorBlessingUsing)
                    Console.WriteLine($"Вы получаете {godArmorBlessingUp}Def каждый ход, вплоть до {godArmorBlessingLimit}Def");
                Console.WriteLine();
                Console.BackgroundColor = ConsoleColor.Black;

                if (stepCounter == bossHpInfo)
                {
                    Console.WriteLine($"В прошлом раунде вы узнали, что у Босса осталось {bossHealth}HP!\n");
                    bossHpInfo += bossHpInfoStep;
                }
                else
                {
                    Console.WriteLine("Вы не знаете параметров босса, но в процессе боя, вы будете опытным путём\nдобывать информацию!" +
                    "Будте внимательны и следите за подсказками!\n");
                }

                Console.WriteLine("За ход вы можете совершить только одно действие!");

                Console.WriteLine($"Выберите действие:");
                Console.WriteLine($"1.Обычная атака, наносит {playerDamage} урона.");

                if (armorgedonTry > 0 && armorgedonStepCounter <= (armorgedonStepDuration - armorgedonReloading))
                {
                    Console.WriteLine($"2.Armorgedon({armorgedonManaCost}MP, активное) - даёт {armorgedonBonusArmor} брони на {armorgedonStepDuration} хода." +
                        $" Можно использовать {armorgedonTry} раз(а).");
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.WriteLine($"2.Armorgedon({armorgedonManaCost}MP, активное) - даёт {armorgedonBonusArmor} брони на {armorgedonStepDuration} хода. " +
                        $"Можно использовать {armorgedonTry} раз(а).");
                    Console.BackgroundColor = ConsoleColor.Black;
                }

                if (isArmorgedonUsing == false && isSaintShieldIsUsed == false)
                {
                    Console.WriteLine($"3.Святой щит({saintShieldManaCost}MP, активное) - один раз блокирующий входящий урон, нельзя использовать если активен Armorgedon");
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.WriteLine($"3.Святой щит({saintShieldManaCost}MP, активное) - один раз блокирующий входящий урон, нельзя использовать если активен Armorgedon");
                    Console.BackgroundColor = ConsoleColor.Black;
                }

                if (isSaintSactifaceUsing == false)
                {
                    Console.WriteLine($"4.Святой удар({saintStrikeManaCost}MP, активное) - наносит x{saintStrikeDamageMultiplier} повреждений, нельзя использвать если активна Святая жертвенность");
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.WriteLine($"4.Святой удар({saintStrikeManaCost}MP, активное) - наносит x{saintStrikeDamageMultiplier} повреждений, нельзя использвать если активна Святая жертвенность");
                    Console.BackgroundColor = ConsoleColor.Black;
                }
                if (isSaintSactifaceUsing)
                {
                    Console.BackgroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"5.Святая жертвенность({saintSacrifaceManaCost}MP, {saintSacrifaceHealthCost}HP каждый ход, включаемое) - увеличивает урон в {saintSactifaceDamageMultiplier} раза, пока активно.\n" +
                    $"Повторное использование деактивирует Святую жертвенность");
                    Console.BackgroundColor = ConsoleColor.Black;
                }
                else
                {
                    Console.WriteLine($"5.Святая жертвенность({saintSacrifaceManaCost}MP, {saintSacrifaceHealthCost}HP каждый ход, включаемое) - увеличивает урон в {saintSactifaceDamageMultiplier} раза, пока активно.\n" +
                    $"Повторное использование деактивирует Святую жертвенность");
                }
                
                if (isGodArmorBlessingUsing)
                {
                    Console.BackgroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"6.Благословение Бога Брони({godArmorBlessingManaCost}MP, пассивное) - после каста имеет 30% шанс увеличить броню на 1 каждый ход.\n" +
                    $"Вплоть до {godArmorBlessingLimit} брони.");
                    Console.BackgroundColor = ConsoleColor.Black;

                }
                else
                {
                    Console.WriteLine($"6.Благословение Бога Брони({godArmorBlessingManaCost}MP, пассивное) - после каста имеет 30% шанс увеличить броню на 1 каждый ход.\n" +
                    $"Вплоть до {godArmorBlessingLimit} брони.");
                }
                
                Console.WriteLine($"7.Святое исцеление({isSaintHealingManaCostUsing}MP, активное) - Восстанавливает от {saintHealingMin} до {saintHealingMax} здоровья игроку.");

                playerChoice = Convert.ToByte(Console.ReadLine());
                isPlayerMakeAction = false;

                switch (playerChoice)
                {
                    case 1:
                        {
                            int playerTempDamage = (int)(playerDamage * bossArmorPercent);
                            int damageSpikes = (int)(playerTempDamage * damageSpikesCoefficient * playerArmorProcent);

                            if (isSaintSactifaceUsing == false)
                            {
                                playerCurrentHealth -= damageSpikes;
                                bossHealth -= playerTempDamage;
                                Console.WriteLine($"Вы успешно нанесли боссу {playerTempDamage} урона!");
                                Console.WriteLine($"Вы получили {damageSpikes} урона!");
                            }
                            else
                            {
                                playerTempDamage *= saintSactifaceDamageMultiplier;
                                bossHealth -= playerTempDamage;
                                Console.WriteLine($"Засчёт активной Святой Жертвенности вы успешно нанесли боссу {playerTempDamage} урона!");
                            }

                            isPlayerMakeAction = true;
                            break;
                        }
                    case 2:
                        {
                            if (isArmorgedonUsing == false)
                            {
                                if (armorgedonTry > 0)
                                {
                                    if (armorgedonStepCounter <= armorgedonStepDuration - armorgedonReloading)
                                    {
                                        if (playerCurrentMana - armorgedonManaCost >= 0)
                                        {
                                            playerCurrentMana-=armorgedonManaCost;
                                            playerArmor += armorgedonBonusArmor;
                                            isArmorgedonUsing = true;
                                            armorgedonStepCounter = armorgedonStepDuration;
                                            armorgedonTry -= 1;
                                            Console.WriteLine($"Вы успешно использовали Armorgedon и добавили себе {armorgedonBonusArmor}DEF!");
                                            isPlayerMakeAction = true;
                                        }
                                        else
                                        {
                                            Console.WriteLine("У вас не достаточно маны для использования Armorgedon-a!");
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine($"Ещё не прошло {armorgedonReloading} ходов с послднего использвания!");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("У вас закончились использования!");
                                }    
                            }
                            else
                            {
                                Console.WriteLine("Умение уже активно!");
                            }
                            break;
                        }
                    case 3:
                        {
                            if(isSaintShieldUsing == false && isSaintShieldIsUsed == false)
                            {
                                if(playerCurrentMana - saintStrikeManaCost >= 0)
                                {
                                    saintShiledBuferArmor = playerArmor;
                                    playerArmor = saintShieldArmorBonus;
                                    isSaintShieldUsing = true;
                                    isSaintShieldIsUsed = true;
                                    playerCurrentMana -= saintShieldManaCost;
                                    Console.WriteLine("Вы успешно использовали Святой Щит! В этом раунде вы защищены от всего урона!");
                                    isPlayerMakeAction = true;
                                }
                                else
                                {
                                    Console.WriteLine("У вас недостаточно маны для использования Святого Щита!");
                                }
                                
                            }
                            else
                            {
                                Console.WriteLine("Вы уже использовали Святой Щит!");
                            }
                            break;
                        }
                    case 4:
                        {
                            if (isSaintSactifaceUsing == false)
                            {
                                if(playerCurrentMana - saintStrikeManaCost >= 0)
                                {
                                    int playerTempDamage = (int)(playerDamage * saintStrikeDamageMultiplier * bossArmorPercent);
                                    bossHealth -= playerTempDamage;
                                    playerCurrentMana -= saintStrikeManaCost;
                                    Console.WriteLine($"Вы успешно использовали Святой Удар! Вы нанесли {playerTempDamage} урона боссу!");
                                    isPlayerMakeAction = true;
                                }
                                else
                                {
                                    Console.WriteLine("У вас не достаточно маны!");
                                }
                                
                            }
                            else
                            {
                                Console.WriteLine("Вы не можете использовать Святой Удар при активной Святой Жертвенности!");
                            }    
                            break;
                        }
                    case 5:
                        {
                            if (isSaintSactifaceUsing == false)
                            {
                                if (playerCurrentMana - saintSacrifaceManaCost >= 0)
                                {
                                    playerCurrentMana -= saintSacrifaceManaCost;
                                    isSaintSactifaceUsing = true;
                                    Console.WriteLine($"Вы успешно использовали Святую Жертвенность! Ваши обычные атаки наносят в {saintSactifaceDamageMultiplier} раза больше урона!\n" +
                                        $"Внимание, вы теряете {saintSacrifaceHealthCost} каждый ход!");
                                    isPlayerMakeAction = true;
                                }
                                else
                                {
                                    Console.WriteLine("Вам не хватает маны для использования Святой Жертвенности!");
                                }
                            }
                            else
                            {
                                isSaintSactifaceUsing = false;
                                Console.WriteLine("Деактивируем Святую Жертвенность!");
                            }
                            break;
                        }
                    case 6:
                        {
                            if(isGodArmorBlessingUsing == false)
                            {
                                if(playerCurrentMana - godArmorBlessingManaCost >= 0)
                                {
                                    playerCurrentMana -= godArmorBlessingManaCost;
                                    isGodArmorBlessingUsing = true;
                                    Console.WriteLine($"Боги услышали вашу молитву! Вы получаете Благословение Бога Брони!");
                                    isPlayerMakeAction = true;
                                }
                                else
                                {
                                    Console.WriteLine("У вас не достаточно маны!");
                                }                               
                            }
                            else
                            {
                                Console.WriteLine("Благословение Бога Брони уже активно!");
                            }
                            break;
                        }
                    case 7:
                        {
                            if(playerCurrentMana - isSaintHealingManaCostUsing >= 0)
                            {
                                playerCurrentMana -= isSaintHealingManaCostUsing;
                                int saintHealing = random.Next(saintHealingMin, saintHealingMax);
                                if(playerHealth - playerCurrentHealth <= saintHealing)
                                {
                                    saintHealing = playerHealth - playerCurrentHealth;
                                }
                                else
                                {
                                    playerCurrentHealth += saintHealing;
                                }
                                Console.WriteLine($"Вы успешно использовали Святое Исцеление и  востановили {saintHealing}HP!");
                                isPlayerMakeAction = true;
                            }
                            else
                            {
                                Console.WriteLine("У вас недостаточно маны для использования Святого Исцеления!");
                            }
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Такого действия нету! Попробуйте ещё раз.");
                            break;
                        }
                }

                if (isPlayerMakeAction == true)
                {

                    int bossToxicStrikeChance = random.Next(0, 5);
                    if (bossMana > bossToxicStrikeManaCost && !isBossToxicStrikeUsing && bossToxicStrikeChance == 0)
                    {
                        int bossToxicStrikeDamage;
                        isBossToxicStrikeUsing = true;
                        bossToxicStrikeStepCounter = bossToxicStrikeCooldawn;
                        playerArmor -= bossToxicStrikeArmorDamage;
                        bossToxicStrikeDamage = (int)(bossDamage * playerArmorProcent);
                        playerCurrentHealth -= bossToxicStrikeDamage;
                        Console.WriteLine($"Босс нанёс вам {bossToxicStrikeDamage} урона и снизил вашу броню на {bossToxicStrikeArmorDamage}!");
                    }

                    if(bossToxicStrikeStepCounter == 0)
                    {
                        isBossToxicStrikeUsing = false;
                        playerArmor += bossToxicStrikeArmorDamage;
                        bossToxicStrikeStepCounter--;
                        Console.WriteLine($"Вы чуствуете что ваша броня восстанавливается! Вы возвращаете себе {bossToxicStrikeArmorDamage} утраченной после атаки босса!");
                    }

                    if (isBossToxicStrikeUsing)
                        bossToxicStrikeStepCounter--;

                    int bossBonesArmorChance = random.Next(0, 4);
                    if (bossMana > bossBonesArmorManaCost && !isBossBonesArmorUsing && bossBonesArmorChance == 0)
                    {
                        isBossBonesArmorUsing = true;
                        bossBonesArmorStepCounter = bossBonesArmorCooldawn;
                        bossArmor += bossBonesArmorValue;
                    }

                    if (bossBonesArmorStepCounter == 0)
                    {
                        isBossBonesArmorUsing = false;
                        bossBonesArmorStepCounter--;
                    }

                    if (isBossBonesArmorUsing)
                        bossBonesArmorStepCounter--;

                    int bossCurrentDamage = (int)(bossDamage * playerArmorProcent);
                    playerCurrentHealth -= bossCurrentDamage;
                    Console.WriteLine($"Босс нанёс вам {bossCurrentDamage}!");

                    if (armorgedonStepCounter == -100)
                    {
                        armorgedonStepCounter = armorgedonStepDuration - armorgedonReloading;
                    }

                    armorgedonStepCounter--;

                    if (armorgedonStepCounter == 0)
                    {
                        isArmorgedonUsing = false;
                        playerArmor -= armorgedonBonusArmor;
                    }

                    if (isSaintShieldUsing == true && isSaintShieldIsUsed == true)
                    {
                        isSaintShieldUsing = false;
                        playerArmor = saintShiledBuferArmor;
                    }

                    if(isSaintSactifaceUsing == true)
                    {
                        playerCurrentHealth -= saintSacrifaceHealthCost;
                    }

                    if(isGodArmorBlessingUsing == true && ((isArmorgedonUsing == false && playerArmor < 50) || (isArmorgedonUsing == true && playerArmor < (50 - armorgedonBonusArmor))))
                    {
                        int armorUpChance = random.Next(godArmorBlessingMinChance, godArmorBlessingMaxChance);
                        if (armorUpChance == godArmorBlessingMinChance)
                        {
                            playerArmor += godArmorBlessingUp;
                            Console.WriteLine($"Боги благословили вас и даровали вам {godArmorBlessingUp} брони!");
                        }
                    }

                    if (playerHealth - playerCurrentHealth > playerPassiveHealthRegen)
                    {
                        playerCurrentHealth += playerPassiveHealthRegen;
                    }
                    else
                    {
                        playerCurrentHealth = playerHealth;
                    }

                    if (playerMana - playerCurrentMana > playerPassiveManaRegen)
                    {
                        playerCurrentMana += playerPassiveManaRegen;
                    }
                    else
                    {
                        playerCurrentMana = playerMana;
                    }
                }
                Console.ReadLine();
            }

            if (playerCurrentHealth <= 0 && bossHealth <= 0)
            {
                Console.WriteLine($"Сражение длилось несколько дней, и под конец Оакис и Ильмера упали замертво! Оба!\n" +
                    $"Доблестный паладин пал в бою, забрав с собой в могилу злобную паучиху!");
            }
            else if (playerCurrentHealth <= 0)
            {
                Console.WriteLine($"Оакис пал в бою честью Храбрых! Злобная Ильмера одержала верх, над силами света!\n" +
                    $"Но не слишком торжествуй, Ильмера! Ибо по стопам Оакиса придут другие и повергнут тебя во тьму!");
            }
            else if (bossHealth <= 0)
            {
                Console.WriteLine($"Оакис сражался с Ильмерой не на жизнь, а на смерть! В итоге злобная паучиха обессилила и пала мёртвой!" +
                    $"Победа досталась силам света!");
            }
        }
    }
}
