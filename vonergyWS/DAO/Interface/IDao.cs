using System.Collections.Generic;

namespace vonergyWS.DAO.Interface
{
    public interface IDao<T> where T : class
    {
        T Cadastrar(T objeto);

        IList<T> Listar();

        IList<T> ListarInativos();

        IList<T> ListarAtivos();

        T ListarId(long? id);

        void Remover(long? id);

        T Atualizar(T objeto);
    }
}
