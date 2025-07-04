﻿using LogicaNegocio.Entidades;
using LogicaNegocio.ExepcionesEntidades;
using LogicaNegocio.InterfacesRepositorio;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAccesoDatos.Repositorio
{
    public class RepositorioEnvio : IRepositorioEnvio
    {
        private readonly Context _context;
        public RepositorioEnvio(Context context)
        {
            _context = context;
        }
        public void Add(Envio entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Envio entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Envio> GetAll()
        {
            return _context.Envios;
        }

        public Envio? GetById(int id)
        {
            return _context.Envios.Where(e => e.Id == id).Include(e => e.Cliente).Include(e => e.Empleado).Include(e => e.ListaSeguimiento).SingleOrDefault();
        }

        public void Update(Envio entity)
        {
            ArgumentNullException.ThrowIfNull(entity);
            Envio envio = GetById(entity.Id) ?? throw new EnvioException("El envio a actualizar no existe.");
            _context.Entry(envio).State = EntityState.Detached;
            _context.Envios.Update(entity);
            _context.SaveChanges();
        }

        public Envio? GetByNroTracking(string nroTracking)
        {
            return _context.Envios.Include(e => e.Cliente).Include(e => e.Empleado).FirstOrDefault(e => e.NroTracking.Trim() == nroTracking.Trim());
        }

        public IEnumerable<Envio> GetByUsuario(int id)
        {
            return _context.Envios.Where(e => e.Cliente.Id == id);
        }
    }
}
