import { Button } from 'danholibraryrjs';
import { useSetProjects } from 'providers/MeProvider';

export default function ResetSessionButton() {
    const setProjects = useSetProjects();

    return (
        <Button importance="tertiary" crud="delete" onClick={() => setProjects(true)}>
            Clear Session Storage
        </Button>
    );
}