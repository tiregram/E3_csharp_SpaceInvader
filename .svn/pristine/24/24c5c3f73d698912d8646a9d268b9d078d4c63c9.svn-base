using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceInvaders
{
    class MenuItem
    {
        public string Name { get; set; }
        public string Info { get; set; }
        public delegate bool actionMenuValitation();
        public MenuItem.actionMenuValitation actionValidate;

        public MenuItem(String name, string info,MenuItem.actionMenuValitation action)
        {

            this.Name = name;
            this.Info = info;
            this.actionValidate = action;
        }


    }
}
