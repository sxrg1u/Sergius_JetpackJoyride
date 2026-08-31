# Jetpack Joyride
Eine eigene Umsetzung des Jetpack Joyride-Spielprinzips in C# mit Windows Forms.

---

## Über das Projekt
Dieses Projekt ist eine eigene Implementierung des bekannten Jetpack Joyride-Spielprinzips, entwickelt in C# mithilfe von Windows Forms. Ziel war es, ein vollständiges Spiel mit echter Physik-Simulation und dynamisch steigendem Schwierigkeitsgrad zu entwickeln.

Der Spieler steuert einen Charakter durch ein scrollendes Level und muss drei verschiedenen Lasertypen ausweichen, während Schwerkraft und Jetpack-Kraft die Bewegung bestimmen. Je länger man überlebt, desto höher der Score – und desto schwieriger das Spiel.

## Funktionen
• Jetpack-Steuerung – Leertaste gedrückt halten fliegt den Charakter nach oben, loslassen lässt die Schwerkraft wirken
• Drei Lasertypen – Horizontale Laser auf zufälliger Höhe, BottomUp-Laser die von unten aufsteigen, und diagonale Laser die hin- und herspringen
• Physik-Simulation – Schwerkraft, Jetpack-Kraft und Velocity-Clamp mit Math.Clamp() für realistische Bewegung
• Jetpack-Munition – Beim Fliegen werden automatisch gelbe Kugeln nach unten abgefeuert
• Kollisionserkennung – Berührung mit einem Laser führt sofort zum Game Over via Rectangle.IntersectsWith()
• Dynamischer Schwierigkeitsgrad – Lasergeschwindigkeit, Spawn-Rate und Anzahl gleichzeitiger Laser steigen mit dem Score
• Punkte & Highscore – Der aktuelle Punktestand und der Highscore werden live angezeigt
• Neustart – Nach einem Game Over kann das Spiel direkt neu gestartet oder beendet werden

## Was ich gelernt habe
• Game-Loop mit einem Windows Forms Timer (16ms Tick ≈ 60 fps)
• Physik-Simulation mit Schwerkraft, Jetpack-Kraft und Geschwindigkeits-Clamp
• Kollisionserkennung mit Rectangle.IntersectsWith()
• Dynamische Panel-Verwaltung: Objekte zur Laufzeit spawnen, bewegen und entfernen
• Steigendes Schwierigkeitssystem über laserSpeed, laserSpawnInterval und lasersPerSpawn
• Highscore-Tracking und Game-Over-Dialog mit Neustart-Option

## Autor
sxrg1u – Privates Projekt

---

## Download & Spielen
**Schritt 1 – Repository holen:** `git clone https://github.com/sxrg1u/Sergius_JetpackJoyride.git` (oder als ZIP herunterladen).

**Schritt 2 – Projekt öffnen:** Die Datei `Sergius_JetpackJoyride.slnx` mit Visual Studio (2022 oder neuer, Workload ".NET Desktop Development") öffnen.

**Schritt 3 – Starten:** Projekt builden und mit F5 ausführen.

**Voraussetzungen:** Windows, .NET Desktop Runtime, Visual Studio.

**Steuerung:** Leertaste gedrückt halten zum Fliegen (Jetpack), loslassen zum Fallen. Lasern ausweichen und so lange wie möglich überleben!
