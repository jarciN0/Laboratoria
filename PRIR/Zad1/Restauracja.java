import java.util.ArrayList;
import java.util.List;
import java.util.Random;

public class Restauracja {

    public static void main(String[] args) {
        Random r = new Random();
        List<String> skladniki = new ArrayList<String>();
        skladniki.add("pomidor");
        skladniki.add("sałata");
        skladniki.add("mieso kurczak");
        skladniki.add("mieso wolowo-baranie");
        skladniki.add("ogorek");
        skladniki.add("ser szwajcarski");
        skladniki.add("ser gouda");
        skladniki.add("pita");
        skladniki.add("lawasz");
        Skladniki s = new Skladniki(skladniki);
        String[] dania = {"Kabab z minsem", "Kabab bez minsa", "Rollo mieszane"};
        for (String danie : dania) {
            new Danie(danie, r.nextInt(skladniki.size()), s).start();
        }
    }
}
