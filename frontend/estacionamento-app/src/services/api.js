import axios from 'axios';

const API_URL = 'http://sua-api-url.com/api';

export const getVehicles = async (inParking = true) => {
  try {
    const response = await axios.get(`${API_URL}/vehicles`, {
      params: { inParking }
    });
    return response.data;
  } catch (error) {
    console.error('Error fetching vehicles:', error);
    return [];
  }
};

export const postVehicleEntry = async (vehicleData) => {
  try {
    const response = await axios.post(`${API_URL}/vehicles`, vehicleData);
    return response.data;
  } catch (error) {
    console.error('Error adding vehicle:', error);
    return null;
  }
};

export const deleteVehicleExit = async (plate) => {
  try {
    const response = await axios.delete(`${API_URL}/vehicles/${plate}`);
    return response.data;
  } catch (error) {
    console.error('Error removing vehicle:', error);
    return null;
  }
};
