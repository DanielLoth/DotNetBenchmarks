using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Diagnosers;
using BenchmarkDotNet.Order;

namespace NET46
{
    [Config(typeof(Config))]
    [OrderProvider(SummaryOrderPolicy.FastestToSlowest)]
    public class DictionaryVsSwitchBenchmarks
    {
        public static int N = 255;
        public static int SearchValue = 233;

        public static Dictionary<int, int> map = new Dictionary<int, int>();
        public static ConcurrentDictionary<int, int> concurrentMap = new ConcurrentDictionary<int, int>();

        public DictionaryVsSwitchBenchmarks()
        {
            for (var i = 0; i < N; i++)
            {
                map[i] = i;
                concurrentMap[i] = i;
            }
        }

        /*
        // * Summary *

        BenchmarkDotNet=v0.10.14, OS=Windows 10.0.17134
        Intel Core i5-4200U CPU 1.60GHz (Haswell), 1 CPU, 4 logical and 2 physical cores
        Frequency=2240908 Hz, Resolution=446.2477 ns, Timer=TSC
        .NET Core SDK=2.1.301
          [Host]     : .NET Core 2.1.1 (CoreCLR 4.6.26606.02, CoreFX 4.6.26606.05), 64bit RyuJIT
          DefaultJob : .NET Core 2.1.1 (CoreCLR 4.6.26606.02, CoreFX 4.6.26606.05), 64bit RyuJIT


                       Method |       Mean |     Error |    StdDev | Allocated |
        --------------------- |-----------:|----------:|----------:|----------:|
                       Switch |   4.374 ns | 0.0393 ns | 0.0349 ns |       0 B |
                   Dictionary |  12.478 ns | 0.3217 ns | 0.3951 ns |       0 B |
         ConcurrentDictionary |  22.064 ns | 0.1965 ns | 0.1742 ns |       0 B |
                      IfBlock | 182.541 ns | 3.4792 ns | 3.0842 ns |       0 B |


        BenchmarkDotNet=v0.10.14, OS=Windows 10.0.17134
        Intel Core i5-4200U CPU 1.60GHz (Haswell), 1 CPU, 4 logical and 2 physical cores
        Frequency=2240908 Hz, Resolution=446.2477 ns, Timer=TSC
          [Host]     : .NET Framework 4.7.1 (CLR 4.0.30319.42000), 32bit LegacyJIT-v4.7.3110.0
          DefaultJob : .NET Framework 4.7.1 (CLR 4.0.30319.42000), 32bit LegacyJIT-v4.7.3110.0


                       Method |       Mean |     Error |    StdDev | Allocated |
        --------------------- |-----------:|----------:|----------:|----------:|
                       Switch |   2.876 ns | 0.0297 ns | 0.0263 ns |       0 B |
                   Dictionary |  16.357 ns | 0.3206 ns | 0.4494 ns |       0 B |
         ConcurrentDictionary |  24.579 ns | 0.0943 ns | 0.0737 ns |       0 B |
                      IfBlock | 178.798 ns | 2.5768 ns | 2.2843 ns |       0 B |
         */

        private class Config : ManualConfig
        {
            public Config()
            {
                // Same as having the class-level attribute.
                Add(MemoryDiagnoser.Default);
                //Add(StatisticColumn.AllStatistics);
                //Add(DefaultJob);
            }
        }

        [Benchmark(OperationsPerInvoke = 32)]
        public void ConcurrentDictionary()
        {
            CD(); CD(); CD(); CD();
            CD(); CD(); CD(); CD();
            CD(); CD(); CD(); CD();
            CD(); CD(); CD(); CD();
            CD(); CD(); CD(); CD();
            CD(); CD(); CD(); CD();
            CD(); CD(); CD(); CD();
            CD(); CD(); CD(); CD();
        }

        [Benchmark(OperationsPerInvoke = 32)]
        public void Dictionary()
        {
            D(); D(); D(); D();
            D(); D(); D(); D();
            D(); D(); D(); D();
            D(); D(); D(); D();
            D(); D(); D(); D();
            D(); D(); D(); D();
            D(); D(); D(); D();
            D(); D(); D(); D();
        }

        [Benchmark(OperationsPerInvoke = 32)]
        public void IfBlock()
        {
            IB(); IB(); IB(); IB();
            IB(); IB(); IB(); IB();
            IB(); IB(); IB(); IB();
            IB(); IB(); IB(); IB();
            IB(); IB(); IB(); IB();
            IB(); IB(); IB(); IB();
            IB(); IB(); IB(); IB();
            IB(); IB(); IB(); IB();
        }

        [Benchmark(OperationsPerInvoke = 32)]
        public void Switch()
        {
            S(); S(); S(); S();
            S(); S(); S(); S();
            S(); S(); S(); S();
            S(); S(); S(); S();
            S(); S(); S(); S();
            S(); S(); S(); S();
            S(); S(); S(); S();
            S(); S(); S(); S();
        }

        #region Private methods

        private int D()
        {
            return map[SearchValue];
        }

        private int CD()
        {
            return concurrentMap[SearchValue];
        }

        private int IB()
        {
            if (SearchValue == 0) return 0;
            else if (SearchValue == 1) return 1;
            else if (SearchValue == 2) return 2;
            else if (SearchValue == 3) return 3;
            else if (SearchValue == 4) return 4;
            else if (SearchValue == 5) return 5;
            else if (SearchValue == 6) return 6;
            else if (SearchValue == 7) return 7;
            else if (SearchValue == 8) return 8;
            else if (SearchValue == 9) return 9;
            else if (SearchValue == 10) return 10;
            else if (SearchValue == 11) return 11;
            else if (SearchValue == 12) return 12;
            else if (SearchValue == 13) return 13;
            else if (SearchValue == 14) return 14;
            else if (SearchValue == 15) return 15;
            else if (SearchValue == 16) return 16;
            else if (SearchValue == 17) return 17;
            else if (SearchValue == 18) return 18;
            else if (SearchValue == 19) return 19;
            else if (SearchValue == 20) return 20;
            else if (SearchValue == 21) return 21;
            else if (SearchValue == 22) return 22;
            else if (SearchValue == 23) return 23;
            else if (SearchValue == 24) return 24;
            else if (SearchValue == 25) return 25;
            else if (SearchValue == 26) return 26;
            else if (SearchValue == 27) return 27;
            else if (SearchValue == 28) return 28;
            else if (SearchValue == 29) return 29;
            else if (SearchValue == 30) return 30;
            else if (SearchValue == 31) return 31;
            else if (SearchValue == 32) return 32;
            else if (SearchValue == 33) return 33;
            else if (SearchValue == 34) return 34;
            else if (SearchValue == 35) return 35;
            else if (SearchValue == 36) return 36;
            else if (SearchValue == 37) return 37;
            else if (SearchValue == 38) return 38;
            else if (SearchValue == 39) return 39;
            else if (SearchValue == 40) return 40;
            else if (SearchValue == 41) return 41;
            else if (SearchValue == 42) return 42;
            else if (SearchValue == 43) return 43;
            else if (SearchValue == 44) return 44;
            else if (SearchValue == 45) return 45;
            else if (SearchValue == 46) return 46;
            else if (SearchValue == 47) return 47;
            else if (SearchValue == 48) return 48;
            else if (SearchValue == 49) return 49;
            else if (SearchValue == 50) return 50;
            else if (SearchValue == 51) return 51;
            else if (SearchValue == 52) return 52;
            else if (SearchValue == 53) return 53;
            else if (SearchValue == 54) return 54;
            else if (SearchValue == 55) return 55;
            else if (SearchValue == 56) return 56;
            else if (SearchValue == 57) return 57;
            else if (SearchValue == 58) return 58;
            else if (SearchValue == 59) return 59;
            else if (SearchValue == 60) return 60;
            else if (SearchValue == 61) return 61;
            else if (SearchValue == 62) return 62;
            else if (SearchValue == 63) return 63;
            else if (SearchValue == 64) return 64;
            else if (SearchValue == 65) return 65;
            else if (SearchValue == 66) return 66;
            else if (SearchValue == 67) return 67;
            else if (SearchValue == 68) return 68;
            else if (SearchValue == 69) return 69;
            else if (SearchValue == 70) return 70;
            else if (SearchValue == 71) return 71;
            else if (SearchValue == 72) return 72;
            else if (SearchValue == 73) return 73;
            else if (SearchValue == 74) return 74;
            else if (SearchValue == 75) return 75;
            else if (SearchValue == 76) return 76;
            else if (SearchValue == 77) return 77;
            else if (SearchValue == 78) return 78;
            else if (SearchValue == 79) return 79;
            else if (SearchValue == 80) return 80;
            else if (SearchValue == 81) return 81;
            else if (SearchValue == 82) return 82;
            else if (SearchValue == 83) return 83;
            else if (SearchValue == 84) return 84;
            else if (SearchValue == 85) return 85;
            else if (SearchValue == 86) return 86;
            else if (SearchValue == 87) return 87;
            else if (SearchValue == 88) return 88;
            else if (SearchValue == 89) return 89;
            else if (SearchValue == 90) return 90;
            else if (SearchValue == 91) return 91;
            else if (SearchValue == 92) return 92;
            else if (SearchValue == 93) return 93;
            else if (SearchValue == 94) return 94;
            else if (SearchValue == 95) return 95;
            else if (SearchValue == 96) return 96;
            else if (SearchValue == 97) return 97;
            else if (SearchValue == 98) return 98;
            else if (SearchValue == 99) return 99;
            else if (SearchValue == 100) return 100;
            else if (SearchValue == 101) return 101;
            else if (SearchValue == 102) return 102;
            else if (SearchValue == 103) return 103;
            else if (SearchValue == 104) return 104;
            else if (SearchValue == 105) return 105;
            else if (SearchValue == 106) return 106;
            else if (SearchValue == 107) return 107;
            else if (SearchValue == 108) return 108;
            else if (SearchValue == 109) return 109;
            else if (SearchValue == 110) return 110;
            else if (SearchValue == 111) return 111;
            else if (SearchValue == 112) return 112;
            else if (SearchValue == 113) return 113;
            else if (SearchValue == 114) return 114;
            else if (SearchValue == 115) return 115;
            else if (SearchValue == 116) return 116;
            else if (SearchValue == 117) return 117;
            else if (SearchValue == 118) return 118;
            else if (SearchValue == 119) return 119;
            else if (SearchValue == 120) return 120;
            else if (SearchValue == 121) return 121;
            else if (SearchValue == 122) return 122;
            else if (SearchValue == 123) return 123;
            else if (SearchValue == 124) return 124;
            else if (SearchValue == 125) return 125;
            else if (SearchValue == 126) return 126;
            else if (SearchValue == 127) return 127;
            else if (SearchValue == 128) return 128;
            else if (SearchValue == 129) return 129;
            else if (SearchValue == 130) return 130;
            else if (SearchValue == 131) return 131;
            else if (SearchValue == 132) return 132;
            else if (SearchValue == 133) return 133;
            else if (SearchValue == 134) return 134;
            else if (SearchValue == 135) return 135;
            else if (SearchValue == 136) return 136;
            else if (SearchValue == 137) return 137;
            else if (SearchValue == 138) return 138;
            else if (SearchValue == 139) return 139;
            else if (SearchValue == 140) return 140;
            else if (SearchValue == 141) return 141;
            else if (SearchValue == 142) return 142;
            else if (SearchValue == 143) return 143;
            else if (SearchValue == 144) return 144;
            else if (SearchValue == 145) return 145;
            else if (SearchValue == 146) return 146;
            else if (SearchValue == 147) return 147;
            else if (SearchValue == 148) return 148;
            else if (SearchValue == 149) return 149;
            else if (SearchValue == 150) return 150;
            else if (SearchValue == 151) return 151;
            else if (SearchValue == 152) return 152;
            else if (SearchValue == 153) return 153;
            else if (SearchValue == 154) return 154;
            else if (SearchValue == 155) return 155;
            else if (SearchValue == 156) return 156;
            else if (SearchValue == 157) return 157;
            else if (SearchValue == 158) return 158;
            else if (SearchValue == 159) return 159;
            else if (SearchValue == 160) return 160;
            else if (SearchValue == 161) return 161;
            else if (SearchValue == 162) return 162;
            else if (SearchValue == 163) return 163;
            else if (SearchValue == 164) return 164;
            else if (SearchValue == 165) return 165;
            else if (SearchValue == 166) return 166;
            else if (SearchValue == 167) return 167;
            else if (SearchValue == 168) return 168;
            else if (SearchValue == 169) return 169;
            else if (SearchValue == 170) return 170;
            else if (SearchValue == 171) return 171;
            else if (SearchValue == 172) return 172;
            else if (SearchValue == 173) return 173;
            else if (SearchValue == 174) return 174;
            else if (SearchValue == 175) return 175;
            else if (SearchValue == 176) return 176;
            else if (SearchValue == 177) return 177;
            else if (SearchValue == 178) return 178;
            else if (SearchValue == 179) return 179;
            else if (SearchValue == 180) return 180;
            else if (SearchValue == 181) return 181;
            else if (SearchValue == 182) return 182;
            else if (SearchValue == 183) return 183;
            else if (SearchValue == 184) return 184;
            else if (SearchValue == 185) return 185;
            else if (SearchValue == 186) return 186;
            else if (SearchValue == 187) return 187;
            else if (SearchValue == 188) return 188;
            else if (SearchValue == 189) return 189;
            else if (SearchValue == 190) return 190;
            else if (SearchValue == 191) return 191;
            else if (SearchValue == 192) return 192;
            else if (SearchValue == 193) return 193;
            else if (SearchValue == 194) return 194;
            else if (SearchValue == 195) return 195;
            else if (SearchValue == 196) return 196;
            else if (SearchValue == 197) return 197;
            else if (SearchValue == 198) return 198;
            else if (SearchValue == 199) return 199;
            else if (SearchValue == 200) return 200;
            else if (SearchValue == 201) return 201;
            else if (SearchValue == 202) return 202;
            else if (SearchValue == 203) return 203;
            else if (SearchValue == 204) return 204;
            else if (SearchValue == 205) return 205;
            else if (SearchValue == 206) return 206;
            else if (SearchValue == 207) return 207;
            else if (SearchValue == 208) return 208;
            else if (SearchValue == 209) return 209;
            else if (SearchValue == 210) return 210;
            else if (SearchValue == 211) return 211;
            else if (SearchValue == 212) return 212;
            else if (SearchValue == 213) return 213;
            else if (SearchValue == 214) return 214;
            else if (SearchValue == 215) return 215;
            else if (SearchValue == 216) return 216;
            else if (SearchValue == 217) return 217;
            else if (SearchValue == 218) return 218;
            else if (SearchValue == 219) return 219;
            else if (SearchValue == 220) return 220;
            else if (SearchValue == 221) return 221;
            else if (SearchValue == 222) return 222;
            else if (SearchValue == 223) return 223;
            else if (SearchValue == 224) return 224;
            else if (SearchValue == 225) return 225;
            else if (SearchValue == 226) return 226;
            else if (SearchValue == 227) return 227;
            else if (SearchValue == 228) return 228;
            else if (SearchValue == 229) return 229;
            else if (SearchValue == 230) return 230;
            else if (SearchValue == 231) return 231;
            else if (SearchValue == 232) return 232;
            else if (SearchValue == 233) return 233;
            else if (SearchValue == 234) return 234;
            else if (SearchValue == 235) return 235;
            else if (SearchValue == 236) return 236;
            else if (SearchValue == 237) return 237;
            else if (SearchValue == 238) return 238;
            else if (SearchValue == 239) return 239;
            else if (SearchValue == 240) return 240;
            else if (SearchValue == 241) return 241;
            else if (SearchValue == 242) return 242;
            else if (SearchValue == 243) return 243;
            else if (SearchValue == 244) return 244;
            else if (SearchValue == 245) return 245;
            else if (SearchValue == 246) return 246;
            else if (SearchValue == 247) return 247;
            else if (SearchValue == 248) return 248;
            else if (SearchValue == 249) return 249;
            else if (SearchValue == 250) return 250;
            else if (SearchValue == 251) return 251;
            else if (SearchValue == 252) return 252;
            else if (SearchValue == 253) return 253;
            else if (SearchValue == 254) return 254;

            throw new Exception();
        }

        private int S()
        {
            switch (SearchValue)
            {
                case 0: return 0;
                case 1: return 1;
                case 2: return 2;
                case 3: return 3;
                case 4: return 4;
                case 5: return 5;
                case 6: return 6;
                case 7: return 7;
                case 8: return 8;
                case 9: return 9;
                case 10: return 10;
                case 11: return 11;
                case 12: return 12;
                case 13: return 13;
                case 14: return 14;
                case 15: return 15;
                case 16: return 16;
                case 17: return 17;
                case 18: return 18;
                case 19: return 19;
                case 20: return 20;
                case 21: return 21;
                case 22: return 22;
                case 23: return 23;
                case 24: return 24;
                case 25: return 25;
                case 26: return 26;
                case 27: return 27;
                case 28: return 28;
                case 29: return 29;
                case 30: return 30;
                case 31: return 31;
                case 32: return 32;
                case 33: return 33;
                case 34: return 34;
                case 35: return 35;
                case 36: return 36;
                case 37: return 37;
                case 38: return 38;
                case 39: return 39;
                case 40: return 40;
                case 41: return 41;
                case 42: return 42;
                case 43: return 43;
                case 44: return 44;
                case 45: return 45;
                case 46: return 46;
                case 47: return 47;
                case 48: return 48;
                case 49: return 49;
                case 50: return 50;
                case 51: return 51;
                case 52: return 52;
                case 53: return 53;
                case 54: return 54;
                case 55: return 55;
                case 56: return 56;
                case 57: return 57;
                case 58: return 58;
                case 59: return 59;
                case 60: return 60;
                case 61: return 61;
                case 62: return 62;
                case 63: return 63;
                case 64: return 64;
                case 65: return 65;
                case 66: return 66;
                case 67: return 67;
                case 68: return 68;
                case 69: return 69;
                case 70: return 70;
                case 71: return 71;
                case 72: return 72;
                case 73: return 73;
                case 74: return 74;
                case 75: return 75;
                case 76: return 76;
                case 77: return 77;
                case 78: return 78;
                case 79: return 79;
                case 80: return 80;
                case 81: return 81;
                case 82: return 82;
                case 83: return 83;
                case 84: return 84;
                case 85: return 85;
                case 86: return 86;
                case 87: return 87;
                case 88: return 88;
                case 89: return 89;
                case 90: return 90;
                case 91: return 91;
                case 92: return 92;
                case 93: return 93;
                case 94: return 94;
                case 95: return 95;
                case 96: return 96;
                case 97: return 97;
                case 98: return 98;
                case 99: return 99;
                case 100: return 100;
                case 101: return 101;
                case 102: return 102;
                case 103: return 103;
                case 104: return 104;
                case 105: return 105;
                case 106: return 106;
                case 107: return 107;
                case 108: return 108;
                case 109: return 109;
                case 110: return 110;
                case 111: return 111;
                case 112: return 112;
                case 113: return 113;
                case 114: return 114;
                case 115: return 115;
                case 116: return 116;
                case 117: return 117;
                case 118: return 118;
                case 119: return 119;
                case 120: return 120;
                case 121: return 121;
                case 122: return 122;
                case 123: return 123;
                case 124: return 124;
                case 125: return 125;
                case 126: return 126;
                case 127: return 127;
                case 128: return 128;
                case 129: return 129;
                case 130: return 130;
                case 131: return 131;
                case 132: return 132;
                case 133: return 133;
                case 134: return 134;
                case 135: return 135;
                case 136: return 136;
                case 137: return 137;
                case 138: return 138;
                case 139: return 139;
                case 140: return 140;
                case 141: return 141;
                case 142: return 142;
                case 143: return 143;
                case 144: return 144;
                case 145: return 145;
                case 146: return 146;
                case 147: return 147;
                case 148: return 148;
                case 149: return 149;
                case 150: return 150;
                case 151: return 151;
                case 152: return 152;
                case 153: return 153;
                case 154: return 154;
                case 155: return 155;
                case 156: return 156;
                case 157: return 157;
                case 158: return 158;
                case 159: return 159;
                case 160: return 160;
                case 161: return 161;
                case 162: return 162;
                case 163: return 163;
                case 164: return 164;
                case 165: return 165;
                case 166: return 166;
                case 167: return 167;
                case 168: return 168;
                case 169: return 169;
                case 170: return 170;
                case 171: return 171;
                case 172: return 172;
                case 173: return 173;
                case 174: return 174;
                case 175: return 175;
                case 176: return 176;
                case 177: return 177;
                case 178: return 178;
                case 179: return 179;
                case 180: return 180;
                case 181: return 181;
                case 182: return 182;
                case 183: return 183;
                case 184: return 184;
                case 185: return 185;
                case 186: return 186;
                case 187: return 187;
                case 188: return 188;
                case 189: return 189;
                case 190: return 190;
                case 191: return 191;
                case 192: return 192;
                case 193: return 193;
                case 194: return 194;
                case 195: return 195;
                case 196: return 196;
                case 197: return 197;
                case 198: return 198;
                case 199: return 199;
                case 200: return 200;
                case 201: return 201;
                case 202: return 202;
                case 203: return 203;
                case 204: return 204;
                case 205: return 205;
                case 206: return 206;
                case 207: return 207;
                case 208: return 208;
                case 209: return 209;
                case 210: return 210;
                case 211: return 211;
                case 212: return 212;
                case 213: return 213;
                case 214: return 214;
                case 215: return 215;
                case 216: return 216;
                case 217: return 217;
                case 218: return 218;
                case 219: return 219;
                case 220: return 220;
                case 221: return 221;
                case 222: return 222;
                case 223: return 223;
                case 224: return 224;
                case 225: return 225;
                case 226: return 226;
                case 227: return 227;
                case 228: return 228;
                case 229: return 229;
                case 230: return 230;
                case 231: return 231;
                case 232: return 232;
                case 233: return 233;
                case 234: return 234;
                case 235: return 235;
                case 236: return 236;
                case 237: return 237;
                case 238: return 238;
                case 239: return 239;
                case 240: return 240;
                case 241: return 241;
                case 242: return 242;
                case 243: return 243;
                case 244: return 244;
                case 245: return 245;
                case 246: return 246;
                case 247: return 247;
                case 248: return 248;
                case 249: return 249;
                case 250: return 250;
                case 251: return 251;
                case 252: return 252;
                case 253: return 253;
                case 254: return 254;
            }

            throw new Exception();
        }

        #endregion
    }
}
