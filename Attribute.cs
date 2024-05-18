using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Markup;

namespace task
{ 
    // КЛАСС ДЛЯ ПРЕДСТАВЛЕНИЯ ДАННЫХ ИЗ ТАБЛИЦЫ Attribute
    public class Attribute
    {
        private string name;
        private string value;
        private List<String> data;

        public Attribute(string name, string value) { 
            this.name = name;
            this.value = value;
            this.data = new List<String>();
        }

        // представление атрибута в виде списка параметров
        public List<string> get_attribute(){
            data.Clear();
            data.Add(name);
            data.Add(value);
            return data;
            }
    }
}
