# Documentation

Use this file to fill in your documentation
## Mob programmering schema
|   |  1 |  2 | 3  |  4 |
|---|---|---|---|---|
| driver  | edgar  | elsa  | emil  |  daniel |
| cd  |  elsa |  edgar |  daniel |  emil |
| timer  | emil  | daniel  | edgar  | elsa  |
| spy  | daniel  | emil  | elsa  |  edgar |

## Projekt managment
* <a href="https://share.clickup.com/b/h/4-8851288-2/0d65952681c886a">Kanban tavla</a>
* <a href="https://share.clickup.com/l/h/4-8851288-1/c525cb63007e621">Att g�ra lista</a>

## User stories
* Som spelare vill jag sl� t�rning s� att jag f�r ett antal steg f�r att g� med viss pj�s
* Som spelare vill jag v�lja viss pj�s s� den kan f�rflyttas
* Som spelare vill jag kunna se allas spelares pj�ser och dess position f�r att planera mitt n�sta drag
* Som spelare vill jag kunna knuffa ut annan spelare s� att den m�ste b�rja om fr�n start f�r att pj�serna hamnar p� samma position
* Som spelare vill jag f� avslutnings rapport om spelet f�r att veta vem som vann
* Som spelare vill jag kunna l�gga ut en pj�s f�r att jag har kastat 1
* Som spelare vill jag kunna l�gga ut en pj�s och flytta 6 steg eller tv� pj�ser och flytta 1 steg f�r att jag har kastat 6
* Som spelare vill jag f� ett extra kast f�r att jag har kastat 6
* Som spelare vill jag kunna v�lja f�rg p� mina pj�ser f�r att best�mma vilken f�rg jag spelar med
* Som spelare vill jag att mina pj�ser flyttar sig medsols runt spelplanen f�r att komma i m�l
* Som spelare vill jag sl� r�tt siffra f�r kunna flytta mig till dess center efter ett varv p� br�det
* Som spelare vill jag att min pj�s flyttas bak�t om jag sl�r f�r m�nga steg in i m�l f�r att siffran  m�ste vara r�tt
* Som spelare vill jag ha alla mina pj�ser i spelplanens center f�r att vinna
* Som spelare vill jag kunna spara spelet f�r att kunna ta upp det igen efter paus
* Som spelare vill jag kunna h�mta tidigare spel f�r att kunna �teruppta det

## Diagram
* <a href="https://viewer.diagrams.net/?highlight=0000ff&edit=_blank&layers=1&nav=1&title=CRCDiagram.drawio#Uhttps%3A%2F%2Fraw.githack.com%2FPGVSNH20%2Fludo-game-ludo1%2Fmain%2FDocumentation%2FCRCDiagram.drawio">CRC</a>
* <a href="https://viewer.diagrams.net/?highlight=0000ff&edit=_blank&layers=1&nav=1&title=CRCDiagram.drawio#Uhttps%3A%2F%2Fraw.githack.com%2FPGVSNH20%2Fludo-game-ludo1%2Fmain%2FDocumentation%2FCRCDiagram_final.drawio">CRC Final</a>
* <a href="https://viewer.diagrams.net/?highlight=0000ff&edit=_blank&layers=1&nav=1&title=CRCDiagram.drawio#Uhttps%3A%2F%2Fraw.githack.com%2FPGVSNH20%2Fludo-game-ludo1%2Fmain%2FDocumentation%2FUseCaseDiagram.drawio">Use case</a>

## Klasser
### GameBoard
* H�ller information om:
  * Vart pj�ser befinner sig relativt till varandra
  * Vart pj�ser befinner sig relativt till virtuell 2D br�da
* Har metoder som kan:
  * Ber�kna olika positioner p� banor och br�dan utifr�n pj�sernas position
  * Skriva ut representation av 2D br�dan i konsolen
### GameDice
* H�ller referens till System.Random instans
* Har metod som tar fram slumpm�ssigt siffra fr�n 1 till 6
* Har metod som simulerar grafiskt kastning av t�rning i konsolen
### GameMove
* H�ller information om:
  * Spelare som �ger "move"
  * Pj�sen som anv�nds i "move"
  * Pj�sens ursprungliga position
  * Resultat fr�n t�rnings kast i aktuella "move"
### GamePiece
* H�ller information om:
  * Vilken f�rg �r det p� pj�sen
  * Vilken nummer pj�sen har
  * Position pj�sen befinner sig relativt till start och slut av pj�sens bana.
### LudoGame
* H�ller information om:
  * Vilka spelare som deltar i spelet
  * Alla "moves" som exekveras i spelet
  * Referens till spelare som �r vinnare
  * Upps�ttning av pj�ser som anv�nds i spelet
  * Referens till spelare som har n�sta "move"
  * Namn p� spelet
  * N�r spelet skapades
  * N�r spelet sist �ndrades
### GamePlayer
* H�ller information om:
  * Spelares namn
  * Spelares spelf�rg
  * Spelares typ (m�nniska eller robot)
### GamePlayers
* H�ller information om:
  * Upsetting av spelare som ing�r i ett spel
  * Antal spelare i upps�ttningen
### GameRunner
* H�ller information om:
  * Referens till aktuella spel
  * Referens till t�rning
  * Referens till br�da
  * Referens till GameAI
* Har metoder som kan:
  * Skapa och lagra ny spel
  * Ladda upp tidigare spel
  * Spela skapade eller laddade spel:
    * Skapa ny move
    * Exekvera move och lagra den
### InputDialogs
* Har metoder som kan:
  * Starta konsol dialog f�r att skapa nytt spel*
  * Starta konsol dialog f�r att ange antal spelare
  * Starta konsol dialog f�r att skapa spelare*
  * Starta konsol dialog f�r att v�lja vilken pj�s som ska flyttas
  * Starta konsol dialog f�r att v�lja vilken spel som ska laddas upp
### Tools
* Har metoder som kan:
  * Skapa upps�ttning av pj�s utifr�n antal anv�ndare och dess f�rg
  * Skapa lista med pj�s som g�r att flytta i aktuell "move" enligt spel reglarna
  * Ber�kna nya pj�s position
  * S�tta f�rgen p� text utifr�n spelf�rgen
