'use client';

import { useEffect, useState } from 'react';
import { Project, ProjectStatus } from '@/lib/types';
import { projectsApi } from '@/lib/api';
import {
    Table,
    TableBody,
    TableCell,
    TableHead,
    TableHeader,
    TableRow,
} from "@/components/ui/table";
import { Badge } from "@/components/ui/badge";
import { Button } from "@/components/ui/button";
import { EditProjectForm } from './EditProjectForm';

const getStatusColor = (status: number) => {
    switch (status) {
        case 2: // Completed
            return "bg-green-500/10 text-green-700 hover:bg-green-500/20";
        case 1: // InProgress
            return "bg-blue-500/10 text-blue-700 hover:bg-blue-500/20";
        case 0: // NotStarted
        default:
            return "bg-gray-500/10 text-gray-700 hover:bg-gray-500/20";
    }
};

const getStatusText = (status: number) => {
    switch (status) {
        case 2:
            return "Completed";
        case 1:
            return "In Progress";
        case 0:
        default:
            return "Not Started";
    }
};

const formatDate = (dateString: string) => {
    return new Date(dateString).toLocaleDateString();
};

export function ProjectList() {
    const [projects, setProjects] = useState<Project[]>([]);
    const [loading, setLoading] = useState(true);
    const [error, setError] = useState<string | null>(null);
    const [selectedProject, setSelectedProject] = useState<Project | null>(null);

    useEffect(() => {
        const fetchProjects = async () => {
            try {
                const data = await projectsApi.list();
                console.log('Raw API response:', data);
                // Remove duplicates and ensure unique IDs
                const uniqueProjects = data.reduce((acc: Project[], current) => {
                    const exists = acc.find(p => p.id === current.id);
                    if (!exists) {
                        acc.push(current);
                    }
                    return acc;
                }, []);
                setProjects(uniqueProjects);
                setError(null);
            } catch (err) {
                console.error('Error details:', err);
                setError('Failed to fetch projects');
            } finally {
                setLoading(false);
            }
        };

        fetchProjects();
    }, []);

    if (loading) {
        return (
            <div className="flex items-center justify-center min-h-[200px]">
                <div className="animate-spin rounded-full h-8 w-8 border-b-2 border-primary"></div>
            </div>
        );
    }

    if (error) {
        return (
            <div className="rounded-lg bg-destructive/15 p-4 text-destructive">
                <div className="flex items-center gap-2">
                    <svg
                        xmlns="http://www.w3.org/2000/svg"
                        width="16"
                        height="16"
                        viewBox="0 0 24 24"
                        fill="none"
                        stroke="currentColor"
                        strokeWidth="2"
                        strokeLinecap="round"
                        strokeLinejoin="round"
                    >
                        <circle cx="12" cy="12" r="10" />
                        <line x1="12" y1="8" x2="12" y2="12" />
                        <line x1="12" y1="16" x2="12.01" y2="16" />
                    </svg>
                    {error}
                </div>
            </div>
        );
    }

    if (!projects || projects.length === 0) {
        return (
            <div className="rounded-lg border p-8 text-center text-muted-foreground">
                No projects found.
            </div>
        );
    }

    return (
        <>
            <div className="rounded-lg border">
                <Table>
                    <TableHeader>
                        <TableRow>
                            <TableHead className="w-[300px]">Name</TableHead>
                            <TableHead>Status</TableHead>
                            <TableHead>Priority</TableHead>
                            <TableHead>Start Date</TableHead>
                            <TableHead>End Date</TableHead>
                            <TableHead className="w-[150px]">Actions</TableHead>
                        </TableRow>
                    </TableHeader>
                    <TableBody>
                        {projects.map((project, index) => {
                            const key = `${project.id}-${index}`;
                            return (
                                <TableRow key={key}>
                                    <TableCell>
                                        <div>
                                            <div className="font-medium">{project.name}</div>
                                            <div className="text-sm text-muted-foreground">
                                                {project.description}
                                            </div>
                                        </div>
                                    </TableCell>
                                    <TableCell>
                                        <Badge className={getStatusColor(project.status)}>
                                            {getStatusText(project.status)}
                                        </Badge>
                                    </TableCell>
                                    <TableCell>{project.priority}</TableCell>
                                    <TableCell>
                                        {formatDate(project.startDate)}
                                    </TableCell>
                                    <TableCell>
                                        {project.endDate ? formatDate(project.endDate) : "-"}
                                    </TableCell>
                                    <TableCell>
                                        <div className="flex gap-2">
                                            <Button
                                                variant="ghost"
                                                size="sm"
                                                onClick={() => setSelectedProject(project)}
                                            >
                                                <svg
                                                    xmlns="http://www.w3.org/2000/svg"
                                                    width="16"
                                                    height="16"
                                                    viewBox="0 0 24 24"
                                                    fill="none"
                                                    stroke="currentColor"
                                                    strokeWidth="2"
                                                    strokeLinecap="round"
                                                    strokeLinejoin="round"
                                                    className="mr-2"
                                                >
                                                    <path d="M17 3a2.85 2.83 0 1 1 4 4L7.5 20.5 2 22l1.5-5.5Z"/>
                                                    <path d="m15 5 4 4"/>
                                                </svg>
                                                Edit
                                            </Button>
                                        </div>
                                    </TableCell>
                                </TableRow>
                            );
                        })}
                    </TableBody>
                </Table>
            </div>
            {selectedProject && (
                <EditProjectForm
                    project={selectedProject}
                    onClose={() => setSelectedProject(null)}
                    onUpdate={(updatedProject: Project) => {
                        setProjects(projects.map(p => 
                            p.id === updatedProject.id ? updatedProject : p
                        ));
                        setSelectedProject(null);
                    }}
                />
            )}
        </>
    );
} 