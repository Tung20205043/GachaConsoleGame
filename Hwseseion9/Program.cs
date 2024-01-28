using System;
using static Hwseseion9.GameConstants;
using System.Diagnostics;
using System.Reflection.Emit;

namespace Hwseseion9 {
    internal class Program {
        static void Main(string[] args) {
            while (true) {
                int key = PrintGameUI();
                if (key == 5)
                    break;

                switch (key) {
                    case 1:
                        Gacha();
                        break;
                    case 2:
                        ViewList();
                        break;
                    case 3:
                        ViewGold();
                        break;
                    case 4:
                        break;
                }
            }

            Console.ReadKey();
        }

        public static int PrintGameUI() {
            int key;
            do {
                Console.Clear();
                Console.WriteLine("=================== Gia lap game Gacha ==========================");
                Console.WriteLine("1. Gacha vat pham");
                Console.WriteLine("2. Kho do hien tai");
                Console.WriteLine("3. Luong tien hien tai");
                Console.WriteLine("4. Thoat chuong trinh");
                Console.Write("--- Nhap lua chon: ");
            } while (!int.TryParse(Console.ReadLine(), out key));

            return key;
        }

        public static void Gacha() {
            Console.Clear();
            Console.WriteLine("====================== Gacha =============================");
            Console.WriteLine("Chuc mung ban da nhan duoc: ");
            int rateRarity = GameHelper.GetRandomNumber(1, 100);
            if (rateRarity > 0 && rateRarity <= 5) {
                Console.WriteLine("Vat pham co do hiem 'Mythical'");
                RandomType(Rarity.Mythical, 4);
            }
            if (rateRarity > 5 && rateRarity <= 10) {
                Console.WriteLine("Vat pham co do hiem 'Legendary'");
                RandomType(Rarity.Legendary, 3);
            }
            if (rateRarity > 10 && rateRarity <= 25) {
                Console.WriteLine("Vat pham co do hiem 'Epic'");
                RandomType(Rarity.Epic, 2);
            }
            if (rateRarity > 25 && rateRarity <= 60) {
                Console.WriteLine("Vat pham co do hiem 'Rare'");
                RandomType(Rarity.Rare, 1);
            }
            if (rateRarity > 60 && rateRarity <= 100) {
                Console.WriteLine("Vat pham co do hiem 'Common'");
                RandomType(Rarity.Common, 0);
            }

        }
        public static void RandomType(Rarity rarity, int price) {
            int rateType = GameHelper.GetRandomNumber(1, 4);
            switch (rateType) {
                case 1:
                    Console.WriteLine("Vu khi loai 'Armour'");
                    CreateItem(ItemType.Armour, rarity, price);
                    break;
                case 2:
                    Console.WriteLine("Vu khi loai 'Bow'");
                    CreateItem(ItemType.Bow, rarity, price);
                    break;
                case 3:
                    Console.WriteLine("Vu khi loai 'Sword'");
                    CreateItem(ItemType.Sword, rarity, price);
                    break;
                case 4:
                    Console.WriteLine("Vu khi loai 'Staff'");
                    CreateItem(ItemType.Staff, rarity, price);
                    break;
            }
        }
        public static void CreateItem(ItemType type, Rarity rarity, int price) {
            Console.WriteLine("----------- Lua chon de tiep tuc --------------");
            Console.WriteLine("1. Them vao kho do");
            Console.WriteLine("2. Quay lai main menu");
            int choice;
            do {
                Console.Write("Nhap lua chon: ");
            } while (!int.TryParse(Console.ReadLine(), out choice));

            if (choice == 1) {
                if (itemPackage.Count == 10) {
                    Console.WriteLine("Kho trang bi cua ban da day, an phim bat ki de quay lai menu....");
                    Console.ReadLine();
                    PrintGameUI();
                } else {
                    switch (type) {
                        case ItemType.Sword:

                            Item newSword = new Sword(1, type, rarity, goldSell[price]); 
                            itemPackage.Add(newSword);
                            Console.WriteLine("Them trang bi thanh cong, an phim bat ki de quay lai menu....");
                            break;
                        case ItemType.Staff:
                            Item newStaff = new Staff(1, type, rarity, goldSell[price]);
                            itemPackage.Add(newStaff);
                            Console.WriteLine("Them trang bi thanh cong, an phim bat ki de quay lai menu....");
                            break;
                        case ItemType.Bow:
                            Item newBow = new Bow(1, type, rarity, goldSell[price]);
                            itemPackage.Add(newBow);
                            Console.WriteLine("Them trang bi thanh cong, an phim bat ki de quay lai menu....");
                            break;
                        case ItemType.Armour:
                            Item newArmour = new Armor(1, type, rarity, goldSell[price]);
                            itemPackage.Add(newArmour);
                            Console.WriteLine("Them trang bi thanh cong, an phim bat ki de quay lai menu....");
                            break;
                    }
                }
            } else if (choice == 2) {
                PrintGameUI();
            }
        }

        public static void ViewList() {
            Console.Clear();
            if (itemPackage.Count == 0) {
                Console.WriteLine("Tui do hien tai trong!");
                Console.WriteLine("An phim bat ki de quay lai menu");
                Console.ReadLine();
                PrintGameUI();
            }

            if (itemPackage.Count > 0) {
                Console.WriteLine("===================== Kho do ============================");
                for (int i = 0; i < itemPackage.Count; i++) {
                    Console.WriteLine($"{(i+1)}, { itemPackage[i].itemType}");
                }
                Console.WriteLine("Xem chi tiet trang bi, chon tu 1 -> 10");
                Console.WriteLine("Nhap 0 de quay lai menu");
                int userInput;
                while (!int.TryParse(Console.ReadLine(), out userInput) ) {
                }

                switch (userInput) {
                    case 1:
                        ShowInformation(itemPackage[0]);
                        break;
                    case 2:
                        //if (itemPackage[1] == null) {
                        //    Console.WriteLine("Vat pham khong ton tai");
                        //    Console.ReadLine();
                        //}
                        ShowInformation(itemPackage[1]);
                        break;
                    case 3:
                        ShowInformation(itemPackage[2]);
                        break;
                    case 4:
                        ShowInformation(itemPackage[3]);
                        break;
                    case 5:
                        ShowInformation(itemPackage[4]);
                        break;
                    case 6:
                        ShowInformation(itemPackage[5]);
                        break;
                    case 7:
                        ShowInformation(itemPackage[6]);
                        break;
                    case 8:
                        ShowInformation(itemPackage[7]);
                        break;
                    case 9:
                        ShowInformation(itemPackage[8]);
                        break;
                    case 10:
                        ShowInformation(itemPackage[9]);
                        break;
                    case 0:
                        PrintGameUI();
                        break;

                }

                Console.ReadLine();
            }
            
        }
        public static void ShowInformation(Item item) {
            Console.WriteLine("=============== Chi tiet vat pham =================");
            Console.WriteLine($"Loai vat pham: {item.itemType} ");
            Console.WriteLine($"Do hiem: {item.rarity}");
            Console.WriteLine($"Cap do hien tai: {item.level}/10");
            Console.WriteLine($"Gia ban: {item.price}$ ");
            Console.WriteLine("---------------------");
            Console.WriteLine("1. Quay lai tui do");
            Console.WriteLine("2. Nang cap vat pham nay");
            Console.WriteLine("3. Ghep vat pham nay");
            Console.WriteLine("4. Ban vat pham nay");
            Console.WriteLine("--- Nhap lua chon: ");
            int userInput;
            while (!int.TryParse(Console.ReadLine(), out userInput)) {
            }

            switch (userInput) {
                case 1:
                    ViewList();
                    break;
                case 2:
                    Console.WriteLine($"Ban can: " +
                        $"{GameConstants.goldToUpgradeItem[(int)item.rarity]} vang de nang cap vat pham nay ");
                    Console.WriteLine($"An phim bat ki de tiep tuc ");
                    Console.ReadLine();
                    ViewUpgrade(item);
                    break;
                case 3:
                    Console.WriteLine("Chon vat pham de ghep voi vat pham nay");
                    int userInput2;
                    while (!int.TryParse(Console.ReadLine(), out userInput2)) {
                    }
                    switch (userInput2) {
                        case 1:
                            ViewUplevel(item,itemPackage[0]);
                            break;
                        case 2:                      
                            ViewUplevel(item, itemPackage[1]);
                            break;
                        case 3:
                            ViewUplevel(item, itemPackage[2]);
                            break;
                        case 4:
                            ViewUplevel(item, itemPackage[3]);
                            break;
                        case 5:
                            ViewUplevel(item, itemPackage[4]);
                            break;
                        case 6:
                            ViewUplevel(item, itemPackage[5]);
                            break;
                        case 7:
                            ViewUplevel(item, itemPackage[6]);
                            break;
                        case 8:
                            ViewUplevel(item, itemPackage[7]);
                            break;
                        case 9:
                            ViewUplevel(item, itemPackage[8]);
                            break;
                        case 10:
                            ViewUplevel(item, itemPackage[9]);
                            break;
                    }
                    Console.ReadLine();
                    break;
                case 4:
                    itemPackage.Remove(item);
                    CurencyManager.PlusGold(item.price);
                    Console.WriteLine($"Ban vat pham thanh cong, ban nhan duoc: {item.price} vang");
                    Console.WriteLine($"An phim bat ki de quay lai.... ");
                    Console.ReadLine();
                    ViewList();
                    break;
            }
        }
        public static void ViewGold() {
            Console.WriteLine($"Hien ban dang co: {CurencyManager.currentGold} vang");
            Console.WriteLine($"An phim bat ki de quay lai menu.... ");
            Console.ReadLine();
            PrintGameUI();
        }
        public static void ViewUpgrade(Item item) {
            if (item.CanUpgrade(item.rarity)) {
                if (item.rarity == Rarity.Mythical) {
                    Console.WriteLine("Vat pham nay da o do hiem toi da");
                    Console.WriteLine($"An phim bat ki de quay lai tui do.... ");
                    Console.ReadLine();
                    ViewList();
                } 
                else {
                    item.OnUpgradeItem(item.rarity);
                    item.price = goldSell[(int)item.rarity];
                    Console.WriteLine($"Nang cap thanh cong");
                    Console.WriteLine($"Ban con lai: {CurencyManager.currentGold} vang");
                    Console.WriteLine($"An phim bat ki de quay lai tui do.... ");
                    Console.ReadLine();
                    ViewList();
                }
           } else {
                Console.WriteLine("Luong vang hien tai khong du");
                Console.WriteLine($"An phim bat ki de quay lai tui do.... ");
                Console.ReadLine();
                ViewList();
            }
        }
        public static void ViewUplevel(Item item1, Item item2) {
            if (item1.itemType == item2.itemType && item1.rarity == item2.rarity) {
                itemPackage.Remove(item1);
                itemPackage.Remove(item2);
                switch (item1.itemType) {
                    case ItemType.Bow:
                        Item newBow = new Bow(item1.level + item2.level, ItemType.Bow, item1.rarity, goldSell[(int)item1.rarity]);
                        itemPackage.Add(newBow);
                        PrintNewItem(newBow);
                        break;
                    case ItemType.Staff:
                        Item newStaff = new Bow(item1.level + item2.level, ItemType.Staff, item1.rarity, goldSell[(int)item1.rarity]);
                        itemPackage.Add(newStaff);
                        PrintNewItem(newStaff);
                        break;
                    case ItemType.Armour:
                        Item newArmour = new Bow(item1.level + item2.level, ItemType.Armour, item1.rarity, goldSell[(int)item1.rarity]);
                        itemPackage.Add(newArmour);
                        PrintNewItem(newArmour);
                        break;
                    case ItemType.Sword:
                        Item newSword = new Bow(item1.level + item2.level, ItemType.Sword, item1.rarity, goldSell[(int)item1.rarity]);
                        itemPackage.Add(newSword);
                        PrintNewItem(newSword);
                        break;
                }
                
            } 
            else {
                Console.WriteLine("2 vat pham khong co cung loai hoac do hiem");
                Console.WriteLine($"An phim bat ki de quay lai.... ");
                Console.ReadLine();
                ShowInformation(item1);
                }
            }
        public static void PrintNewItem(Item item) {
            Console.WriteLine("=============== Chuc mung=================");
            Console.WriteLine("Nang cap vat pham thanh cong, ban nhan duoc: ");
            Console.WriteLine("-----------------");
            Console.WriteLine($"Vat pham: {item.itemType} ");
            Console.WriteLine($"Do hiem: {item.rarity}");
            Console.WriteLine($"Cap do hien tai: {item.level}/10");
            Console.WriteLine($"Gia ban: {item.price}$ ");
            Console.WriteLine("-----------------");
            Console.WriteLine($"An phim bat ki de quay lai tui do.... ");
            Console.ReadLine();
            ViewList();
        }
    }
}
