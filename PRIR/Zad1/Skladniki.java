import java.util.List;
import java.util.Random;

public class Skladniki {
    List<String> nazwy_skladnikow;
    public Skladniki(List<String> skladniki) {
        this.nazwy_skladnikow = skladniki;
    }

    synchronized String dodaj_skladnik(){
        Random r = new Random();
        int index = r.nextInt(nazwy_skladnikow.size());
        return nazwy_skladnikow.get(index);
    }
}
