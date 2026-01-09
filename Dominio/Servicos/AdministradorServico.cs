using System.Linq;
using MinimalAPI.dominio.Entidades;
using MinimalAPI.dominio.DTOs;
using MinimalAPI.Infraestrutura.Db;
using MinimalAPI.dominio.Interfaces;

namespace MinimalAPI.dominio.Servicos;

public class AdministradorServico : IAdministradorServico
{
    private readonly DbContexto _contexto;

    public AdministradorServico(DbContexto contexto)
    {
        _contexto = contexto;
    }

    public Administrador? BuscaPorId(int id)
    {
        return _contexto.Administradores.FirstOrDefault(v => v.Id == id)!;
    }

    public Administrador Incluir(Administrador administrador)
    {
        _contexto.Administradores.Add(administrador);
        _contexto.SaveChanges();
        return administrador;
    }

    public Administrador? Login(LoginDTO loginDTO)
    {
        return _contexto.Administradores
            .FirstOrDefault(a =>
                a.Email == loginDTO.Email &&
                a.Senha == loginDTO.Password);
    }

    public List<Administrador> Todos(int? pagina)
    {
        var query = _contexto.Administradores.AsQueryable();

        int itensPorPagina = 10;

        if (pagina != null)
            query = query
                .Skip(((int)pagina - 1) * itensPorPagina)
                .Take(itensPorPagina);

        return query.ToList();
    }
}
