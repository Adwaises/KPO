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
        public void createFileParam()
        {
            using (FileStream fstream = File.Create(@"ConnectParam.txt")) { }

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

        public int getLinesFile()
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

        private void createFileAdm()
        {
            using (FileStream fstream = File.Create(@"Admin.txt")) { }
            using (FileStream fstream = new FileStream(@"Admin.txt", FileMode.OpenOrCreate))
            {
                byte[] array = System.Text.Encoding.Default.GetBytes("admin");
                fstream.Write(array, 0, array.Length);

            }
        }
        public string getPasswd()
        {
            if (File.Exists(@"Admin.txt"))
            {
                using (FileStream fstream = File.OpenRead(@"Admin.txt"))
                {
                    byte[] array = new byte[fstream.Length];
                    fstream.Read(array, 0, array.Length);
                    string textFromFile = System.Text.Encoding.Default.GetString(array);
                    return textFromFile;
                }
            }
            else
            {
                createFileAdm();
                return "admin";
            }

        }
        public void setPasswd(string paswd)
        {
            using (FileStream fstream = new FileStream(@"Admin.txt", FileMode.OpenOrCreate))
            {
                fstream.SetLength(0);
                byte[] array = System.Text.Encoding.Default.GetBytes(paswd);
                fstream.Write(array, 0, array.Length);

            }
        }

    }
}
