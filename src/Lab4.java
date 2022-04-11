import javax.swing.*;
import java.awt.*;

class Panel extends JPanel{
    Image image;

    Panel(){

        image = new ImageIcon("obiekty.png").getImage();
        this.setPreferredSize(new Dimension(1420,671));
    }

    public void paint(Graphics g) {

        Graphics2D g2D = (Graphics2D) g;
        g2D.drawImage(image, 0, 0, null);

    }
}

public class Lab4 extends JFrame {

    Panel panel;

    Lab4(){

        panel = new Panel();
        this.setTitle("Lab 4 - wykreowane obiekty");
        this.add(panel);
        this.pack();
        this.setLocationRelativeTo(null);
        this.setVisible(true);
    }
}

