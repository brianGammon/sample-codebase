import axios from 'axios';
import { Project } from './types';

const API_URL = 'http://localhost:5180/api';

const api = axios.create({
    baseURL: API_URL,
    headers: {
        'Content-Type': 'application/json',
    }
});

export const projectsApi = {
    list: async (): Promise<Project[]> => {
        const response = await api.get<Project[]>('/projects');
        return response.data;
    },

    getById: async (id: number): Promise<Project> => {
        const response = await api.get<Project>(`/projects/${id}`);
        return response.data;
    },

    create: async (project: Omit<Project, 'id'>): Promise<Project> => {
        const response = await api.post<Project>('/projects', project);
        return response.data;
    },

    update: async (project: Project): Promise<void> => {
        await api.put(`/projects/${project.id}`, project);
    }
}; 