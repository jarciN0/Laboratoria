import java.net.*;
import java.io.*;
import java.util.*;
class jHTTPSMulti extends Thread {
    private Socket socket = null;
    String getAnswer() {
        InetAddress adres;
        String name = "";
        String ip = "";
        try {
            adres = InetAddress.getLocalHost();
            name = adres.getHostName();
            ip = adres.getHostAddress();
        }
        catch (UnknownHostException ex) { System.err.println(ex); }
        String document = "<html>\r\n" +
                "<body style=\"background-color:lightgray;\"><br>\r\n" +
                "<h2><font color=red>jHTTPServer</font>\r\n" +
                "<font color=blue>wersja innowacyjna :)</font></h2>\r\n" +
                "<h3>Serwer na watkach</h3><hr>\r\n" +
                "Data: <b>" + new Date() + "</b><br>\r\n" +
                "Nazwa hosta: <b>" + name + "</b><br>\r\n" +
                "IP hosta: <b>" + ip + "</b><br>\r\n" +
                "<hr><center><h1>POLSKA DO BOJU!</h1></center>\r\n" +
                "<center><img src='https://i.ytimg.com/vi/oj10UBB07kY/maxresdefault.jpg'><center>\r\n" +
                "</body>\r\n" +
                "</html>\r\n";
        String header = "HTTP/1.1 200 OK\r\n" +
                "Server: jHTTPServer ver 1.1\r\n" +
                "Last-Modified: Fri, 28 Jul 2000 07:58:55 GMT\r\n" +
                "Content-Length: " + document.length() + "\r\n" +
                "Connection: close\r\n" +
                "Content-Type: text/html; charset=iso-8859-2";
        return header + "\r\n\r\n" + document;
    }
    public jHTTPSMulti(Socket socket){
        System.out.println("Nowy obiekt jHTTPSMulti...");
        this.socket = socket;
        start();
    }
    public void run() {
        try {
            PrintWriter out = new PrintWriter(socket.getOutputStream(), true);
            BufferedReader in = new BufferedReader(
                    new InputStreamReader(socket.getInputStream()));
            System.out.println("---------------- Pierwsza linia zapytania ----------------");
            System.out.println(in.readLine());
            System.out.println("---------------- Wysylam odpowiedz -----------------------");
            System.out.println(getAnswer());
            System.out.println("---------------- Koniec odpowiedzi -----------------------");
            out.println(getAnswer());
            out.flush();
        } catch (IOException e) {
            System.out.println("Blad IO danych!");
        }
        finally {
            try {
                if (socket != null) socket.close();
            } catch (IOException e) {
                System.out.println("Blad zamkniecia gniazda!");
            }
        } // finally
    }
}
public class Zad6 {
    public static void main(String[] args) throws IOException {
        ServerSocket server = new ServerSocket(80);
        try {
            while (true) {
                Socket socket = server.accept();
                new jHTTPSMulti(socket);
            } // while
        } // try
        finally { server.close();}
    } // main
}