using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Less_8_Itogi_3
{
    internal class CalculateVolume
    {
        // метод класса
        public long calcVol(string pathDir)
        {
            // объявляем переменную для подсчета памяти
            long volMemory = 0;

            // объвляем объект DirectoryInfo
            DirectoryInfo dirObject = new DirectoryInfo(pathDir);

            // создаем массив папок по укзанному пути
            DirectoryInfo[] dirs = dirObject.GetDirectories();

            // создаем массив файлов по указанному пути
            FileInfo[] files = dirObject.GetFiles();

            // запускаем цикл по файлам в верхней папке
            foreach (FileInfo file in files)
            {
                volMemory = volMemory + file.Length;
            }

            // а вот теперь нужна рекурсия для просмотра файлов в папках более низкого уровня
            for (int count = 0; count < dirs.Length; count++)
            {
                volMemory = volMemory + calcVol(pathDir + "\\" + dirs[count].Name);
            }
            return volMemory;
        }
    }
}
