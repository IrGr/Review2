using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for FuldProdukt
/// </summary>
public class FuldProdukt:_Produkt
{
    public List<_Billede> Billeder { get; private set; }

	public FuldProdukt()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public FuldProdukt(_Produkt produkt, List<_Billede> billeder)
    {
        id = produkt.id;
        navn = produkt.navn;
        pris = produkt.pris;
        beskrivelse = produkt.beskrivelse;
        _Serie = produkt._Serie;
        _Billede = produkt._Billede;
        design_aar = produkt.design_aar;
        designer = produkt.designer;
        varenr = produkt.varenr;
        Billeder = billeder;
    }
    //fk_primert_billede_id = produkt.fk_primert_billede_id;
}       