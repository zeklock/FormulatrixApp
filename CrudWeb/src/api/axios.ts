import axios from "axios";
import router from "../router";

// Create axios instance
const api = axios.create({
  baseURL: "http://localhost:5293/api",
  headers: {
    "Content-Type": "application/json",
  },
});

// Request interceptor (optional: add token)
api.interceptors.request.use(
  (config) => {
    const token = localStorage.getItem("token");
    if (token) {
      config.headers.Authorization = `Bearer ${token}`;
    }
    return config;
  },
  (error) => Promise.reject(error),
);

// Response interceptor (optional: handle 401)
api.interceptors.response.use(
  (response) => response,
  (error) => {
    if (error.response?.status === 401) {
      localStorage.removeItem("token");
      router.push("/login");
    }
    return Promise.reject(error);
  },
);

export default api;
