using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
using System.IO;

namespace Lesson10Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            // сериализация без аттрибутов
            XmlSerializer serialiserClassical = new XmlSerializer(typeof(UserClassical));

            UserClassical userinstance0 = new UserClassical()
            {
                Name = "Vasya Pupkin",
                Age = 20,
                Login = "peterson47",
                Password = "qwerty",
                characteristics = { "bold", "tall" }

            };
            using (FileStream stream = new FileStream("Serialization.xml", FileMode.Create, FileAccess.Write, FileShare.Read))
            {

                serialiserClassical.Serialize(stream, userinstance0);

                Console.WriteLine("Класс сериализован методом XmlSerializer в Serialization.xml");
            }


            // - СЕРИАЛИЗАЦИЯ С АТТРИБУТАМИ
            XmlSerializer serialiser = new XmlSerializer(typeof(User));

            User userinstance = new User()
            {
                Name = "Vasya Pupkin",
                Age = 20,
                Login = "peterson47",
                Password = "qwerty",
                characteristics = { "bold", "tall" }

            };
            using (FileStream stream = new FileStream("SerializationWithAttributes.xml", FileMode.Create, FileAccess.Write, FileShare.Read))
            {

                serialiser.Serialize(stream, userinstance);

                Console.WriteLine("Класс сериализован методом XmlSerializer с аттрибутами в SerializationWithAttributes.xml");
            }

            // -- ДЕСИРЕАЛИЗАЦИЯ ПЕРВОГО КЛАССА / TASK3

            using (FileStream filestream = new FileStream("Serialization.xml", FileMode.Open))
            {
                UserClassical userInstandeDeserialized = (UserClassical)serialiserClassical.Deserialize(filestream);
                Console.WriteLine("Результат десериализации");
                Console.WriteLine($"Имя: {userInstandeDeserialized.Name}, Возраст {userInstandeDeserialized.Age}, Логин {userInstandeDeserialized.Login}, Пароль {userInstandeDeserialized.Password}, Характеристика {userInstandeDeserialized.characteristics[0]}, {userInstandeDeserialized.characteristics[1]}");
            }
                Console.ReadLine();
        }


    }
    //- class for classical serialization
    [XmlRoot("UserDataClass")]
    public class UserClassical
    {

        public string Name { get; set; }

        
        public int Age { get; set; }
        
        public string Login { get; set; }

        
        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        private string password = "111111";
        
        public List<string> characteristics = new List<string>();
    }

    // CLASS FOR ATTRIBUTES SERIALIZATION
    [XmlRoot("UserDataWithAttributes")]
        public class User
        {
            
            public string Name { get; set; }

        [XmlAttribute("Age")]
        public int Age { get; set; }
        [XmlAttribute("Login")]
        public string Login { get; set; }

        [XmlAttribute("Pass")]
        public string Password
            {
                get { return password; }
                set { password = value; }
            }

            private string password = "111111";
        [XmlAttribute("Characteristics")]
        public List<string> characteristics = new List<string>();
        }


    
}
