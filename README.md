# Monitor-Windows-Agent
MWA je Windows aplikacija koja se na IWM-u izvršava u dva načina rada:
  -   	kao windows service, pod ograničenim userom koji nema Admin prava
  -   	kao desktop aplikacija, pod ograničenim userom koji nema Admin prava
MWA ima dvije glavne uloge:
-   	prikuplja informacije sa IWM-a i šalje na Monitor Server (MS)
-   	prima naredbe od korisnika, putem MS-a, i izvršava ih na IWM-u
# Installation
### Steps for installing MWA Desktop application

1. Nakon preuzimanja projekta, otvoriti folder Monitor-Windows-Agent i pokrenuti setup.exe.
2. Nakon što se pokrene instalacija odabrati lokaciju na koju će aplikacija biti instalirana.
3. Omogućeno je automatsko stvaranje desktop ikone, pa nakon završetka instalacije, sam postupak je završen i desktop aplikacija je spremna za korištenje.
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
1. Korisnik ima mogućnost čitanja podataka iz .txt file-a.
2. Korisnik ima mogućnost slanja file-a prema serveru, kao i primanje file-a od servera.
3. Korisnik ima mogućnost da se svaki zahtjev prikaže u Event Vieweru u vidu logova u kojima se nalazi podatak o klijentu koji zahtjeva neki upit, te podatak o tipu upita koji se zahtijeva. 
# Contribute
1. Dodjeljivanje radnih zadataka (preuzimanje) se radi na nivou Itema, a razvoj softvera se obavlja na nivou Taska.
  Za svaki Item osoba koja je preuzela da radi taj Item kreira novi Branch na Repozitorij koristeći opciju kreiranja brancha za Issue.
   Na tom branchu se radi razvoj. Svaki task koji se odradi na tom Itemu/Branchu mora imati commit message. `ZABRANJENO JE RADITI NA MASTER BRANCH`
2. Nakon završetka rada na itemu, radi se Push na repozitorij i kreiranja Pull requesta, te kreirati Issue za testiranje.
3. Test dodijeliti nekom od članova tima koji nisu radili na tom Itemu. Taj član tima popunjava test scenario.
4. Kad je tester provjerio urađeni Item, odobrava Pull request ako je sve OK ili odbija ako nije, a developer rješava probleme i request konflikte, ako ih ima.
