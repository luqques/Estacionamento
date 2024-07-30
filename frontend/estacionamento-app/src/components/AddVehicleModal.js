import React, { useState } from 'react';
import Modal from './Modal';

const AddVehicleModal = ({ isOpen, onClose, onAddVehicle }) => {

  const [vehicleData, setVehicleData] = useState({
    placa: '',
    nomeProprietario: '',
    modeloVeiculo: '',
  });

  const handleChange = (e) => {
    const { name, value } = e.target;
    setVehicleData({ ...vehicleData, [name]: value });
  };

  const handleSubmit = (e) => {
    e.preventDefault();
    onAddVehicle(vehicleData);
    onClose();
  };

  return (
    <Modal isOpen={isOpen} onClose={onClose}>
      <h2 className="text-lg font-bold mb-4">Adicionar Registro ao Estacionamento</h2>
      <form onSubmit={handleSubmit}>
        <input
          type="text"
          name="placa"
          placeholder="Placa do veículo"
          value={vehicleData.placa}
          onChange={handleChange}
          className="border rounded w-full py-2 px-3 mb-4"
        />
        <input
          type="text"
          name="nomeProprietario"
          placeholder="Nome do proprietário"
          value={vehicleData.nomeProprietario}
          onChange={handleChange}
          className="border rounded w-full py-2 px-3 mb-4"
        />
        <input
          type="text"
          name="modelo"
          placeholder="Modelo do veículo"
          value={vehicleData.modelo}
          onChange={handleChange}
          className="border rounded w-full py-2 px-3 mb-4"
        />
        <div className='flex justify-end'>
          <button type="submit" className="bg-green-500 text-white px-4 py-2 rounded-md font-semibold">
            Registrar
          </button>
        </div>
      </form>
    </Modal>
  );
};

export default AddVehicleModal;
