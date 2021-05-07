# Monitor-Windows-Agent
Build status: ![example workflow](https://github.com/asabanovic6/Monitor-Windows-Agent/actions/workflows/mwa-desktop.yml/badge.svg)
MWA je Windows aplikacija koja se na IWM-u izvršava u dva načina rada:
  -   	kao windows service, pod ograničenim userom koji nema Admin prava
  -   	kao desktop aplikacija, pod ograničenim userom koji nema Admin prava
MWA ima dvije glavne uloge:
-   	prikuplja informacije sa IWM-a i šalje na Monitor Server (MS)
-   	prima naredbe od korisnika, putem MS-a, i izvršava ih na IWM-u
# Installation
### Steps for installing MWA Desktop application

1. Desktop aplikaciju možete preuzeti sa sljedećeg linka https://drive.google.com/drive/folders/1ajc4YKHu9yHLcXwiv6qrJ7igk3BPQ9-k
2. Nakon što se pokrene instalacija odabrati lokaciju na koju će aplikacija biti instalirana.
3. Omogućeno je automatsko stvaranje desktop ikone, pa po završetku instalacije desktop aplikacija je spremna za korištenje.
### Steps for installing MWA Windows service
Nakon preuzimanja projekta, pozicionirati se unutar Command Prompta na sljedeću lokaciju:
```bash
cd Monitor-Windows-Agent\MonitorWindowsService\bin\Debug\netcoreapp3.1
```
Nakon toga servis se instalira komandom:
```bash
monitorwindowsservice.exe install start
```
Deinstaliranje servisa se vrši komandom:
```bash
monitorwindowsservice.exe uninstall
```
# Features
1. Pinganje servera i slanje json objekta prilikom pinganja 
2. Razmjena datoteka i slanje screenshota ka serveru 
3. Prikazivanje zahtjeva u Event Vieweru u vidu logova o upitima
4. Aktivacijska forma 
5. Forma za praćenje izmjena nad konfiguracijskom datotekom
6. Upravljanje errorima
7. Slanje podataka o iskoristivosti CPU,GPU,RAM i HDD prema serveru
8. Pinganje servra i slanje foldera ili file-a prilikom pinganja
# Contribute
1. Dodjeljivanje radnih zadataka (preuzimanje) se radi na nivou Itema, a razvoj softvera se obavlja na nivou Taska.
  Za svaki Item osoba koja je preuzela da radi taj Item kreira novi Branch na Repozitorij koristeći opciju kreiranja brancha za Issue.
   Na tom branchu se radi razvoj. Svaki task koji se odradi na tom Itemu/Branchu mora imati commit message. `ZABRANJENO JE RADITI NA MASTER BRANCH`
2. Nakon završetka rada na itemu, radi se Push na repozitorij i kreiranja Pull requesta, te kreirati Issue za testiranje.
3. Test dodijeliti nekom od članova tima koji nisu radili na tom Itemu. Taj član tima popunjava test scenario.
4. Kad je tester provjerio urađeni Item, odobrava Pull request ako je sve OK ili odbija ako nije, a developer rješava probleme i request konflikte, ako ih ima.
