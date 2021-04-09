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
* Som spelare vill jag slå tärning så att jag får ett antal steg för att gå med viss pjäs
* Som spelare vill jag välja viss pjäs så den kan förflyttas
* Som spelare vill jag kunna se allas spelares pjäser och dess position för att planera mitt nästa drag
* Som spelare vill jag kunna knuffa ut annan spelare så att den måste börja om från start för att pjäserna hamnar på samma position
* Som spelare vill jag få avslutnings rapport om spelet för att veta vem som vann
* Som spelare vill jag kunna lägga ut en pjäs för att jag har kastat 1
* Som spelare vill jag kunna lägga ut en pjäs och flytta 6 steg eller två pjäser och flytta 1 steg för att jag har kastat 6
* Som spelare vill jag få ett extra kast för att jag har kastat 6
* Som spelare vill jag kunna välja färg på mina pjäser för att bestämma vilken färg jag spelar med
* Som spelare vill jag att mina pjäser flyttar sig medsols runt spelplanen för att komma i mål
* Som spelare vill jag slå rätt siffra för kunna flytta mig till dess center efter ett varv på brädet
* Som spelare vill jag att min pjäs flyttas bakåt om jag slår för många steg in i mål för att siffran  måste vara rätt
* Som spelare vill jag ha alla mina pjäser i spelplanens center för att vinna
* Som spelare vill jag kunna spara spelet för att kunna ta upp det igen efter paus
* Som spelare vill jag kunna hämta tidigare spel för att kunna återuppta det

## Diagram
* <a href="https://viewer.diagrams.net/?highlight=0000ff&edit=_blank&layers=1&nav=1&title=CRCDiagram.drawio#Uhttps%3A%2F%2Fraw.githack.com%2FPGVSNH20%2Fludo-game-ludo1%2Fmain%2FDocumentation%2FCRCDiagram.drawio">CRC</a>
* <a href="https://viewer.diagrams.net/?highlight=0000ff&edit=_blank&layers=1&nav=1&title=CRCDiagram.drawio#Uhttps%3A%2F%2Fraw.githack.com%2FPGVSNH20%2Fludo-game-ludo1%2Fmain%2FDocumentation%2FCRCDiagram_final.drawio">CRC Final</a>
* <a href="https://viewer.diagrams.net/?highlight=0000ff&edit=_blank&layers=1&nav=1&title=CRCDiagram.drawio#Uhttps%3A%2F%2Fraw.githack.com%2FPGVSNH20%2Fludo-game-ludo1%2Fmain%2FDocumentation%2FUseCaseDiagram.drawio">Use case</a>

## Klasser
### GameBoard
* Håller information om:
  * Vart pjäser befinner sig relativt till varandra
  * Vart pjäser befinner sig relativt till virtuell 2D bräda
* Har metoder som kan:
  * Beräkna olika positioner på banor och brädan utifrån pjäsernas position
  * Skriva ut representation av 2D brädan i konsolen
### GameDice
* Håller referens till System.Random instans
* Har metod som tar fram slumpmässigt siffra från 1 till 6
* Har metod som simulerar grafiskt kastning av tärning i konsolen
### GameMove
* Håller information om:
  * Spelare som äger "move"
  * Pjäsen som används i "move"
  * Pjäsens ursprungliga position
  * Resultat från tärnings kast i aktuella "move"
### GamePiece
* Håller information om:
  * Vilken färg är det på pjäsen
  * Vilken nummer pjäsen har
  * Position pjäsen befinner sig relativt till start och slut av pjäsens bana.
### LudoGame
* Håller information om:
  * Vilka spelare som deltar i spelet
  * Alla "moves" som exekveras i spelet
  * Referens till spelare som är vinnare
  * Uppsättning av pjäser som används i spelet
  * Referens till spelare som har nästa "move"
  * Namn på spelet
  * När spelet skapades
  * När spelet sist ändrades
### GamePlayer
* Håller information om:
  * Spelares namn
  * Spelares spelfärg
  * Spelares typ (människa eller robot)
### GamePlayers
* Håller information om:
  * Upsetting av spelare som ingår i ett spel
  * Antal spelare i uppsättningen
### GameRunner
* Håller information om:
  * Referens till aktuella spel
  * Referens till tärning
  * Referens till bräda
  * Referens till GameAI
* Har metoder som kan:
  * Skapa och lagra ny spel
  * Ladda upp tidigare spel
  * Spela skapade eller laddade spel:
    * Skapa ny move
    * Exekvera move och lagra den
      * Updatera pjäsens position
      * Updatera eventeulla oponents pjäs position
      * Updatera spel bräda 
### InputDialogs
* Har metoder som kan:
  * Starta konsol dialog för att skapa nytt spel
  * Starta konsol dialog för att ange antal spelare
  * Starta konsol dialog för att skapa spelare*
  * Starta konsol dialog för att välja vilken pjäs som ska flyttas
  * Starta konsol dialog för att välja vilken spel som ska laddas upp
### Tools
* Har metoder som kan:
  * Skapa uppsättning av pjäs utifrån antal användare och dess färg
  * Skapa lista med pjäs som gör att flytta i aktuell "move" enligt spel reglarna
  * Beräkna nya pjäs position
  * Sätta färgen på text utifrån spelfärgen
