// src/components/DeleteVehicleModal.js
import React, { useState } from 'react';
import Modal from './Modal';

const DeleteVehicleModal = ({ isOpen, onClose, onDeleteVehicle }) => {

  const [placa, setPlaca] = useState('');

  const handleSubmit = (e) => {
    e.preventDefault();
    onDeleteVehicle(placa);
    onClose();
  };

  return (
    <Modal isOpen={isOpen} onClose={onClose}>
      <h2 className="text-lg font-bold mb-4">Remover Veículo do Estacionamento</h2>
      <form onSubmit={handleSubmit}>
        <input
          type="text"
          placeholder="Placa do veículo"
          value={placa}
          onChange={(e) => setPlaca(e.target.value)}
          className="border rounded w-full py-2 px-3 mb-4"
        />
        <div className='flex justify-end'>
          <button type="submit" className="bg-red-500 text-white px-4 py-2 rounded-md font-semibold">
            Remover
          </button>
        </div>
      </form>
    </Modal>
  );
};

export default DeleteVehicleModal;
