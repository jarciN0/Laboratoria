import javax.swing.*;
import java.awt.*;

class MyPanel extends JPanel{

    MyPanel(){
        this.setPreferredSize(new Dimension(500,500));
    }

    public void paint(Graphics g) {

        Graphics2D g2D = (Graphics2D) g;

        Rectangle dom = new Rectangle(getWidth()/4,4*getHeight()/10,getWidth()/2,getHeight()/2);

        int[] x = {getWidth()/4, getWidth()/2, 3*getWidth()/4};
        int[] y = {4*getHeight()/10, getHeight()/10, 4*getHeight()/10};
        Polygon dach = new Polygon(x, y,3);

        Rectangle oknoL = new Rectangle(
                getWidth()/4 + dom.width/6,
                4*getHeight()/10 + dom.height/10,
                dom.width/4,
                dom.height/4);
        Rectangle oknoP = new Rectangle(
                getWidth()/4 + dom.width - dom.width/6 - oknoL.width,
                4*getHeight()/10 + dom.height/10,
                dom.width/4,
                dom.height/4);
        Rectangle drzwi = new Rectangle(dom.x + dom.width/2 - dom.width/8,
                dom.y + dom.height/2 + dom.height/10,
                dom.width/4,
                dom.height/2 - dom.height/10);

        g2D.setBackground(Color.gray);
        g2D.setPaint(Color.pink);
        g2D.fill(dom);

        g2D.setPaint(Color.magenta);
        g2D.fillPolygon(dach);

        g2D.setPaint(Color.blue);
        g2D.fill(oknoL);
        g2D.fill(oknoP);

        g2D.setPaint(Color.red);
        g2D.fill(drzwi);

        g2D.setStroke(new BasicStroke(3));
        g2D.setPaint(Color.black);
        g2D.draw(dom);
        g2D.drawPolygon(dach);
        g2D.draw(oknoL);
        g2D.draw(oknoP);
        g2D.drawLine((int)oknoL.getCenterX(), oknoL.y, (int)oknoL.getCenterX(), oknoL.y + oknoL.height);
        g2D.drawLine(oknoL.x, (int)oknoL.getCenterY(), oknoL.x + oknoL.width, (int)oknoL.getCenterY());
        g2D.drawLine((int)oknoP.getCenterX(), oknoP.y, (int)oknoP.getCenterX(), oknoP.y + oknoP.height);
        g2D.drawLine(oknoP.x, (int)oknoP.getCenterY(), oknoP.x + oknoP.width, (int)oknoP.getCenterY());
        g2D.draw(drzwi);
        g2D.drawLine((int)drzwi.getMaxX() - 5, (int)drzwi.getCenterY(), (int)drzwi.getMaxX(), (int)drzwi.getCenterY());


        g2D.setFont(new Font("Arial Black", Font.BOLD, drzwi.height/4));
        g2D.drawString("17", (int)(dom.getMaxX() - drzwi.x/5), drzwi.y - (drzwi.y - (int)oknoL.getMaxY())/2);
    }
}

public class Lab1 extends JFrame {

    MyPanel panel;

    Lab1(){

        panel = new MyPanel();

        this.add(panel);
        this.pack();
        this.setLocationRelativeTo(null);
        this.setVisible(true);
    }
}