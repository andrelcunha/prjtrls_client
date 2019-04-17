using System;
namespace AssemblyCSharp.SagaDasProfissoes.Scripts.Utilities
{
    public interface IMessageHandler
    {
        void OnError();
        void OnSucess();
    }
}
