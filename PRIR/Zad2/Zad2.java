public class Zad2 {
    public static void main(String[] args) throws InterruptedException {
        final int max = 1000;
        for (int i = 1; i < 5; i++) {
            Thread t = new Cwiartka(max, i);
            t.start();
            t.join();
        }
    }
}
