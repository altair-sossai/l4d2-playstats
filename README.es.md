# L4D2 Play Stats

🌐 [English](README.md) | [Português](README.pt.md) | **Español**

Permite extraer los datos de los archivos de estadísticas generados por el plugin *l4d2_playstats.smx*.

[![Build Status](https://dev.azure.com/altairsossai/L4D2%20-%20Play%20Stats/_apis/build/status/build-l4d2-playstats?branchName=main)](https://dev.azure.com/altairsossai/L4D2%20-%20Play%20Stats/_build/latest?definitionId=30&branchName=main)
[![NuGet](https://img.shields.io/nuget/v/L4D2PlayStats.svg)](https://www.nuget.org/packages/L4D2PlayStats)

La biblioteca tiene como destino **.NET 10** (`net10.0`) y no depende de otros paquetes.

## Instalación

```shell
dotnet add package L4D2PlayStats
```

## Habilitar el registro de estadísticas en el servidor de Left 4 Dead 2
Para habilitar las estadísticas, el plugin *l4d2_playstats.smx* debe estar instalado en el servidor y hay que agregar los siguientes parámetros al archivo de configuración:
```code
confogl_addcvar sm_stats_writestats 1
-- or
sm_cvar sm_stats_writestats 1
```
Más detalles en: https://github.com/SirPlease/L4D2-Competitive-Rework

Cómo el plugin escribe los archivos:
- Solo en modo versus, en `addons/sourcemod/logs/`, un archivo por mapa, con el nombre `<yyyy-MM-dd>_<HH-mm>_<round>_<map>.txt` (por ejemplo `2023-02-04_03-13_0011_c8m1_apartment.txt`).
- El archivo se crea al final de la primera mitad y se completa al final de la segunda mitad. Las secciones `[Scoring:]` y `[PlayerNames:]` solo se escriben después de la segunda mitad, así que un archivo leído después de la primera mitad no tiene marcador ni nombres de jugadores.
- `sm_stats_writestats 2` también agrega tablas legibles al mismo archivo. La biblioteca se prueba con archivos escritos con `1`.

Para enviar estos archivos a [l4d2-playstats-api](https://github.com/altair-sossai/l4d2-playstats-api), usa el plugin [l4d2_playstats_sync](https://github.com/altair-sossai/l4d2-zone-server/blob/master/addons/sourcemod/plugins/optional/l4d2_playstats_sync.smx).

## Cómo usar
Pasa el contenido de un archivo de estadísticas al constructor de `Statistics`, o usa `Statistics.TryParse`, que devuelve `false` en lugar de lanzar una excepción cuando el contenido está vacío o no es válido.

```csharp
using L4D2PlayStats;

var content = File.ReadAllText("2023-02-04_03-13_0011_c8m1_apartment.txt");

if (!Statistics.TryParse(content, out var statistics) || statistics == null)
{
    Console.WriteLine("Not a valid statistics file.");
    return;
}

var gameRound = statistics.GameRound;
Console.WriteLine($"{gameRound?.MapName} - {gameRound?.ConfigurationName} - {statistics.MapElapsed}");

foreach (var half in statistics.Halves)
{
    Console.WriteLine($"Team {half.RoundHalf?.Team}: SI killed {half.RoundHalf?.SiKilled}, MVP (SI damage) {half.MvpSiDamage?.PlayerName}");

    foreach (var player in half.Players)
    {
        Console.WriteLine($"  {player.PlayerName} {player.ProfileUrl}: SI damage {player.SiDamage}, common {player.Common}, FF given {player.FfGiven}");
    }

    foreach (var infected in half.InfectedPlayers)
    {
        Console.WriteLine($"  {infected.PlayerName}: damage {infected.DmgTotal}, spawns {infected.Spawns}");
    }
}

if (statistics.Scoring is { } scoring)
{
    Console.WriteLine($"A {scoring.TeamA?.Score} x {scoring.TeamB?.Score} B");
}
```

Un archivo de estadísticas tiene este formato (resumido):
```text
[Gameround:11]
11;2023-02-04;03:13;4;VanillaMod v2.8;c8m1_apartment;

[RoundHalf:0]
0;A;0;3;0;0;145;16;4721;20;1;0;4;1;36;1675480206;1675480402;0;0;1675480319;1675480402;

[Progress:A]
0;A;0;400;11629.93;7333.72;9998.64;9998.64;7277.55;8428.84;8428.84;7926.63;9998.64;

[Players:A]:
1;8;STEAM_1:0:15152893;0;58;0;0;0;20;0;0;2;0;0;2;0;0;0;16;0;0;0;0;0;0;20;4;2;0;1230;0;1;1;0;0;0;0;0;0;0;0;0;0;0;0;0;84;15;8;0;0;0;0;0;0;0;13;0;2;0;0;0;0;0;7;0;0;0;0;1;15;8;0;0;1675480206;1675480402;1675480206;1675480359;1675480206;1675480324;
2;11;STEAM_1:1:57980687;0;418;0;0;0;173;0;0;11;0;0;5;0;0;0;46;0;0;0;23;0;0;44;17;6;3;1511;698;1;0;0;0;0;0;0;1;0;0;0;0;0;0;0;117;10;16;0;532;119;0;0;0;0;10;0;0;0;0;0;0;0;10;0;2;0;0;4;10;16;5;3136;1675480206;1675480402;1675480206;1675480402;1675480206;1675480402;
.....
```

Un archivo completo está en [L4D2PlayStats.UnitTest/Statistics](https://github.com/altair-sossai/l4d2-playstats/tree/main/L4D2PlayStats.UnitTest/Statistics).

### Tipos principales

| Tipo | Qué contiene |
|------|--------------|
| `Statistics` | `GameRound`, `Halves`, `Scoring`, `PlayerNames`, `TeamA` / `TeamB` (nombres de los supervivientes de cada equipo), `MapStart`, `MapEnd`, `MapElapsed`. `ToString()` vuelve a escribir el contenido en el formato de archivo del plugin. |
| `GameRound` | `Round`, `When`, `TeamSize`, `ConfigurationName`, `MapName`. |
| `Statistics.Half` | `RoundHalf`, `Progress`, `Players`, `InfectedPlayers`, además de `MvpSiDamage`, `MvpCommon`, `LvpFfGiven` y las secuencias ordenadas `MvpsSiDamage`, `MvpsCommon`, `LvpsFfGiven`. |
| `RoundHalf` | Totales del equipo en la mitad: `Team`, `Restarts`, `PillsUsed`, `KitsUsed`, `DefibsUsed`, `Common`, `SiKilled`, `SiDamage`, `SiSpawned`, `WitchKilled`, `TankKilled`, `Incaps`, `Deaths`, `FfDamageTotal`, horas de inicio/fin/pausa/tank y `RoundElapsed`, `PauseElapsed`, `TankElapsed`. |
| `Progress` | `Team`, `Survived`, `MaxCompletionScore`, `MaxFlowDist` y la lista de `Flows` (`FarFlowDist`, `CurFlowDist`). |
| `Player` | Un superviviente en una mitad: disparos, impactos y headshots por clase de arma, `Common`, `SiKilled`, `SiDamage`, skeets, levels, crowns, `DmgTaken`, fuego amigo causado/recibido (totales y por tipo), `TankDamage`, `WitchDamage`, horas de presencia/vivo/de pie. |
| `InfectedPlayer` | Un jugador infectado en una mitad: daño (`DmgTotal`, `DmgUpright`, `DmgTank`, ...), `HunterDPs`, `JockeyDPs`, `DeathCharges`, `Booms`, `Ledged`, spawns por clase, `TankPasses`, horas de presencia. |
| `Scoring` | `TeamA` / `TeamB` (`Letter`, `FirstScoresSet`, `Score`), `ScoreDiff`, `Draw`, `TeamAWon`, `TeamBWon`. |
| `PlayerName` | `Index`, `SteamId`, `Name`. |

`Player`, `InfectedPlayer` y `PlayerName` exponen `SteamId` (tal como lo escribe el plugin, por ejemplo `STEAM_1:0:15152893`) y los derivados `CommunityId` (SteamID64), `Steam3` y `ProfileUrl`. `PlayerName` en `Player` / `InfectedPlayer` se rellena a partir de la sección `[PlayerNames:]`, así que es `null` mientras esa sección no existe.

`RoundHalf`, `Player` e `InfectedPlayer` también tienen un indexador por los enums `RoundStats`, `PlayerStats` e `InfectedStats` (namespace `L4D2PlayStats.Enums`) que devuelve cada valor como `long` (las horas en segundos Unix); los métodos de extensión `DataType()` en `L4D2PlayStats.Extensions` indican si un campo es un número o una fecha.

Las horas leídas de timestamps Unix (`StartTime`, `MapStart`, `TimeStartPresent`, ...) son valores `DateTime` en UTC. `GameRound.When` es la fecha y hora local del servidor, tal como se escribe en el archivo.

Pequeña muestra de los valores presentes en la clase Statistics.
```json
{
    "GameRound": {
        "Round": 11,
        "When": "2023-02-04T03:13:00",
        "TeamSize": 4,
        "ConfigurationName": "VanillaMod v2.8",
        "MapName": "c8m1_apartment"
    },
    "Halves": [
        {
            "RoundHalf": {
                "Round": 0,
                "Team": "A",
                "Restarts": 0,
                "PillsUsed": 3,
                "KitsUsed": 0,
                "DefibsUsed": 0,
                "Common": 145,
                "SiKilled": 16,
                "SiDamage": 4721,
                ...
                "StartTimeTank": "2023-02-04T03:11:59Z",
                "StopTimeTank": "2023-02-04T03:13:22Z"
            },
            ...
        },
        ...
    ],
   ...
}
```

## Compilar y probar
Requiere el SDK de .NET 10.

```shell
git clone https://github.com/altair-sossai/l4d2-playstats.git
cd l4d2-playstats
dotnet build
dotnet test
```

Las pruebas (MSTest) están en `L4D2PlayStats.UnitTest`. `StatisticsTests` lee el archivo de ejemplo en `L4D2PlayStats.UnitTest/Statistics` y comprueba que `ToString()` lo reproduce línea por línea.

## Publicación
`azure-pipelines.yml` se ejecuta en cada push a `main`: compila, ejecuta las pruebas, empaqueta la biblioteca usando el número de build como versión del paquete (`1.0.0.<revision>`, que reemplaza el `<Version>` del csproj) y publica el `.nupkg` como el artefacto de build `package`. El envío de ese artefacto a nuget.org no lo hace ese archivo.

Para crear y enviar un paquete por tu cuenta:

```shell
dotnet pack L4D2PlayStats/L4D2PlayStats.csproj -c Release -o ./artifacts -p:PackageVersion=1.0.0-local
dotnet nuget push ./artifacts/L4D2PlayStats.1.0.0-local.nupkg --source https://api.nuget.org/v3/index.json --api-key <your-api-key>
```

El id de paquete `L4D2PlayStats` en nuget.org pertenece a este proyecto, así que para publicar un fork cambia el `<PackageId>` en `L4D2PlayStats/L4D2PlayStats.csproj`, o envíalo a tu propio feed. El paquete incluye el README en inglés y `assets/icon.png`.

## Repositorios relacionados
- [l4d2-playstats-api](https://github.com/altair-sossai/l4d2-playstats-api): API que almacena, procesa y sirve los datos de las partidas, construida sobre este paquete.
- [l4d2-zone-server](https://github.com/altair-sossai/l4d2-zone-server): archivos del servidor, incluido el plugin `l4d2_playstats_sync`.
- [L4D2-Competitive-Rework](https://github.com/SirPlease/L4D2-Competitive-Rework): origen del plugin *l4d2_playstats.smx* y de las configs competitivas.
