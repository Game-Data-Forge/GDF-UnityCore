namespace GDFFoundation
{
    public enum GDFDataArea
    {
        Unknown, 
        European,
        European_GDPR_EU, // Countries need to respect GDPR

        NorthAmerica,
        NorthAmerica_Canada_PIPEDA, // Canada PIPEDA
        NorthAmerica_California_CCPA, // USA California CCPA

        SouthAmerica,
        SouthAmerica_Brazil_LGPD, // Brazil LGPD
        SouthAmerica_Argentina_LPDP, // Argentina LPDP

        Africa,
        Africa_SouthAfrica_POPIA, // South Africa POPIA
        Africa_Nigeria_NDPR, // Nigeria NDPR

        Asia,
        Asia_Russia, // Russia Federal Law No. 152-FZ 
        Asia_India_PDPB, // India PDPB
        Asia_China_PIPL, // China PIPL
        Asia_Japan_APPI, // Japan APPI
        Asia_SouthKorea_PIPA, // South Korea PIPA
        Asia_Singapore_PDPA, // Singapore PDPA

        Oceania, 
        Oceania_Australia, // Australia Privacy Act 1988
        Oceania_NewZealand, // New Zealand Privacy Act

        Antarctica
    }
}