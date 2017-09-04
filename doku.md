# WpfApplication1

## Interfaces
Die WPF Anwendung besitzt eine Servicereferenz auf den ServiceContract 'IChatService' und die DataContracts UserData und EventData.
Der ServiceContract repraesentiert die Faehigkeiten des Service-Hosts, die DataContracts definieren das Datenmodell.

Die WPF Anwendung implementiert auch 'IChatClient'. Dort werden die Callback-Funktionen fuer den Client festgelegt.

## GUI
Um InputFelder wie 'DateTimePicker' und 'ColorPicker' benutzen zu koennen, habe ich eine Referenz auf Xceeds WPF Toolkit hinzugefuegt.


Extensions:
- Xceed.Wpf.Toolkit,  [https://github.com/xceedsoftware/wpftoolkit](https://github.com/xceedsoftware/wpftoolkit), 20.08.2017


# Host

Der Host hat eine Referenz auf System.ServiceModel. In 'Program' wird von dort eine Instanz von ServiceHost erzeugt, die vom Typ 'ChatService' ist. So werden alle dort definierten Funktionen und Datenmodelle vom Host angeboten.
Indirekt wird dann ueber den Callback-Contract in 'IChatService' auch 'IChatClient' publiziert.

Weitere wichtige Referenzen im Host sind die auf DAL, Model und das EntityFramework, um die die bestehende Datenbankmodelle nutzten zu koennen.

## Callbacks
Durch die Verwendung von Callbacks auf dem Client muessen die Clients nicht in Intervallen fragen, ob es neue Informationen gibt. So wird der Service entlastet.

## Transparenz
Der ServiceHost bietet CRUD-Funktionalitaet fuer fuer alle seine DataContracts an. Die DataContracts ensprechen weitestgehend den Datenbankmodellen. 
