namespace Less_8_Itogi_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // необходимые переменные
            string pathDir;
            int valMinutes;
            double volumeMemory = 0;
            
            Console.WriteLine("Уважаемый пользователь!");
            Console.WriteLine("Вы запустили программу очистки выбранной дериктории от неиспользованнных файлов!");
            Console.Write("Укажите путь к нужной папке: ");
            pathDir = Console.ReadLine();

            try
            {
                if (Directory.Exists(pathDir))
                {
                    Console.WriteLine("Необходимо ввести кол-во минут для нужности / ненужности файла!");
                    Console.WriteLine("Кол-во минут надо ввести как целое число!");
                    Console.Write("Введите кол-во минут: ");
                    try
                    {
                        valMinutes = Convert.ToInt32(Console.ReadLine());

                        // начинаем работать с ранее созданными классами
                        
                        // определяем кол-во занятого места изначально
                        CalculateVolume calculateVolumeOld = new CalculateVolume();
                        volumeMemory = calculateVolumeOld.calcVol(pathDir);
                        Console.WriteLine("Объем папки до удаления: {0}", volumeMemory);


                        // здесь вызов метода по удалению ненужных файлов
                        DeleteObjects deleteObjects = new DeleteObjects();
                        deleteObjects.delObj(pathDir, valMinutes);
                        Console.WriteLine("Удалено {0} файлов", deleteObjects.valDelFiles);


                        // здесь заново подсчитываем кол-во занятого места уже после очистки
                        volumeMemory = calculateVolumeOld.calcVol(pathDir);
                        Console.WriteLine("Объем папки после удаления: {0}", volumeMemory);
                    }
                    catch
                    {
                        Console.WriteLine("Вы ввели некорректное значение минут!");
                        Console.WriteLine("Нажмите любую клавишу для завершения программы!");
                        Console.ReadKey();
                    }
                }
                
                else 
                {
                    Console.WriteLine("Вы указали неверный путь до папки!");
                    Console.WriteLine("Нажмите любую клавишу для завершения программы!");
                    Console.ReadKey();
                }
            }
            
            catch
            {
                Console.WriteLine("Произошла непредвиденная ошибка! Возможно Вы ввели некорректный путь или что другое!");
                Console.WriteLine("Нажмите любую клавишу для завершения программы!");
                Console.ReadKey();
            }
        }
    }
}