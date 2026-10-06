using ScreenSound.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScreenSound.Banco;    

internal class MusicaDAL
{
    private readonly ScreenSoundContext _context;

    public MusicaDAL(ScreenSoundContext context)
    {
        _context = context;
    }

    public IEnumerable<Musica> Listar()
    {
        return _context.Musicas.ToList();
    }

    public void Adicionar(Musica musica)
    {
        _context.Musicas.Add(musica);
        _context.SaveChanges();
    }

    public void Atualizar(Musica musica)
    {
        _context.Musicas.Update(musica);
        _context.SaveChanges();
    }

    public void Deletar(int id)
    {
        var musicaEncontrada = _context.Musicas.FirstOrDefault(m => m.Id == id);
        if (musicaEncontrada != null)
        {
            _context.Musicas.Remove(musicaEncontrada);
            _context.SaveChanges();
            return;
        }

        Console.WriteLine("Musica não encontrada para exclusão.");
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
