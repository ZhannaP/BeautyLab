import api from "./api";

export const getAll = () => api.get("/Master");
export const create = (data) => api.post("/Master", data);
export const remove = (id) => api.delete(`/Master/${id}`);
