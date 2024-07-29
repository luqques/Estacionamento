// src/components/VehicleList.js
import React from 'react';

const VehicleList = ({ vehicles, setSelectedPlate }) => {
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
          <th className="px-4 py-2 border">Ação</th>
        </tr>
      </thead>
      <tbody>
        {vehicles.map((vehicle) => (
          <tr key={vehicle.placa} className="hover:bg-gray-100">
            <td className="px-4 py-2 border">{vehicle.placa}</td>
            <td className="px-4 py-2 border">{vehicle.horarioChegada}</td>
            <td className="px-4 py-2 border">{vehicle.horarioSaida}</td>
            <td className="px-4 py-2 border">{vehicle.duracao}</td>
            <td className="px-4 py-2 border">{vehicle.tempoCobrado}</td>
            <td className="px-4 py-2 border">{vehicle.preco}</td>
            <td className="px-4 py-2 border">{vehicle.valorPagar}</td>
            <td className="px-4 py-2 border">
              <button
                className="bg-red-500 text-white px-4 py-1 rounded hover:bg-red-600"
                onClick={() => setSelectedPlate(vehicle.placa)}
              >
                Selecionar
              </button>
            </td>
          </tr>
        ))}
      </tbody>
    </table>
  );
};

export default VehicleList;
