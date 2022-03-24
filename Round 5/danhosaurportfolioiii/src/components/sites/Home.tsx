import { useDarkMode, Button } from "danholibraryrjs"
export default function Home() {
    const [dark, setDark] = useDarkMode();

    return (
        <div>
            <Button importance="primary" crud={dark ? 'create' : 'delete'} onClick={() => setDark(v => !v)}>Toggle</Button>
        </div>
    )
}
