# L4D2 Play Stats

🌐 [English](README.md) | **Português** | [Español](README.es.md)

Permite extrair os dados dos arquivos de estatísticas gerados pelo plugin *l4d2_playstats.smx*.

[![Build Status](https://dev.azure.com/altairsossai/L4D2%20-%20Play%20Stats/_apis/build/status/build-l4d2-playstats?branchName=main)](https://dev.azure.com/altairsossai/L4D2%20-%20Play%20Stats/_build/latest?definitionId=30&branchName=main)
[![NuGet](https://img.shields.io/nuget/v/L4D2PlayStats.svg)](https://www.nuget.org/packages/L4D2PlayStats)

A biblioteca tem como alvo o **.NET 10** (`net10.0`) e não depende de outros pacotes.

## Instalação

```shell
dotnet add package L4D2PlayStats
```

## Habilitando o registro de estatísticas no servidor de Left 4 Dead 2
Para habilitar as estatísticas, o plugin *l4d2_playstats.smx* precisa estar instalado no servidor e os seguintes parâmetros precisam ser adicionados ao arquivo de configuração:
```code
confogl_addcvar sm_stats_writestats 1
-- or
sm_cvar sm_stats_writestats 1
```
Mais detalhes em: https://github.com/SirPlease/L4D2-Competitive-Rework

Como o plugin grava os arquivos:
- Somente no modo versus, em `addons/sourcemod/logs/`, um arquivo por mapa, com o nome `<yyyy-MM-dd>_<HH-mm>_<round>_<map>.txt` (por exemplo `2023-02-04_03-13_0011_c8m1_apartment.txt`).
- O arquivo é criado ao fim do primeiro half e complementado ao fim do segundo half. As seções `[Scoring:]` e `[PlayerNames:]` só são gravadas após o segundo half, então um arquivo lido após o primeiro half não tem placar nem nomes de jogadores.
- `sm_stats_writestats 2` também acrescenta tabelas legíveis ao mesmo arquivo. A biblioteca é testada com arquivos gravados com `1`.

Para enviar esses arquivos para a [l4d2-playstats-api](https://github.com/altair-sossai/l4d2-playstats-api), use o plugin [l4d2_playstats_sync](https://github.com/altair-sossai/l4d2-zone-server/blob/master/addons/sourcemod/plugins/optional/l4d2_playstats_sync.smx).

## Como usar
Passe o conteúdo de um arquivo de estatísticas para o construtor de `Statistics`, ou use `Statistics.TryParse`, que retorna `false` em vez de lançar exceção quando o conteúdo está vazio ou é inválido.

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

Um arquivo de estatísticas tem este formato (resumido):
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

Um arquivo completo está em [L4D2PlayStats.UnitTest/Statistics](https://github.com/altair-sossai/l4d2-playstats/tree/main/L4D2PlayStats.UnitTest/Statistics).

### Principais tipos

| Tipo | O que contém |
|------|--------------|
| `Statistics` | `GameRound`, `Halves`, `Scoring`, `PlayerNames`, `TeamA` / `TeamB` (nomes dos sobreviventes de cada time), `MapStart`, `MapEnd`, `MapElapsed`. `ToString()` escreve o conteúdo de volta no formato de arquivo do plugin. |
| `GameRound` | `Round`, `When`, `TeamSize`, `ConfigurationName`, `MapName`. |
| `Statistics.Half` | `RoundHalf`, `Progress`, `Players`, `InfectedPlayers`, além de `MvpSiDamage`, `MvpCommon`, `LvpFfGiven` e das sequências ordenadas `MvpsSiDamage`, `MvpsCommon`, `LvpsFfGiven`. |
| `RoundHalf` | Totais do time no half: `Team`, `Restarts`, `PillsUsed`, `KitsUsed`, `DefibsUsed`, `Common`, `SiKilled`, `SiDamage`, `SiSpawned`, `WitchKilled`, `TankKilled`, `Incaps`, `Deaths`, `FfDamageTotal`, horários de início/fim/pausa/tank e `RoundElapsed`, `PauseElapsed`, `TankElapsed`. |
| `Progress` | `Team`, `Survived`, `MaxCompletionScore`, `MaxFlowDist` e a lista de `Flows` (`FarFlowDist`, `CurFlowDist`). |
| `Player` | Um sobrevivente em um half: tiros, acertos e headshots por classe de arma, `Common`, `SiKilled`, `SiDamage`, skeets, levels, crowns, `DmgTaken`, fogo amigo causado/recebido (totais e por tipo), `TankDamage`, `WitchDamage`, horários de presença/vivo/de pé. |
| `InfectedPlayer` | Um jogador infectado em um half: dano (`DmgTotal`, `DmgUpright`, `DmgTank`, ...), `HunterDPs`, `JockeyDPs`, `DeathCharges`, `Booms`, `Ledged`, spawns por classe, `TankPasses`, horários de presença. |
| `Scoring` | `TeamA` / `TeamB` (`Letter`, `FirstScoresSet`, `Score`), `ScoreDiff`, `Draw`, `TeamAWon`, `TeamBWon`. |
| `PlayerName` | `Index`, `SteamId`, `Name`. |

`Player`, `InfectedPlayer` e `PlayerName` expõem `SteamId` (como gravado pelo plugin, por exemplo `STEAM_1:0:15152893`) e os derivados `CommunityId` (SteamID64), `Steam3` e `ProfileUrl`. `PlayerName` em `Player` / `InfectedPlayer` é preenchido a partir da seção `[PlayerNames:]`, então fica `null` enquanto essa seção não existe.

`RoundHalf`, `Player` e `InfectedPlayer` também têm um indexador pelos enums `RoundStats`, `PlayerStats` e `InfectedStats` (namespace `L4D2PlayStats.Enums`) que retorna cada valor como `long` (horários em segundos Unix); os métodos de extensão `DataType()` em `L4D2PlayStats.Extensions` indicam se um campo é número ou data.

Horários lidos de timestamps Unix (`StartTime`, `MapStart`, `TimeStartPresent`, ...) são valores `DateTime` em UTC. `GameRound.When` é a data e hora local do servidor, como gravada no arquivo.

Pequena amostra dos valores presentes na classe Statistics.
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

## Compilando e testando
Requer o SDK do .NET 10.

```shell
git clone https://github.com/altair-sossai/l4d2-playstats.git
cd l4d2-playstats
dotnet build
dotnet test
```

Os testes (MSTest) ficam em `L4D2PlayStats.UnitTest`. `StatisticsTests` lê o arquivo de exemplo em `L4D2PlayStats.UnitTest/Statistics` e verifica que `ToString()` o reproduz linha a linha.

## Publicação
O `azure-pipelines.yml` roda a cada push na `main`: compila, roda os testes, empacota a biblioteca usando o número do build como versão do pacote (`1.0.0.<revision>`, que sobrescreve o `<Version>` do csproj) e publica o `.nupkg` como o artefato de build `package`. O envio desse artefato para o nuget.org não é feito por esse arquivo.

Para criar e enviar um pacote por conta própria:

```shell
dotnet pack L4D2PlayStats/L4D2PlayStats.csproj -c Release -o ./artifacts -p:PackageVersion=1.0.0-local
dotnet nuget push ./artifacts/L4D2PlayStats.1.0.0-local.nupkg --source https://api.nuget.org/v3/index.json --api-key <your-api-key>
```

O id de pacote `L4D2PlayStats` no nuget.org pertence a este projeto, então para publicar um fork altere o `<PackageId>` em `L4D2PlayStats/L4D2PlayStats.csproj`, ou envie para o seu próprio feed. O pacote inclui o README em inglês e o `assets/icon.png`.

## Repositórios relacionados
- [l4d2-playstats-api](https://github.com/altair-sossai/l4d2-playstats-api): API que armazena, processa e disponibiliza os dados das partidas, construída sobre este pacote.
- [l4d2-zone-server](https://github.com/altair-sossai/l4d2-zone-server): arquivos do servidor, incluindo o plugin `l4d2_playstats_sync`.
- [L4D2-Competitive-Rework](https://github.com/SirPlease/L4D2-Competitive-Rework): origem do plugin *l4d2_playstats.smx* e das configs competitivas.
