using System;
using System.Collections.Generic;
using System.Text;

namespace StarWar.UI.ConsoleApp.Screens
{
    class MasterScreenFixed<T> : MasterScreen where T : MasterScreen, new()
    {
        protected static T screen;
        protected MasterScreenFixed() : base() { }
        public static T Screen => screen ??= new T();

        protected virtual void WriteBody() { }
        public void WriteScreen()
        {
            Console.Clear();
            WriteHead();
            WriteBody();
        }
    }
}
