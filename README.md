﻿<div align="center">

![L4D2](https://torneiol4d2.blob.core.windows.net/imgs/icon-256.png)

</div>

# L4D2 Play Stats

Allows extracting existing data from statistics files generated by the *l4d2_playstats.smx* plugin.

[![Build Status](https://dev.azure.com/altairsossai/L4D2%20-%20Play%20Stats/_apis/build/status/build-l4d2-playstats?branchName=main)](https://dev.azure.com/altairsossai/L4D2%20-%20Play%20Stats/_build/latest?definitionId=30&branchName=main)
[![NuGet](https://img.shields.io/nuget/v/L4D2PlayStats.svg)](https://www.nuget.org/packages/L4D2PlayStats)

## Installation

```PM>
dotnet add package L4D2PlayStats
```

## Enabling statistics logging on the Left 4 Dead 2 server.
To enable statistics, you must have the *l4d2_playstats.smx* plugin installed on the server and add the following parameters to the configuration file:
```code
confogl_addcvar sm_stats_writestats 1
-- or
sm_cvar sm_stats_writestats 1
```
See more details at: https://github.com/SirPlease/L4D2-Competitive-Rework

## How to use
Just instantiate the Statistics class passing the content of the statistics file as a parameter
```csharp
var content = @"[Gameround:11]
11;2023-02-04;03:13;4;VanillaMod v2.8;c8m1_apartment;

[RoundHalf:0]
0;A;0;3;0;0;145;16;4721;20;1;0;4;1;36;1675480206;1675480402;0;0;1675480319;1675480402;

[Progress:A]
0;A;0;400;11629.93;7333.72;9998.64;9998.64;7277.55;8428.84;8428.84;7926.63;9998.64;

[Players:A]:
1;8;STEAM_1:0:15152893;0;58;0;0;0;20;0;0;2;0;0;2;0;0;0;16;0;0;0;0;0;0;20;4;2;0;1230;0;1;1;0;0;0;0;0;0;0;0;0;0;0;0;0;84;15;8;0;0;0;0;0;0;0;13;0;2;0;0;0;0;0;7;0;0;0;0;1;15;8;0;0;1675480206;1675480402;1675480206;1675480359;1675480206;1675480324;
2;11;STEAM_1:1:57980687;0;418;0;0;0;173;0;0;11;0;0;5;0;0;0;46;0;0;0;23;0;0;44;17;6;3;1511;698;1;0;0;0;0;0;0;1;0;0;0;0;0;0;0;117;10;16;0;532;119;0;0;0;0;10;0;0;0;0;0;0;0;10;0;2;0;0;4;10;16;5;3136;1675480206;1675480402;1675480206;1675480402;1675480206;1675480402;
.....
";

var statistics = new Statistics(content);
```

Small sample of the values present in the Statistics class.
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
