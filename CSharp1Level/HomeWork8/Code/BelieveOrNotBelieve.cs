using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace HomeWork8.Code
{
    public delegate void ChangedName(string filename);

    //Класс для хранения списка вопросов. А так же для сериализации в XML и десериализации из XML
    public class BelieveOrNotBelieve
    {
        string fileName;
        List<Question> list;

        public string FileName
        {
            set
            {
                fileName = value;
                changeName?.Invoke(fileName);
            }
        }
        public List<Question> List => list;
        public int Count{get=> list.Count; }

        public static event ChangedName changeName;

        //Индексатор - свойство для доступа к закрытому объекту
        public Question this[int index]
        {
            get
            {
                if (list != null && index >= 0 && index < list.Count)
                    return list[index];
                else throw new IndexOutOfRangeException("Выход за пределы списка вопросов");
            }
        }

        public BelieveOrNotBelieve(string fileName)
        {
            this.fileName = fileName;
            changeName?.Invoke(fileName);
            list = new List<Question>();
        }

        public void Add(string text, bool trueFalse)
        {
            list.Add(new Question(text, trueFalse));
        }
        public void Remove(int index)
        {
            list.RemoveAt(index);
        }

        #region Сохрание и Загрузка
        public void Save()
        {
            XmlSerializer xmlFormat = new XmlSerializer(typeof(List<Question>));
            Stream fStream = new FileStream(fileName, FileMode.Create, FileAccess.Write);
            xmlFormat.Serialize(fStream, list);
            fStream.Close();
        }

        public void Load()
        {
            XmlSerializer xmlFormat = new XmlSerializer(typeof(List<Question>));
            Stream fStream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            list = (List<Question>)xmlFormat.Deserialize(fStream);
            fStream.Close();
        }
        #endregion
    }
}
