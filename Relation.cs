using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task
{
    // КЛАСС ДЛЯ ПРЕДСТАВЛЕНИЯ ДАННЫХ ИЗ ТАБЛИЦЫ Links
    public class Relation
    {
        private Object parent;
        private Object child;

        public Relation(Object parent, Object child)
        {
            this.parent = parent;
            this.child = child;
        }

        public Object get_parent()        {            return this.parent;        }
        public Object get_child()        {            return this.child;        }


        // ПРОВЕРЯЕМ, СОДЕРЖИТ ЛИ ОТНОШЕНИЕ УКАЗАННЫЙ ОБЪЕКТ
        public bool is_here(Object obj)
        {
            if (this.parent == obj || this.child == obj)
            {
                return true;
            }
            return false;
        }

        // ЯВЛЯЕТСЯ ЛИ ОБЪЕКТ РЕБЕНКОМ В ОТНОШЕНИИ
        public bool is_child(Object obj)
        {
            if (this.child == obj)
            {
                return true;
            }
            return false;
        }
    }
}
