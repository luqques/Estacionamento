import React from 'react';
import { format } from 'date-fns';

const ListaRegistros = ({ veiculos }) => {

  const formatarDataHora = (dataHoraString) => {
    if (!dataHoraString) return null;
    
    const dataHora = new Date(dataHoraString);
    return format(dataHora, 'dd/MM/yyyy HH:mm:ss');
  };

  const formatarReais = (valor) => {
    if (valor === 0) return null;
    
    return new Intl.NumberFormat('pt-BR', {
      style: 'currency',
      currency: 'BRL'
    }).format(valor);
  };

  return (
    <table className="min-w-full bg-white shadow-md rounded-lg overflow-hidden mt-5">
      <thead>
        <tr className='bg-blue-300'>
          <th className="px-4 py-2 border">Placa</th>
          <th className="px-4 py-2 border">Horário de Entrada</th>
          <th className="px-4 py-2 border">Horário de Saída</th>
          <th className="px-4 py-2 border">Duração</th>
          <th className="px-4 py-2 border">Horas Cobradas</th>
          <th className="px-4 py-2 border">Preço da Hora</th>
          <th className="px-4 py-2 border">Valor a Pagar</th>
        </tr>
      </thead>
      <tbody>
        {veiculos.map((veiculo) => (
          <tr key={veiculo.placa} className="hover:bg-gray-100">
            <td className="px-4 py-2 border">{veiculo.placa}</td>
            <td className="px-4 py-2 border">{formatarDataHora(veiculo.dataHoraEntrada)}</td>
            <td className="px-4 py-2 border">{formatarDataHora(veiculo.dataHoraSaida)}</td>
            <td className="px-4 py-2 border">{veiculo.duracao}</td>
            <td className="px-4 py-2 border">{veiculo.tempoCobradoHoras}</td>
            <td className="px-4 py-2 border">{formatarReais(veiculo.precoHora)}</td>
            <td className="px-4 py-2 border">{formatarReais(veiculo.valorPagar)}</td>
          </tr>
        ))}
      </tbody>
    </table>
  );
};

export default ListaRegistros;
