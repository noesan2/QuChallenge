using NUnit.Framework.Internal;
using WordFinderQU;

namespace Tests
{
    public class Tests
    {
        private WordFinder sut;

        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void BaseCase()
        {
            var matrix = new List<string> { "abcdc", "fgwio", "chill", "pqnsd", "uvdxy" };
            sut = new WordFinder(matrix);
            var wordstream = new List<string> { "cold", "wind", "snow", "chill" };

            var expectedResult = new List<string> { "cold", "wind", "chill" };

            Assert.That(sut.Find(wordstream).OrderBy(x => x), Is.EqualTo(expectedResult.OrderBy(x => x)));

        }

        [Test]
        [TestCaseSource(nameof(WordstreamRepetedCasesData))]
        public void WordstreamRepetedCases(List<string> matrix, List<string> wordstream, List<string> expectedResult)
        {
            sut = new WordFinder(matrix);

            Assert.That(sut.Find(wordstream), Is.EqualTo(expectedResult));

        }

        [Test]
        [TestCaseSource(nameof(LowEdgeCasesData))]
        public void LowEdgeCases(List<string> matrix, List<string> wordstream, List<string> expectedResult)
        {
            sut = new WordFinder(matrix);

            var actualResult = sut.Find(wordstream);
            Assert.That(actualResult, Is.EqualTo(expectedResult));

        }

        #region TestCases

        public static object[] LowEdgeCasesData = {
            new object[] { new List<string> {"abcdc", "fgwio", "chill", "pqnsd", "uvdxy" }, new List<string> { "cold", "wind", "snow", "chill"}, new List<string> { "chill" , "cold", "wind", } }
            , new object[] { new List<string> {"child"}, new List<string> {"child"}, new List<string> {"child"} }
            , new object[] { new List<string> {"c"}, new List<string> {"dog"}, new List<string> { } }
            , new object[] { new List<string> {"c"}, new List<string> {"c" }, new List<string> {"c"} }
            , new object[] { new List<string>(), new List<string> {"c" }, new List<string>() }
            ,  new object[] { new List<string> {"pmhuacgaubpunypkoysfjmlvfnfqzzdpfgfxjxvnxkpkwtcfdxsxhdnpfgmidvph", "tmxoccsvcrnqexvaconnjzkfwzqonvrysxhcktsgvpxdhyfxtfyqwvtupcjiicwr", "zcsyilhtuaorvrprunwihkwawqpqjojrejrbewunmdfrxhpsxjjmcmowjcfdmqhr", "zwgzudwlxqurqpttabjpxjfxtyeyywtahnziytwsuxsjxhvjsgkehpzktrmuhhps", "ugjbksireffvfgagjmycyugywvafwvbwjnasopozmsvdlmahahbyuudhofsywcci", "yjuifokippcmawlfcgelagcxudorevlauvenlyimowydaegiwviscgxmckksdhkf", "nguxmehglmaglgpsfekyyizumstdhcauvqjdzmnrsfivjzmwaighgxhzorxzzdvd", "omngxvbdbpidtuchgxqgyahnzeyckecftneelkcywmlmgaknvfspzdzfikdyztaw", "gtouftwhudonfrwlqmzrdgezatefkftrtqdwrvgymcvafkoztevffiqulqppgyuc", "fpowaybpuvtnfzgjqrqgzenqpnsjcfymarznhbrioaidtxoeabjulxeuqxfasham", "qucgngmrlzokxdwwkgtyjczjtghqzsnxoipezlulzlvzljugjdqrscknrhnvrylq", "clbmdnkbftdmxkfbjjwezvvzbdgubynecukgdmshjzfcaplqaslkcxmzztgdhxuy", "ohayninxfriyqvufijmtoqvtyjiqbrcblomaspepeudbenogrxbgbiztszkexbbp", "verzxggzcpiywifnbjlyjetzwmpcmalibjymwnrkbopgvhchiepugqowezyquyox", "ykwoydcjhjdqwwzhvvkqoripikzmalocfusaxwfgdvxtgjymlxabpqtlssvueohx", "efzrzhlqqbfmivmzdckvvhyqkmkmdwkhnieehgtyzchgogcccylcewygcmstozgw", "sxnupnyzvarzyymyfmogxpzpnasnlrwtevpyuudvyhykcfdbyznjqgpxikamgmmo", "vzajkuulaaplnjpjvzkdutcukedpkvusbkryhgmqpxgtyevvfwnjfnbyxeuygnck", "nqpiqnkvudwtakyyrghduppebqsmlatunlhqlxcssqgrxifsumxtghogbmibfhaq", "gmbgjiyqncmwiqtwgiawlvkmsalazdwngjltdgoncykfokoukuthusdgtihluruk", "fnakmrlujfovweknvevjiazbkmajfkmylystdpyfmpddnfiwjehhjuhtogezfzkc", "ybxeociwkeryevbogofkgriqcykgzabqjpthllilkcmjvpbixkxkdrfdcpnemcwq", "ncehwifxrkqrzcsuqgqmljtfblfesvzasdfvoehkeicfdilcvrcllxtpiovrbdnn", "bwzaoivmnxtfmrxbzsnnbbbazbozgszuqcxlouyysmudxlmrvbydiadkjxiyjfon", "llpgkrydtvkawjilvsrgsjmdwbmrygoutxabeycoqhscquxounaewbhhwhxksgeq", "zeciaalessxyytpajslieskyxqxmunymxrcufsmqzjtqvwzrzlarlhbvmxmxnyxk", "wvpipskhbyrhxyuihfbvziagjlewbrnozbkuvtnknhmjotyarokpbczfyyolovdn", "ubflwinjyewimjvptwxjmcihnqvmghtpoxmjhaklgcjcxsgrcngptqypxbaeuarn", "okvcgcivnfhwzafgqstigwbjppzxnwrgrghsdtgdpulfsybzpbmzhfdyhfbuykwt", "wefympmyahzpstkjotnebubcfdzyvlnddpapxntxuqxsjfvtpxnzwxboepzpgkgd", "exttrotxuoxcjfmstnnabrepmrpashwofkdjrpvwjpchhevuzagebbsdapdyvrrg", "cxaitdjbzvamywzjuvjqluippsfkenmslupxtrbbsoawaynovtivzkqyqbnjzcck", "glqbeuophaghsfgvyirdrnswmdmzmtnddcoisstpaokonzhzmcaqvtwfqehsmlyz", "zbmywhzgsvisayvtxozxodasscwnqaxwzisfydizpgehsndhjtekjyjwhuvtdffr", "bmeiwevxywqkaqeqfoqkigikdttnezjrsnopsbhptusmnhyxadvuvkzpmhjwblix", "frnchelpucbizprrqhomomgqqzfceqkwrhykygpktqqybqhmtxqhiogkwgyozgtk", "lfvjpjjtxmhwxypladqitomrjwhcnqbgjyvrwgwzpuztxybhptceeeyimjaxwfxo", "nhnbcexeasfpupzqyavtnghwvreifddyrlkbcfssbqcfbtjzyvvswsskpbwpeqij", "bibubydlbmzblcpskverewzhzdrdfnzghtcvbhbpmgzfboxxowibgnpwhkhjglrf", "vklenjowqfqmfhghoptwljlrdinpnwrfsjdmphmzinprybrdttjpmsvymwvmspvh", "uxwdvtyhigivmogjlzgunssfuschtgkfyewuojjeurkmqcyyuovsloflpcjijebe", "aoxdcjtbsazcdyuffblqhcmvmwpoxrfaducxofwhbciwqofwacztrgzxqappemww", "gpozypctwuiujzdbdstpywwpvcdjzytwvfuryhjlzmcrpjtljbzyndkgkvgbndyd", "fdhtxlhfpoflutcbzjcvabqczseqlfaxtzrydciygksgvohwyorfzryunhzqeflq", "ugdjlfmufdyatcoxljijumacxqdxmmpwvlibyzxfpfxtoisolrrtrlmcydyvismv", "ohofcbckvffgmpdzefzmxzkfeajlranppiffokujjtsskfsqqlluravtuubwbmvj", "ybkypnfomnkamisprhvqalijyopldnhzocuuxznkkbaihmohimfjupaxlhaftjac", "cgasjiyyrujjvhqavxgfmgicyxvrnqlqianopwxdjogrsfszvvcrkitsqjstntis", "ynqatvgqjuovzycjknmhyxspzlolvfnhfeamhezxsxnzzcooqkjutacuqwdltrxl", "bgrwkispcpzfoaogyihlbcpkzwxdkqyerdknxkrgoqdsbbxhmrxkheocacsvznti", "ufgakafkepqtekygfreikibjaaqawfjxrwpcsjjzzjpmkzfmjyegofihoyeprxbt", "bkbzwmwvkdfidgxgovcbvkymsrlgjrmgkktznhmfsztqzlsnqiyfcyikckjdupkz", "dqrnqjkoiaxsniglxymnawisnbuxpzcscrzuxhhltifaajmyqakegzoebsipawoj", "yvegxfqjfeojderhegnvqwerixbufqgiktautddhypsaoyialutmnhpjznivydvb", "ynxksddaznhqzzqapssxsjvzuxapyqcsgllvxfykpbqxqtlkegiztmdehlkzbbdy", "vxtezoclnzlsefnorfuzwqppgunbuzrmfgatmytscjwnuzbzcsduowmshkrpfsdb", "dsndhmyzwezqvvxgnmzenzrllkojtsrkxtelygfbviogtsefcblkjcyhmxhewlhp", "okfihongvcytnegfycfifneqyslxbpkfatmhpjgvfqrezlpzfvpvnehpczgslbuo", "rfyndwnepidrfpwlcpzewrhtserpimiymqndkuzbdfjmkaaeuusfsjnowxbpsrze", "knjrozzgaglnxwqkusacsgrgggwnptbkaxhfezpfryujtbcmvbgztsgqeatsnjfm", "mvqzgybxwucluovlfunaliydqkjhxgafqcaxjehwseuurnjnqidbscycjkpiudxw", "ubktetfwrnzbdkxnujvtfumnahstkzkyfmbabbkwbyvatgsaebmwrumvjfhychar", "wdfwbupidsnmgwmqghszgwleomnupjpqbfbzmvecifvimmxrmxndqhwnhpfqzblo", "hxrjtpmwocyfunazptmgtcbyxqmqooosrrmixjluzsqmflweyecqhpsfbmxowsfb"},
                new List<string> { "xsx", "zcs", "ry", "pmhuacgaubpunypkoysfjmlvfnfqzzdpfgfxjxvnxkpkwtcfdxsxhdnpfgmidvph", "hxsgj", "lub"},
                new List<string> { "ry", "zcs", "lub", "xsx", "hxsgj", "pmhuacgaubpunypkoysfjmlvfnfqzzdpfgfxjxvnxkpkwtcfdxsxhdnpfgmidvph" } }
        };

        public static object[] WordstreamRepetedCasesData = {
            new object[] { new List<string> {"abcdc", "fgwio", "chill", "pqnsd", "uvdxy" }, new List<string> { "cold", "cold", "cold", "chill"}, new List<string> { "chill", "cold" } }
        };

        public static string[] largeMatrix = ["pmhuacgaubpunypkoysfjmlvfnfqzzdpfgfxjxvnxkpkwtcfdxsxhdnpfgmidvph", "tmxoccsvcrnqexvaconnjzkfwzqonvrysxhcktsgvpxdhyfxtfyqwvtupcjiicwr", "zcsyilhtuaorvrprunwihkwawqpqjojrejrbewunmdfrxhpsxjjmcmowjcfdmqhr", "zwgzudwlxqurqpttabjpxjfxtyeyywtahnziytwsuxsjxhvjsgkehpzktrmuhhps", "ugjbksireffvfgagjmycyugywvafwvbwjnasopozmsvdlmahahbyuudhofsywcci", "yjuifokippcmawlfcgelagcxudorevlauvenlyimowydaegiwviscgxmckksdhkf", "nguxmehglmaglgpsfekyyizumstdhcauvqjdzmnrsfivjzmwaighgxhzorxzzdvd", "omngxvbdbpidtuchgxqgyahnzeyckecftneelkcywmlmgaknvfspzdzfikdyztaw", "gtouftwhudonfrwlqmzrdgezatefkftrtqdwrvgymcvafkoztevffiqulqppgyuc", "fpowaybpuvtnfzgjqrqgzenqpnsjcfymarznhbrioaidtxoeabjulxeuqxfasham", "qucgngmrlzokxdwwkgtyjczjtghqzsnxoipezlulzlvzljugjdqrscknrhnvrylq", "clbmdnkbftdmxkfbjjwezvvzbdgubynecukgdmshjzfcaplqaslkcxmzztgdhxuy", "ohayninxfriyqvufijmtoqvtyjiqbrcblomaspepeudbenogrxbgbiztszkexbbp", "verzxggzcpiywifnbjlyjetzwmpcmalibjymwnrkbopgvhchiepugqowezyquyox", "ykwoydcjhjdqwwzhvvkqoripikzmalocfusaxwfgdvxtgjymlxabpqtlssvueohx", "efzrzhlqqbfmivmzdckvvhyqkmkmdwkhnieehgtyzchgogcccylcewygcmstozgw", "sxnupnyzvarzyymyfmogxpzpnasnlrwtevpyuudvyhykcfdbyznjqgpxikamgmmo", "vzajkuulaaplnjpjvzkdutcukedpkvusbkryhgmqpxgtyevvfwnjfnbyxeuygnck", "nqpiqnkvudwtakyyrghduppebqsmlatunlhqlxcssqgrxifsumxtghogbmibfhaq", "gmbgjiyqncmwiqtwgiawlvkmsalazdwngjltdgoncykfokoukuthusdgtihluruk", "fnakmrlujfovweknvevjiazbkmajfkmylystdpyfmpddnfiwjehhjuhtogezfzkc", "ybxeociwkeryevbogofkgriqcykgzabqjpthllilkcmjvpbixkxkdrfdcpnemcwq", "ncehwifxrkqrzcsuqgqmljtfblfesvzasdfvoehkeicfdilcvrcllxtpiovrbdnn", "bwzaoivmnxtfmrxbzsnnbbbazbozgszuqcxlouyysmudxlmrvbydiadkjxiyjfon", "llpgkrydtvkawjilvsrgsjmdwbmrygoutxabeycoqhscquxounaewbhhwhxksgeq", "zeciaalessxyytpajslieskyxqxmunymxrcufsmqzjtqvwzrzlarlhbvmxmxnyxk", "wvpipskhbyrhxyuihfbvziagjlewbrnozbkuvtnknhmjotyarokpbczfyyolovdn", "ubflwinjyewimjvptwxjmcihnqvmghtpoxmjhaklgcjcxsgrcngptqypxbaeuarn", "okvcgcivnfhwzafgqstigwbjppzxnwrgrghsdtgdpulfsybzpbmzhfdyhfbuykwt", "wefympmyahzpstkjotnebubcfdzyvlnddpapxntxuqxsjfvtpxnzwxboepzpgkgd", "exttrotxuoxcjfmstnnabrepmrpashwofkdjrpvwjpchhevuzagebbsdapdyvrrg", "cxaitdjbzvamywzjuvjqluippsfkenmslupxtrbbsoawaynovtivzkqyqbnjzcck", "glqbeuophaghsfgvyirdrnswmdmzmtnddcoisstpaokonzhzmcaqvtwfqehsmlyz", "zbmywhzgsvisayvtxozxodasscwnqaxwzisfydizpgehsndhjtekjyjwhuvtdffr", "bmeiwevxywqkaqeqfoqkigikdttnezjrsnopsbhptusmnhyxadvuvkzpmhjwblix", "frnchelpucbizprrqhomomgqqzfceqkwrhykygpktqqybqhmtxqhiogkwgyozgtk", "lfvjpjjtxmhwxypladqitomrjwhcnqbgjyvrwgwzpuztxybhptceeeyimjaxwfxo", "nhnbcexeasfpupzqyavtnghwvreifddyrlkbcfssbqcfbtjzyvvswsskpbwpeqij", "bibubydlbmzblcpskverewzhzdrdfnzghtcvbhbpmgzfboxxowibgnpwhkhjglrf", "vklenjowqfqmfhghoptwljlrdinpnwrfsjdmphmzinprybrdttjpmsvymwvmspvh", "uxwdvtyhigivmogjlzgunssfuschtgkfyewuojjeurkmqcyyuovsloflpcjijebe", "aoxdcjtbsazcdyuffblqhcmvmwpoxrfaducxofwhbciwqofwacztrgzxqappemww", "gpozypctwuiujzdbdstpywwpvcdjzytwvfuryhjlzmcrpjtljbzyndkgkvgbndyd", "fdhtxlhfpoflutcbzjcvabqczseqlfaxtzrydciygksgvohwyorfzryunhzqeflq", "ugdjlfmufdyatcoxljijumacxqdxmmpwvlibyzxfpfxtoisolrrtrlmcydyvismv", "ohofcbckvffgmpdzefzmxzkfeajlranppiffokujjtsskfsqqlluravtuubwbmvj", "ybkypnfomnkamisprhvqalijyopldnhzocuuxznkkbaihmohimfjupaxlhaftjac", "cgasjiyyrujjvhqavxgfmgicyxvrnqlqianopwxdjogrsfszvvcrkitsqjstntis", "ynqatvgqjuovzycjknmhyxspzlolvfnhfeamhezxsxnzzcooqkjutacuqwdltrxl", "bgrwkispcpzfoaogyihlbcpkzwxdkqyerdknxkrgoqdsbbxhmrxkheocacsvznti", "ufgakafkepqtekygfreikibjaaqawfjxrwpcsjjzzjpmkzfmjyegofihoyeprxbt", "bkbzwmwvkdfidgxgovcbvkymsrlgjrmgkktznhmfsztqzlsnqiyfcyikckjdupkz", "dqrnqjkoiaxsniglxymnawisnbuxpzcscrzuxhhltifaajmyqakegzoebsipawoj", "yvegxfqjfeojderhegnvqwerixbufqgiktautddhypsaoyialutmnhpjznivydvb", "ynxksddaznhqzzqapssxsjvzuxapyqcsgllvxfykpbqxqtlkegiztmdehlkzbbdy", "vxtezoclnzlsefnorfuzwqppgunbuzrmfgatmytscjwnuzbzcsduowmshkrpfsdb", "dsndhmyzwezqvvxgnmzenzrllkojtsrkxtelygfbviogtsefcblkjcyhmxhewlhp", "okfihongvcytnegfycfifneqyslxbpkfatmhpjgvfqrezlpzfvpvnehpczgslbuo", "rfyndwnepidrfpwlcpzewrhtserpimiymqndkuzbdfjmkaaeuusfsjnowxbpsrze", "knjrozzgaglnxwqkusacsgrgggwnptbkaxhfezpfryujtbcmvbgztsgqeatsnjfm", "mvqzgybxwucluovlfunaliydqkjhxgafqcaxjehwseuurnjnqidbscycjkpiudxw", "ubktetfwrnzbdkxnujvtfumnahstkzkyfmbabbkwbyvatgsaebmwrumvjfhychar", "wdfwbupidsnmgwmqghszgwleomnupjpqbfbzmvecifvimmxrmxndqhwnhpfqzblo", "hxrjtpmwocyfunazptmgtcbyxqmqooosrrmixjluzsqmflweyecqhpsfbmxowsfb"];

        private List<string> MatrixGenerator(int x, int y)
        {
            var validsChars = "abcdefghijklmnopqrstuvwxyz";
            var rdm = new Random();
            var result = new List<string>();

            for (int i = 0; i < y; i++)
            {
                result.Add(new string(Enumerable.Repeat(validsChars, x)
                                .Select(s => s[rdm.Next(s.Length)]).ToArray()));
            }

            return result;
        }


        #endregion
    }
}