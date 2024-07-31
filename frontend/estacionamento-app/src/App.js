import React, { useState, useEffect } from 'react';
import Header from './components/Header';
import ListaRegistros from './components/ListaRegistros';
import Filter from './components/Filter';
import Button from './components/Button';
import AddVeiculoModal from './components/AddVeiculoModal';
import RemoveVeiculoModal from './components/RemoveVeiculoModal';
import VeiculoDetalhesModal from './components/VeiculoDetalhesModal';
import Toggle from './components/Toggle';
import { getRegistrosEstacionamento, postEntradaVeiculo, deleteSaidaVeiculo } from './services/api';

const App = () => {
  const [veiculos, setVeiculos] = useState([]);
  const [filter, setFilter] = useState('');
  const [addModalOpen, setAddModalOpen] = useState(false);
  const [deleteModalOpen, setDeleteModalOpen] = useState(false);
  const [placa, setSelectedPlate] = useState(null);
  const [registrosAtivos, setRegistrosAtivos] = useState(true);
  const [veiculoDetalhes, setVeiculoDetalhes] = useState(null);
  const [detalhesModalOpen, setDetalhesModalOpen] = useState(false);

  useEffect(() => {
    fetchVeiculos();
  }, [registrosAtivos]);

  const fetchVeiculos = async () => {
    const data = await getRegistrosEstacionamento(registrosAtivos);
    setVeiculos(data);
  };

  const handleToggleChange = () => {
    setRegistrosAtivos(!registrosAtivos);
  };

  const handleFilterChange = (newFilter) => {
    setFilter(newFilter);
  };

  const handleAddVeiculo = async (veiculoData) => {
    await postEntradaVeiculo(veiculoData);
    fetchVeiculos();
  };

  const handleRemoveVeiculo = async (placa) => {
    const response = await deleteSaidaVeiculo(placa);
    fetchVeiculos();
  
    if (response) {
      setVeiculoDetalhes(response);
      setDetalhesModalOpen(true);
    }
  };

  const filteredVeiculos = veiculos.filter(veiculo => 
    veiculo.placa.toLowerCase().includes(filter.toLowerCase())
  );

  return (
    <div>
      <Header />
      <div className='m-10'>
        <Button onClick={() => setAddModalOpen(true)} color="green">Marcar Entrada</Button>
        <Button onClick={() => setDeleteModalOpen(true)} color="red" disabled={!placa}>Marcar Saída</Button>
        <Filter onChange={handleFilterChange} />
        <Toggle registrosAtivos={registrosAtivos} onToggle={handleToggleChange}/> Veículos dentro do estacionamento
        <AddVeiculoModal
          isOpen={addModalOpen}
          onClose={() => setAddModalOpen(false)}
          onAddVeiculo={handleAddVeiculo}
        />
        <RemoveVeiculoModal
          isOpen={deleteModalOpen}
          onClose={() => setDeleteModalOpen(false)}
          onRemoveVeiculo={handleRemoveVeiculo}
        />
        <VeiculoDetalhesModal
          isOpen={detalhesModalOpen}
          onClose={() => setDetalhesModalOpen(false)}
          veiculo={veiculoDetalhes}
        />
        <ListaRegistros veiculos={filteredVeiculos} setSelectedPlate={setSelectedPlate} />
      </div>
    </div>
  );
};

export default App;
