# Documentation

Use this file to fill in your documentation
### Mob programmering schema
|   |  1 |  2 | 3  |  4 |
|---|---|---|---|---|
| driver  | edgar  | elsa  | emil  |  daniel |
| cd  |  elsa |  edgar |  daniel |  emil |
| timer  | emil  | daniel  | edgar  | elsa  |
| spy  | daniel  | emil  | elsa  |  edgar |


### User stories
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

### Klasser
* GamePiece
* User
* Dice	
	* ThrowValue
	* ThrowDice()
* GameBoard
	* BoardTrack
	* FinalTrack
* Move
	* UserName
	* GamePieceId
	* DiceThrowValue
	* GamePiecePosition
* GameEngineAPI
	* Lista med GamePiece