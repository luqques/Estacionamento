import React, { useState, useEffect } from 'react';
import Header from './components/Header';
import VehicleList from './components/VehicleList';
import Filter from './components/Filter';
import Button from './components/Button';
import AddVehicleModal from './components/AddVehicleModal';
import DeleteVehicleModal from './components/DeleteVehicleModal';
import Toggle from './components/Toggle';
import { getVehicles, postVehicleEntry, deleteVehicleExit } from './services/api';

const App = () => {
  const [vehicles, setVehicles] = useState([]);
  const [filter, setFilter] = useState('');
  const [addModalOpen, setAddModalOpen] = useState(false);
  const [deleteModalOpen, setDeleteModalOpen] = useState(false);
  const [placa, setSelectedPlate] = useState(null);
  const [registrosAtivos, setRegistrosAtivos] = useState(true);

  useEffect(() => {
    fetchVehicles();
  }, [registrosAtivos]);

  const fetchVehicles = async () => {
    const data = await getVehicles(registrosAtivos);
    setVehicles(data);
  };

  const handleToggleChange = () => {
    setRegistrosAtivos(!registrosAtivos);
  };

  const handleFilterChange = (newFilter) => {
    setFilter(newFilter);
  };

  const handleAddVehicle = async (vehicleData) => {
    await postVehicleEntry(vehicleData);
    fetchVehicles();
  };

  const handleRemoveVeiculo = async (placa) => {
    await deleteVehicleExit(placa);
    fetchVehicles();
    setSelectedPlate(null);
  };

  const filteredVehicles = vehicles.filter(vehicle => 
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
        <AddVehicleModal
          isOpen={addModalOpen}
          onClose={() => setAddModalOpen(false)}
          onAddVehicle={handleAddVehicle}
        />
        <DeleteVehicleModal
          isOpen={deleteModalOpen}
          onClose={() => setDeleteModalOpen(false)}
          onRemoveVeiculo={handleRemoveVeiculo}
        />
        <VehicleList vehicles={filteredVehicles} setSelectedPlate={setSelectedPlate} />
      </div>
    </div>
  );
};

export default App;
