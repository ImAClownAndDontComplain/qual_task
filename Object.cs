using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace task
{
    // КЛАСС ДЛЯ ПРЕДСТАВЛЕНИЯ ДАННЫХ ИЗ ТАБЛИЦЫ Objects
    public class Object
    {
        private int id;
        private string type;
        private string product;
        private List<Attribute> attributes;

        public Object(int id, string type, string product)
        {
            this.id = id;
            this.type = type;
            this.product = product;
            this.attributes = new List<Attribute>();
        }

        public int get_id() { return this.id; }

        public string get_type() { return this.type; }

        public string get_product() { return this.product; }

        // СТРОКА ДЛЯ ПРЕДСТАВЛЕНИЯ В ДЕРЕВЕ
        public string get_all()
        {
            return this.id.ToString() + "  |  " + this.product.ToString();
        }

        public List<Attribute> get_attributes() { 
            return this.attributes; 
        }


        public void add_attribute(Attribute attribute)
        {
            this.attributes.Add(attribute);
        }

        // УДАЛЕНИЕ АТРИБУТА С ЗАДАННЫМИ ПАРАМЕТРАМИ
        public void remove_attribute(string name, string value)
        {

            foreach (Attribute attribute in this.attributes)
            {
                List<string> attr_data = attribute.get_attribute();
                if (attr_data.First() == name &&
                    attr_data.Last() == value)
                {
                    this.attributes.Remove(attribute);
                    return;
                }
            }
        }

    }
}
