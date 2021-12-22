﻿namespace AdventOfCode2021.Assignments
{
    public class Day22Input
    {
        public static string InputExampleA1 = @"on x=10..12,y=10..12,z=10..12
on x=11..13,y=11..13,z=11..13
off x=9..11,y=9..11,z=9..11
on x=10..10,y=10..10,z=10..10";
        public static string InputExampleB1 = @"on x=-5..47,y=-31..22,z=-19..33
on x=-44..5,y=-27..21,z=-14..35
on x=-49..-1,y=-11..42,z=-10..38
on x=-20..34,y=-40..6,z=-44..1
off x=26..39,y=40..50,z=-2..11
on x=-41..5,y=-41..6,z=-36..8
off x=-43..-33,y=-45..-28,z=7..25
on x=-33..15,y=-32..19,z=-34..11
off x=35..47,y=-46..-34,z=-11..5
on x=-14..36,y=-6..44,z=-16..29
on x=-57795..-6158,y=29564..72030,z=20435..90618
on x=36731..105352,y=-21140..28532,z=16094..90401
on x=30999..107136,y=-53464..15513,z=8553..71215
on x=13528..83982,y=-99403..-27377,z=-24141..23996
on x=-72682..-12347,y=18159..111354,z=7391..80950
on x=-1060..80757,y=-65301..-20884,z=-103788..-16709
on x=-83015..-9461,y=-72160..-8347,z=-81239..-26856
on x=-52752..22273,y=-49450..9096,z=54442..119054
on x=-29982..40483,y=-108474..-28371,z=-24328..38471
on x=-4958..62750,y=40422..118853,z=-7672..65583
on x=55694..108686,y=-43367..46958,z=-26781..48729
on x=-98497..-18186,y=-63569..3412,z=1232..88485
on x=-726..56291,y=-62629..13224,z=18033..85226
on x=-110886..-34664,y=-81338..-8658,z=8914..63723
on x=-55829..24974,y=-16897..54165,z=-121762..-28058
on x=-65152..-11147,y=22489..91432,z=-58782..1780
on x=-120100..-32970,y=-46592..27473,z=-11695..61039
on x=-18631..37533,y=-124565..-50804,z=-35667..28308
on x=-57817..18248,y=49321..117703,z=5745..55881
on x=14781..98692,y=-1341..70827,z=15753..70151
on x=-34419..55919,y=-19626..40991,z=39015..114138
on x=-60785..11593,y=-56135..2999,z=-95368..-26915
on x=-32178..58085,y=17647..101866,z=-91405..-8878
on x=-53655..12091,y=50097..105568,z=-75335..-4862
on x=-111166..-40997,y=-71714..2688,z=5609..50954
on x=-16602..70118,y=-98693..-44401,z=5197..76897
on x=16383..101554,y=4615..83635,z=-44907..18747
off x=-95822..-15171,y=-19987..48940,z=10804..104439
on x=-89813..-14614,y=16069..88491,z=-3297..45228
on x=41075..99376,y=-20427..49978,z=-52012..13762
on x=-21330..50085,y=-17944..62733,z=-112280..-30197
on x=-16478..35915,y=36008..118594,z=-7885..47086
off x=-98156..-27851,y=-49952..43171,z=-99005..-8456
off x=2032..69770,y=-71013..4824,z=7471..94418
on x=43670..120875,y=-42068..12382,z=-24787..38892
off x=37514..111226,y=-45862..25743,z=-16714..54663
off x=25699..97951,y=-30668..59918,z=-15349..69697
off x=-44271..17935,y=-9516..60759,z=49131..112598
on x=-61695..-5813,y=40978..94975,z=8655..80240
off x=-101086..-9439,y=-7088..67543,z=33935..83858
off x=18020..114017,y=-48931..32606,z=21474..89843
off x=-77139..10506,y=-89994..-18797,z=-80..59318
off x=8476..79288,y=-75520..11602,z=-96624..-24783
on x=-47488..-1262,y=24338..100707,z=16292..72967
off x=-84341..13987,y=2429..92914,z=-90671..-1318
off x=-37810..49457,y=-71013..-7894,z=-105357..-13188
off x=-27365..46395,y=31009..98017,z=15428..76570
off x=-70369..-16548,y=22648..78696,z=-1892..86821
on x=-53470..21291,y=-120233..-33476,z=-44150..38147
off x=-93533..-4276,y=-16170..68771,z=-104985..-24507";
        public static string InputExampleA2 = @"on x=-20..26,y=-36..17,z=-47..7
on x=-20..33,y=-21..23,z=-26..28
on x=-22..28,y=-29..23,z=-38..16
on x=-46..7,y=-6..46,z=-50..-1
on x=-49..1,y=-3..46,z=-24..28
on x=2..47,y=-22..22,z=-23..27
on x=-27..23,y=-28..26,z=-21..29
on x=-39..5,y=-6..47,z=-3..44
on x=-30..21,y=-8..43,z=-13..34
on x=-22..26,y=-27..20,z=-29..19
off x=-48..-32,y=26..41,z=-47..-37
on x=-12..35,y=6..50,z=-50..-2
off x=-48..-32,y=-32..-16,z=-15..-5
on x=-18..26,y=-33..15,z=-7..46
off x=-40..-22,y=-38..-28,z=23..41
on x=-16..35,y=-41..10,z=-47..6
off x=-32..-23,y=11..30,z=-14..3
on x=-49..-5,y=-3..45,z=-29..18
off x=18..30,y=-20..-8,z=-3..13
on x=-41..9,y=-7..43,z=-33..15";
        public static string InputA = @"on x=-3..43,y=-40..7,z=-4..40
on x=-20..26,y=-14..40,z=-10..35
on x=-15..35,y=-41..5,z=-24..27
on x=-29..15,y=-6..44,z=-3..42
on x=-41..8,y=-44..0,z=-5..42
on x=-29..24,y=-42..12,z=-38..9
on x=-27..25,y=-29..24,z=-18..35
on x=-38..15,y=-9..44,z=-39..10
on x=-21..29,y=-37..16,z=-26..27
on x=-48..6,y=-7..44,z=-46..4
off x=-30..-13,y=17..31,z=2..17
on x=-28..21,y=-29..25,z=-25..19
off x=-7..3,y=9..25,z=-25..-10
on x=-9..45,y=-11..36,z=-45..2
off x=6..19,y=-39..-29,z=2..11
on x=-8..40,y=-28..22,z=-10..44
off x=-4..11,y=35..47,z=-41..-26
on x=-42..7,y=-16..34,z=-43..4
off x=-49..-33,y=-23..-10,z=-22..-11
on x=-8..44,y=1..46,z=-30..18";

        public static string InputB = @"on x=-3..43,y=-40..7,z=-4..40
on x=-20..26,y=-14..40,z=-10..35
on x=-15..35,y=-41..5,z=-24..27
on x=-29..15,y=-6..44,z=-3..42
on x=-41..8,y=-44..0,z=-5..42
on x=-29..24,y=-42..12,z=-38..9
on x=-27..25,y=-29..24,z=-18..35
on x=-38..15,y=-9..44,z=-39..10
on x=-21..29,y=-37..16,z=-26..27
on x=-48..6,y=-7..44,z=-46..4
off x=-30..-13,y=17..31,z=2..17
on x=-28..21,y=-29..25,z=-25..19
off x=-7..3,y=9..25,z=-25..-10
on x=-9..45,y=-11..36,z=-45..2
off x=6..19,y=-39..-29,z=2..11
on x=-8..40,y=-28..22,z=-10..44
off x=-4..11,y=35..47,z=-41..-26
on x=-42..7,y=-16..34,z=-43..4
off x=-49..-33,y=-23..-10,z=-22..-11
on x=-8..44,y=1..46,z=-30..18
on x=62232..78415,y=10592..16840,z=-63799..-39301
on x=-19561..-12116,y=15146..45174,z=61387..76078
on x=44301..72304,y=-60234..-37123,z=-41404..-18517
on x=-75853..-50603,y=-4587..13851,z=-66858..-40374
on x=-77069..-67384,y=-3885..10407,z=27840..55973
on x=-12168..10955,y=54286..82573,z=27822..43165
on x=-38401..-23118,y=-1152..11109,z=59601..83589
on x=71961..76671,y=-8646..25487,z=-25494..-21642
on x=-70932..-43122,y=-43284..-31794,z=-42928..-32310
on x=-89678..-65722,y=9032..29150,z=-14924..-5850
on x=42230..56799,y=3544..35677,z=-74586..-51550
on x=-43423..-29919,y=-78347..-55784,z=-19813..15947
on x=-65221..-45165,y=30159..48369,z=-63401..-38200
on x=-60966..-30690,y=-18861..3995,z=-70228..-60072
on x=-6435..21804,y=-80463..-53220,z=49250..65363
on x=-74843..-66633,y=3498..26678,z=-39115..-13584
on x=-69309..-56701,y=24561..48536,z=19706..37198
on x=-75035..-46424,y=2924..33601,z=-44952..-38121
on x=28459..53641,y=52011..65743,z=-43314..-22682
on x=-43880..-24889,y=-4074..19818,z=58330..79647
on x=5136..11702,y=14099..41185,z=69653..89427
on x=-79331..-49170,y=-48385..-23280,z=-2929..21279
on x=-50070..-26116,y=50287..84921,z=-49305..-18856
on x=-19588..2763,y=-35936..-21848,z=71238..78682
on x=-76518..-54361,y=-295..19687,z=-50588..-29444
on x=-67546..-55956,y=48660..54549,z=-10623..6603
on x=-73497..-60027,y=14945..26090,z=-66427..-31560
on x=35611..40289,y=46748..74940,z=25897..39311
on x=-77695..-67359,y=-27857..-8017,z=-18063..-7051
on x=-72148..-55420,y=-23094..-751,z=-63716..-32227
on x=31806..41545,y=18538..45727,z=53987..75941
on x=-21249..-3712,y=-85052..-64540,z=19463..42568
on x=-67446..-37670,y=11960..36978,z=-67928..-51082
on x=-71787..-50613,y=-56085..-30035,z=-46074..-31001
on x=22468..32297,y=57670..70131,z=-49482..-23637
on x=-60650..-34937,y=-36029..-26802,z=-73401..-50897
on x=20118..32744,y=-54809..-38065,z=-61419..-44658
on x=-58264..-20841,y=12601..35135,z=-69753..-52140
on x=-54544..-32381,y=53673..71651,z=232..19267
on x=-36779..-11146,y=28736..60514,z=59995..66863
on x=65860..80449,y=38764..44797,z=-12277..-6722
on x=-71507..-48817,y=-60355..-35948,z=-6765..13684
on x=11300..45161,y=39409..68818,z=43737..51630
on x=-78980..-62750,y=19728..30900,z=-6042..20859
on x=50083..64019,y=-233..6235,z=56949..72154
on x=50786..58145,y=-27728..-2863,z=56811..71571
on x=-13976..630,y=12322..27019,z=-83735..-70784
on x=-82646..-61357,y=-31008..-20185,z=20679..35924
on x=-37751..-21996,y=-47573..-35178,z=-59950..-49760
on x=32031..58155,y=61627..73098,z=-3360..25799
on x=-84082..-67328,y=13405..20392,z=-6253..7349
on x=-20530..3394,y=-36538..-14359,z=71447..81666
on x=3738..27286,y=-78149..-55767,z=-56997..-21213
on x=56040..86994,y=16919..37104,z=2122..29289
on x=38040..71411,y=10478..34303,z=45625..62019
on x=25678..57820,y=-62186..-40695,z=49476..70027
on x=-61489..-43958,y=-34778..-26373,z=40201..62476
on x=-59788..-35126,y=-54443..-43673,z=-40903..-28049
on x=-55539..-43327,y=-7703..13954,z=-76875..-48852
on x=31815..48567,y=18422..35510,z=-72647..-43995
on x=31212..50433,y=-62581..-52691,z=-57228..-35978
on x=44355..61445,y=-14875..6397,z=49115..75379
on x=57224..82861,y=-12471..12459,z=13388..26000
on x=-87341..-67200,y=-3744..23720,z=-43001..-29993
on x=-67173..-43779,y=-5589..8687,z=-53952..-35735
on x=-42871..-20075,y=-70825..-46379,z=-42452..-33755
on x=-27193..-7849,y=36999..48863,z=49672..81986
on x=-46545..-28539,y=78..10172,z=-76130..-66536
on x=-55534..-19293,y=-21909..232,z=49568..87547
on x=-75492..-54838,y=-39896..-16427,z=21039..56416
on x=-34090..-18521,y=-83764..-69131,z=26890..40869
on x=46759..58406,y=-55273..-35717,z=-46346..-13138
on x=-84958..-64253,y=20765..39015,z=-23572..1778
on x=57342..72014,y=36497..65204,z=21410..41391
on x=54168..68656,y=6336..42268,z=-45973..-28425
on x=-90861..-58437,y=-23267..-5398,z=2616..20544
on x=-8199..-494,y=-39990..-32228,z=-75177..-56547
on x=-86024..-69118,y=-43300..-8345,z=103..25459
on x=50915..62692,y=38996..59716,z=-48904..-17880
on x=-39749..-21185,y=-78844..-65189,z=1734..17238
on x=-32954..-17916,y=66435..84502,z=-40130..-21316
on x=61584..73780,y=-20712..-1677,z=38878..45170
on x=45796..58695,y=-70161..-47672,z=2878..31228
on x=-78582..-56535,y=-17640..14975,z=-36315..-21466
on x=-4160..8618,y=-29687..-3221,z=75530..87788
on x=-78137..-54029,y=-42166..-24690,z=40752..59931
on x=69729..74049,y=-16793..9895,z=-41508..-29918
on x=-11852..-2623,y=-85130..-66318,z=23216..42693
on x=-76287..-61540,y=-4794..7900,z=19191..26682
on x=32602..55983,y=-50325..-24787,z=-62128..-39196
on x=-22148..-1170,y=-62217..-53758,z=-73565..-36167
on x=17439..28883,y=-76155..-71068,z=-18908..5736
on x=48200..65680,y=-64455..-27665,z=25147..31719
on x=64795..81991,y=-8790..7332,z=-21538..-14052
on x=-96602..-65239,y=-5774..19890,z=-4709..4170
on x=-7315..21241,y=35835..51112,z=-78709..-65080
on x=38040..63518,y=7706..31595,z=-69544..-59049
on x=11022..31768,y=-60181..-41336,z=61981..74058
on x=60814..79169,y=-15319..-6431,z=31482..60354
on x=65935..89703,y=-33779..-17121,z=11786..44610
on x=47215..70647,y=-57277..-25185,z=-39314..-20468
on x=-14898..-4285,y=13143..33601,z=72764..86137
on x=29194..46178,y=23821..48382,z=-78917..-57813
on x=-60846..-51135,y=-1470..20626,z=38111..65359
on x=-32902..-18054,y=-81197..-52970,z=-43062..-19360
on x=-292..18879,y=-83298..-58330,z=-58335..-36532
on x=-62389..-32864,y=-26791..-10657,z=-70702..-58449
on x=-20825..-13958,y=-77497..-53968,z=-59040..-45444
on x=29346..56896,y=-51072..-23769,z=33955..71536
on x=-27734..-15957,y=36696..51387,z=66196..74129
on x=48678..65614,y=-76307..-57918,z=-35513..-15294
on x=-43040..-29368,y=-34815..-19371,z=46790..80390
on x=-28567..-22105,y=17928..36393,z=-81680..-65545
on x=67248..91645,y=1559..32758,z=-40242..-23098
on x=36724..63048,y=48069..57066,z=18566..44735
on x=-19855..8205,y=-22876..5922,z=61683..88689
on x=-46483..-34890,y=30332..66050,z=38519..52424
on x=-71057..-46742,y=58094..76003,z=17571..32419
on x=-61818..-45170,y=-49686..-35378,z=13446..43846
on x=-38648..-17655,y=-63484..-47362,z=38783..60976
on x=49249..54032,y=25040..40211,z=54911..70815
on x=-90457..-59180,y=-13590..7774,z=-46897..-27383
on x=-25833..-6370,y=-71612..-60010,z=42945..55834
on x=-76047..-54916,y=-9549..16127,z=49284..56885
on x=-76789..-55532,y=-70334..-34488,z=-18633..3524
on x=42295..63723,y=-66989..-52135,z=-9423..16511
on x=-8739..9047,y=-94231..-68385,z=843..18296
on x=36696..48859,y=-31653..-3861,z=-73869..-52590
on x=-84893..-55445,y=-33801..-5207,z=26793..53784
on x=-27590..-15517,y=61939..82965,z=8012..25287
on x=-23845..-3130,y=33441..56380,z=-75575..-54393
on x=-49590..-28680,y=-66980..-56632,z=11731..32502
on x=-25872..-9457,y=63491..71388,z=28939..41410
on x=17561..26392,y=-85114..-69067,z=17003..23223
on x=9257..24618,y=60390..77736,z=-15564..-8465
on x=-72647..-34666,y=43941..68905,z=18608..49413
on x=-35350..-15110,y=-67690..-37215,z=-72309..-36728
on x=-52895..-38678,y=-75279..-61942,z=-8339..-2693
on x=-4350..10691,y=40327..56362,z=50641..71742
on x=13163..42843,y=-50227..-25534,z=-66345..-54724
on x=12804..22720,y=64345..84392,z=29646..40797
on x=2940..20961,y=53772..62243,z=-64218..-35808
on x=-15329..9252,y=-7827..9759,z=-97184..-63091
on x=-43606..-22308,y=-73706..-43157,z=35910..60926
on x=62751..73464,y=29164..44599,z=-25734..614
on x=60593..69893,y=17362..41403,z=37882..54560
on x=53360..75636,y=-19345..-12541,z=-41800..-34461
on x=22218..55056,y=-75758..-65816,z=-3216..-1613
on x=-43450..-26117,y=-4078..22034,z=69628..82208
on x=38780..48776,y=-81886..-66193,z=-14136..5119
on x=38066..76131,y=-54635..-50106,z=-34991..-13298
on x=70126..76638,y=11747..16080,z=15148..39863
on x=-56772..-43519,y=-8491..4092,z=-69663..-60969
on x=-49178..-38445,y=-27733..-10309,z=-71876..-52012
on x=23542..53001,y=41348..54767,z=50420..63450
on x=26594..51105,y=-36676..-28075,z=54218..70716
on x=52224..68872,y=-58466..-46953,z=-34956..-14580
on x=3544..11393,y=55531..84179,z=-44876..-11566
on x=-36163..-23271,y=-90357..-71417,z=-3517..5870
on x=-38208..-17207,y=-49215..-29184,z=52983..73246
on x=38958..52561,y=-2028..5565,z=45925..78959
on x=-57489..-35252,y=18259..39381,z=-72512..-40801
on x=46613..59329,y=-73337..-47692,z=10023..24111
on x=66254..89475,y=12116..30229,z=-19678..4658
on x=-65916..-28609,y=57632..67489,z=-11829..7076
on x=6034..26412,y=-12523..-6467,z=-96231..-77020
on x=-44242..-17421,y=-29083..155,z=-80517..-68048
on x=-31891..-5784,y=52676..67141,z=-57318..-33381
on x=15602..50635,y=55675..89601,z=-8876..29053
on x=12405..28611,y=-1499..20568,z=-84268..-67917
on x=2329..31126,y=53540..77472,z=47225..69835
on x=52355..70249,y=-55679..-22110,z=-64568..-41983
on x=54525..74930,y=-50044..-20045,z=29342..43786
on x=46246..81614,y=-48348..-44135,z=-17296..-3467
on x=47807..74339,y=-25213..-8,z=27998..58852
on x=67840..85219,y=-7359..-2946,z=26689..39513
on x=-67655..-54202,y=-22642..-7348,z=-54402..-28835
on x=20984..42485,y=43132..74728,z=-46534..-31519
on x=66009..84055,y=-3179..5259,z=2563..33587
on x=-76523..-53193,y=16573..37349,z=5706..21580
on x=-13390..13752,y=-80290..-67370,z=-26395..189
on x=-62867..-40050,y=2034..20245,z=47289..75246
on x=-18832..4816,y=26348..28598,z=-81741..-73590
on x=42308..77577,y=46606..61501,z=-16455..4537
on x=-12380..8417,y=-9960..26034,z=-97408..-69096
on x=18436..20736,y=-49430..-48135,z=42804..69548
on x=40238..75486,y=-57454..-39330,z=-35448..-9564
on x=-34835..-8626,y=19088..37766,z=57893..81468
on x=-80242..-60834,y=-20847..-3354,z=31994..41992
on x=12788..20601,y=26059..58171,z=-74550..-53001
on x=61751..83834,y=-22335..-7018,z=-45469..-25870
on x=-3007..23549,y=-39286..-21872,z=70498..93172
on x=69221..89946,y=19941..44108,z=7788..13362
on x=-95343..-69835,y=12056..19570,z=3415..21867
on x=-90651..-57952,y=-39119..-18641,z=2955..34477
on x=-37223..-16563,y=68718..81628,z=-11086..26546
on x=62255..90686,y=-28491..-10328,z=-11346..-6297
on x=42455..76414,y=11967..31349,z=41589..49905
on x=18591..33641,y=-19443..-15508,z=-90926..-58802
on x=-67254..-53011,y=46245..63689,z=375..24815
off x=-38028..-25623,y=-83477..-61351,z=-26028..-16673
on x=-2199..22797,y=54212..63567,z=-72096..-51236
off x=-54871..-24768,y=43838..68179,z=-63088..-36194
on x=20497..56978,y=-11700..15690,z=64931..81115
off x=-54381..-34633,y=8039..17779,z=-76137..-58795
off x=51477..84135,y=-17379..1866,z=40822..57539
on x=37701..51374,y=-65141..-46442,z=22410..54885
off x=-12548..14428,y=13703..33056,z=-79100..-68871
off x=15593..20291,y=-14437..12007,z=67532..85257
off x=-55369..-31256,y=47970..54611,z=28361..58364
on x=49170..61409,y=-14806..-4147,z=-65407..-38356
on x=-18873..11206,y=-52823..-30293,z=62812..66448
off x=-74893..-47904,y=-34903..-7950,z=29429..44776
on x=-24803..-15306,y=5179..35151,z=61121..93405
off x=28976..48984,y=-74526..-51739,z=-31068..-19583
on x=52545..65835,y=9722..40251,z=42529..73769
off x=41358..64764,y=-27042..-15030,z=38958..67706
on x=21929..54332,y=-10651..5093,z=67676..74683
on x=-7636..9795,y=-36929..-20539,z=73351..82547
on x=15553..38175,y=-78459..-40725,z=-47587..-21396
on x=-53611..-46052,y=-77056..-52310,z=-10669..10590
on x=-47044..-24817,y=35785..66765,z=-47689..-42849
off x=-41776..-25155,y=52358..76927,z=-44718..-18180
on x=71962..92575,y=-13992..13864,z=20310..38403
on x=-64296..-45131,y=-1964..31151,z=-56286..-38404
on x=-34043..-4743,y=24339..54036,z=-73729..-61189
off x=40031..58527,y=-43220..-23735,z=-66702..-47898
on x=-41653..-8827,y=-71233..-67830,z=27057..33924
on x=42117..50369,y=-50297..-24887,z=-58922..-39149
on x=44697..47206,y=44127..74207,z=-26198..-4204
off x=-64818..-29508,y=-75479..-50139,z=21525..28437
off x=-36127..-14009,y=63248..82382,z=-7088..21515
on x=-22346..-3316,y=-34334..-27980,z=68551..84501
off x=-63656..-44418,y=-46240..-37283,z=44102..63998
on x=42848..61454,y=37274..43040,z=-42276..-27862
off x=25927..39396,y=36760..55741,z=62845..65744
on x=61099..74396,y=-44220..-14439,z=4426..34934
on x=38135..64887,y=-61363..-56987,z=-27251..-4353
on x=-41422..-40242,y=59456..68481,z=19328..39916
on x=27813..50890,y=44492..70473,z=30823..38170
on x=42407..58114,y=-58216..-24853,z=-59380..-46619
off x=-39591..-24200,y=-38599..-17971,z=51337..66646
off x=28603..42263,y=43373..63393,z=29927..54376
on x=-70738..-47600,y=5089..24045,z=-63275..-44100
on x=31533..50084,y=-70044..-57781,z=-33619..-11015
on x=-10455..5948,y=-17053..7100,z=77949..91079
off x=-87903..-50960,y=-34071..-14546,z=14359..38573
off x=-38703..-20975,y=-13470..3473,z=73810..91414
on x=33655..64872,y=-25580..-1048,z=53888..70390
on x=-71637..-50798,y=28325..53714,z=17421..31638
off x=-55242..-27662,y=-75377..-60316,z=-29332..-8736
on x=-26586..-8155,y=-87538..-57785,z=-2040..25080
off x=24465..37168,y=34761..53791,z=39921..60666
on x=-16242..-8869,y=13695..27441,z=-96161..-73439
off x=59033..80092,y=-8095..11728,z=42145..60993
off x=11437..14692,y=-66695..-53698,z=48235..66183
on x=-54644..-27579,y=-31468..4132,z=-71581..-62630
off x=46353..58084,y=-3058..22129,z=58659..70045
on x=37049..55781,y=-75886..-53260,z=-622..21244
on x=-45935..-27782,y=-44567..-23554,z=50025..72851
off x=55315..89225,y=-13679..1212,z=-54007..-26061
on x=-97689..-70211,y=7766..18203,z=-7347..3677
on x=-44569..-27022,y=57559..73037,z=-45160..-22051
off x=-53250..-29410,y=-70096..-58881,z=-33377..973
off x=-30822..-10238,y=-82089..-58987,z=-39229..-7182
off x=-86427..-66229,y=-23110..-12319,z=-2752..22391
off x=11202..32323,y=-91353..-70211,z=-45981..-7959
on x=-55765..-20776,y=67067..74178,z=-25729..-6326
off x=-59612..-54141,y=54186..71718,z=-13639..3545
on x=17333..29248,y=-92046..-61823,z=-32686..-13638
off x=-85001..-68771,y=7344..34167,z=-19381..9274
on x=-22492..-7276,y=61063..85098,z=-47228..-9988
off x=11683..27384,y=-11488..26255,z=-76968..-60851
on x=-90912..-61678,y=-7748..4592,z=2394..22140
off x=22854..43131,y=56525..65481,z=34055..46279
on x=61222..73027,y=26851..46121,z=-27180..-9128
off x=-40801..-4805,y=-42994..-18670,z=-90053..-61495
off x=-15426..9005,y=67165..77424,z=-32921..-2590
off x=-38948..-20859,y=-16125..6579,z=-93624..-69605
on x=8737..30186,y=69397..97228,z=3615..10393
off x=-82229..-50677,y=-34930..-22764,z=25970..46201
on x=-30586..-10821,y=-78721..-62793,z=-60976..-33247
on x=8677..43376,y=-1963..6457,z=72386..92229
on x=18331..52556,y=59243..83657,z=30524..31942
off x=34147..53274,y=11028..29158,z=-74710..-66758
on x=22915..35555,y=-68910..-53186,z=-37262..-6080
on x=-57704..-37280,y=-7..32810,z=59915..78037
on x=-34576..-18184,y=-67359..-42480,z=49889..51191
on x=68833..76004,y=-47040..-23935,z=-9774..12179
off x=-33985..-11402,y=-19706..-7112,z=62284..79653
on x=65876..83321,y=-27400..-15906,z=-30853..-24215
on x=13342..33212,y=-65282..-62183,z=-47114..-26725
on x=-42083..-13267,y=-89352..-60397,z=-13707..15549
on x=-2774..9062,y=8711..37179,z=69642..88272
on x=35832..45938,y=6145..43491,z=59531..82381
off x=-52869..-35126,y=14291..50238,z=-66971..-45782
off x=-60007..-56613,y=40390..73281,z=-13989..4637
off x=-69805..-33370,y=-64308..-41427,z=12303..35877
off x=-20393..-8769,y=60210..77478,z=9384..35625
on x=29926..57019,y=-72458..-36233,z=-55883..-31730
on x=-63437..-34528,y=-64513..-62515,z=-4272..10279
off x=15640..28872,y=52714..74618,z=35447..50673
off x=60533..74155,y=9756..30773,z=-50753..-25011
on x=-75313..-56343,y=24557..34443,z=37734..61187
on x=45556..73844,y=-39638..-14275,z=-58677..-23903
on x=-28985..-9643,y=-68309..-45208,z=54172..76725
off x=20003..45372,y=-28507..-21011,z=-82535..-67206
off x=38757..57238,y=-77872..-52176,z=-1571..22315
off x=3963..8570,y=-85377..-50328,z=-55787..-40193
off x=-9665..28099,y=-36864..-22430,z=-77024..-75149
on x=39455..57136,y=-49959..-22534,z=33729..53131
off x=-49257..-28357,y=-18581..4758,z=-78146..-58967
on x=-27820..-7790,y=-19630..1853,z=-91091..-62392
off x=15496..42544,y=-87801..-57845,z=2704..23958
off x=-33696..-15689,y=53481..66119,z=31226..59352
off x=-14853..18572,y=-90928..-70354,z=-45348..-25075
off x=-51945..-45162,y=-17663..18077,z=-69748..-47140
off x=-38685..-26762,y=-61621..-57470,z=-54626..-26565
on x=-59197..-39711,y=-58794..-29329,z=41612..56036
on x=-61092..-45239,y=-60204..-43407,z=-64388..-34354
off x=-71156..-60166,y=-35439..-11181,z=37863..61706
off x=-54938..-34663,y=17403..41295,z=62030..73014
off x=-15765..9652,y=-44945..-40294,z=55918..73261
on x=-43301..-12340,y=44378..66941,z=35850..59199
on x=-33997..-6707,y=-69230..-46955,z=-64569..-40828
on x=-21735..4727,y=74446..80740,z=-8007..3245
on x=-52407..-32967,y=-35618..-13383,z=62442..68079
off x=16353..30246,y=-37565..-26597,z=54290..84827
on x=-79714..-59571,y=21540..34393,z=-44291..-22042
off x=28404..48739,y=43301..81383,z=-57562..-32765
off x=65068..78093,y=-44456..-39480,z=-9124..10872
on x=1936..26341,y=69589..75551,z=29521..36608
on x=-93624..-69411,y=4518..14729,z=-29385..-5992
on x=-21378..-6725,y=68980..94804,z=165..18574
off x=-17819..5033,y=-2206..33484,z=-96021..-68333
on x=-13726..14343,y=-78432..-57454,z=-51720..-28192
off x=36047..67847,y=-58408..-37640,z=-39969..-24608
on x=-50235..-28751,y=-19198..2573,z=-74544..-61896
off x=27739..49746,y=-81075..-51944,z=-17342..948
off x=-44140..-13447,y=-87524..-66633,z=-1378..18189
off x=-67322..-52524,y=-71407..-40174,z=-30055..-10329
on x=-64253..-41319,y=31957..46204,z=27534..45178
on x=-66932..-50331,y=39481..63503,z=-3650..25040
off x=2188..12660,y=-93988..-69989,z=-7133..754
on x=-33475..-24315,y=3029..15804,z=71485..76334
on x=38421..63272,y=-33224..-23786,z=-58227..-43105
on x=50465..56280,y=7565..37162,z=-63999..-36984
on x=28671..47377,y=44756..62563,z=-62733..-40938
off x=-74428..-49628,y=26541..55540,z=-13135..15370
off x=-34080..-10628,y=58681..84157,z=13989..37447
on x=20221..48849,y=53931..75387,z=13850..35410
off x=-45997..-32480,y=-68402..-48523,z=-9016..4855
on x=49540..62457,y=49461..63046,z=-15040..19817
off x=37764..59146,y=47763..56285,z=31391..42731
off x=-24327..-6960,y=9965..45119,z=56411..91265
off x=51617..85885,y=-19450..-6138,z=-48520..-27457
off x=-23396..-17819,y=70786..83597,z=-21176..1453
on x=51808..65220,y=4232..8921,z=-56469..-46083
off x=-57403..-51066,y=-67220..-39982,z=8804..44370
on x=10670..18532,y=-30790..-24088,z=-92006..-61689
off x=26696..40305,y=11421..23073,z=63374..84468
off x=-69519..-40908,y=-74663..-36465,z=7741..26549
on x=30563..57894,y=19965..38546,z=41677..60864
on x=-75447..-50527,y=17848..26657,z=32710..69118
on x=-84060..-56826,y=-44333..-27683,z=20683..30359
on x=40356..75101,y=-45729..-24430,z=-54208..-47032
off x=-48628..-32337,y=-73667..-53337,z=-60166..-30766
on x=43016..66723,y=52114..63653,z=-42493..-20463
on x=55050..66144,y=36983..63632,z=-19611..-4974
off x=23794..48581,y=-36960..-28318,z=54270..69018
on x=26732..50857,y=-45816..-21969,z=45753..79664
on x=15678..28557,y=-66232..-52963,z=-48680..-42545
on x=-35902..-22950,y=-16211..-1754,z=-88655..-68008
off x=-26285..-18123,y=-1914..16713,z=59514..88101
on x=-44727..-17109,y=57739..80430,z=-33461..-21024
off x=-48050..-29215,y=-64233..-47352,z=13408..34765
on x=57310..80634,y=23074..48995,z=-6140..10145
on x=-82584..-64412,y=-36929..-8918,z=-30744..-20425
on x=1762..13898,y=64026..71221,z=-57339..-43117
off x=46409..76785,y=-51642..-24778,z=-27883..-17791
off x=-37325..-20870,y=-42767..-30436,z=-73733..-49594
off x=-2638..9939,y=5218..30204,z=-92271..-72962
on x=-51641..-19872,y=-75627..-55223,z=-8799..4538
on x=46279..56352,y=-5487..13228,z=-72223..-59547
on x=28698..50028,y=-36550..-27480,z=-68725..-54961
on x=-75231..-48661,y=9764..33430,z=-58299..-41917
on x=-3483..23158,y=13480..25885,z=72510..95758
off x=-18675..-2624,y=16051..39272,z=60246..78170
off x=52280..66124,y=-64097..-29418,z=7002..42023
on x=-30514..-22186,y=60270..90187,z=-4397..18590
on x=446..19197,y=-85001..-71792,z=21425..47374
on x=51070..68670,y=37421..67959,z=-15610..11603
on x=-77901..-60148,y=-44344..-21055,z=18341..34826
on x=70381..84879,y=-12006..-355,z=-12304..8343
on x=-53588..-40065,y=48904..61274,z=16395..40150
on x=-22528..4952,y=30750..59031,z=51962..79814
off x=-63726..-38963,y=-40859..-23357,z=-61143..-41380
off x=37566..48308,y=-76087..-54237,z=-31897..-1304
on x=-5934..5731,y=65596..68103,z=44118..63815
off x=-59314..-34557,y=-73628..-51952,z=-12402..8294";
        
    }
}
