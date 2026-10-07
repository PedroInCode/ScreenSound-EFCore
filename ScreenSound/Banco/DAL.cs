using Microsoft.EntityFrameworkCore;
using ScreenSound.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScreenSound.Banco;

internal class DAL<T> where T : class
{
    protected readonly ScreenSoundContext _context;

    protected DAL(ScreenSoundContext context)
    {
        _context = context;
    }

    public IEnumerable<T> Listar() => _context.Set<T>().ToList();
    public void Adicionar(T objeto) => _context.Set<T>().Add(objeto);
    public void Atualizar(T objeto) => _context.Set<T>().Update(objeto);
    public void Deletar(T objeto) => _context.Set<T>().Remove(objeto);
    public T? RecuperarPor(Func<T, bool> condicao) => _context.Set<T>().FirstOrDefault();
    


}
