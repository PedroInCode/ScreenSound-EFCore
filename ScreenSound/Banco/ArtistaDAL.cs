using Microsoft.Data.SqlClient;
using ScreenSound.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScreenSound.Banco;

internal class ArtistaDAL : DAL<Artista>
{
    public ArtistaDAL(ScreenSoundContext context) : base(context) { }
    

    public Artista? RecuperarPeloNome(string nome)
    {
        if(string.IsNullOrWhiteSpace(nome))
        {
            throw new ArgumentException("O nome do artista não pode ser nulo ou vazio.", nameof(nome));
        }
        return _context.Artistas.FirstOrDefault(a => a.Nome.Equals(nome));
    }
}
