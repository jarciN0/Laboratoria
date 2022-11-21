public class Zad3 {
    public static void main(String[] args) {
        for (int i = 1; i < 5; i++) {
            new GrayScale("major" + i + ".jpg").start();
        }
    }
}
