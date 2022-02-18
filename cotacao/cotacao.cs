namespace AulaAsync.cotacao
{
    public class Cotacao
    {
        public string code { get; set; }
        public string codein { get; set; }
        public string name { get; set; }
        public string high { get; set; }
        public string low { get; set; }
        public string varBid { get; set; }
        public string pctChange { get; set; }
        public string bid { get; set; }
        public string ask { get; set; }
        public string timestamp { get; set; }
        public string create_date { get; set; }
    }

    public class MoedaRUBBRL {
        public Cotacao RUBBRL {get; set;}
    }

    public class MoedaUSDRUB {
        public Cotacao USDRUB {get; set;}
    }

    public class MoedaUSDBRL {
        public Cotacao USDBRL {get; set;}
    }

    public class MoedaRUBUSD {
       public Cotacao RUBUSD {get; set;}
    }
}