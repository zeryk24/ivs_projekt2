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
* *%
* x! - faktorial
* x√y - odmocnina
* x^y - mocnina
* xln - přirozenej logaritmus

* závorky, priority operaci

### String format pro parser
#### Sčítání, násobení apod.

        "-5+3*-10-2" //jde
        "2+-5" //je
        "--5+2" //výsledek bude 7

#### Funkce s dvěma parametry:

Nemuže v nich být výraz, pouze číslo, odmocnina nemůže být záporná

        "5^2+4√7" //odmocnina z 5 + 4 na sedmou
        "(5+3)^2+4√7" //jde

        "-5√2)" //nejde
#### Faktorial:
před faktoriálem musí být rovnou výraz

        "5!+2"

        "5+!" //- nepujde zadat
        "5*!" //- nepujde zadat




