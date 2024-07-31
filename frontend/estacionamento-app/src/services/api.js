import axios from 'axios';

const API_URL = 'https://localhost:4440/api/v1';

export const getRegistrosEstacionamento = async (registrosAtivos) => {
  try {
    const response = await axios.get(`${API_URL}/registroEstacionamento/listar-registros`, {
      params: { registrosAtivos }
    });
    return response.data;
  } catch (error) {
    console.error('Erro ao buscar por veículos no estacionamento: ', error);
    return [];
  }
};

export const postEntradaVeiculo = async (veiculoData) => {
  try {
    const response = await axios({
      method: 'POST',
      url: `${API_URL}/registroEstacionamento/registrar-entrada`,
      data: veiculoData,
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

export const deleteSaidaVeiculo = async (placaVeiculo) => {
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

// export const postTabelaDePrecos = async (preco) => {
//   try {
//     const response = await axios({
//       method: 'POST',
//       url: `${API_URL}/registroEstacionamento/registrar-entrada`,
//       data: veiculoData,
//       headers: {
//         'content-type': 'application/json',
//       },
//     })
//     return response.data;
//   } catch (error) {
//     console.error('Erro ao adicionar veículo ao estacionamento: ', error);
//     return null;
//   }
// };
