using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KPO_System
{
    public class FileManager
    {
        public void createFile(string name)
        {
            using (FileStream fstream = File.Create(name)) { }

        }

        public bool exists(string name)
        {
            if (File.Exists(name))
            {
                return true;
            } else
            {
                return false;
            }
        }

        public int getLengthFile()
        {
            string textFromFile;
            using (FileStream fstream = File.OpenRead(@"ConnectParam.txt"))
            {
                byte[] array = new byte[fstream.Length];
                // считываем данные
                fstream.Read(array, 0, array.Length);
                // декодируем байты в строку
                textFromFile = System.Text.Encoding.Default.GetString(array);
            }
            return textFromFile.Length;
        }

        public int getLinesFile(string name)
        {
            string textFromFile;
            using (FileStream fstream = File.OpenRead(name))
            {
                byte[] array = new byte[fstream.Length];
                // считываем данные
                fstream.Read(array, 0, array.Length);
                // декодируем байты в строку
                textFromFile = System.Text.Encoding.Default.GetString(array);

            }
            string[] param = textFromFile.Split('\n');
            return param.Length;
        }

        public string[] getParam()
        {
            string[] param;
            using (FileStream fstream = File.OpenRead(@"ConnectParam.txt"))
            {
                // преобразуем строку в байты
                byte[] array = new byte[fstream.Length];
                // считываем данные
                fstream.Read(array, 0, array.Length);
                // декодируем байты в строку
                string textFromFile = System.Text.Encoding.Default.GetString(array);
                textFromFile = textFromFile.Replace("\r", string.Empty);
                param = textFromFile.Split('\n');
            }

            return param;
        }

        public void setParam(string text)
        {
            using (FileStream fstream = new FileStream(@"ConnectParam.txt", FileMode.OpenOrCreate))
            {
                fstream.SetLength(0);
                // преобразуем строку в байты
                byte[] array = System.Text.Encoding.Default.GetBytes(text);
                // запись массива байтов в файл
                fstream.Write(array, 0, array.Length);
            }
        }

        //admin

        public string getPasswd()
        {
            using (FileStream fstream = File.OpenRead(@"confp"))
            {
                byte[] array = new byte[fstream.Length];
                fstream.Read(array, 0, array.Length);
                string textFromFile = System.Text.Encoding.Default.GetString(array);

                return textFromFile;
            }
        }
        public void setPasswd(string paswd)
        {
            using (FileStream fstream = new FileStream(@"confp", FileMode.OpenOrCreate))
            {
                fstream.SetLength(0);
                byte[] array = System.Text.Encoding.Default.GetBytes(paswd);
                fstream.Write(array, 0, array.Length);

            }
        }

        //посл вход

        public string getLast()
        {
            using (FileStream fstream = File.OpenRead(@"last.txt"))
            {
                byte[] array = new byte[fstream.Length];
                fstream.Read(array, 0, array.Length);
                string textFromFile = System.Text.Encoding.Default.GetString(array);

                return textFromFile;
            }
        }

        public void setLast(string last)
        {
            using (FileStream fstream = new FileStream(@"last.txt", FileMode.OpenOrCreate))
            {
                fstream.SetLength(0);
                byte[] array = System.Text.Encoding.Default.GetBytes(last);
                fstream.Write(array, 0, array.Length);

            }
        }
    }
}
