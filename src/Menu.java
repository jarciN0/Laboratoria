import javax.swing.*;
import java.awt.*;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;


interface Kolory {
    Color PODSTAWOWY = Color.PINK;
    Color ZMIENIONY = Color.LIGHT_GRAY;
}

class MyButton extends JButton {

    Color color = Kolory.PODSTAWOWY;

    MyButton(String string) {
        super(string);
        setBackground(color);
    }

    void zmienKolor() {
        if (color == Kolory.PODSTAWOWY) {
            color = Kolory.ZMIENIONY;
        } else {
            color = Kolory.PODSTAWOWY;
        }
        setBackground(color);
    }
}

public class Menu extends JFrame {

    Menu() {
        super("Projekt 1 MENU");
        setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        setBounds(100,50, 800, 200);
        getContentPane().setBackground(Color.YELLOW);
        getContentPane().setLayout(new GridLayout(1,4));

        MyButton[] przyciski = new MyButton[4];

        for (int i = 0; i < 4; i++) {
            przyciski[i] = new MyButton("LAB" + (i+1));
            getContentPane().add(przyciski[i]);
            final int i1 = i;
            przyciski[i].addActionListener(new ActionListener() {
                @Override
                public void actionPerformed(ActionEvent e) {
                    przyciski[i1].zmienKolor();
                    if(i1 == 0){ new Lab1();}
                    if(i1 == 1){ new Lab2();}
                    if(i1 == 2){ new Lab3();}
                    if(i1 == 3){ new Lab4();}
                }
            });
        }
        setVisible(true);
    }

}