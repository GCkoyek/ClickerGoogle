# Clicker Game  
Mobilna gra typu idle‑clicker stworzona w Unity z integracją Firebase

Projekt to wieloplatformowa gra mobilna typu clicker, przygotowana na Android i iOS. Rozgrywka opiera się na szybkim zdobywaniu punktów, ulepszaniu statystyk oraz progresji opartej na danych przechowywanych w chmurze. Firebase odpowiada za logowanie, synchronizację postępu i trwałe przechowywanie danych gracza.

---

## **Funkcjonalności**

- Intuicyjna rozgrywka typu clicker/idle  
- System ulepszeń zwiększających tempo zdobywania punktów  
- Zapis i odczyt postępu w Firebase Realtime Database  
- Logowanie użytkownika (anonimowe lub przez Firebase Auth)  
- Automatyczna synchronizacja danych między urządzeniami  
- Obsługa Android i iOS z jednym kodem źródłowym  
- Lekka, responsywna architektura zoptymalizowana pod urządzenia mobilne  

---

## **Technologie**

- Unity (2021/2022+)  
- C#  
- Firebase Realtime Database  
- Firebase Authentication  
- Unity Mobile Build System  
- ScriptableObjects (konfiguracja ulepszeń)  
- Unity UI Toolkit / Canvas UI  

---

## **Architektura projektu**

### **1. System progresji**
Odpowiada za:

- naliczanie punktów za kliknięcia,  
- generowanie pasywnego dochodu (idle),  
- obsługę ulepszeń wpływających na mnożniki i tempo,  
- aktualizację UI w czasie rzeczywistym.

Logika jest odseparowana od warstwy prezentacji, co ułatwia rozwój i testowanie.

---

### **2. Integracja Firebase**
Warstwa komunikacji z chmurą obejmuje:

- logowanie użytkownika (anonimowe lub przez konto Google/Apple),  
- zapis postępu do Realtime Database,  
- odczyt danych przy starcie gry,  
- synchronizację zmian w tle,  
- zabezpieczenia danych (reguły Firebase).

Dane gracza przechowywane są w strukturze:

```
users/
   userId/
      score: int
      upgrades:
         upgrade1: level
         upgrade2: level
```

---

### **3. UI i interakcje**
Interfejs został zaprojektowany z myślą o urządzeniach mobilnych:

- duży przycisk główny (core gameplay),  
- panel ulepszeń,  
- panel profilu użytkownika,  
- wskaźniki postępu i mnożników,  
- animacje i efekty wizualne zwiększające dynamikę gry.

---

### **4. System ulepszeń**
Ulepszenia są definiowane w ScriptableObjects:

- koszt,  
- mnożnik,  
- przyrost pasywny,  
- skalowanie kosztów,  
- opis i nazwa.

Dzięki temu dodawanie nowych ulepszeń nie wymaga zmian w kodzie.

---

### **5. Obsługa platform mobilnych**
Projekt jest przygotowany do kompilacji na:

- **Android (ARMv7/ARM64)**  
- **iOS (IL2CPP)**  

Z uwzględnieniem:

- optymalizacji pamięci,  
- kompresji assetów,  
- responsywnego UI,  
- obsługi różnych DPI i proporcji ekranu.

---

## **Struktura projektu**

```
/Scripts
    Core/
        ClickManager.cs
        IdleManager.cs
        UpgradeManager.cs
    Firebase/
        FirebaseInitializer.cs
        FirebaseAuthService.cs
        FirebaseDatabaseService.cs
    UI/
        MainUI.cs
        UpgradeUI.cs
        ProfileUI.cs
    Data/
        UpgradeData.cs (ScriptableObject)

/Resources
    Upgrades/

/Prefabs
    UI Elements
    Managers
```

---

## **Przepływ gry**

1. Uruchomienie aplikacji i inicjalizacja Firebase  
2. Automatyczne logowanie użytkownika  
3. Pobranie danych z chmury  
4. Wyświetlenie głównego ekranu gry  
5. Gracz klika, zdobywa punkty i kupuje ulepszenia  
6. Postęp jest zapisywany w tle do Firebase  
7. Po ponownym uruchomieniu gra kontynuuje od ostatniego stanu  

---

## **Jak uruchomić projekt**

1. Zainstaluj Unity (2021/2022+).  
2. Włącz obsługę Android/iOS w Unity Hub.  
3. Skonfiguruj Firebase w konsoli:  
   - utwórz projekt,  
   - dodaj aplikację Android/iOS,  
   - pobierz `google-services.json` / `GoogleService-Info.plist`.  
4. Umieść pliki konfiguracyjne w projekcie Unity.  
5. Zainstaluj Firebase SDK przez Unity Package Manager.  
6. Uruchom scenę startową i przetestuj logowanie oraz zapis danych.  

---

## **Wymagania**

- Unity 2021/2022+  
- Konto Firebase  
- Firebase SDK for Unity  
- Android SDK / Xcode (dla iOS)  

---

## **Dalszy rozwój**

- system misji i zadań dziennych,  
- ranking globalny oparty na Firebase,  
- powiadomienia push (Firebase Cloud Messaging),  
- tryb offline z synchronizacją po powrocie online,  
- animacje 2D/3D zwiększające dynamikę rozgrywki,  
- sklep premium i mikropłatności.  
