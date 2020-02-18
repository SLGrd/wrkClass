namespace wrkClass
{
    class ModelClass
    {
        public class WrkClsModel
        {
            public string P1 { get; set; }
            public string P2 { get; set; }
            public string P3 { get; set; }            

            public WrkClsModel()
            {
                P1 = ""; P2 = ""; P3 = "";
            }

            public WrkClsModel(string p1, string p2, string p3)
            {
                P1 = p1; P2 = p2; P3 = p3;
            }
        }
    }
}