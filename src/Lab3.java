import javax.swing.*;
import java.awt.*;

import static java.lang.StrictMath.pow;

class Krzywa extends JPanel {
    @Override
    public void paintComponent(Graphics g) {
        super.paintComponent(g);
        Graphics2D g2 = (Graphics2D) g;
        setBackground(Color.GRAY);
        double Jx, Jy, Mx, My;

        double[] jx = {
                75, 60, 189, 189,
                189, 189, 210, 197,
                197, 184, 144, 131,
                131, 118, 83, 74,
                74, 65, 112, 100,
                100, 88, 149, 136,
                136, 123, 178, 177,
                177, 176, 182, 167,
                167, 152, 81, 80,
                80, 79, 78, 77
        };
        double[] jy = {
                37, 37, 53, 38,
                38, 23, 363, 356,
                356, 349, 382, 390,
                390, 398, 341, 353,
                353, 365, 325, 316,
                316, 307, 335, 342,
                342, 349, 304, 319,
                319, 334, 87, 88,
                88, 89, 69, 84,
                84, 99, 29, 44
        };
        double[] mx = {
                306, 304, 334, 357,
                357, 371, 404, 446,
                446, 459, 534, 551,
                551, 569, 573, 561,
                561, 553, 525, 519,
                519, 512, 534, 516,
                516, 502, 473, 461,
                461, 451, 437, 429,
                429, 420, 401, 386,
                386, 380, 367, 356,
                356, 347, 315, 306
        };
        double[] my = {
                404, 419, 86, 78,
                78, 73, 175, 198,
                198, 205, 78, 79,
                79, 80, 397, 406,
                406, 412, 404, 415,
                415, 428, 203, 198,
                198, 194, 233, 242,
                242, 250, 255, 245,
                245, 233, 181, 183,
                183, 184, 398, 408,
                408, 416, 402, 403
        };

        g2.setColor(Color.BLACK);

        for(int i = 0; i <= 9; i++) {
            for(double t = 0; t <=1; t=t+0.001) {
                Jx = pow(1-t,3) * jx[4*i] + 3 * pow(1-t,2) * t * jx[4*i+1] + 3 * (1-t) * pow(t,2) * jx[4*i+2] + pow(t,3) * jx[4*i+3];
                Jy = pow(1-t,3) * jy[4*i] + 3 * pow(1-t,2) * t * jy[4*i+1] + 3 * (1-t) * pow(t,2) * jy[4*i+2] + pow(t,3) * jy[4*i+3];
                g2.drawLine((int)Jx, (int)Jy, (int)Jx, (int)Jy);

            }
        }

        for(int i = 0; i <= 10; i++) {
            for(double t = 0; t <=1; t=t+0.001) {
                Mx = pow(1-t,3) * mx[4*i] + 3 * pow(1-t,2) * t * mx[4*i+1] + 3 * (1-t) * pow(t,2) * mx[4*i+2] + pow(t,3) * mx[4*i+3];
                My = pow(1-t,3) * my[4*i] + 3 * pow(1-t,2) * t * my[4*i+1] + 3 * (1-t) * pow(t,2) * my[4*i+2] + pow(t,3) * my[4*i+3];
                g2.drawLine((int)Mx, (int)My, (int)Mx, (int)My);

            }
        }

    }
}

public class Lab3 {
    Lab3(){
        JFrame f = new JFrame();
        Container c = f.getContentPane();
        c.setLayout(new BorderLayout());
        Krzywa k = new Krzywa();
        c.add(k);
        f.setSize(700,500);
        f.setVisible(true);
    }

}