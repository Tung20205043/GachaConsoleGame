using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hwseseion9 {
    public static class GameConstants {
        public static int[] goldToUpgradeItem = new int[5] {150, 200, 250, 300, 500 };
        public static int[] goldSell = new int[5] { 100, 150, 200, 250, 400 };
        public static int[] levelItem = new int[5] {1,2,3,4,5 };

        public static List<Item> itemPackage = new List<Item>();


        public enum Rarity { 
            Common,
            Rare,
            Epic,
            Legendary,
            Mythical
        }
        public enum ItemType { 
            Armour,
            Bow,
            Sword,
            Staff
        }
    }
}
