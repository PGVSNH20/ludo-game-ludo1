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
* Skapade Test projekt och en unitest*
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