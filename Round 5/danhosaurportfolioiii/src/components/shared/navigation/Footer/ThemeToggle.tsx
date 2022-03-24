import { useEffect } from "react";
import { Button, useDarkMode } from "danholibraryrjs";
import { ms } from "danholibraryjs";
import { useModal } from "providers/ModalProvider";
import './ThemeToggle.scss';

export default function ThemeToggle() {
    const [isDark, setDarkMode] = useDarkMode();
    const [showModal] = useModal(<div id="youre-blind">
        <h1>Can you still see?</h1>
        <h3>Lightmode is dangerous.. Change back?</h3>
        <Button importance="primary" onClick={() => {
            showModal('hide');
            setDarkMode(true);
        }} value="Go back to darkmode" />
    </div>)
    
    useEffect(() => {
        document.body.classList.toggle("light", !isDark);

        let timeout: NodeJS.Timeout = null;
        if (!isDark) {
            timeout = setTimeout(() => {
                showModal("show");
            }, ms('5s'))
        }
        return () => timeout = null;
    }, [isDark])

    return (
        <input type="checkbox" checked={isDark} onChange={e => {
            setDarkMode(v => !v)
        }} />
    )
}