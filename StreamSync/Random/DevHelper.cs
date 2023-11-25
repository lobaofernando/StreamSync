using FuzzyString;

namespace NZWalksAPI;

public class DevHelper
{
    public static string RandomStringGenerator(int length)
    {
        var random = new Random();
        var chars = new char[length];
        for (int i = 0; i < length; i++)
        {
            chars[i] = (char)random.Next(65, 90);
        }
        return new string(chars);
    }

    static string EncontrarStringMaisSemelhante(string stringOriginal, List<string> stringsComparacao)
    {
        string maisSemelhante = "";
        int menorDistancia = int.MaxValue;

        foreach (var str in stringsComparacao)
        {
            int distancia = str.LevenshteinDistance(stringOriginal);

            if (distancia < menorDistancia)
            {
                menorDistancia = distancia;
                maisSemelhante = str;
            }
        }

        return maisSemelhante;
    }
}
