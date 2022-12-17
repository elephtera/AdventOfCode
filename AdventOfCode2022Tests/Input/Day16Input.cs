﻿namespace AdventOfCode2022Tests.Input
{
    public class Day16Input : IDayInput
    {
        public IList<string> ExampleInput => new List<string>() { @"Valve AA has flow rate=0; tunnels lead to valves DD, II, BB
Valve BB has flow rate=13; tunnels lead to valves CC, AA
Valve CC has flow rate=2; tunnels lead to valves DD, BB
Valve DD has flow rate=20; tunnels lead to valves CC, AA, EE
Valve EE has flow rate=3; tunnels lead to valves FF, DD
Valve FF has flow rate=0; tunnels lead to valves EE, GG
Valve GG has flow rate=0; tunnels lead to valves FF, HH
Valve HH has flow rate=22; tunnel leads to valve GG
Valve II has flow rate=0; tunnels lead to valves AA, JJ
Valve JJ has flow rate=21; tunnel leads to valve II" };

        public IList<string> Input => new List<string>() { @"Valve FY has flow rate=0; tunnels lead to valves TG, CD
Valve EK has flow rate=12; tunnels lead to valves JE, VE, PJ, CS, IX
Valve NU has flow rate=0; tunnels lead to valves FG, HJ
Valve AY has flow rate=0; tunnels lead to valves EG, KR
Valve DH has flow rate=0; tunnels lead to valves FX, VW
Valve IX has flow rate=0; tunnels lead to valves VW, EK
Valve DZ has flow rate=0; tunnels lead to valves HT, FG
Valve YE has flow rate=0; tunnels lead to valves CI, MS
Valve OO has flow rate=0; tunnels lead to valves FX, CS
Valve SB has flow rate=0; tunnels lead to valves RR, AP
Valve HT has flow rate=4; tunnels lead to valves DZ, GA, CI, DE, JS
Valve MS has flow rate=11; tunnels lead to valves PJ, WG, CA, YE
Valve CD has flow rate=0; tunnels lead to valves UW, FY
Valve IZ has flow rate=0; tunnels lead to valves XF, AP
Valve JE has flow rate=0; tunnels lead to valves EK, TQ
Valve DN has flow rate=0; tunnels lead to valves KR, VE
Valve VW has flow rate=13; tunnels lead to valves DH, IX
Valve UH has flow rate=0; tunnels lead to valves MN, TQ
Valve TB has flow rate=0; tunnels lead to valves AP, BJ
Valve XT has flow rate=0; tunnels lead to valves TQ, UW
Valve RR has flow rate=0; tunnels lead to valves FG, SB
Valve BJ has flow rate=0; tunnels lead to valves TB, AA
Valve DE has flow rate=0; tunnels lead to valves HT, WI
Valve MT has flow rate=0; tunnels lead to valves EW, FG
Valve HJ has flow rate=0; tunnels lead to valves KS, NU
Valve WI has flow rate=3; tunnels lead to valves XF, DX, DE, EW
Valve KI has flow rate=0; tunnels lead to valves GW, TQ
Valve JS has flow rate=0; tunnels lead to valves UW, HT
Valve XF has flow rate=0; tunnels lead to valves WI, IZ
Valve VE has flow rate=0; tunnels lead to valves DN, EK
Valve CI has flow rate=0; tunnels lead to valves YE, HT
Valve GW has flow rate=0; tunnels lead to valves EG, KI
Valve TQ has flow rate=14; tunnels lead to valves WG, KI, JE, UH, XT
Valve AA has flow rate=0; tunnels lead to valves BJ, CF, DX, RB, AQ
Valve EW has flow rate=0; tunnels lead to valves MT, WI
Valve UW has flow rate=6; tunnels lead to valves XT, CD, NZ, JS
Valve MN has flow rate=0; tunnels lead to valves KR, UH
Valve FG has flow rate=8; tunnels lead to valves NU, RR, MT, MK, DZ
Valve RB has flow rate=0; tunnels lead to valves NZ, AA
Valve AQ has flow rate=0; tunnels lead to valves AA, MK
Valve WG has flow rate=0; tunnels lead to valves TQ, MS
Valve YW has flow rate=0; tunnels lead to valves CA, KR
Valve CA has flow rate=0; tunnels lead to valves YW, MS
Valve PJ has flow rate=0; tunnels lead to valves MS, EK
Valve EG has flow rate=23; tunnels lead to valves AY, GW
Valve NC has flow rate=0; tunnels lead to valves TG, KS
Valve WY has flow rate=16; tunnel leads to valve VQ
Valve AP has flow rate=7; tunnels lead to valves IZ, VQ, TB, SB
Valve CF has flow rate=0; tunnels lead to valves GA, AA
Valve FX has flow rate=20; tunnels lead to valves DH, OO
Valve NZ has flow rate=0; tunnels lead to valves RB, UW
Valve KS has flow rate=19; tunnels lead to valves NC, HJ
Valve VQ has flow rate=0; tunnels lead to valves WY, AP
Valve TG has flow rate=17; tunnels lead to valves NC, FY
Valve GA has flow rate=0; tunnels lead to valves CF, HT
Valve CS has flow rate=0; tunnels lead to valves OO, EK
Valve MK has flow rate=0; tunnels lead to valves AQ, FG
Valve KR has flow rate=18; tunnels lead to valves MN, DN, YW, AY
Valve DX has flow rate=0; tunnels lead to valves AA, WI" };
    }
}
