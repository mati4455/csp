namespace CSP
{
    public static class BinaryData
    {

        public static bool?[,] GetSet(int n)
        {
            switch (n)
            {
                case 2: return Set_2X2;
                case 4: return Set_4X4;
                case 6: return Set_6X6;
                case 8: return Set_8X8;
                case 10: return Set_10X10;
                case 12: return Set_12X12;
                case 14: return Set_14X14;
                case 16: return Set_16x16;
                case 18: return Set_18x18;
            }
            return null;
        }


        private static bool?[,] Set_2X2 =
        {
            {true, false},
            {false, true}
        };

        private static bool?[,] Set_4X4 =
        {
            {true, true, false, false},
            {true, false, true, false},
            {false, true, false, true},
            {false, false, true, true}
        };

        private static bool?[,] Set_6X6 =
        {
            {true, true, false, true, false, false},
            {false, false, true, true, false, true},
            {true, false, true, false, true, false},
            {false, true, false, true, false, true},
            {false, false, true, false, true, true},
            {true, true, false, false, true, false}
        };

        private static bool?[,] Set_8X8 =
        {
            {true, true, false, true, false, true, false, false},
            {true, true, false, true, false, false, true, false},
            {false, false, true, false, true, true, false, true},
            {true, true, false, false, true, true, false, false},
            {false, false, true, true, false, false, true, true},
            {true, false, true, true, false, true, false, false},
            {false, true, false, false, true, false, true, true},
            {false, false, true, false, true, false, true, true}
        };

        private static bool?[,] Set_10X10 =
        {
            {true, true, false, true, false, true, false, true, false, false},
            {false, false, true, false, true, false, true, false, true, true},
            {true, true, false, true, true, false, false, true, false, false},
            {true, true, false, true, false, true, false, false, true, false},
            {false, false, true, false, true, false, true, true, false, true},
            {true, true, false, false, true, false, true, true, false, false},
            {false, false, true, true, false, true, false, false, true, true},
            {true, false, true, true, false, true, false, true, false, false},
            {false, true, false, false, true, false, true, false, true, true},
            {false, false, true, false, false, true, true, false, true, true}
        };

        private static bool?[,] Set_12X12 =
        {
            {true, true, false, true, true, false, true, false, false, true, false, false},
            {true, true, false, true, true, false, false, true, false, false, true, false},
            {false, false, true, false, false, true, true, false, true, true, false, true},
            {true, true, false, true, false, true, false, true, false, false, true, false},
            {true, true, false, false, true, false, true, false, true, false, false, true},
            {false, false, true, true, false, true, true, false, true, true, false, false},
            {false, true, false, true, false, true, false, true, false, false, true, true},
            {true, false, true, false, true, false, false, true, false, true, true, false},
            {false, false, true, false, true, false, true, false, true, true, false, true},
            {true, true, false, true, true, false, false, true, false, true, false, false},
            {false, false, true, false, false, true, false, true, true, false, true, true},
            {false, false, true, false, false, true, true, false, true, false, true, true}
        };

        private static bool?[,] Set_14X14 =
        {
            {true, true, false, true, true, false, true, false, true, false, false, true, false, false},
            {true, true, false, true, true, false, true, false, false, true, false, true, false, false},
            {false, false, true, false, false, true, false, true, true, false, true, false, true, true},
            {true, true, false, true, true, false, true, false, false, true, false, false, true, false},
            {true, true, false, true, true, false, false, true, true, false, false, true, false, false},
            {false, false, true, false, false, true, false, true, true, false, true, true, false, true},
            {true, true, false, true, false, true, true, false, false, true, false, false, true, false},
            {false, false, true, false, true, false, false, true, true, false, true, true, false, true},
            {true, false, true, false, true, true, false, true, false, false, true, true, false, false},
            {false, true, false, true, false, false, true, false, true, true, false, false, true, true},
            {false, false, true, false, false, true, false, true, false, true, true, false, true, true},
            {true, false, false, true, true, false, true, true, false, false, true, true, false, false},
            {false, true, true, false, false, true, false, false, true, true, false, false, true, true},
            {false, false, true, false, false, true, true, false, false, true, true, false, true, true}
        };

        private static bool?[,] Set_16x16 =
        {
            {true, true, false, true, true, false, true, false, true, false, false, true, false, false, true, false},
            {true, false, true, false, true, true, false, true, false, true, true, false, false, true, false, false},
            {false, false, true, true, false, true, true, false, true, false, true, false, true, false, false, true},
            {false, true, false, false, true, false, false, true, true, false, false, true, true, false, true, true},
            {true, true, false, true, true, false, true, false, false, true, true, false, false, true, false, false},
            {false, false, true, true, false, true, true, false, true, true, false, true, false, false, true, false},
            {true, true, false, false, true, false, false, true, false, false, true, false, true, true, false, true},
            {true, false, true, false, true, false, true, false, true, false, true, false, true, false, false, true},
            {false, true, false, true, false, true, true, false, false, true, false, true, false, true, true, false},
            {true, false, true, false, false, true, false, true, true, false, false, true, true, false, true, false},
            {true, false, true, false, true, false, false, true, false, false, true, false, true, true, false, true},
            {false, true, false, true, false, false, true, false, true, true, false, true, false, true, true, false},
            {false, false, true, true, false, true, false, true, false, true, false, true, true, false, false, true},
            {true, true, false, false, true, false, true, false, true, false, true, false, false, true, true, false},
            {false, false, true, false, false, true, false, true, false, true, true, false, true, true, false, true},
            {false, true, false, true, false, true, false, true, false, true, false, true, false, false, true, true}
        };
        
        private static bool?[,] Set_18x18 =
        {
            {true, false, true, false, true, false, true, false, false, true, true, false, true, true, false, true, false, false},
            {false, true, true, false, true, false, true, false, true, true, false, true, false, false, true, false, true, false},
            {false, true, false, true, false, true, false, true, false, false, true, true, false, true, false, true, false, true},
            {true, false, true, true, false, true, false, true, false, true, false, false, true, false, true, false, true, false},
            {false, true, false, false, true, false, true, false, true, true, false, true, false, true, false, true, true, false},
            {true, false, false, true, false, true, false, true, false, false, true, false, true, false, true, true, false, true},
            {false, true, true, false, true, false, false, true, true, false, false, true, false, true, true, false, false, true},
            {true, true, false, true, false, true, true, false, false, true, true, false, false, true, false, false, true, false},
            {true, false, true, true, false, true, false, true, true, false, false, true, true, false, false, true, false, false},
            {false, true, false, false, true, false, true, false, false, true, true, false, true, false, true, false, true, true},
            {false, false, true, true, false, true, false, false, true, false, true, true, false, true, false, true, false, true},
            {true, true, false, false, true, true, false, true, true, false, false, true, false, true, false, true, false, false},
            {true, false, false, true, false, false, true, true, false, true, false, false, true, false, true, false, true, true},
            {false, false, true, true, false, true, false, false, true, false, true, false, true, false, true, false, true, true},
            {true, true, false, false, true, false, true, true, false, true, false, true, false, true, false, true, false, false},
            {false, false, true, false, true, false, true, false, true, false, true, false, true, true, false, true, false, true},
            {false, true, false, true, false, true, false, true, true, false, false, true, false, false, true, false, true, true},
            {true, false, true, false, true, false, true, false, false, true, true, false, true, false, true, false, true, false}
        };
    }
}
