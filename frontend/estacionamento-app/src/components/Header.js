// src/components/Header.js
import React from 'react';

const Header = () => {
  const currentDate = new Date().toLocaleString();

  return (
    <header className="bg-blue-600 text-white p-4">
      <h1 className="text-3xl font-bold">Estacionamento Carro Bem Guardado</h1>
      <p>{currentDate}</p>
    </header>
  );
};

export default Header;
