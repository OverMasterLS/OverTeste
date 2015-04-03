using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LeagueSharp;
using LeagueSharp.Common;
using SharpDX;
using Color = System.Drawing.Color;

namespace OverTeste
{
    class Program
    {
        public static String ChampNome = "Jinx";
        public static Orbwalking.Orbwalker Orbwalker;
        private static Obj_AI_Hero Player {get{ return ObjectManager.Player;}}

        public static Menu OverMaster; 

        static void Main(string[] args)
        {

            CustomEvents.Game.OnGameLoad += Game_OnGameLoad;

        }

        static void Game_OnGameLoad(EventArgs args)
        {

            if (Player.ChampionName != "Jinx")
                return;
            OverMaster = new Menu("OverMaster" + ChampNome, ChampNome, true);
            OverMaster.AddSubMenu(new Menu("Orbwalker","Orbwalker"));
            Orbwalker = new Orbwalking.Orbwalker(OverMaster.SubMenu("Orbwalker"));


            var ts = new Menu("TargetSelector", "Target Selector");
            TargetSelector.AddToMenu(ts);
            OverMaster.AddSubMenu(ts);
            OverMaster.AddItem(new MenuItem ("nossoMenu1","Opção1").SetValue(true));
            OverMaster.AddItem(new MenuItem ("nossoMenu2","Opção2").SetValue(new KeyBind("Y".ToCharArray()[0],KeyBindType.Toggle,true)));
            OverMaster.AddItem(new MenuItem ("nossoMenu3","Opção3").SetValue(new Slider(0,0,100)));

            OverMaster.AddToMainMenu();

            Game.PrintChat("OverMaster"+ChampNome + "injetado");
            Game.PrintChat("<font color =\"#87CEEB\">Secundo Script Criado com sucesso =)))</font>");

           
        }
    }
}
