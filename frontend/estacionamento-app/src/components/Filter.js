// src/components/Filter.js
import React from 'react';

const Filter = ({ onChange }) => {
  return (
    <input
      type="text"
      placeholder="Filtrar por placa"
      onChange={(e) => onChange(e.target.value)}
      className="border rounded w-100 py-2 px-3"
    />
  );
};

export default Filter;
