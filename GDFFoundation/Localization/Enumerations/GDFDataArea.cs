namespace GDFFoundation
{
    public enum GDFDataArea
    {
        Unknown = 0,

        European = 100,
        European_GDPR = 101, // Countries need to respect GDPR

        NorthAmerica = 200,
        NorthAmerica_Canada_PIPEDA = 201, // Canada PIPEDA
        NorthAmerica_California_CCPA = 202, // USA California CCPA

        SouthAmerica = 300,
        SouthAmerica_Brazil_LGPD = 301, // Brazil LGPD
        SouthAmerica_Argentina_LPDP = 302, // Argentina LPDP

        Africa = 400,
        Africa_SouthAfrica_POPIA = 401, // South Africa POPIA
        Africa_Nigeria_NDPR = 402, // Nigeria NDPR

        Asia = 500,
        Asia_Russia = 501, // Russia Federal Law No. 152-FZ 
        Asia_India_PDPB = 502, // India PDPB
        Asia_China_PIPL = 503, // China PIPL
        Asia_Japan_APPI = 504, // Japan APPI
        Asia_SouthKorea_PIPA = 506, // South Korea PIPA
        Asia_Singapore_PDPA = 507, // Singapore PDPA

        Oceania = 600,
        Oceania_Australia = 601, // Australia Privacy Act 1988
        Oceania_NewZealand = 602, // New Zealand Privacy Act

        Antarctica = 700,

        Tesseract = 999
    }
}