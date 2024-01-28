using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Hwseseion9.GameConstants;

namespace Hwseseion9 {
    public class Armor : Item {
        public int _price;

        //public override int level { 
        //    get => _level;
        //    set => _level = level; }
        public override int price {
            get => _price;
            set => _price = value;
        }
        public Armor (int level, ItemType itemType, Rarity rarity, int price) : base(level, itemType, rarity, price) {

        }
        public override void DoUpgradeItem(Rarity rarityCost) {
            rarity = (Rarity)((int)rarity + 1);
            CurencyManager.currentGold -= goldToUpgradeItem[(int)rarityCost];
        }
    }
}
