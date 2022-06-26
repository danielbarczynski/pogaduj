# pogaduj

Projekt na zajęcia "Programowanie Aplikacji Backendowych". Jest to aplikacja interaktywnego czatu, gdzie użytkownicy mogą wylosować rozmówcę i z nim porozmawiać w pełni prywatnie (rozmowy nie są nigdzie zapisywanie). Chciałbym zaznaczyć, że jest to kontynuacja porzuconego przeze mnie projektu, także pierwszy commit jest dość duży, bo składa się na niego kilka commitów z poprzedniego projektu. Inspirowane na https://6obcy.org/

Krótki opis działania:

Aby móc dołączyć do pokoju czatu, należy się najpierw zalogować bądź założyć konto. Po dołączeniu do pokoju "n" w bazie danych zapełnia się miejsce, informując algorytm, że dany pokój jest dostępny dla jeszcze jednej osoby. Kiedy dołączy jeszcze jedna osoba, pokój się zamyka i kolejna osoba dołączy do pokoju "n + 1". Jeśli jakiś rozmówca opuści pokój miejsce się zwalnia dla kolejnego rozmówcy, więc wystarczy tak naprawdę poczekać, aż kolejna osoba dołączy. Użytkownicy są też zabezpieczani przed przypadkowym opuszczeniem pokoju i utraceniem rozmówcy/wiadomości przez event "preventdeafult". Jak już wspomniałem wyżej, wiadomości nie są nigdzie zapisywane.

Harmonogram:

1. Funkcja rejestracji (identity) X
2. Funkcja logowania (identity) X
3. Funkcja wysyłania wiadomości (javascript) X
4. Funkcja odbierania wiadomości (signalR) X
5. Funkcja zarządzania kontem X
6. Funkcja walidacji danych X
7. Funkcja autoryzacji użytkowników X
8. Migracja danych X
9. Funkcja łączenia się z bazą danych (entity framework) X
10. Funkcja dołączania do pokoju X
11. Algorytm znajdowania wolnego pokoju X
12. Algorytm zwalniania pokoju po opuszczeniu X
13. Funkcja wysyłania wiadomości tylko do użytkowników w danym pokoju X
14. Informowanie o dołączeniu danego użytkownika do pokoju X
15. Informowanie o opuszczeniu pokoju przez danego użytkownika X
16. Udostępnienie aplikacji na azure X (zaimplementowane, anulowane przez wysokie opłaty)

