# Dagbok
## 2021-03-30
* Vi diskuterade ludo spelets regaler och vad vi har att f�rh�lla oss till
* Vi skrev n�gra user stories utifr�n diskussionen
* Vi diskuterade och p�b�rjade skissa p� n�gra t�nkbara klasser (Documentation/readme.md)
* Vi diskuterade och p�b�rjade en use case diagram (Documentation/UseCaseDiagram.drawio)

## 2021-03-31
* Vi fortsatte med v�rt Use Case Diagram (Documentation/UseCaseDiagram.drawio)
* Vi p�b�rjade ett Class Responsibility Collaborator-diagram (CRC) (Documentation/CRCDiagram.drawio)
* Vi uppdaterade dokumentationen med nya klasser
* Vi skrev till n�gra user stories
* Vi satte upp lokala databas och konfigurerade upp DbContext klass f�r Entity Framwork ramverket. Vi kommer anv�nda SQL databas. Connectionstring: 
```
"Server=localhost;Database=LudoGameDb;User Id=sa;Password=My!P@ssw0rd1;"
```
## 2021-04-01
* Vi jobbade med LudoGame och GameRunner klasser
* Gjorde om lite GameDice klassen
* Skapade Test projekt och en unittest*
## 2021-04-05
* Vi diskuterade om att eventuellt anv�nda n�gon form av projektorganiserings verktyg - clickup.com
* Vi diskuterade logik om hur vi ska t�nka kring pj�sernas position och dess uppdatering
* Vi jobbade med metoder i GameRunner klassen:
  * CreateNewMove - metod som skapar Move objekt som ska inneh�lla all information f�r att utf�ra steg
  * ExecuteMove - metod 
    * som utf�r ett Move och uppdaterar pj�sernas position
    * uppdaterar Board tracks
    * uppdaterar opponents pj�sen om det beh�vs
    * kollar om det finns en vinnare.
## 2021-04-06
* Vi jobbade p� med GameRunner klassen
  * Skrev logik som kollar och tar fram pj�ser som g�r att flytta (pj�s f�r inte st� p� samma plats som annan pj�s av samma f�rg och pj�s f�r inte hoppa �ver n�gon annan pj�s av samma f�rg)
* Vi p�b�rjade consolapp och fick g�ra sm� fixar och buggr�ttningar i GameRunner och andra klasser
* Vi gjorde enhetstester f�r GameBoard, GameRunner, GamePiece
* Vi uppgraderade GameBoard klassen med GUI br�da
* Vi uppgraderade GameDice med grafiskt simulering av t�rningskast
## 2021-04-07
* Vi jobbade med GameRunner och kastade om lite metoder.
* Skapade ny namespace "Assets" d�r vi la en del metoder p� klassen Tools fr�n GameRunner f�r att g�ra den l�ttare att f�rst�
* Vi gjorde en hel del unit tester och provade Xunit ramverk samt Nunit som har ganska enkelt s�tt att testa Console.ReadLine och Console.WriteLine st�ngar.
* Vi fortsatte med tidigare skapad DbContext och lade upp code first datamodel i migreringen
* Vi skapade metoder som lagrar ny spel och lagrar Moves i databasen samt gjorde lite manuella tester.
## 2021-04-08
* Vi f�rs�tta jobba med console-application
* Vi skapade metoder f�r att ladda data fr�n dbcontext och p� s� s�tt kunna forts�tta tidigare spel
* Vi skapade n�gra egenskaper (SpelNamn, AntalSpelare och Datum) p� n�gra db context klasser
* Vi skapade och testade AI spelare som kan g�ra relativt smarta moves
* Vi diskuterade uppl�gget med video inl�mning och kom fram till att vi ska g�ra plan f�r scener och manuset
* Diversa sm� fixar i koden
## 2021-04-09
* Vi skapade �vergripande struktur f�r video och vilka delar som ska presenteras och vem ska presentera dessa
* Vi pimpade till lite v�lkomst meny
* Vi lade till lite extra data om spelet i spell�ge
* Vi gjorde en loop som g�r programmet k�rs tills man aktivt v�ljer st�nga den.
## 2021-04-10
* Vi skapade funktionalitet f�r att lagra spel till json fil och ladda upp spel fr�n json fil
  * Det �r en spel som lagras per fil
  * Efter inl�sning av spelet g�rs kontroll mot databasen om spelet finns lagrat d�r
    * Om spel finns s� forts�tter spelande p� den
    * Om inte spel finns g�rs en djupkloning av spel och ny spel lagras i databasen
## 2021-04-12
* Vi jobbade med inspelning av video
## 2021-04-13
* Vi satt ihop alla delar till en video och la upp den p� stream
* Vi la till en datatj�nst projekt "LudoGameRESTApi" som kan ta fram lista med alla spel i databasen