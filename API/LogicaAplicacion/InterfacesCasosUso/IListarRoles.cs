﻿using Compartido.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.InterfacesCasosUso
{
    public interface IListarRoles
    {
        List<InfoSelectDTO> Ejecutar();
    }
}
