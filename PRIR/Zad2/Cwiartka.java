import java.util.Random;

public class Cwiartka extends Thread
{
    int liczba_punktow;
    int ktora_cwiartka;
    public Cwiartka(int liczba,int ktora_cwiartka) {
        this.liczba_punktow = liczba;
        this.ktora_cwiartka = ktora_cwiartka;
    }

    @Override
    public void run() {
        System.out.println("jestem w " + ktora_cwiartka);
        float percent = 90;
        int radius = 1;
        int punkty_wycinka = 0, punkty_ogolem = 0;
        int pom1 = 0, pom2 = 0;

        for (int i = 0; i < Math.pow(liczba_punktow, 2); i++) {
            float startAngle = 0;
            double rand_x = 0, rand_y = 0;
            switch (ktora_cwiartka) {
                case 1 -> {
                    rand_x = Math.random();
                    rand_y = Math.random();
                    startAngle = 0;
                }
                case 2 -> {
                    rand_x = Math.random() - 1;
                    rand_y = Math.random();
                    startAngle = 90;
                }
                case 3 -> {
                    rand_x = Math.random() - 1;
                    rand_y = Math.random() - 1;
                    startAngle = 180;
                }
                case 4 -> {
                    rand_x = Math.random();
                    rand_y = Math.random() - 1;
                    startAngle = 270;
                }
            }
            float endAngle = 360/percent + startAngle;
            double polarradius = Math.sqrt(rand_x * rand_x + rand_y * rand_y);
            double Angle = Math.atan(rand_y/rand_x);
            if (Angle>=startAngle && Angle<=endAngle && polarradius<radius) {
                punkty_wycinka++;
            }
            punkty_ogolem++;

            double x = Math.random()*2-1;
            double y = Math.random()*2-1;
            double odl = x * x + y * y;
            if (odl <= 1)
                pom1++;
            pom2++;

        }
        System.out.println("Finalny wynik PI dla cwiartki nr" +
                ktora_cwiartka + " wynosi: " + (4.0 * punkty_wycinka/punkty_ogolem));
        System.out.println("Finalny wynik PI dla wątku nr" +
                ktora_cwiartka + " wynosi: " + (4.0 * pom1/pom2));
    }
}