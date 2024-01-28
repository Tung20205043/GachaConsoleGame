

namespace Hwseseion9 {
    public static class CurencyManager {
        public static int currentGold = 1000;

        public static void PlusGold(int price) {
            currentGold += price;
            
        }
        public static void MinusGold(int price) { 
            currentGold -= price;
        }
    }
}
