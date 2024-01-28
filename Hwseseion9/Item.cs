using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Hwseseion9.GameConstants;

namespace Hwseseion9 {
    public abstract class Item {
        public abstract int price { get; set; }
        public  int level;
        //public int price;
        public ItemType itemType;
        public Rarity rarity;

        public Item() { }
        public Item(int level, ItemType itemType, Rarity rarity, int price) {
            this.level = level;
            this.price = price;
            this.itemType = itemType;
            this.rarity = rarity;
        }
        public void AddToPack() { }
        public bool CanUpgrade(Rarity rarityToUpgrade) {
            return CurencyManager.currentGold >= goldToUpgradeItem[(int)rarityToUpgrade];
        }
        public void OnUpgradeItem(Rarity rarityToUpgrade) {
            if (!CanUpgrade(rarityToUpgrade))
                return;
            DoUpgradeItem(rarityToUpgrade);
        }
        public abstract void DoUpgradeItem(Rarity rarityCost);

    }
}
