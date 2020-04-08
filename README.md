#### tým:
    \_(*_*)_/\_(*_*)_/\_(*_*)_/\_(*_*)_/
#### členové:
* xbacae00
* xskvar09
* xzavad18
* xnovot2a 

### git setup easy návod
buď odsato: https://git-scm.com/ nebo takhle na linuxu:

    sudo apt-get install git
v nějakým shellu (klidně cmd, nebo powershell na win): 

    git config --global user.nane "Nejaky jmeno"
    git config --global user.email "nejakej@email.ee"

Pak naklonovat do momentáního adresáře:

    git clone https://github.com/JanSkvaril/ivs_projekt2.git

A frčíš

### Co se musí dělat
Erik:
- [ ] GUI a nápověda
- [ ] Mockup GUI

Honza:
- [ ] Parser
- [ ] Testy pro parser
- [ ] Uživatelská a programová dokumentace

Michal:
- [ ] Matematická knihovna
- [ ] Testy pro knihovnu
- [ ] Makefile 

Kuba:
- [ ] Profiling
- [ ] Instalačka

Nerozděleno:
- [x] Verzování (git)
- [ ] **Nasdílet repozitář někomu z ivs**
- [ ] Screen jak debugujem

### Funkce co se budou podporovat:
* +-
* */
* x! - faktorial
* x√y - odmocnina
* x^y - mocnina
* lnx - přirozenej logaritmus

* závorky, priority operaci

### String format pro parser
    x+y
    x-y
    x*y
    x/y
    x^y
    x√y
    x!
    lnx

* x a y může být číslo s plus nebo s mínus před ním, nebo závorky s čímkoliv vevnitř
* do závorek lze dávat další závorky




