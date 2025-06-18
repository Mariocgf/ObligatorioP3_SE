using Compartido.DTOs.Envio;
using LogicaNegocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosUso.EnvioCU
{
    public class BuscarEnvioXFechaUsuario
    {
        private readonly IRepositorioEnvio _repoEnvio;
        public BuscarEnvioXFechaUsuario(IRepositorioEnvio repoEnvio)
        {
            _repoEnvio = repoEnvio;
        }
        public List<EnvioUsuarioDto> Ejecutar(int id, DateTime fechaDesde, DateTime fechaHasta)
        {
            List<EnvioUsuarioDto> envios;

            return envios;
        }
    }
}
