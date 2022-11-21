import java.awt.*;
import java.awt.image.BufferedImage;
import java.io.*;
import javax.imageio.ImageIO;
import javax.swing.JFrame;
public class GrayScale extends Thread{
    String sciezka;

    public GrayScale(String sciezka) {
        this.sciezka = sciezka;
    }

    @Override
    public void run() {
        try {
            File input = new File(sciezka);
            BufferedImage image = ImageIO.read(input);
            int width = image.getWidth();
            int height = image.getHeight();
            for (int i = 1; i < height - 1; i++) {
                for (int j = 1; j < width - 1; j++) {

                    Color c = new Color(image.getRGB(j, i));
                    int red = (int) (c.getRed());
                    int green = (int) (c.getGreen());
                    int blue = (int) (c.getBlue());

                    int final_red, final_green, final_blue;

                    final_red = 255 - red;
                    final_green = 255 - green;
                    final_blue = 255 - blue;
                    Color newColor = new Color(final_red, final_green, final_blue);
                    image.setRGB(j, i, newColor.getRGB());
                }
            }
            File ouptut = new File("grayed"+sciezka);
            ImageIO.write(image, "jpg", ouptut);
        } catch (Exception e) {
        }
    }

}