import React from 'react';
import { format } from 'date-fns';

const VehicleList = ({ vehicles }) => {

  const formatDate = (dateString) => {
    if (!dateString) return 'N/A';
    const date = new Date(dateString);
    return format(date, 'dd/MM/yyyy HH:mm:ss');
  };

  const formatReais = (value) => {
    return new Intl.NumberFormat('pt-BR', {
      style: 'currency',
      currency: 'BRL'
    }).format(value);
  };

  return (
    <table className="min-w-full bg-white shadow-md rounded-lg overflow-hidden mt-5">
      <thead>
        <tr>
          <th className="px-4 py-2 border">Placa</th>
          <th className="px-4 py-2 border">Horário de Chegada</th>
          <th className="px-4 py-2 border">Horário de Saída</th>
          <th className="px-4 py-2 border">Duração</th>
          <th className="px-4 py-2 border">Tempo Cobrado (hora)</th>
          <th className="px-4 py-2 border">Preço</th>
          <th className="px-4 py-2 border">Valor a Pagar</th>
        </tr>
      </thead>
      <tbody>
        {vehicles.map((vehicle) => (
          <tr key={vehicle.placa} className="hover:bg-gray-100">
            <td className="px-4 py-2 border">{vehicle.placa}</td>
            <td className="px-4 py-2 border">{formatDate(vehicle.dataHoraEntrada)}</td>
            <td className="px-4 py-2 border">{formatDate(vehicle.dataHoraSaida)}</td>
            <td className="px-4 py-2 border">{vehicle.duracao}</td>
            <td className="px-4 py-2 border">{vehicle.tempoCobradoHoras}</td>
            <td className="px-4 py-2 border">{formatReais(vehicle.precoHora)}</td>
            <td className="px-4 py-2 border">{formatReais(vehicle.valorPagar)}</td>
          </tr>
        ))}
      </tbody>
    </table>
  );
};

export default VehicleList;
