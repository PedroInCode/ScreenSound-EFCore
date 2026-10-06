using ScreenSound.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScreenSound.Banco;    

internal class MusicaDAL : DAL<Musica>
{
    private readonly ScreenSoundContext _context;

    public MusicaDAL(ScreenSoundContext context)
    {
        _context = context;
    }

    public override IEnumerable<Musica> Listar()
    {
        return _context.Musicas.ToList();
    }

    public override void Adicionar(Musica musica)
    {
        _context.Musicas.Add(musica);
        _context.SaveChanges();
    }

    public override void Atualizar(Musica musica)
    {
        _context.Musicas.Update(musica);
        _context.SaveChanges();
    }

    public override void Deletar(Musica musica)
    {
        _context.Musicas.Remove(musica);
        _context.SaveChanges();
    }

    public Musica? RecuperarPorNome(string nome)
    {
        if(string.IsNullOrWhiteSpace(nome))
        {
            throw new ArgumentException("O nome da música não pode ser nulo ou vazio.", nameof(nome));
        }   
        return _context.Musicas.FirstOrDefault(m => m.Nome.Equals(nome));
    }
}
