import axios from "axios";
const URL = "http://localhost:5000/api/services";

export const getAll = () => axios.get(URL);
export const create = (data) => axios.post(URL, data);
export const remove = (id) => axios.delete(`${URL}/${id}`);
