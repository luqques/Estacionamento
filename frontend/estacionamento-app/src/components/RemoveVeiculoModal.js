import React, { useState } from 'react';
import Modal from './Modal';

const RemoveVeiculoModal = ({ isOpen, onClose, onRemoveVeiculo }) => {

  const [placa, setPlaca] = useState('');

  const handleSubmit = (e) => {
    e.preventDefault();
    onRemoveVeiculo(placa);
    onClose();
  };

  return (
    <Modal isOpen={isOpen} onClose={onClose}>
      <h2 className="text-lg font-bold mb-4">Remover Veículo do Estacionamento</h2>
      <form onSubmit={handleSubmit}>
        <input
          type="text"
          name="placa"
          placeholder="Placa do veículo"
          value={placa}
          onChange={(e) => setPlaca(e.target.value)}
          className="border rounded w-full py-2 px-3 mb-4"
        />
        <div className='flex justify-end'>
          <button type="submit" className="bg-red-600 text-white px-4 py-2 rounded-md font-semibold">
            Remover
          </button>
        </div>
      </form>
    </Modal>
  );
};

export default RemoveVeiculoModal;
