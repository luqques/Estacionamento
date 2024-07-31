import React from 'react';

const Button = ({ onClick, children, color }) => {
  const bgColor = color === 'green' ? 'bg-green-700' : 'bg-red-700';
  const hoverColor = color === 'green' ? 'hover:bg-green-800' : 'hover:bg-red-800';

  return (
    <button
      className={`${bgColor} text-white px-4 py-2 rounded ${hoverColor} me-4`}
      onClick={onClick}
    >
      {children}
    </button>
  );
};

export default Button;
