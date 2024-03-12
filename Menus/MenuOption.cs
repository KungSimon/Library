using Library.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Menus
{
    public class MenuOption : IMenuOption
    {
        public string Text { get; private set; }
        public Action Action { get; private set; }

        public MenuOption(string text, Action action)
        {
            this.Text = text;
            this.Action = action;
        }
    }
}
