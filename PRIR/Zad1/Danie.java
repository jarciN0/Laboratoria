import java.util.List;
import java.util.Random;
public class Danie extends Thread{
    String nazwa;
    int ilosc_skladnikow;
    Skladniki s;

    public Danie(String nazwa, int ilosc_skladnikow, Skladniki skladniki) {
        this.nazwa = nazwa;
        this.ilosc_skladnikow = ilosc_skladnikow;
        this.s = skladniki;
    }


    @Override
    public void run() {
        System.out.println("Rozpoczynam przygotowywanie dania " + nazwa);
        System.out.println();
        try {
            Thread.sleep(1000);
        } catch (InterruptedException e) {
            System.out.println(e);
        }

        while (ilosc_skladnikow > 0){
            System.out.println("Dodaje składnik " + s.dodaj_skladnik() + " do dania " + nazwa);
            ilosc_skladnikow--;
        }
        System.out.println("Danie " + nazwa + " gotowe do serwisu");
    }
}
