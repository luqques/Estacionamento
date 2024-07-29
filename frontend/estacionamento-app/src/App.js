// src/App.js
import React, { useState, useEffect } from 'react';
import Header from './components/Header';
import VehicleList from './components/VehicleList';
import Filter from './components/Filter';
import Button from './components/Button';
import Modal from './components/Modal';
import { getVehicles, postVehicleEntry, deleteVehicleExit } from './services/api';

const App = () => {
  const [vehicles, setVehicles] = useState([]);
  const [filter, setFilter] = useState('');
  const [modalOpen, setModalOpen] = useState(false);
  const [selectedPlate, setSelectedPlate] = useState(null);

  useEffect(() => {
    fetchVehicles();
  }, []);

  const fetchVehicles = async () => {
    const data = await getVehicles();
    setVehicles(data);
  };

  const handleFilterChange = (newFilter) => {
    setFilter(newFilter);
  };

  const handleAddVehicle = async (vehicleData) => {
    await postVehicleEntry(vehicleData);
    fetchVehicles();
    setModalOpen(false);
  };

  const handleRemoveVehicle = async () => {
    if (selectedPlate) {
      await deleteVehicleExit(selectedPlate);
      fetchVehicles();
      setSelectedPlate(null); // Limpar a seleção após a remoção
    }
  };

  const filteredVehicles = vehicles.filter(vehicle => 
    vehicle.placa.toLowerCase().includes(filter.toLowerCase())
  );

  return (
    <div>
      <Header />
      <div className="m-10">
        <Button onClick={() => setModalOpen(true)} color="green">Marcar Entrada</Button>
        <Button onClick={() => setModalOpen(true)} color="red" disabled={!selectedPlate}>
          Marcar Saída
        </Button>
        <Filter onChange={handleFilterChange} />
        <VehicleList vehicles={filteredVehicles} setSelectedPlate={setSelectedPlate} />
        <Modal isOpen={modalOpen} onClose={() => setModalOpen(false)}>
          {/* Formulário de entrada de veículo */}
        </Modal>
      </div>
    </div>
  );
};

export default App;
