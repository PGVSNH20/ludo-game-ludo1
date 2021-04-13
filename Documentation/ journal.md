# Dagbok
## 2021-03-30
* Vi diskuterade ludo spelets regaler och vad vi har att förhålla oss till
* Vi skrev några user stories utifrån diskussionen
* Vi diskuterade och påbörjade skissa på några tänkbara klasser (Documentation/readme.md)
* Vi diskuterade och påbörjade en use case diagram (Documentation/UseCaseDiagram.drawio)

## 2021-03-31
* Vi fortsatte med vårt Use Case Diagram (Documentation/UseCaseDiagram.drawio)
* Vi påbörjade ett Class Responsibility Collaborator-diagram (CRC) (Documentation/CRCDiagram.drawio)
* Vi uppdaterade dokumentationen med nya klasser
* Vi skrev till några user stories
* Vi satte upp lokala databas och konfigurerade upp DbContext klass för Entity Framwork ramverket. Vi kommer använda SQL databas. Connectionstring: 
```
"Server=localhost;Database=LudoGameDb;User Id=sa;Password=My!P@ssw0rd1;"
```
## 2021-04-01
* Vi jobbade med LudoGame och GameRunner klasser
* Gjorde om lite GameDice klassen
* Skapade Test projekt och en unittest*
## 2021-04-05
* Vi diskuterade om att eventuellt använda någon form av projektorganiserings verktyg - clickup.com
* Vi diskuterade logik om hur vi ska tänka kring pjäsernas position och dess uppdatering
* Vi jobbade med metoder i GameRunner klassen:
  * CreateNewMove - metod som skapar Move objekt som ska innehålla all information för att utföra steg
  * ExecuteMove - metod 
    * som utför ett Move och uppdaterar pjäsernas position
    * uppdaterar Board tracks
    * uppdaterar opponents pjäsen om det behövs
    * kollar om det finns en vinnare.
## 2021-04-06
* Vi jobbade på med GameRunner klassen
  * Skrev logik som kollar och tar fram pjäser som går att flytta (pjäs för inte stå på samma plats som annan pjäs av samma färg och pjäs för inte hoppa över någon annan pjäs av samma färg)
* Vi påbörjade consolapp och fick göra små fixar och buggrättningar i GameRunner och andra klasser
* Vi gjorde enhetstester för GameBoard, GameRunner, GamePiece
* Vi uppgraderade GameBoard klassen med GUI bräda
* Vi uppgraderade GameDice med grafiskt simulering av tärningskast
## 2021-04-07
* Vi jobbade med GameRunner och kastade om lite metoder.
* Skapade ny namespace "Assets" där vi la en del metoder på klassen Tools från GameRunner för att göra den lättare att förstå
* Vi gjorde en hel del unit tester och provade Xunit ramverk samt Nunit som har ganska enkelt sätt att testa Console.ReadLine och Console.WriteLine stängar.
* Vi fortsatte med tidigare skapad DbContext och lade upp code first datamodel i migreringen
* Vi skapade metoder som lagrar ny spel och lagrar Moves i databasen samt gjorde lite manuella tester.
## 2021-04-08
* Vi försätta jobba med console-application
* Vi skapade metoder för att ladda data från dbcontext och på så sätt kunna fortsätta tidigare spel
* Vi skapade några egenskaper (SpelNamn, AntalSpelare och Datum) på några db context klasser
* Vi skapade och testade AI spelare som kan göra relativt smarta moves
* Vi diskuterade upplägget med video inlämning och kom fram till att vi ska göra plan för scener och manuset
* Diversa små fixar i koden
## 2021-04-09
* Vi skapade övergripande struktur för video och vilka delar som ska presenteras och vem ska presentera dessa
* Vi pimpade till lite välkomst meny
* Vi lade till lite extra data om spelet i spelläge
* Vi gjorde en loop som gör programmet körs tills man aktivt väljer stänga den.
## 2021-04-10
* Vi skapade funktionalitet för att lagra spel till json fil och ladda upp spel från json fil
  * Det är en spel som lagras per fil
  * Efter inläsning av spelet görs kontroll mot databasen om spelet finns lagrat där
    * Om spel finns så fortsätter spelande på den
    * Om inte spel finns görs en djupkloning av spel och ny spel lagras i databasen
## 2021-04-12
* Vi jobbade med inspelning av video
## 2021-04-13
* Vi satt ihop alla delar till en video och la upp den på stream
* Vi la till en datatjänst projekt "LudoGameRESTApi" som kan ta fram lista med alla spel i databasen