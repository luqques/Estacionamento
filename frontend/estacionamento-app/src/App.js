import React, { useState, useEffect } from 'react';
import Header from './components/Header';
import ListaRegistros from './components/ListaRegistros';
import Filter from './components/Filter';
import Button from './components/Button';
import AddVeiculoModal from './components/AddVeiculoModal';
import RemoveVeiculoModal from './components/RemoveVeiculoModal';
import VeiculoDetalhesModal from './components/VeiculoDetalhesModal';
import AddPrecoModal from './components/AddPrecoModal';
import Toggle from './components/Toggle';
import { getRegistrosEstacionamento, postEntradaVeiculo, deleteSaidaVeiculo, postPrecoHora } from './services/api';

const App = () => {
  const [veiculos, setVeiculos] = useState([]);
  const [filter, setFilter] = useState('');
  const [addRegistroModalOpen, setAddRegistroModalOpen] = useState(false);
  const [removeRegistroModalOpen, setRemoveRegistroModalOpen] = useState(false);
  const [addPrecoModalOpen, setAddPrecoModalOpen] = useState(false);
  const [placa, setSelectedPlate] = useState(null);
  const [registrosAtivos, setRegistrosAtivos] = useState(true);
  const [veiculoDetalhes, setVeiculoDetalhes] = useState(null);
  const [detalhesRegistroModalOpen, setDetalhesRegistroModalOpen] = useState(false);

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
      setDetalhesRegistroModalOpen(true);
    }
  };

  const handleAddPreco = async (precoHora) => {
    await postPrecoHora(precoHora);
    fetchVeiculos();
  };

  const filteredVeiculos = veiculos.filter(veiculo => 
    veiculo.placa.toLowerCase().includes(filter.toLowerCase())
  );

  return (
    <div>
      <Header />
      <div className="mx-10 mt-10 flex">
        <Button onClick={() => setAddRegistroModalOpen(true)} color="green">Marcar Entrada</Button>
        <Button onClick={() => setRemoveRegistroModalOpen(true)} color="red" disabled={!placa}>Marcar Saída</Button>
        <Filter onChange={handleFilterChange} />
        <div className='mt-2 me-5'>
          <Toggle registrosAtivos={registrosAtivos} onToggle={handleToggleChange}/> Veículos dentro do estacionamento
        </div>
        <div className="flex justify-end">
          <Button onClick={() => setAddPrecoModalOpen(true)} color="green">Alterar Preços</Button>
        </div>
        <AddVeiculoModal
          isOpen={addRegistroModalOpen}
          onClose={() => setAddRegistroModalOpen(false)}
          onAddVeiculo={handleAddVeiculo}
        />
        <RemoveVeiculoModal
          isOpen={removeRegistroModalOpen}
          onClose={() => setRemoveRegistroModalOpen(false)}
          onRemoveVeiculo={handleRemoveVeiculo}
        />
        <VeiculoDetalhesModal
          isOpen={detalhesRegistroModalOpen}
          onClose={() => setDetalhesRegistroModalOpen(false)}
          veiculo={veiculoDetalhes}
        />
        <AddPrecoModal
          isOpen={addPrecoModalOpen}
          onClose={() => setAddPrecoModalOpen(false)}
          onAddPreco={handleAddPreco}
        />
        </div>
        <div className="mx-10">
          <ListaRegistros veiculos={filteredVeiculos} setSelectedPlate={setSelectedPlate} />
        </div>
    </div>
  );
};

export default App;
