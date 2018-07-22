﻿using System;
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
               // mdb.init(param[0], param[1], param[2], param[3], param[4]);

                //if (mdb.conn == null)
                //{
                //    FormConnect fc = new FormConnect();
                //    fc.ShowDialog();
                //}
            }

            return param;
        }

        public void setParam(string text)
        {
            using (FileStream fstream = new FileStream(@"ConnectParam.txt", FileMode.OpenOrCreate))
            {
                // преобразуем строку в байты
                byte[] array = System.Text.Encoding.Default.GetBytes(text);
                // запись массива байтов в файл
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
                } else
            {
                using (FileStream fstream = File.Create(@"Admin.txt")) { }
                using (FileStream fstream = new FileStream(@"Admin.txt", FileMode.OpenOrCreate))
                {
                    byte[] array = System.Text.Encoding.Default.GetBytes("admin");
                    fstream.Write(array, 0, array.Length);
                    return "admin";
                }
            }

        }

    }
}
