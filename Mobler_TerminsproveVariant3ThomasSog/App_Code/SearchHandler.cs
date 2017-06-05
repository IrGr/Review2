using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for SearchHandler
/// </summary>
public class SearchHandler
{
    private List<_Produkt> _listOfProducts;
	public SearchHandler()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    
    public SearchHandler(List<_Produkt> listofProds)
    {
        _listOfProducts = listofProds;
    }


    public List<_Produkt> GetSearchResult(int minaar, int maxaar, int minpris, int maxpris, List<int> serie, string designer)
    {

        if (minaar == 0) minaar = 1; // Min sættes til 1 som default
        if (maxaar == 0) maxaar = int.MaxValue; // Max sættes til 10000 som default
        if (minpris == 0) minpris = 1; // Min sættes til 1 som default
        if (maxpris == 0) maxpris = int.MaxValue; // Max sættes til 10000 som default

        // Konverter strenge til småbogstaver
        //varenummer = varenummer.ToLowerInvariant();
        //fritext = fritext.ToLowerInvariant();

        // Vi kan nu lave en filtreret søgning på alt
        // Hint contains "" (blank) er altid sand
        // Alle kolonner med string konverteres til lowercase
        var result = _listOfProducts.Where(p=>
            (p.design_aar >= Convert.ToInt32(minaar) && p.design_aar <= Convert.ToInt32(maxaar))//år
             && (p.designer == designer || string.IsNullOrEmpty(designer))//designer
            && (p.pris >= Convert.ToInt32(minpris) && p.pris <= Convert.ToInt32(maxpris))// min / max pris
            ).ToList();

        // kategori holdes udenfor da filtret ikke altid kan evaluere sandt uden at blive grådig
        if (serie.Count > 0)
            result = result.Where(prod => serie.Contains(prod.fk_serie_id)).ToList();

        return result;
    }
}