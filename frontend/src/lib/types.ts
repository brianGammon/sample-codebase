export enum ProjectStatus {
    NotStarted = "0",
    InProgress = "1",
    Completed = "2"
}

export interface Project {
    id: number;
    name: string;
    description: string;
    status: number;
    startDate: string;
    endDate?: string | null;
    priority: number;
} 