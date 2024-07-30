// src/App.js
import React, { useState, useEffect } from 'react';
import Header from './components/Header';
import VehicleList from './components/VehicleList';
import Filter from './components/Filter';
import Button from './components/Button';
import AddVehicleModal from './components/AddVehicleModal';
import DeleteVehicleModal from './components/DeleteVehicleModal';
import { getVehicles, postVehicleEntry, deleteVehicleExit } from './services/api';

const App = () => {
  const [vehicles, setVehicles] = useState([]);
  const [filter, setFilter] = useState('');
  const [addModalOpen, setAddModalOpen] = useState(false);
  const [deleteModalOpen, setDeleteModalOpen] = useState(false);
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
    //fetchVehicles();
  };

  const handleRemoveVehicle = async () => {
    if (selectedPlate) {
      await deleteVehicleExit(selectedPlate);
      fetchVehicles();
      setSelectedPlate(null);
    }
  };

  const filteredVehicles = vehicles.filter(vehicle => 
    vehicle.placa.toLowerCase().includes(filter.toLowerCase())
  );

  return (
    <div>
      <Header />
      <div className='m-10'>
        <Button onClick={() => setAddModalOpen(true)} color="green">Marcar Entrada</Button>
        <Button onClick={() => setDeleteModalOpen(true)} color="red" disabled={!selectedPlate}>Marcar Saída</Button>
        <Filter onChange={handleFilterChange} />
        <AddVehicleModal
          isOpen={addModalOpen}
          onClose={() => setAddModalOpen(false)}
          onAddVehicle={handleAddVehicle}
        />
        <DeleteVehicleModal
          isOpen={deleteModalOpen}
          onClose={() => setDeleteModalOpen(false)}
          onDeleteVehicle={handleRemoveVehicle}
          selectedPlate={selectedPlate}
        />
        <VehicleList vehicles={filteredVehicles} setSelectedPlate={setSelectedPlate} />
      </div>
    </div>
  );
};

export default App;
