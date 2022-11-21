import java.util.Scanner;

public class Zad5 {
    public static void main(String[] args) {
        System.out.println("Wybierz który problem Filozofa cie interesuje (1-3): ");
        Scanner input1 = new Scanner(System.in);
        int filozof = input1.nextInt();

        System.out.println("Wybierz liczbe filozofow (2-100): ");
        Scanner input2 = new Scanner(System.in);
        int maks = input2.nextInt();

        if(maks > 1 && maks < 101) {
            switch (filozof) {
                case 1:
                    for ( int i =0; i<maks; i++) {
                        new Filozof1(i, maks).start();
                    }
                case 2:
                    for ( int i =0; i<maks; i++) {
                        new Filozof2(i, maks).start();
                    }
                case 3:
                    for ( int i =0; i<maks; i++) {
                        new Filozof3(i, maks).start();
                    }
                default:
                    System.out.println("Wybrano nieprawidłowy numer");
            }
        }
        else System.out.println("Nieprawidlowa liczba filozofow");
    }
}
