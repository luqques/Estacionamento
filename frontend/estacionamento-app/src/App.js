import React, { useState, useEffect } from 'react';
import Header from './components/Header';
import VehicleList from './components/VehicleList';
import Filter from './components/Filter';
import Button from './components/Button';
import AddVeiculoModal from './components/AddVeiculoModal';
import RemoveVeiculoModal from './components/RemoveVeiculoModal';
import Toggle from './components/Toggle';
import { getRegistrosEstacionamento, postEntradaVeiculo, deleteSaidaVeiculo } from './services/api';

const App = () => {
  const [veiculos, setVeiculos] = useState([]);
  const [filter, setFilter] = useState('');
  const [addModalOpen, setAddModalOpen] = useState(false);
  const [deleteModalOpen, setDeleteModalOpen] = useState(false);
  const [placa, setSelectedPlate] = useState(null);
  const [registrosAtivos, setRegistrosAtivos] = useState(true);

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

  const handleAddVehicle = async (veiculoData) => {
    await postEntradaVeiculo(veiculoData);
    fetchVeiculos();
  };

  const handleRemoveVeiculo = async (placa) => {
    await deleteSaidaVeiculo(placa);
    fetchVeiculos();
    setSelectedPlate(null);
  };

  const filteredVeiculos = veiculos.filter(vehicle => 
    vehicle.placa.toLowerCase().includes(filter.toLowerCase())
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
          onAddVehicle={handleAddVehicle}
        />
        <RemoveVeiculoModal
          isOpen={deleteModalOpen}
          onClose={() => setDeleteModalOpen(false)}
          onRemoveVeiculo={handleRemoveVeiculo}
        />
        <VehicleList veiculos={filteredVeiculos} setSelectedPlate={setSelectedPlate} />
      </div>
    </div>
  );
};

export default App;
