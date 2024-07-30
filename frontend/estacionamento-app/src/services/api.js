import axios from 'axios';

const API_URL = 'https://localhost:4440/api/v1';

export const getVehicles = async (inParking = true) => {
  try {
    const response = await axios.get(`${API_URL}/registroEstacionamento/listar-registros`, {
      params: { inParking }
    });
    return response.data;
  } catch (error) {
    console.error('Erro ao buscar por registros do estacionamento: ', error);
    return [];
  }
};

export const postVehicleEntry = async (vehicleData) => {
  try {
    const response = await axios({
      method: 'POST',
      url: `${API_URL}/registroEstacionamento/registrar-entrada`,
      data: vehicleData,
      headers: {
        'content-type': 'application/json',
      },
    })
    return response.data;
  } catch (error) {
    console.error('Erro ao adicionar veículo ao estacionamento: ', error);
    return null;
  }
};

export const deleteVehicleExit = async (placaVeiculo) => {
  try {
    const response = await axios({
      method: 'DELETE',
      url: `${API_URL}/registroEstacionamento/registrar-saida/${placaVeiculo}`,
      headers: {
        'content-type': 'application/json',
      },
    })
    return response.data;
  } catch (error) {
    console.error('Erro ao remover veículo do estacionamento: ', error);
    return null;
  }
};
