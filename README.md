ZASTOSOWANA INNOWACYJNOŚĆ:

Menu stworzone z przycisków dla kazdego programu.

Lab1: Rysunek w pełni responsywny.

Lab2 (gra Snake): Wąż wielokolorowy, dodany licznik punktow, opoznienie klatek zmniejsza sie po zjedzeniu jablka (dodany licznik predkosci).

Do wygenerowania plików z lab4 wykorzystalem zalaczone archiwum (patchoff.jar). 

Lab5: Zmieniony zakres z [0..1] na [0..255]

Lab6: Aby narysować wykres tworzę tablice składowych. Metodą Points.Clear czyszcze wykres, a metodą Points.AddXY rysuję dodając punkty. Do modyfikacji obrazu na podstawie wyrównania histogramu wykorzystuję tablicę LUT, którą obliczam korzystając z funkcji LUT, podając do niej wartości składowych koloru oraz wymiar obrazu. Po policzeniu tablic LUT dla wszystkich trzech składowych, modyfikuję obraz, korzystając ze składowych, które mam w tych tablicach. Aby zmodyfikować obraz na podstawie skalowania histogramu, musze przeliczyć tablice LUT, więc używam funkcji calculateLUT.

Lab7: Funkcja "przetworz", ktora przeksztalca obraz na podstawie maski oraz jej sumy(które ustawiam w metodzie button_Click, zgodnie z maskami, które były podane na stronie). x_mniej, x_wiecej, y_mniej, y_wiecej to zmienne, które wykorzystuję przy krawędziach obrazu, aby program nie próbował pobrać pikseli spoza obrazu. Przed podzieleniem składowych przez sumę maski sprawdzam czy nie jest ona równa 0.
