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