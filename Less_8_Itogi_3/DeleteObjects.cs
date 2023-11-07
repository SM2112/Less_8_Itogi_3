using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

namespace Less_8_Itogi_3
{
    internal class DeleteObjects
    {
        // поля  класса
        
        private int intervalTimeFile;
        public int valDelFiles = 0;

        // метод класса 
        public void delObj(string strPath, int intervalTime)
        {
            string strPathDir = strPath;
            intervalTimeFile = intervalTime;

            // дополнительно проверяем есть ли по указанному пути папка
            // хотя этого можно и не делать, так как проверку мы прошли в главноем методе
            if (Directory.Exists(strPathDir))
            {

                // сначала создаем объект типа DirectoryInfo
                DirectoryInfo dirInfo = new DirectoryInfo(strPathDir);

                // создаем массив папок, которые находятся внутри верхней папки
                DirectoryInfo[] dirs = dirInfo.GetDirectories();


                // затем создаем массив файлов (это файлы в папке верхнего уровня)
                FileInfo[] files = dirInfo.GetFiles();

                //if (files.Length > 0)
                //{
                    // поля для отсечки времени
                    DateTime timeLastUse;
                    DateTime timeNow = DateTime.Now;

                    // поле для подсчета удаленнных файлов
                    int i = 0;

                    // запускаем цикл по файлам 
                    foreach (FileInfo file in files)
                    {
                        timeLastUse = file.LastAccessTime;
                        if ((timeNow - timeLastUse) > TimeSpan.FromMinutes(intervalTimeFile))
                        {
                            file.Delete();
                            i++;
                        }
                    }
                    // записываем в переменную кол-во удаленных файлов
                    valDelFiles = valDelFiles + i;
                    // Console.WriteLine("Путь к главной папке: {0}", strPathDir);

                    // а вот теперь надо запустить рекурсию  для папок ниже уровня
                    for (int count = 0; count < dirs.Length; count++)
                    {
                        delObj(strPathDir + "\\" + dirs[count].Name, intervalTimeFile);
                    }
                //}
            }
            else
            {
                Console.WriteLine("По исходному пути нужная директория не найдена!");
                Console.ReadKey();
            }

        }

    }
}
