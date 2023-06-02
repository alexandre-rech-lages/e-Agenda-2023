﻿namespace e_Agenda.WinApp.ModuloDespesa
{
    public interface IRepositorioDespesa
    {
        void Inserir(Despesa novaDespesa);
        void Editar(int id, Despesa despesaAtualizada);
        void Excluir(Despesa despesa);
        Despesa SelecionarPorId(int id);
        List<Despesa> SelecionarTodos();
    }
}
