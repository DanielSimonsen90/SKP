import { useDarkMode, Button } from "danholibraryrjs"
export default function Home() {
    const [dark, setDark] = useDarkMode();

    return (
        <div>
            <p>Darkmode: {dark.toString()}</p>
            <Button importance="primary" onClick={() => setDark(v => !v)}>Toggle</Button>
        </div>
    )
}
