using ScreenSound.Banco;
using ScreenSound.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScreenSound.Menus;

internal class MenuMostrarMusicasPorAno : Menu
{
    public override void Executar(DAL<Artista> artistaDAL)
    {
        base.Executar(artistaDAL);
        ExibirTituloDaOpcao("Mostrar musicas por ano de lançamento");
        Console.Write("Digite o ano para consultar músicas: ");
        string anoLancamento = Console.ReadLine()!;

        var musicaDAL = new DAL<Musica>(new ScreenSoundContext());
        var listaAnoLancamento = musicaDAL.ListarPor(a => a.AnoLancamento == Convert.ToInt32(anoLancamento));

        if (listaAnoLancamento.Any())
        {
            Console.WriteLine($"Músicas lançadas em {anoLancamento}:");
            foreach (var musica in listaAnoLancamento)
            {
                musica.ExibirFichaTecnica();
            }

            Console.WriteLine("\nPressione qualquer tecla para continuar...");
            Console.ReadKey();
            Console.Clear();
        }
        else
        {
            Console.WriteLine("\nNenhuma música encontrada para o ano informado.");
            Console.WriteLine("\nPressione qualquer tecla para continuar...");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
