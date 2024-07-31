import React, { useState } from 'react';
import Modal from './Modal';

const AddPrecoModal = ({ isOpen, onClose, onAddPreco }) => {

  const [precoHora, setPreco] = useState('');

  const handleSubmit = (e) => {
    e.preventDefault();
    onAddPreco(precoHora);
    onClose();
  };

  return (
    <Modal isOpen={isOpen} onClose={onClose}>
      <h2 className="text-lg font-bold mb-4">Alterar o preço da hora</h2>
      <form onSubmit={handleSubmit}>
        <input
          type="text"
          name="precoHora"
          placeholder="Preço da hora"
          value={precoHora}
          onChange={(e) => setPreco(e.target.value)}
          className="border rounded w-full py-2 px-3 mb-4"
        />
        <div className='flex justify-end'>
          <button type="submit" className="bg-green-700 text-white px-4 py-2 rounded-md font-semibold">
            Alterar
          </button>
        </div>
      </form>
    </Modal>
  );
};

export default AddPrecoModal;
