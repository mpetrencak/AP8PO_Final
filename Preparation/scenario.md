1) Obecný scénář Vaší aplikace.

Úvazek = <0;1>

x <= 0,5 - poloviční úvazek

x <= 0,25 - čtvrtinový úvazek


Předmět
- entita, která má zkratku, název, rozsah přednášek, cvičení a seminářů, způsob ukončení a počet kreditů
- patří do jednoho nebo více studijních oborů
- je vyučován jedním nebo více zaměstnanci

Způsob zakončení předmětu
- klasifikovaný zápočet nebo zkouška
- je obodován úvazkovými body
- je vykonáván jedním zaměstnancem

Štítek
- je přednáška, cvičení nebo seminář
- je obodován úvazkovými body
- je k němu přiřazen jeden zaměstnanec
- má nastavitelný maximální počet studentů

Zaměstnanec
- entita, která má jméno, e-mail a telefonní číslo
- může mít míru úvazku
- nemusí mít žádný úvazek, pokud se jedná o doktoranda nebo externího vyučujícího
- je zařazen k žádnému nebo více štítkům

Studijní obor
- entita, která má název a zkratku
- obsahuje seznam předmětů
- má jednu nebo více forem studia
- obsahuje počet studentů

Forma studia
- prezenční nebo kombinovaná

Aplikace
- slouží tajemníkovi ústavu pro navržení úvazkových listů pro jednotlivé zaměstnance
- nemusí poskytovat funkci přihlašování
- musí perzistentně ukládat data dvěma způsoby: pomocí SQL databáze a XML databáze
- generuje štítky na základě počtu studentů ve studijním oboru
- obsahuje formulář pro vytvoření nového studijního oboru
- uživatel může studijní obor upravit a smazat
- obsahuje formulář pro vytvoření nového zaměstnance
- uživatel může zaměstnance upravit a smazat
- obsahuje formulář pro vytvoření nového předmětu
- uživatel může předmět upravit a smazat
- uživatel může ručně upravit maximální počet studentů u štítku a způsobu zakončení studia
- uživatel může ručně ke štítku přiřadit zaměstnance
- uživatel může ručně u štítku změnit zaměstnance
- uživatel může štítek smazat
- obsahuje formulář pro zadání počtu studentů

2) Otázky na které se chcete zeptat.

Jaké jsou vzorečky na výpočet bodů úvazku?

3) Technologie, které chcete použít.

WPF, C#, XML, SQLite, MVC