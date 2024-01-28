using System;

namespace Hwseseion9 {
    public static class GameHelper {
        public static int GetRandomNumber(int min, int max) {
            Random r = new Random();
            return r.Next(min, max);
        }
    }
}