using Microsoft.VisualBasic;
using RepeatedString;
using System.Diagnostics;
using System.Text;

namespace TestProject1
{
    public class UnitTest_SaveThePrisoner
    {

        struct Data
        {
            public int n;
            public int m;
            public int s;
        }

        List<Data> LoadData(string strdata)
        {
            List<Data> datas = new List<Data>();

            var strings = strdata.Split('\r');

            foreach (var s in strings)
            {
                if (s != string.Empty)
                {
                    var nums = s.Split('\u0020', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);
                    if (nums.Length == 3)
                    {
                        datas.Add(new Data()
                        {
                            n = Convert.ToInt32(nums[0]),
                            m = Convert.ToInt32(nums[1]),
                            s = Convert.ToInt32(nums[2]),
                        });
                    }
                }
            }

            return datas;
        }

        List<int> LoadAnswers(string stranswers)
        {
            List<int> answers = new List<int>();
            var strings = stranswers.Split('\r', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);
            foreach (var s in strings)
            {
                if (s != string.Empty)
                {
                    answers.Add(Convert.ToInt32(s));
                }
            }
            return answers;
        }

        [Fact]
        public void TetsCase1()
        {
            List<Data> datas = LoadData(DataStr_01);
            List<int> answers = LoadAnswers(Answers_01);
            Assert.True(datas.Count == answers.Count);
            int cnt = 0;

            foreach (var data in datas)
            {
                var res = SaveThePrisonerClass.saveThePrisoner(data.n, data.m, data.s);
                Assert.Equal(answers[cnt], res);
                cnt++;
            }
        }


        [Fact]
        public void TetsCase2()
        {
            List<Data> datas = LoadData(DataStr_02);
            List<int> answers = LoadAnswers(Answers_02);
            Assert.True(datas.Count == answers.Count);
            int cnt = 0;

            foreach (var data in datas)
            {
                var res = SaveThePrisonerClass.saveThePrisoner(data.n, data.m, data.s);
                Assert.Equal(answers[cnt], res);
                cnt++;
            }
        }

        string DataStr_01 = @"
352926151 380324688 94730870
94431605 679262176 5284458
208526924 756265725 150817879
962975336 972576181 396355184
464237185 937820284 255816794
649320641 742902564 647542323
174512033 711706897 68977959
107283902 156676511 67149447
104513201 298399273 96292548
113378824 274011418 98103763
934815799 991959468 212396037
88325121 435452998 24617705
984873585 997634055 103050157
344218387 715364875 90658180
556065259 615709967 156417592
57109959 451440582 4188603
353972922 573651462 244520504
946486979 973168361 647886035
368127406 680428368 105517295
884634320 965112925 119757238
422557970 744431033 28932300
634954007 957414623 341366379
190265362 445253893 184632922
293315518 479153471 120684020
72410472 80198999 984948
784893322 849791807 360911386
846191883 880790237 510053756
297201660 812278057 198376746
945087694 999220046 465061514
786859800 831171414 378370933
528402029 859318899 224559950
522640531 755821672 28838424
864006909 879474138 806467486
613544440 943850900 258190755
734228459 928771704 265979283
542812502 597832172 330877768
541133561 748691081 126348492
51187317 524866691 1143193
885290374 990676850 373368385
147955933 450823700 138416059
100046465 587967212 32555061
233926824 996957988 31809378
785405778 835771758 689182705
444389615 870657324 72775880
702580369 895325888 345053199
968559651 974760313 326732084
299437419 514618345 254272806
901702945 930227426 727030891
721843209 736359383 225283784
833018320 883439261 806599246
267346244 307857609 46989880
299901304 892163356 210218436
565637506 795821687 158300457
107336562 781910357 54488503
513281286 916998022 254269425
413431205 611661371 188998419
740163288 938647312 571382392
44702121 296589002 43470596
771733011 919327188 317638907
718860003 815844769 495144331
377975600 438513404 111085209
424965480 928959619 20776133
234986523 732169039 205952749
377078343 981597420 219264561
612269027 791414524 580170106
232336090 616084008 81392003
75059328 274029861 53524881
239121359 646856043 141349731
923193147 943368157 206717532
12565064 536852817 11557940
360225746 970375527 284883902
213705306 380885426 14495860
659446919 699401237 73837176
335372713 785363124 7610828
538388654 859196325 110284314
118558760 713483972 83950807
896959032 961368580 8848444
25543240 521123082 2472730
258530682 935834352 194732411
465248213 679599042 334563499
331230504 637771661 76778140
976340152 988657462 243958260
552994811 922743535 540135280
626831986 839281366 24222267
157704591 253731033 59023773
806377559 859228114 238044289
838798445 996851254 268459446
847646888 928001503 755190846
877625009 999275937 874127074
847949466 893343194 10497830
35029316 784675240 8200127
111807455 690309882 23190325
355765714 554560093 311565654
1890615 614626804 976253
132293206 165429783 65360680
506726160 934170235 455394293
210041918 328800789 159203369
499999999 999999997 2
499999999 999999998 2
999999999 999999999 1
";


        string Answers_01 = @"
122129406
23525398
72975907
405956028
265162707
91803604
82636723
9258153
81152217
31978708
269539705
18445097
115810626
117586280
216062299
55859471
110226121
674567416
49690850
200235842
350805362
28872987
59090728
13206454
8773474
425809870
544652109
119049822
519193865
422682546
27074790
262019564
821934714
588497214
460522527
385897437
333906011
14136713
478754860
145371959
20243482
93060069
739548684
54653973
537798717
332932745
170016312
755555371
239799957
24001866
87501244
202677879
388484637
85042925
144704874
387228584
29703127
27144750
465233083
592129096
171623012
99804791
233162218
69626951
147046575
467740
27317429
70841696
226892541
8113004
174582190
181675979
113791493
122228525
431091984
86082218
73257991
12731011
96444034
83666114
52088792
256275569
356889192
236671646
155050214
290894843
426512254
835545460
118152992
55891557
22230414
42655476
154594318
1153181
98497256
376112207
67920321
499999999
1
999999999
";


        string DataStr_02 = @"3 394274638 3
7 615562705 2
2 739424390 2
654809340 204894365 472730208
12 430895283 10
820162082 641616307 588599124
11 872829055 1
8 863472675 5
6 737005495 6
13 140874526 1
5 838370030 1
7987995 944258007 3704096
20 452477339 2
16 316486845 3
7 371704047 4
10 847309774 1
19 326960619 13
10 995691642 9
7 116507988 3
8 94123457 3
5 559772387 5
8 68776125 2
2 950135853 2
10 871101260 5
7 202574414 2
18 179098809 5
2 241943014 1
796 906236986 70
10 351834097 7
17 807384911 17
8 315277218 2
1 809644535 1
10 817801950 3
5 440531117 5
20 880268919 8
6 293435347 2
18 19114015 3
4 735038152 3
622 756206857 245
7 482235723 6
1 332585626 1
3 917360179 1
7 382333528 5
3 910271929 2
2 559295142 1
6 852399876 4
5 507841274 3
8 703690620 7
2 731894216 1
15 315371646 13
12 450649452 4
7 100332753 7
9 304145150 8
7 80202029 5
1 269193929 1
18 950000152 5
45900 625548176 41768
9 980493422 6
2 59893403 2
10 397424389 1
20 659990005 9
8 962771014 1
1 582734799 1
1 962681512 1
1 176253776 1
7 778510859 2
9 182827716 2
5 846583622 2
18 570581961 6
17 446480767 11
10 483724534 6
3 11307206 1
7 584440269 1
14 697311573 8
4 999357627 1
17 199341423 9
7 457329882 2
6 640291708 3
10 879791830 8
3 269794978 3
3 70223500 3
8 29789831 5
1 982193421 1
5 614503262 5
2 511908640 2
8 256981399 7
5 230221644 4
6 131578521 3
7 421457224 1
1 528381267 1
4 296324763 1
13 413984801 9
15 24726509 13
3 258277558 3
15 837095618 13
1 17894198 1
93327 722377177 12125
3830347 568814045 3368104
12 10766669 6
8 117991680 2";

        string Answers_02 = @"3
3
1
22815232
12
410053348
10
7
6
13
5
5378692
20
15
4
4
5
10
4
3
1
6
2
4
1
1
2
607
3
17
3
1
2
1
6
2
15
2
27
2
1
1
7
2
2
3
1
2
2
3
3
2
3
2
1
8
18843
1
2
9
13
6
1
1
1
1
7
3
2
2
9
2
7
14
3
9
3
6
7
3
3
3
1
1
1
5
2
5
6
1
3
4
11
3
5
1
38321
1460445
10
1";

    }
}


