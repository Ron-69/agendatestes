using System;
using System.Collections.Generic;
using Agenda.Domain;

namespace Agenda.DAO
{
   public interface ITelefones //Acesso a dados a tabela telefones
    {
        List<ITelefone> ObterTodosDoContato(Guid ContatoId);
    }
}
