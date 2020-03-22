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
* ! - faktorial
* sqrt(x,y) - odmocnina
* pow(x,y) - mocnina

co dál???


### String format pro parser
#### Sčítání, násobení apod.

        "-5+3*-10-2" //jde

        "+-5" //nejde?

#### Funkce s dvěma parametry:

Nemuže v nich být výraz, pouze číslo, odmocnina nemůže být záporná

        "sqrt(5,2)+pow(4,7)" //odmocnina z 5 + 4 na sedmou

        "sqrt(5+2,5)" //nejde
        "sqrt(-5,2)" //nejde

#### Faktorial:
za faktoriálem musí být rovnou číslo

        "!5+2"

        "!-5+2" //- nepujde zadat
        "!*5" //- nepujde zadat




