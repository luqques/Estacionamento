import React from 'react';
import Modal from './Modal';
import { format } from 'date-fns';

const VeiculoDetalhesModal = ({ isOpen, onClose, veiculo }) => {
  if (!veiculo) return null;

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

  const formatarTimeStamp = (timeStamp) => {
    const [tempo] = timeStamp.split('.');
    return tempo;
  };

  return (
    <Modal isOpen={isOpen} onRequestClose={onClose} className="font-sans" contentLabel="Detalhes do Veículo">
      <div className='text-xl mb-5 font-bold'>Saída registrada com sucesso!</div>
      <p><strong>Placa:</strong> {veiculo.placa}</p>
      <p><strong>Hora de Entrada:</strong> {formatarDataHora(veiculo.dataHoraEntrada)}</p>
      <p><strong>Data de Saída:</strong> {formatarTimeStamp(formatarDataHora(veiculo.dataHoraSaida))}</p>
      <p><strong>Duração:</strong> {formatarTimeStamp(veiculo.duracao)}</p>
      <p><strong>Horas Cobradas:</strong> {veiculo.tempoCobradoHoras} hora(s)</p>
      <p><strong>Preço da Hora:</strong> {formatarReais(veiculo.precoHora)}</p>
      <p><strong>Valor a Pagar:</strong> {formatarReais(veiculo.valorPagar)}</p>
      <div className='flex justify-end'>
          <button onClick={onClose} className="w-36 bg-blue-700 text-white px-4 py-2 rounded-md font-semibold">
            Ok
          </button>
      </div>
    </Modal>
  );
};

export default VeiculoDetalhesModal;
