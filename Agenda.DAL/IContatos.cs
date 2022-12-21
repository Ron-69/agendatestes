using System;
using Agenda.Domain;

namespace Agenda.DAO
{
    public interface IContatos
    {
        IContato Obter(Guid id);
    }
}
