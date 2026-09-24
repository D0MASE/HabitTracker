# Self Improvement Tracker

## Projekto pavadinimas

Self Improvement Tracker

## Sprendžiamo uždavinio aprašymas

Projekto tikslas – sukurti internetinę savęs tobulinimo ir kasdienių įpročių sekimo sistemą, kuri padėtų naudotojui formuoti ir palaikyti teigiamus įpročius bei motyvuotų juos reguliariai atlikti.

Naudotojas sistemoje gali susikurti asmenines savęs tobulinimo užduotis, pavyzdžiui, skaityti knygą, sportuoti, anksti keltis, mokytis ar atlikti kitą pasirinktą veiklą.

Kiekvieną dieną naudotojas gali pažymėti, ar konkrečią užduotį atliko. Už atliktas užduotis skiriamas reward. Sistema taip pat seka užduočių atlikimo serijas (streak).

## Sistemos paskirtis

Sistema skirta:

- savęs tobulinimo tikslams kurti ir valdyti;
- kasdieniams įpročiams ir užduotims sekti;
- atliktų užduočių istorijai saugoti;
- reward skaičiavimui;
- streak sekimui;
- savaitės ir ankstesnių savaičių statistikai peržiūrėti.

## Funkciniai reikalavimai

### Neregistruotas sistemos naudotojas

Neregistruotas naudotojas galės:

1. Peržiūrėti sistemos reprezentacinį puslapį.
2. Peržiūrėti pagrindinę informaciją apie sistemos veikimą.
3. Užsiregistruoti sistemoje.
4. Prisijungti prie internetinės aplikacijos.

### Registruotas sistemos naudotojas

Registruotas naudotojas galės:

1. Prisijungti prie internetinės aplikacijos.
2. Atsijungti nuo internetinės aplikacijos.
3. Peržiūrėti ir redaguoti savo profilio informaciją.
4. Sukurti naują tikslą (Goal).
5. Peržiūrėti savo tikslų sąrašą.
6. Peržiūrėti konkretaus tikslo informaciją kartu su jam priskirtais įpročiais.
7. Redaguoti tikslą.
8. Pašalinti tikslą.
9. Sukurti naują savęs tobulinimo užduotį (Habit) ir priskirti ją konkrečiam tikslui.
10. Peržiūrėti savo užduočių sąrašą.
11. Peržiūrėti konkrečios užduoties informaciją.
12. Redaguoti savo užduotį.
13. Pašalinti savo užduotį.
14. Pažymėti užduotį kaip atliktą konkrečią dieną.
15. Peržiūrėti konkrečios užduoties atlikimų istoriją.
16. Peržiūrėti savaitės užduočių atlikimo statistiką.
17. Peržiūrėti uždirbtą reward.
18. Peržiūrėti dabartinius ir pasiektus streak.
19. Peržiūrėti ankstesnių savaičių rezultatus.

### Administratorius

Administratorius galės:

1. Peržiūrėti registruotų naudotojų sąrašą.
2. Peržiūrėti naudotojo informaciją.
3. Šalinti naudotojus.
4. Peržiūrėti sistemoje sukurtus tikslus.
5. Peržiūrėti sistemoje sukurtas užduotis.
6. Šalinti netinkamas užduotis.
7. Peržiūrėti bendrą sistemos statistiką.

## Taikomosios srities objektai

Pagrindiniai trys taikomosios srities objektai:

### Goal

Naudotojo užsibrėžtas savęs tobulinimo tikslas, turintis pavadinimą ir aprašymą.

### Habit

Konkretaus tikslo siekimui priskirtas veiksmas arba įprotis, turintis pavadinimą, aprašymą ir reward reikšmes.

### HabitCompletion

Konkrečios užduoties atlikimo faktas konkrečią kalendorinę dieną.

Objektų tarpusavio ryšys:

**Naudotojas → Goal → Habit → HabitCompletion**

Pavyzdys:

**Naudotojas → Tikslas „Perskaityti 12 knygų per metus“ → Užduotis „Skaityti knygą“ → Užduoties atlikimas**

## Sistemos architektūra

Sistemą sudaro:

- Kliento pusė (Front-End) – grafinė naudotojo sąsaja.
- Serverio pusė (Back-End) – REST API, atsakinga už verslo logiką ir duomenų valdymą.
- Duomenų bazė – reliacinė duomenų bazė, kurioje saugomi naudotojų, užduočių ir jų atlikimų duomenys.
- Autentifikacija ir autorizacija – naudojant JWT žetonus.
- Debesų infrastruktūra – sistema talpinama debesų technologijų pagrindu veikiančiame serveryje.

Kliento pusė su serverio pusėje realizuota REST API komunikuoja naudojant HTTPS protokolą.

API atsakinga už naudotojų, savęs tobulinimo užduočių ir užduočių atlikimų valdymą bei duomenų mainus su duomenų baze.

Reward ir streak apskaičiavimo logika realizuojama serverio pusėje.

## Pasirinktos technologijos

### .NET

.NET aplinka naudojama serverio pusei ir REST API realizuoti.

### MySQL

MySQL naudojama kaip reliacinė duomenų bazė sistemos duomenims saugoti.

### Microsoft Azure

Microsoft Azure naudojama sistemos talpinimui debesų infrastruktūroje.

### REST API

REST API naudojama duomenų mainams tarp kliento pusės ir serverio.

### HTTPS

HTTPS naudojamas saugiam ryšiui tarp naudotojo naršyklės ir serverio API.

### TCP/IP

TCP/IP naudojamas ryšiui tarp serverio pusėje veikiančios API ir MySQL serverio.

### JWT

JWT žetonai naudojami naudotojų autentifikacijai ir autorizacijai.

### Git

Git naudojamas projekto kodo ir dokumentacijos versijų kontrolei.

## REST API

Numatomi pagrindiniai REST API metodai.

### User

- `GET /api/users/{id}` – gauti konkretų naudotoją.
- `POST /api/users` – sukurti naudotoją.
- `PUT /api/users/{id}` – atnaujinti naudotojo informaciją.
- `DELETE /api/users/{id}` – pašalinti naudotoją.
- `GET /api/users` – grąžinti naudotojų sąrašą.

### Goal

- `GET /api/goals/{id}` – gauti konkretų tikslą.
- `POST /api/goals` – sukurti tikslą.
- `PUT /api/goals/{id}` – atnaujinti tikslą.
- `DELETE /api/goals/{id}` – pašalinti tikslą.
- `GET /api/goals` – grąžinti naudotojo tikslų sąrašą.

### Habit

- `GET /api/habits/{id}` – gauti konkrečią užduotį.
- `POST /api/habits` – sukurti užduotį.
- `PUT /api/habits/{id}` – atnaujinti užduotį.
- `DELETE /api/habits/{id}` – pašalinti užduotį.
- `GET /api/habits` – grąžinti užduočių sąrašą.

### HabitCompletion

- `GET /api/completions/{id}` – gauti konkretų atlikimo įrašą.
- `POST /api/completions` – sukurti atlikimo įrašą.
- `PUT /api/completions/{id}` – atnaujinti atlikimo įrašą.
- `DELETE /api/completions/{id}` – pašalinti atlikimo įrašą.
- `GET /api/completions` – grąžinti atlikimų sąrašą.

Hierarchinis metodas:

`GET /api/goals/{goalId}/habits` – grąžinti konkretaus tikslo įpročių sąrašą.

## Pagrindinis sistemos veikimo scenarijus

1. Naudotojas užsiregistruoja ir prisijungia prie sistemos.
2. Naudotojas susikuria tikslą.
3. Naudotojas tikslui priskiria savęs tobulinimo užduotį ir nustato reward.
4. Naudotojas kiekvieną dieną pažymi, ar užduotis buvo atlikta.
5. Sistema išsaugo atlikimo informaciją duomenų bazėje.
6. Sistema apskaičiuoja naudotojo reward ir seka užduoties streak.
7. Pasiekus septynių dienų streak, suteikiamas papildomas streak reward.
8. Naudotojas gali peržiūrėti savaitės statistiką ir savo progresą.

## Diegimo architektūra

Sistema diegiama Microsoft Azure serveryje.

Diegimo diagramoje pavaizduoti pagrindiniai sistemos komponentai:

- Client;
- Browser;
- Azure server;
- .NET environment;
- HabitTracker API;
- MySQL server;
- `db.sql` duomenų bazės artefaktas.

Ryšys tarp kliento naršyklės ir API vykdomas naudojant HTTPS.

Ryšys tarp .NET aplinkos ir MySQL serverio vykdomas naudojant TCP/IP.
