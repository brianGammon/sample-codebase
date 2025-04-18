import { ProjectList } from '@/components/ProjectList';
import { CreateProjectForm } from '@/components/CreateProjectForm';

export default function Home() {
  return (
    <main className="container mx-auto py-8 px-4 max-w-7xl">
      <div className="flex items-center justify-between mb-8">
        <h1 className="text-3xl font-bold tracking-tight">Projects</h1>
        <CreateProjectForm />
      </div>
      <ProjectList />
    </main>
  );
}
